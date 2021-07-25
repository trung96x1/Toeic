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
using System.Windows.Threading;

namespace Toeic {
    /// <summary>
    /// Interaction logic for AnswerSheet1.xaml
    /// </summary>
    public partial class AnswerSheetWindown : Window {

        private int LISTENING_START = 1;
        private int LISTENING_END = 100;

        private int READING_START = 101;
        private int READING_END = 200;

        private int PART1_START = 1;
        private int PART1_END = 6;

        private int PART2_START = 7;
        private int PART2_END = 31;

        private int PART3_START = 32;
        private int PART3_END = 70;

        private int PART4_START = 71;
        private int PART4_END = 100;

        private int PART5_START = 101;
        private int PART5_END = 130;

        private int PART6_START = 131;
        private int PART6_END = 146;

        private int PART7_START = 147;
        private int PART7_END = 200;

        private int[] RCTable = new int[101] { 5, 5, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100, 105, 110, 115, 120, 125, 130, 135, 140, 145, 150, 155, 160, 165, 170, 175, 180, 185, 190, 195, 200, 205, 210, 215, 220, 225, 230, 235, 240, 245, 250, 255, 260, 265, 270, 275, 280, 285, 290, 295, 300, 305, 310, 315, 320, 325, 330, 335, 340, 345, 350, 355, 360, 365, 370, 375, 380, 385, 390, 395, 400, 405, 410, 415, 420, 425, 430, 435, 440, 445, 450, 455, 460, 465, 470, 475, 480, 485, 490, 495};
        private int[] LCTable = new int[101] { 5, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100, 105, 110, 115, 120, 125, 130, 135, 140, 145, 150, 155, 160, 165, 170, 175, 180, 185, 190, 195, 200, 205, 210, 215, 220, 225, 230, 235, 240, 245, 250, 255, 260, 265, 270, 275, 280, 285, 290, 295, 300, 305, 310, 315, 320, 325, 330, 335, 340, 345, 350, 355, 360, 365, 370, 375, 380, 385, 395, 400, 405, 410, 415, 420, 425, 430, 435, 440, 445, 450, 455, 460, 465, 470, 475, 480, 485, 490, 495, 495, 495, 495, 495 };

        private TestSample mTest;
        private TimeSpan mEndTime;
        private int[] result = new int[201];
        public AnswerSheetWindown( TestSample test ) {
            InitializeComponent();
            this.mTest = test;
            this.tbTitle.Text = this.tbTitle2.Text = mTest.testName;
            initMainLoop();         
        }

        DispatcherTimer dispatcherTimer;
        private void initMainLoop() {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(mainLoop_tick);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
        }

        void mainLoop_tick( object sender, EventArgs e ) {
            countDownTime();
        }

        bool isTimeOut = false;
        private void countDownTime() {
            if(isTimeOut)
                return;
            TimeSpan remainTime = mEndTime - DateTime.Now.TimeOfDay;
            int hh = remainTime.Hours;
            int mm = remainTime.Minutes;
            int ss = remainTime.Seconds;
            if(remainTime <= TimeSpan.FromSeconds(0)) {
                isTimeOut = true;
                dispatcherTimer.Stop();
                ringBell();
            } else if(remainTime <= TimeSpan.FromMinutes(15)) {
                tbRemainTime.Foreground = tbRemainTime2.Foreground = Brushes.Red;
            }

            String hhText = hh.ToString();
            String mmText = mm.ToString();
            String ssText = ss.ToString();

            if(hhText.Length <= 1)
                hhText = "0" + hhText;
            if(mmText.Length <= 1)
                mmText = "0" + mmText;
            if(ssText.Length <= 1)
                ssText = "0" + ssText;

            tbRemainTime.Text = tbRemainTime2.Text = hhText + ":" + mmText + ":" + ssText;
        }

        private void ringBell() {
            MediaPlayer bell = new MediaPlayer();
            bell.Open(new Uri(Environment.CurrentDirectory + @"\Media\bell.mp3"));
            bell.Play();

            EndTimeWindown endTimeWindown = new EndTimeWindown();
            endTimeWindown.Show();
        }

        private void Window_MouseLeftButtonDown( object sender, MouseButtonEventArgs e ) {
            DragMove();
        }

        private void btnClose_Click( object sender, RoutedEventArgs e ) {
            this.Close();
        }

        private void btnSubmit_Click( object sender, RoutedEventArgs e ) {
            int part1Score = 0;
            int part2Score = 0;
            int part3Score = 0;
            int part4Score = 0;
            int part5Score = 0;
            int part6Score = 0;
            int part7Score = 0;
            int listeningScore = 0;
            int readingScore = 0;

            for(int i = 1; i <= 200; i++) {
                String aswName = "asw" + i;
                AnswerItem answerItem = (AnswerItem)this.FindName(aswName);
                if(answerItem.getAnswer() != mTest.testResult[i]) {
                    answerItem.setResult(mTest.testResult[i]);
                } else {
                    if(i >= PART1_START && i <= PART1_END) {
                        part1Score++;
                        listeningScore++;
                    } else if(i >= PART2_START && i <= PART2_END) {
                        part2Score++;
                        listeningScore++;
                    } else if(i >= PART3_START && i <= PART3_END) {
                        part3Score++;
                        listeningScore++;
                    } else if(i >= PART4_START && i <= PART4_END) {
                        part4Score++;
                        listeningScore++;
                    } else if(i >= PART5_START && i <= PART5_END) {
                        part5Score++;
                        readingScore++;
                    } else if(i >= PART6_START && i <= PART6_END) {
                        part6Score++;
                        readingScore++;
                    } else if(i >= PART7_START && i <= PART7_END) {
                        part7Score++;
                        readingScore++;
                    }
                }      
            }

            int totalScore = RCTable[readingScore] + LCTable[listeningScore];
            tbScore.Visibility = Visibility.Visible;
            tbScore.Text = totalScore.ToString();
            
            gridResult.Visibility = Visibility.Visible;
            tbPart1Result.Text = tbPart1Result.Text + part1Score + "/6";
            tbPart2Result.Text = tbPart2Result.Text + part2Score + "/25";
            tbPart3Result.Text = tbPart3Result.Text + part3Score + "/39";
            tbPart4Result.Text = tbPart4Result.Text + part4Score + "/30";
            tbPart5Result.Text = tbPart5Result.Text + part5Score + "/30";
            tbPart6Result.Text = tbPart6Result.Text + part6Score + "/16";
            tbPart7Result.Text = tbPart7Result.Text + part7Score + "/54";
        }

        private void btnStart_Click( object sender, RoutedEventArgs e ) {
            if(paStart1.Kind == MaterialDesignThemes.Wpf.PackIconKind.Play) {
                paStart1.Kind = paStart2.Kind = MaterialDesignThemes.Wpf.PackIconKind.Pause;
                btnStart1.Background = btnStart2.Background = Brushes.Red;
                btnStart1.IsEnabled = btnStart2.IsEnabled = false;
                this.mEndTime = DateTime.Now.TimeOfDay + TimeSpan.FromMinutes(0.1);
                dispatcherTimer.Start();
            } else {
                //Pass
                paStart1.Kind = paStart2.Kind = MaterialDesignThemes.Wpf.PackIconKind.Play;
                btnStart1.Background = btnStart2.Background = Brushes.Green;
            }
        }
    }
}
