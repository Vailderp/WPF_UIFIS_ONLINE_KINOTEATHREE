using Kinoteathree.Models;
using System;
using System.Collections.Generic;
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

namespace Kinoteathree.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ActorTile.xaml
    /// </summary>
    public partial class ActorTile : UserControl
    {
        public ActorTile()
        {
            InitializeComponent();
        }
        public ActorTile HasActor(Actor actor)
        {
            LabelActorName.Content = actor.FirstName + " " + actor.LastName;
            BorderActorPhoto.Background = new ImageBrush(KinoAppHelper.LoadImage(actor.Image));
            return this;
        }
    }
}
