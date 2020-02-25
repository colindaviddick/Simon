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

using Timer = System.Windows.Forms.Timer;

namespace Simon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();

        // Is it the player hitting buttons or the CPU?
        bool PlayerSequence = false;

        int arrayPosition = 0;
        int arrayLength = 2;
        //int[] gameArray = new int[6];
        int[] gameArray = new int[400];
        bool gameMode = true;
        int waitTime = 500;
        static Random r = new Random();
        private Uri[] fileLocations = { (new Uri(@"C:\Users\User\source\repos\Simon\Simon\sounds\x.wav", UriKind.RelativeOrAbsolute)),
                                        (new Uri(@"C:\Users\User\source\repos\Simon\Simon\sounds\1.wav", UriKind.RelativeOrAbsolute)),
                                        (new Uri(@"C:\Users\User\source\repos\Simon\Simon\sounds\2.wav", UriKind.RelativeOrAbsolute)),
                                        (new Uri(@"C:\Users\User\source\repos\Simon\Simon\sounds\3.wav", UriKind.RelativeOrAbsolute)),
                                        (new Uri(@"C:\Users\User\source\repos\Simon\Simon\sounds\4.wav", UriKind.RelativeOrAbsolute)),
                                        (new Uri(@"C:\Users\User\source\repos\Simon\Simon\sounds\5.wav", UriKind.RelativeOrAbsolute)),
                                        (new Uri(@"C:\Users\User\source\repos\Simon\Simon\sounds\6.wav", UriKind.RelativeOrAbsolute)),
                                        (new Uri(@"C:\Users\User\source\repos\Simon\Simon\sounds\7.wav", UriKind.RelativeOrAbsolute)),
                                        (new Uri(@"C:\Users\User\source\repos\Simon\Simon\sounds\8.wav", UriKind.RelativeOrAbsolute)),
                                        (new Uri(@"C:\Users\User\source\repos\Simon\Simon\sounds\9.wav", UriKind.RelativeOrAbsolute))};

        #region
        public MainWindow()
        {
            InitializeComponent();
        }

        async Task Wait(int milliseconds)
        {
            Timer timer1 = new Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };
            while (timer1.Enabled)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public async Task PlaySound(int i)
        {
            mediaPlayer.Open(fileLocations[i]);
            mediaPlayer.Play();
        }

        // Button Click contains
        // TakeInput(#) &
        // UpdateArrayPosition
        #region
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            TakeInput(1);
            UpdateArrayPosition();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            TakeInput(2);
            UpdateArrayPosition();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            TakeInput(3);
            UpdateArrayPosition();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            TakeInput(4);
            UpdateArrayPosition();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            TakeInput(5);
            UpdateArrayPosition();
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            TakeInput(6);
            UpdateArrayPosition();
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            TakeInput(7);
            UpdateArrayPosition();
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            TakeInput(8);
            UpdateArrayPosition();
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            TakeInput(9);
            UpdateArrayPosition();
        }
        #endregion

        async Task TakeInput(int i)
        {
            if (gameMode)
            {
                void Success()
                {
                    if(PlayerSequence)
                    {
                        arrayLength++;
                        gameArray[arrayPosition + 1] = r.Next(1, 3);
                        arrayPosition = 0;
                        PlaySequence();
                        PlayerSequence = false;
                    }
                    else
                    {
                        arrayPosition = 0;
                        PlayerSequence = true;
                    }
                }
                async Task GameOver()
                {
                    PlaySound(0);
                    CountdownPanel.Visibility = Visibility.Visible;
                    CountdownPanel.Background = Brushes.Red;
                    await Wait(waitTime);
                    CountdownPanel.Visibility = Visibility.Hidden;
                    CountdownPanel.Background = Brushes.White;
                }

                switch (i)
                {
                    case 1:
                        if (gameArray[arrayPosition] == 1)
                        {
                            PlaySound(1);
                            button1.Background = Brushes.LightBlue;
                            Wait(waitTime);
                            button1.Background = Brushes.Blue;
                            if (arrayPosition == (arrayLength - 1))
                            {
                                MessageBox.Show("Finished");
                                Success();
                            }
                            arrayPosition++;
                            break;
                        }
                        else
                        {
                            GameOver();
                            break;
                        }
                    case 2:
                        if (gameArray[arrayPosition] == 2)
                        {
                            PlaySound(2);
                            button2.Background = Brushes.LightGreen;
                            Wait(waitTime);
                            button2.Background = Brushes.Green;
                            if (arrayPosition == (arrayLength - 1))
                            {
                                Success();
                            }
                            arrayPosition++;
                            break;
                        }
                        else
                        {
                            GameOver();
                            break;
                        }
                    case 3:
                        if (gameArray[arrayPosition] == 3)
                        {
                            PlaySound(3);
                            button3.Background = Brushes.LightYellow;
                            Wait(waitTime);
                            button3.Background = Brushes.Yellow;
                            if (arrayPosition == (arrayLength - 1))
                            {
                                Success();
                                MessageBox.Show("Finished");
                            }
                            arrayPosition++;
                            break;
                        }
                        else
                        {
                            GameOver();
                            break;
                        }

                        #region Commented out for testing
                        //        case 4:
                        //            if (gameArray[arrayPosition] == 4)
                        //            {
                        //                PlaySound(4);
                        //                button4.Background = Brushes.PaleGoldenrod;
                        //                Wait(waitTime);
                        //                button4.Background = Brushes.Orange;
                        //                if (arrayPosition == (arrayLength - 1))
                        //                {
                        //                    MessageBox.Show("Finished");
                        //                }
                        //                break;
                        //            }
                        //            else
                        //            {
                        //                GameOver();
                        //                break;
                        //            }
                        //        case 5:
                        //            if (gameArray[arrayPosition] == 5)
                        //            {
                        //                PlaySound(5);
                        //                button5.Background = Brushes.LightSalmon;
                        //                Wait(waitTime);
                        //                button5.Background = Brushes.Red;
                        //                if (arrayPosition == (arrayLength - 1))
                        //                {
                        //                    MessageBox.Show("Finished");
                        //                }
                        //                break;
                        //            }
                        //            else
                        //            {
                        //                GameOver();
                        //                break;
                        //            }
                        //        case 6:
                        //            if (gameArray[arrayPosition] == 6)
                        //            {
                        //                PlaySound(6);
                        //                button6.Background = Brushes.LightPink;
                        //                Wait(waitTime);
                        //                button6.Background = Brushes.HotPink;
                        //                if (arrayPosition == (arrayLength - 1))
                        //                {
                        //                    MessageBox.Show("Finished");
                        //                }
                        //                break;
                        //            }
                        //            else
                        //            {
                        //                GameOver();
                        //                break;
                        //            }
                        //        case 7:
                        //            if (gameArray[arrayPosition] == 7)
                        //            {
                        //                PlaySound(7);
                        //                button7.Background = Brushes.LightCyan;
                        //                Wait(waitTime);
                        //                button7.Background = Brushes.Cyan;
                        //                if (arrayPosition == (arrayLength - 1))
                        //                {
                        //                    MessageBox.Show("Finished");
                        //                }
                        //                break;
                        //            }

                        //            else
                        //            {
                        //                GameOver();
                        //                break;
                        //            }
                        //        case 8:
                        //            if (gameArray[arrayPosition] == 8)
                        //            {
                        //                PlaySound(8);
                        //                button8.Background = Brushes.MediumPurple;
                        //                Wait(waitTime);
                        //                button8.Background = Brushes.SlateBlue;
                        //                if (arrayPosition == (arrayLength - 1))
                        //                {
                        //                    MessageBox.Show("Finished");
                        //                }
                        //                break;
                        //            }
                        //            else
                        //            {
                        //                GameOver();
                        //                break;
                        //            }
                        //        case 9:
                        //            if (gameArray[arrayPosition] == 9)
                        //            {
                        //                PlaySound(9);
                        //                button9.Background = Brushes.PaleGoldenrod;
                        //                Wait(waitTime);
                        //                button9.Background = Brushes.GreenYellow;
                        //                if (arrayPosition == (arrayLength - 1))
                        //                {
                        //                    MessageBox.Show("Finished");
                        //                }
                        //                break;
                        //            }
                        //            else
                        //            {
                        //                GameOver();
                        //                break;
                        //            }
                        //    }
                        //}

                        //else if (!gameMode)
                        //{
                        //    switch (i)
                        //    {
                        //        case 1:
                        //            PlaySound(1);
                        //            button1.Background = Brushes.LightBlue;
                        //            Wait(waitTime);
                        //            button1.Background = Brushes.Blue;
                        //            arrayPosition = 0;
                        //            break;
                        //        case 2:
                        //            PlaySound(2);
                        //            button2.Background = Brushes.LightGreen;
                        //            Wait(waitTime);
                        //            button2.Background = Brushes.Green;
                        //            arrayPosition = 0;
                        //            break;
                        //        case 3:
                        //            PlaySound(3);
                        //            button3.Background = Brushes.LightYellow;
                        //            Wait(waitTime);
                        //            button3.Background = Brushes.Yellow;
                        //            arrayPosition = 0;
                        //            break;
                        //        case 4:
                        //            PlaySound(4);
                        //            button4.Background = Brushes.PaleGoldenrod;
                        //            Wait(waitTime);
                        //            button4.Background = Brushes.Orange;
                        //            arrayPosition = 0;
                        //            break;
                        //        case 5:
                        //            PlaySound(5);
                        //            button5.Background = Brushes.LightSalmon;
                        //            Wait(waitTime);
                        //            button5.Background = Brushes.Red;
                        //            arrayPosition = 0;
                        //            break;
                        //        case 6:
                        //            PlaySound(6);
                        //            button6.Background = Brushes.LightPink;
                        //            Wait(waitTime);
                        //            button6.Background = Brushes.HotPink;
                        //            arrayPosition = 0;
                        //            break;
                        //        case 7:
                        //            PlaySound(7);
                        //            button7.Background = Brushes.LightCyan;
                        //            Wait(waitTime);
                        //            button7.Background = Brushes.Cyan;
                        //            arrayPosition = 0;
                        //            break;
                        //        case 8:
                        //            PlaySound(8);
                        //            button8.Background = Brushes.MediumPurple;
                        //            Wait(waitTime);
                        //            button8.Background = Brushes.SlateBlue;
                        //            arrayPosition = 0;
                        //            break;
                        //        case 9:
                        //            PlaySound(9);
                        //            button9.Background = Brushes.PaleGoldenrod;
                        //            Wait(waitTime);
                        //            button9.Background = Brushes.GreenYellow;
                        //            arrayPosition = 0;
                        //            break;
                }
            }
        }

        async void Start_Game_Click(object sender, RoutedEventArgs e)
        {
            //CountdownPanel.Visibility = Visibility.Visible;
            //PopulateGameArray();
            ArrayPos.Text = arrayPosition.ToString();
            //Countdown.Text = "3";
            //await Wait(1000);
            //Countdown.Text = "2";
            //await Wait(1000);
            //Countdown.Text = "1";
            //await Wait(1000);
            //Countdown.Text = "Go!";
            //await Wait(1000);
            //CountdownPanel.Visibility = Visibility.Hidden;
            //Countdown.Visibility = Visibility.Hidden;
            PlaySequence();
        }
        #endregion

        // private void PopulateGameArray()
        // {
        //     for (int i = 0; i < maxLevels; i++)
        //     {
        //         gameArray[i] = r.Next(1, 10);
        //     }
        // 
        //     DeBug.Text = gameArray[0].ToString();
        //     DeBug1.Text = gameArray[1].ToString();
        //     DeBug2.Text = gameArray[2].ToString();
        //     DeBug3.Text = gameArray[3].ToString();
        //     DeBug4.Text = gameArray[4].ToString();
        //     DeBug5.Text = gameArray[5].ToString();
        // }
        #endregion

        private void PlaySequence()
        {
            for (int i = 0; i < (arrayLength); i++)
            {
                TakeInput(gameArray[i]);
            }
            arrayPosition = 0;
        }

        private void UpdateArrayPosition()
        {
            // arrayPosition++;
            ArrayPos.Text = arrayPosition.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlaySequence();
        }
    }
}