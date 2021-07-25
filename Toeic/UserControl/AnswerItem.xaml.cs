using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Toeic {
    /// <summary>
    /// Interaction logic for AnswerItem.xaml
    /// </summary>
    public partial class AnswerItem : UserControl, INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private void notifyPropertyChanged( String info ) {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        private int _quesNumber;

        public int QuesNumber {
            get { return _quesNumber; }
            set {
                _quesNumber = value;
                notifyPropertyChanged("QuesNumber");
            }
        }

        public AnswerItem() {
            InitializeComponent();
            this.DataContext = this;
        }

        private void rdA_Checked( object sender, RoutedEventArgs e ) {
            rdB.IsChecked = rdC.IsChecked = rdD.IsChecked = false;
        }

        private void rdB_Checked( object sender, RoutedEventArgs e ) {
            rdA.IsChecked = rdC.IsChecked = rdD.IsChecked = false;
        }

        private void rdC_Checked( object sender, RoutedEventArgs e ) {
            rdB.IsChecked = rdA.IsChecked = rdD.IsChecked = false;
        }

        private void rdD_Checked( object sender, RoutedEventArgs e ) {
            rdB.IsChecked = rdC.IsChecked = rdA.IsChecked = false;
        }

        public char getAnswer() {
            if((bool)rdA.IsChecked)
                return 'A';
            else if((bool)rdB.IsChecked)
                return 'B';
            else if((bool)rdC.IsChecked)
                return 'C';
            else if((bool)rdD.IsChecked)
                return 'D';
            else
                return '\0';
        }

        public void setResult( char result ) {
            tbQuesNum.Background = Brushes.Red;
            if(result == 'A') {
                tbA.Background = Brushes.Gray;
            } else if(result == 'B') {
                tbB.Background = Brushes.Gray;
            } else if(result == 'C') {
                tbC.Background = Brushes.Gray;
            } else if(result == 'D') {
                tbD.Background = Brushes.Gray;
            }
        }
    }
}
