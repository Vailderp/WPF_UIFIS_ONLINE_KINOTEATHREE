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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kinoteathree.Pages
{
    /// <summary>
    /// Логика взаимодействия для AboutFilmPageAdmin.xaml
    /// </summary>
    public partial class CreateFilmPageAdmin : Page
    {
        public byte[] ImageFullData { get; set; } = null!;
        public byte[] ImageLogoData { get; set; } = null!;
        public byte[] VideoData     { get; set; } = null!;
        public CreateFilmPageAdmin()
        {
            InitializeComponent();
            DataContext = new ViewModels.CreateFilmPageAdminViewModel();
        }

        private void BorderImageFull_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var image = new KinoAppHelper.FileDialogImage().Open();
            if (image.IsGood)
            {
                ImageFullData = image.ImageData;
                BorderImageFull.Background = image.ImageBrush;
            }
        }

        private void BorderImageLogo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var image = new KinoAppHelper.FileDialogImage().Open();
            if (image.IsGood)
            {
                ImageLogoData = image.ImageData;
                BorderImageLogo.Background = image.ImageBrush;
            }
        }

        private void BorderVideo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "All Files|*.*";
            if (dlg.ShowDialog() == true)
            {
                VideoData = File.ReadAllBytes(dlg.FileName);
            }
        }

        private void ComboBox_SelectionChanged()
        {

        }
    }
}
