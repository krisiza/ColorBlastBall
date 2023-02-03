using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Color_Ball_Blast
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        DispatcherTimer numberTimer1 = new DispatcherTimer();
        DispatcherTimer numberTimer2 = new DispatcherTimer();
        DispatcherTimer numberTimer3 = new DispatcherTimer();
        DispatcherTimer numberTimer4 = new DispatcherTimer();
        DispatcherTimer numberTimer5 = new DispatcherTimer();
        DispatcherTimer numberTimer6 = new DispatcherTimer();
        DispatcherTimer numberTimer7 = new DispatcherTimer();
        DispatcherTimer numberTimer8 = new DispatcherTimer();
        DispatcherTimer numberTimer9 = new DispatcherTimer();
        DispatcherTimer numberTimer10 = new DispatcherTimer();
        ImageBrush shotingPlayer = new ImageBrush();
        Random random = new Random();
        bool goLeft, goRight;
        const int playerspeed = 12;
        const int shootspeed = 30;
        int numberspeed = 5;
        int score = 0;
        int level = 1;
        int width;
        int xPostion;
        List<Rectangle> bullets = new List<Rectangle>();
        List<Rectangle> listCois = new List<Rectangle>();
        public List<Rectangle> number1 = new List<Rectangle>();
        public List<Rectangle> number2 = new List<Rectangle>();
        public List<Rectangle> number3 = new List<Rectangle>();
        public List<Rectangle> number4 = new List<Rectangle>();
        public List<Rectangle> number5 = new List<Rectangle>();
        public List<Rectangle> number6 = new List<Rectangle>();
        public List<Rectangle> number7 = new List<Rectangle>();
        public List<Rectangle> number8 = new List<Rectangle>();
        public List<Rectangle> number9 = new List<Rectangle>();
        public List<Rectangle> number10 = new List<Rectangle>();
        Rect rBullet;
        Rect rNumber1;
        Rect rNumber2;
        Rect rNumber3;
        Rect rNumber4;
        Rect rNumber5;
        Rect rNumber6;
        Rect rNumber7;
        Rect rNumber8;
        Rect rNumber9;
        Rect rNumber10;
        public MainWindow()
        {
            InitializeComponent();

            myCanvas.Focus();
            pBar.Value = 1;
            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();

            numberTimer1.Tick += NumberTimerEvent1;
            numberTimer1.Interval = TimeSpan.FromSeconds(4);
            numberTimer1.Start();

            numberTimer2.Tick += NumberTimerEvent2;
            numberTimer2.Interval = TimeSpan.FromSeconds(8);
            numberTimer2.Start();

            numberTimer3.Tick += NumberTimerEvent3;
            numberTimer3.Interval = TimeSpan.FromSeconds(10);
            numberTimer3.Start();

            numberTimer4.Tick += NumberTimerEvent4;
            numberTimer4.Interval = TimeSpan.FromSeconds(14);
            numberTimer4.Start();

            numberTimer5.Tick += NumberTimerEvent5;
            numberTimer5.Interval = TimeSpan.FromSeconds(17);
            numberTimer5.Start();

            numberTimer6.Tick += NumberTimerEvent6;
            numberTimer6.Interval = TimeSpan.FromSeconds(21);
            numberTimer6.Start();

            numberTimer7.Tick += NumberTimerEvent7;
            numberTimer7.Interval = TimeSpan.FromSeconds(4);
            numberTimer7.Start();

            numberTimer8.Tick += NumberTimerEvent8;
            numberTimer8.Interval = TimeSpan.FromSeconds(6);
            numberTimer8.Start();

            numberTimer9.Tick += NumberTimerEvent9;
            numberTimer9.Interval = TimeSpan.FromSeconds(10);
            numberTimer9.Start();

            numberTimer10.Tick += NumberTimerEvent10;
            numberTimer10.Interval = TimeSpan.FromSeconds(13);
            numberTimer10.Start();
        }

        private void NumberTimerEvent10(object sender, EventArgs e)
        {
            if (level >= 10)
            {
                CreateNumber10();
            }
        }
        private void NumberTimerEvent9(object sender, EventArgs e)
        {
            if (level >= 9)
            {
                CreateNumber9();
            }
        }
        private void NumberTimerEvent8(object sender, EventArgs e)
        {
            if (level >= 8)
            {
                CreateNumber8();
            }
        }
        private void NumberTimerEvent7(object sender, EventArgs e)
        {
            if (level >= 7)
            {
                CreateNumber7();
            }
        }
        private void NumberTimerEvent6(object sender, EventArgs e)
        {
            if (level >= 6 && level <= 9)
            {
                CreateNumber6();
            }
        }
        private void NumberTimerEvent5(object sender, EventArgs e)
        {
            if (level >= 5 && level <= 9)
            {
                CreateNumber5();
            }
        }
        private void NumberTimerEvent4(object sender, EventArgs e)
        {
            if (level >= 4 && level <= 7)
            {
                CreateNumber4();
            }
        }
        private void NumberTimerEvent3(object sender, EventArgs e)
        {
            if (level >= 3 && level <= 7)
            {
                CreateNumber3();
            }
        }
        private void NumberTimerEvent2(object sender, EventArgs e)
        {
            if (level >= 2 && level <= 6)
            {
                CreateNumber2();
            }
        }
        private void NumberTimerEvent1(object sender, EventArgs e)
        {
            if (level >= 1 && level <= 5)
            {
                CreateNumber1();
            }

            if (listCois.Count > 0)
            {
                for (int i = 0; i < listCois.Count; i++)
                {
                    myCanvas.Children.Remove(listCois[i]);
                    listCois.Remove(listCois[i]);
                }
            }
        }
        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft && Canvas.GetLeft(player) > 10)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - playerspeed);
            }
            if (goRight && (Canvas.GetLeft(player) + (player.Width + 20)) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + playerspeed);
            }

            playerIsShooting();
            numberIsFallig();
            CoinIsFalling();
            bulletHitNumber();
            DeleteShoots();
            DeleteNumbers(number1);
            DeleteNumbers(number2);
            DeleteNumbers(number3);
            DeleteNumbers(number4);
            DeleteNumbers(number5);
            DeleteNumbers(number6);
            DeleteNumbers(number7);
            DeleteNumbers(number8);
            DeleteNumbers(number9);
            DeleteNumbers(number10);

            DeleteNumbersIfOnSamePosition(number1, number2, rNumber1, rNumber2);
            DeleteNumbersIfOnSamePosition(number1, number3, rNumber1, rNumber3);
            DeleteNumbersIfOnSamePosition(number1, number4, rNumber1, rNumber4);
            DeleteNumbersIfOnSamePosition(number1, number5, rNumber1, rNumber5);
            DeleteNumbersIfOnSamePosition(number2, number3, rNumber2, rNumber3);
            DeleteNumbersIfOnSamePosition(number2, number4, rNumber2, rNumber4);
            DeleteNumbersIfOnSamePosition(number2, number5, rNumber2, rNumber5);
            DeleteNumbersIfOnSamePosition(number2, number6, rNumber2, rNumber6);
            DeleteNumbersIfOnSamePosition(number3, number4, rNumber3, rNumber4);
            DeleteNumbersIfOnSamePosition(number3, number5, rNumber3, rNumber5);
            DeleteNumbersIfOnSamePosition(number3, number6, rNumber3, rNumber6);
            DeleteNumbersIfOnSamePosition(number3, number7, rNumber3, rNumber7);
            DeleteNumbersIfOnSamePosition(number4, number5, rNumber4, rNumber5);
            DeleteNumbersIfOnSamePosition(number4, number6, rNumber4, rNumber6);
            DeleteNumbersIfOnSamePosition(number4, number7, rNumber4, rNumber7);
            DeleteNumbersIfOnSamePosition(number5, number6, rNumber5, rNumber6);
            DeleteNumbersIfOnSamePosition(number5, number7, rNumber5, rNumber7);
            DeleteNumbersIfOnSamePosition(number5, number8, rNumber5, rNumber8);
            DeleteNumbersIfOnSamePosition(number5, number9, rNumber5, rNumber9);
            DeleteNumbersIfOnSamePosition(number6, number7, rNumber6, rNumber7);
            DeleteNumbersIfOnSamePosition(number6, number8, rNumber6, rNumber8);
            DeleteNumbersIfOnSamePosition(number6, number9, rNumber6, rNumber9);
            DeleteNumbersIfOnSamePosition(number7, number8, rNumber7, rNumber8);
            DeleteNumbersIfOnSamePosition(number7, number9, rNumber7, rNumber9);
            DeleteNumbersIfOnSamePosition(number7, number10, rNumber7, rNumber10);
            DeleteNumbersIfOnSamePosition(number8, number9, rNumber8, rNumber9);
            DeleteNumbersIfOnSamePosition(number8, number10, rNumber8, rNumber10);
            DeleteNumbersIfOnSamePosition(number9, number10, rNumber9, rNumber10);

            ScoreMinus(number1, 5);
            ScoreMinus(number2, 10);
            ScoreMinus(number3, 15);
            ScoreMinus(number4, 20);
            ScoreMinus(number5, 25);
            ScoreMinus(number6, 30);
            ScoreMinus(number7, 30);
            ScoreMinus(number8, 35);
            ScoreMinus(number9, 35);
            ScoreMinus(number10, 40);
            NumberInsertPlayer(number1);
            NumberInsertPlayer(number2);
            NumberInsertPlayer(number3);
            NumberInsertPlayer(number4);
            NumberInsertPlayer(number5);
            NumberInsertPlayer(number6);
            NumberInsertPlayer(number7);
            NumberInsertPlayer(number8);
            NumberInsertPlayer(number9);

            if (pBar.Value <= 0 && level == 1)
            {
                GameOver();
            }
        }
        private void playerIsShooting()
        {
            foreach (Rectangle bullet in bullets)
            {
                Canvas.SetTop(bullet, Canvas.GetTop(bullet) - shootspeed);
            }
        }
        private void DeleteShoots()
        {
            for (int y = 0; y < bullets.Count; y++)
            {
                if (Canvas.GetTop(bullets[y]) < 0)
                {
                    myCanvas.Children.Remove(bullets[y]);
                    bullets.Remove(bullets[y]);
                }
            }
        }
        private void DeleteNumbers(List<Rectangle> deleteNumbers)
        {
            for (int i = 0; i < deleteNumbers.Count; i++)
            {
                if (Canvas.GetTop(deleteNumbers[i]) > Application.Current.MainWindow.Height)
                {
                    myCanvas.Children.Remove(deleteNumbers[i]);
                    deleteNumbers.Remove(deleteNumbers[i]);
                }
            }
        }
        private void numberIsFallig()
        {
            foreach (var x in myCanvas.Children.OfType<Rectangle>())
            {
                if (x is Rectangle && (string)x.Tag == "numbers")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + numberspeed);
                }
            }
        }
        private void bulletHitNumber()
        {
            if (bullets.Count > 0)
            {
                for (int i = 0; i < bullets.Count; i++)
                {
                    rBullet = new Rect(Canvas.GetLeft(bullets[i]), Canvas.GetTop(bullets[i]), bullets[i].Width, bullets[i].Height);
                }
                CreateNewNumbers(number1, @"../../image/1.png", number1);

                if (number2.Count != 0)
                {
                    CreateNewNumbers(number2, @"../../image/1.png", number1);
                }
                if (number3.Count != 0)
                {
                    CreateNewNumbers(number3, @"../../image/2.png", number2);
                }
                if (number4.Count != 0)
                {
                    CreateNewNumbers(number4, @"../../image/3.png", number3);
                }
                if (number5.Count != 0)
                {
                    CreateNewNumbers(number5, @"../../image/4.png", number4);
                }
                if (number6.Count != 0)
                {
                    CreateNewNumbers(number6, @"../../image/5.png", number5);
                }
                if (number7.Count != 0)
                {
                    CreateNewNumbers(number7, @"../../image/6..png", number6);
                }
                if (number8.Count != 0)
                {
                    CreateNewNumbers(number8, @"../../image/7.png", number7);
                }
                if (number9.Count != 0)
                {
                    CreateNewNumbers(number9, @"../../image/8..png", number8);
                }
                if (number10.Count != 0)
                {
                    CreateNewNumbers(number10, @"../../image/9.png", number9);
                }
            }
        }
        private void CreateNewNumbers(List<Rectangle> numbers, string image, List<Rectangle> lastList)
        {
            for (int y = numbers.Count - 1; y >= 0; y--)
            {
                Rect rNumber = new Rect(Canvas.GetLeft(numbers[y]), Canvas.GetTop(numbers[y]), numbers[y].Width, numbers[y].Height);

                if (rBullet.IntersectsWith(rNumber))
                {
                    if (rNumber.Width > 50)
                    {
                        CreateNumbers(image, rNumber.Width / 2, rNumber.X + 50, rNumber.Y - 40, lastList);
                        CreateNumbers(image, rNumber.Width / 2, rNumber.X - 50, rNumber.Y - 40, lastList);
                    }

                    myCanvas.Children.Remove(numbers[y]);
                    numbers.Remove(numbers[y]);

                    foreach (var x in myCanvas.Children.OfType<Rectangle>())
                    {
                        if (x is Rectangle && (string)x.Tag == "bullet")
                        {
                            myCanvas.Children.Remove(x);
                            bullets.Remove(x);
                            break;
                        }
                    }

                    if (numbers.Equals(number1))
                    {
                        CreateCoin(rNumber.X, rNumber.Y);
                    }
                    if (numbers.Equals(number2))
                    {
                        CreateCoin(rNumber.X, rNumber.Y);
                        CreateCoin(rNumber.X + 10, rNumber.Y);
                    }
                    if (numbers.Equals(number3))
                    {
                        CreateCoin(rNumber.X, rNumber.Y);
                        CreateCoin(rNumber.X + 10, rNumber.Y);
                        CreateCoin(rNumber.X - 10, rNumber.Y);
                    }
                    if (numbers.Equals(number4))
                    {
                        CreateCoin(rNumber.X, rNumber.Y);
                        CreateCoin(rNumber.X + 10, rNumber.Y);
                        CreateCoin(rNumber.X + 20, rNumber.Y);
                        CreateCoin(rNumber.X - 10, rNumber.Y);
                    }
                    if (numbers.Equals(number5))
                    {
                        CreateCoin(rNumber.X, rNumber.Y);
                        CreateCoin(rNumber.X + 10, rNumber.Y);
                        CreateCoin(rNumber.X + 20, rNumber.Y);
                        CreateCoin(rNumber.X - 10, rNumber.Y);
                        CreateCoin(rNumber.X - 20, rNumber.Y);
                    }
                    if (numbers.Equals(number6))
                    {
                        CreateCoin(rNumber.X, rNumber.Y);
                        CreateCoin(rNumber.X + 10, rNumber.Y);
                        CreateCoin(rNumber.X + 20, rNumber.Y);
                        CreateCoin(rNumber.X - 10, rNumber.Y);
                        CreateCoin(rNumber.X - 20, rNumber.Y);
                        CreateCoin(rNumber.X + 30, rNumber.Y);
                    }
                    if (numbers.Equals(number7))
                    {
                        CreateCoin(rNumber.X, rNumber.Y);
                        CreateCoin(rNumber.X + 10, rNumber.Y);
                        CreateCoin(rNumber.X + 20, rNumber.Y);
                        CreateCoin(rNumber.X - 10, rNumber.Y);
                        CreateCoin(rNumber.X - 20, rNumber.Y);
                        CreateCoin(rNumber.X + 30, rNumber.Y);
                        CreateCoin(rNumber.X - 30, rNumber.Y);
                    }
                    if (numbers.Equals(number8))
                    {
                        CreateCoin(rNumber.X, rNumber.Y);
                        CreateCoin(rNumber.X + 10, rNumber.Y);
                        CreateCoin(rNumber.X + 20, rNumber.Y);
                        CreateCoin(rNumber.X - 10, rNumber.Y);
                        CreateCoin(rNumber.X - 20, rNumber.Y);
                        CreateCoin(rNumber.X + 30, rNumber.Y);
                        CreateCoin(rNumber.X - 30, rNumber.Y);
                        CreateCoin(rNumber.X + 40, rNumber.Y);
                    }
                    if (numbers.Equals(number9))
                    {
                        CreateCoin(rNumber.X, rNumber.Y);
                        CreateCoin(rNumber.X + 10, rNumber.Y);
                        CreateCoin(rNumber.X + 20, rNumber.Y);
                        CreateCoin(rNumber.X - 10, rNumber.Y);
                        CreateCoin(rNumber.X - 20, rNumber.Y);
                        CreateCoin(rNumber.X + 30, rNumber.Y);
                        CreateCoin(rNumber.X - 30, rNumber.Y);
                        CreateCoin(rNumber.X + 40, rNumber.Y);
                        CreateCoin(rNumber.X - 40, rNumber.Y);
                    }
                    if (numbers.Equals(number10))
                    {
                        CreateCoin(rNumber.X, rNumber.Y);
                        CreateCoin(rNumber.X + 10, rNumber.Y);
                        CreateCoin(rNumber.X + 20, rNumber.Y);
                        CreateCoin(rNumber.X - 10, rNumber.Y);
                        CreateCoin(rNumber.X - 20, rNumber.Y);
                        CreateCoin(rNumber.X + 30, rNumber.Y);
                        CreateCoin(rNumber.X - 30, rNumber.Y);
                        CreateCoin(rNumber.X + 40, rNumber.Y);
                        CreateCoin(rNumber.X - 40, rNumber.Y);
                        CreateCoin(rNumber.X - 50, rNumber.Y);
                    }
                }
            }
        }
        private void ScoreMinus(List<Rectangle> numbers, int minusscore)
        {
            Rect rGround = new Rect(Canvas.GetLeft(ground), Canvas.GetTop(ground), ground.Width, ground.Height);
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                Rect rNumber = new Rect(Canvas.GetLeft(numbers[i]), Canvas.GetTop(numbers[i]), numbers[i].Width, numbers[i].Height);

                if (rNumber.IntersectsWith(rGround))
                {
                    pBar.Value -= minusscore;

                    myCanvas.Children.Remove(numbers[i]);
                    numbers.Remove(numbers[i]);

                    if (pBar.Value <= 0 && level != 1)
                    {
                        level -= 1;
                        lbLevel.Content = level.ToString();

                        pBar.Value = 100 - minusscore;
                    }
                }
            }
        }
        private void ChangeScore()
        {
            if (pBar.Value == 100)
            {
                level += 1;
                lbLevel.Content = level.ToString();
                pBar.Value = 1;
            }
            else
            {
                pBar.Value += 10;
            }
            lbScore.Content = score.ToString();
        }
        private void DeleteNumbersIfOnSamePosition(List<Rectangle> listnumber1, List<Rectangle> listnumber2, Rect Rectangle1, Rect Rectangle2)
        {
            for (int i = listnumber1.Count - 1; i >= 0; i--)
            {
                Rectangle1 = new Rect(Canvas.GetLeft(listnumber1[i]), Canvas.GetTop(listnumber1[i]), listnumber1[i].Width, listnumber1[i].Height);

                for (int j = listnumber2.Count - 1; j >= 0; j--)
                {
                    Rectangle2 = new Rect(Canvas.GetLeft(listnumber2[j]), Canvas.GetTop(listnumber2[j]), listnumber2[j].Width, listnumber2[j].Height);
                    if (Rectangle1.IntersectsWith(Rectangle2))
                    {
                        myCanvas.Children.Remove(listnumber1[i]);
                        listnumber1.Remove(listnumber1[i]);
                    }
                }
            }
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = true;

                shotingPlayer.ImageSource = new BitmapImage(new Uri(@"../../image/weltraumschiffL.png", UriKind.Relative));
                player.Fill = shotingPlayer;
            }
            if (e.Key == Key.Right)
            {
                goRight = true;

                shotingPlayer.ImageSource = new BitmapImage(new Uri(@"../../image/weltraumschiffR.png", UriKind.Relative));
                player.Fill = shotingPlayer;
            }
            if (e.Key == Key.Space)
            {
                CreateShot();

                shotingPlayer.ImageSource = new BitmapImage(new Uri(@"../../image/schootingschiff.png", UriKind.Relative));
                player.Fill = shotingPlayer;
            }
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = false;
                shotingPlayer.ImageSource = new BitmapImage(new Uri(@"../../image/weltraumschiff.png", UriKind.Relative));
                player.Fill = shotingPlayer;
            }
            if (e.Key == Key.Right)
            {
                goRight = false;
                shotingPlayer.ImageSource = new BitmapImage(new Uri(@"../../image/weltraumschiff.png", UriKind.Relative));
                player.Fill = shotingPlayer;
            }
            if (e.Key == Key.Space)
            {
                shotingPlayer.ImageSource = new BitmapImage(new Uri(@"../../image/weltraumschiff.png", UriKind.Relative));
                player.Fill = shotingPlayer;
            }
        }
        private Rectangle CreateShot()
        {
            Rectangle shoot;
            shoot = new Rectangle();
            shoot.Tag = "bullet";
            shoot.Width = 10;
            shoot.Height = 20;

            ImageBrush groundImage = new ImageBrush();
            groundImage.ImageSource = new BitmapImage(new Uri(@"../../image/shoot.png", UriKind.Relative));
            shoot.Fill = groundImage;

            myCanvas.Children.Add(shoot);

            Canvas.SetLeft(shoot, Canvas.GetLeft(player) + 66);
            Canvas.SetTop(shoot, Canvas.GetTop(player) - 5);
            bullets.Add(shoot);
            return shoot;
        }
        private Rectangle CreateNumbers(string root, double width, double xPosition, double yPosition, List<Rectangle> numbers)
        {
            Rectangle number;
            number = new Rectangle();
            number.Tag = "numbers";
            number.Width = width;
            number.Height = width;

            ImageBrush groundImage = new ImageBrush();
            groundImage.ImageSource = new BitmapImage(new Uri(root, UriKind.Relative));
            number.Fill = groundImage;

            Canvas.SetLeft(number, xPosition);
            Canvas.SetTop(number, yPosition);

            myCanvas.Children.Add(number);
            numbers.Add(number);

            return number;

        }
        private int Width()
        {
            return width = random.Next(30, 100);
        }
        private int xPosition()
        {
            return xPostion = random.Next(100, 600);
        }
        private Rectangle CreateNumber1()
        {
            return CreateNumbers(@"../../image/1.png", Width(), xPosition(), -100, number1);
        }
        private Rectangle CreateNumber2()
        {
            return CreateNumbers(@"../../image/2.png", Width(), xPosition(), -100, number2);
        }
        private Rectangle CreateNumber3()
        {
            return CreateNumbers(@"../../image/3.png", Width(), xPosition(), -100, number3);
        }
        private Rectangle CreateNumber4()
        {
            return CreateNumbers(@"../../image/4.png", Width(), xPosition(), -100, number4);
        }
        private Rectangle CreateNumber5()
        {
            return CreateNumbers(@"../../image/5.png", Width(), xPosition(), -100, number5);
        }
        private Rectangle CreateNumber6()
        {
            return CreateNumbers(@"../../image/6..png", Width(), xPosition(), -100, number6);
        }
        private Rectangle CreateNumber7()
        {
            return CreateNumbers(@"../../image/7.png", Width(), xPosition(), -100, number7);
        }
        private Rectangle CreateNumber8()
        {
            return CreateNumbers(@"../../image/8..png", Width(), xPosition(), -100, number8);
        }
        private Rectangle CreateNumber9()
        {
            return CreateNumbers(@"../../image/9.png", Width(), xPosition(), -100, number9);
        }
        private Rectangle CreateNumber10()
        {
            return CreateNumbers(@"../../image/10.png", Width(), xPosition(), -100, number10);
        }
        private Rectangle CreateCoin(double width, double hight)
        {
            Rectangle coin;
            coin = new Rectangle();
            coin.Tag = "coins";
            coin.Width = 10;
            coin.Height = 20;

            ImageBrush coinImage = new ImageBrush();
            coinImage.ImageSource = new BitmapImage(new Uri(@"../../image/pngaaa.com-871246 (1).png", UriKind.Relative));
            coin.Fill = coinImage;

            myCanvas.Children.Add(coin);

            Canvas.SetLeft(coin, width);
            Canvas.SetTop(coin, hight);

            listCois.Add(coin);
            return coin;
        }
        int coinspeed = 12;
        private void CoinIsFalling()
        {
            for (int i = 0; i < listCois.Count; i++)
            {
                Rect rCoin = new Rect(Canvas.GetLeft(listCois[i]), Canvas.GetTop(listCois[i]), listCois[i].Width, listCois[i].Height);
                Rect rGround = new Rect(Canvas.GetLeft(ground), Canvas.GetTop(ground), ground.Width, ground.Height);
                Rect rPlayer = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, player.Height);

                if (rCoin.IntersectsWith(rGround))
                {
                    coinspeed = 0;
                }
                else
                {
                    coinspeed = 12;
                    Canvas.SetTop(listCois[i], Canvas.GetTop(listCois[i]) + coinspeed);
                }

                if (rPlayer.IntersectsWith(rCoin))
                {
                    myCanvas.Children.Remove(listCois[i]);
                    listCois.Remove(listCois[i]);

                    score += 1;
                    ChangeScore();
                }
            }
        }
        private void NumberInsertPlayer(List<Rectangle> numbers)
        {
            Rect rPlayer = new Rect(Canvas.GetTop(player), Canvas.GetLeft(player), player.Width, player.Height);
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                Rect rNumber = new Rect(Canvas.GetTop(numbers[i]), Canvas.GetLeft(numbers[i]), numbers[i].Width, numbers[i].Height);

                if (rNumber.IntersectsWith(rPlayer))
                {
                    GameOver();
                }
            }
        }
        private void GameOver()
        {

            MessageBoxResult result;
            result = MessageBox.Show($"Game Over!\nYour Score: {score}", "GAME OVER!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                Close();
                
            }
            ResetGame();
        }
        private void ResetGame()
        {
            myCanvas.Children.Clear();
            number1.Clear();
            number2.Clear();
            number3.Clear();
            number4.Clear();
            number5.Clear();
            number6.Clear();
            number7.Clear();
            number8.Clear();
            number9.Clear();
            number10.Clear();

            score = 0;
            pBar.Value = 1;
  

            goLeft = false;
            goRight = false;

            shotingPlayer.ImageSource = new BitmapImage(new Uri(@"../../image/weltraumschiff.png", UriKind.Relative));
            player.Fill = shotingPlayer;

            Canvas.SetLeft(player, 323);
            myCanvas.Children.Add(player);
            myCanvas.Children.Add(rBild);
            myCanvas.Children.Add(lbLevel);
            myCanvas.Children.Add(lbL);
            myCanvas.Children.Add(lbScore);
            myCanvas.Children.Add(ground);
            myCanvas.Children.Add(pBar);
        }
    }
}
