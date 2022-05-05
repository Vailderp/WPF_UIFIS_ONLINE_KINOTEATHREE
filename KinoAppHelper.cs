using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Kinoteathree
{
    class KinoAppHelper
    {
        public static IEnumerable<T?> GetWindowsAtType<T>() where T: Window
        {
            foreach (var unknownWindow in App.Current.Windows)
            {
                if (unknownWindow is T window)
                {
                    yield return window;
                }
            }
        }

        public static List<T?> GetWindowsListAtType<T>() where T : Window
        {
            return GetWindowsAtType<T>().ToList();
        }

        public static T? GetWindowAtType<T>() where T : Window
        {
            return GetWindowsAtType<T>().FirstOrDefault();
        }

        public static BitmapImage? LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        public static byte[] LoadImageDataFromFileDialog(out BitmapImage? bitmapImage)
        {
            byte[] imageData = Array.Empty<byte>();
            bitmapImage = null;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "All Files|*.*";
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    bitmapImage = new BitmapImage(new Uri(dlg.FileName));
                }
                catch
                {
                    MessageBox.Show("Файл непавильного формата", "Error");
                    return imageData;
                }
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    imageData = ms.ToArray();
                }
            }
            return imageData;
        }
        public class FileDialogImage
        {
            public byte[] ImageData { get; private set; } = Array.Empty<byte>();
            public ImageBrush ImageBrush { get; private set; } = null!;
            public bool IsGood { get; private set; } = true;
            public FileDialogImage()
            {

            }
            public FileDialogImage Open()
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Open Image";
                dlg.Filter = "All Files|*.*";
                if (dlg.ShowDialog() == true)
                {
                    BitmapImage bitmapImage;
                    try
                    {
                        bitmapImage = new BitmapImage(new Uri(dlg.FileName));
                    }
                    catch 
                    {
                        MessageBox.Show("Неверный формат фотографии", "Ошибка");
                        IsGood = false;
                        return this;
                    }
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        encoder.Save(ms);
                        ImageData = ms.ToArray();
                        ImageBrush = new ImageBrush(bitmapImage);
                    }
                }
                else
                {
                    IsGood = false;
                }
                return this;
            }
        }
    }
}
