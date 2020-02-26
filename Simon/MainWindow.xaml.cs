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
        bool playingSequence = true;
        int arrayPosition = 0;
        int arrayLength = 2;
        int arrayFullLength = 10;
        //int[] gameArray = new int[10];
        int[] gameArray = { 1, 2, 3, 1, 2, 3, 1, 2, 3, 1 };
        bool sandboxMode = false;
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
                void Success()
                {
                    if (!playingSequence)
                    {
                        arrayPosition = 0;
                        playingSequence = true;
                        PlaySequence();
                    }
                    else
                    {
                        arrayPosition = 0;
                        playingSequence = false;
                    }
                }
                async Task GameOver()
                {
                    //PlaySound(0);
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
                        UpdateArrayPosition();
                        //if (arrayPosition == (arrayLength - 1))
                        //{
                        //    Success();
                        //    break;
                        //}
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
                        UpdateArrayPosition();
                        //if (arrayPosition == (arrayLength - 1))
                        //{
                        //    Success();
                        //    break;
                        //}
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
                        UpdateArrayPosition();
                        //if (arrayPosition == (arrayLength - 1))
                        //{
                        //    Success();
                        //    break;
                        //}
                        break;
                    }
                    else
                    {
                        GameOver();
                        break;
                    }
            }
        }

        void CreateArray()
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    gameArray[i] = r.Next(1, 4);
            //}

            ShowCurrentArray();
        }

        void ShowCurrentArray()
        {
            string current = (gameArray[0].ToString() +
                        gameArray[1].ToString() +
                        gameArray[2].ToString() +
                        gameArray[3].ToString() +
                        gameArray[4].ToString() +
                        gameArray[5].ToString() +
                        gameArray[6].ToString() +
                        gameArray[7].ToString() +
                        gameArray[8].ToString() +
                        gameArray[9].ToString());
            DeBug.Text = current;
        }

        async void Start_Game_Click(object sender, RoutedEventArgs e)
        {
            arrayPosition = 0;
            CreateArray();
            UpdateArrayPosition();
            PlaySequence();
        }


        private void PlaySequence()
        {
            for (int i = 0; i < (arrayLength - 1); i++)
            {
                TakeInput(gameArray[i]);
            }
            arrayPosition = 0;
            UpdateArrayPosition();
        }

        private void UpdateArrayPosition()
        {
            arrayPosition++;
            ArrayPos.Text = arrayPosition.ToString();
        }
    }
}