using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Kinoteathree.Windows
{
    /// <summary>
    /// Логика взаимодействия для VideoPlayerWindow.xaml
    /// </summary>
    public partial class VideoPlayerWindow : Window
    {
        private DispatcherTimer _timer { get; set; } = null!;
        public VideoPlayerWindow()
        {

        }
        public VideoPlayerWindow WithVideoData(byte[] videoData)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            File.WriteAllBytes(path + "film.mp4", videoData);
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(100);
            _timer.Tick += Timer_Tick;
            LoadAndPlayVideo();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            return this;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            SliderSeek.Value = MeVideoPlayer.Position.TotalSeconds;
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            MeVideoPlayer.Play();
        }

        private void ButtonPause_Click(object sender, RoutedEventArgs e)
        {
            MeVideoPlayer.Pause();
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            MeVideoPlayer.Stop();
        }

        private void SliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MeVideoPlayer.Volume = SliderVolume.Value;
        }

        private void SliderSeek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MeVideoPlayer.Position = TimeSpan.FromSeconds(SliderSeek.Value);
        }

        private void MeVideoPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSpan timeSpan = MeVideoPlayer.NaturalDuration.TimeSpan;
            SliderSeek.Maximum = timeSpan.TotalSeconds;
            _timer.Start();
        }

        private void LoadAndPlayVideo()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            MeVideoPlayer.Source = new Uri(path + "film.mp4");
            MeVideoPlayer.LoadedBehavior = MediaState.Manual;
            MeVideoPlayer.UnloadedBehavior = MediaState.Manual;
            MeVideoPlayer.Volume = SliderVolume.Value;
            MeVideoPlayer.Play();
            WindowState = WindowState.Maximized;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            MeVideoPlayer.Close();
            File.Delete(path + "film.mp4");
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        }
    }
}
