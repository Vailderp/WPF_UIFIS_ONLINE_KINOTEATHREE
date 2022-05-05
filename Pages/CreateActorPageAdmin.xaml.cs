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
    /// Логика взаимодействия для CreateActorPageAdmin.xaml
    /// </summary>
    public partial class CreateActorPageAdmin : Page
    {
        public byte[] ImageData { get; set; } = null!;
        public CreateActorPageAdmin()
        {
            InitializeComponent();
        }


        private void ButtonAddNewActor_Click(object sender, RoutedEventArgs e)
        {
            var ctx = new KinoContext();
            ctx.Actors.Add(new Models.Actor() 
            { 
                Image = ImageData, 
                FirstName = TbFirstName.Text, 
                LastName = TbLastName.Text 
            });
            ctx.SaveChanges();
            MessageBox.Show("Актёр добавлен");
            KinoAppHelper.GetWindowAtType<Windows.UserWindow>()?.Frame.Navigate(new Pages.FilmsListPageAdmin());
        }

        private void BorderActorPhoto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var image = new KinoAppHelper.FileDialogImage().Open();
            if (image.IsGood)
            {
                ImageData = image.ImageData;
                BorderActorPhoto.Background = image.ImageBrush;
            }
        }
    }
}
