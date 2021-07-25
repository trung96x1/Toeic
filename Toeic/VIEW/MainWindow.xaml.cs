using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class DialogAddTest { 
    }

    public partial class MainWindow : Window {

        TestResult testResult;
        public MainWindow() {
            InitializeComponent();
            testResult = TestResult.getInstance();
            
            lvTest.ItemsSource = testResult.getListTest();
        }

        private void Window_MouseLeftButtonDown( object sender, MouseButtonEventArgs e ) {
            DragMove();
        }

        private void btnClose_Click( object sender, RoutedEventArgs e ) {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnAdd_Click( object sender, RoutedEventArgs e ) {
            DialogAddTest dialog = new DialogAddTest();
            DialogHost.Show(dialog, "AddTestDialog");
        }

        private void listViewItem_MouseDoubleClick( object sender, MouseButtonEventArgs e ) {
            ListViewItem item = sender as ListViewItem;
            TestSample test = (TestSample)item.Content;
            AnswerSheetWindown answerSheet = new AnswerSheetWindown(test);
            answerSheet.Owner = this;
            answerSheet.Show();
        }

        private void btnOk_Click( object sender, RoutedEventArgs e ) {
            //pass
        }
    }
}
