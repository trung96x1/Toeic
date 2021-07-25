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
using System.Windows.Shapes;
using WpfAnimatedGif;

namespace Toeic {
    /// <summary>
    /// Interaction logic for EndTimeWindown.xaml
    /// </summary>
    public partial class EndTimeWindown : Window {
        public EndTimeWindown() {
            InitializeComponent();
            //String imagePath = Environment.CurrentDirectory + @"\Media\bell.gif";
            //var image = new BitmapImage();
            //image.BeginInit();
            //image.UriSource = new Uri(imagePath);
            //image.EndInit();
            //ImageBehavior.SetAnimatedSource(ImageShowing, image);
            //ImageBehavior.SetRepeatBehavior(ImageShowing, RepeatBehavior.Forever);
        }
    }
}
