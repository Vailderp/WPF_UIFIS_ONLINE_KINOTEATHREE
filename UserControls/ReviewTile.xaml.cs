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
    /// Логика взаимодействия для ReviewTile.xaml
    /// </summary>
    public partial class ReviewTile : UserControl
    {
        public ReviewTile()
        {
            InitializeComponent();
        }
        public ReviewTile HasReview(Models.Review review)
        {
            LtbReviewText.MultiText = review.Text;
            if (review.User != null)
            {
                TbUserName.Text = review.User.FirstName + " " + review.User.SecondName;
            }
            return this;
        }
    }
}
