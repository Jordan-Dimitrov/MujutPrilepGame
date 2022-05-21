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
using System.Windows.Threading;
namespace MujutPrilep
{
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        int gravity = 8;
        Rect PrilepRect;
        public MainWindow()
        {
            InitializeComponent();
            gameTimer.Tick+=Engine;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            startGame();
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            gravity = 8;
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Space)
            {
                gravity = -8;
            }
        }
        private void Engine(object sender, EventArgs e)
        {
            PrilepRect = new Rect(Canvas.GetLeft(mujPrilep), Canvas.GetTop(mujPrilep), mujPrilep.Width - 12, mujPrilep.Height - 6);
            Canvas.SetTop(mujPrilep, Canvas.GetTop(mujPrilep) + gravity);
            Rect pipes = new Rect(Canvas.GetLeft(pipeTop), Canvas.GetTop(pipeTop), pipeTop.Width, pipeTop.Height);
            Rect pipes2 = new Rect(Canvas.GetLeft(pipeBottom), Canvas.GetTop(pipeBottom), pipeBottom.Width, pipeBottom.Height);
            if (PrilepRect.IntersectsWith(pipes)||PrilepRect.IntersectsWith(pipes2))
            {
                gameTimer.Stop();
            }
            if (Canvas.GetLeft(pipeTop)<-100)
            {
                Canvas.SetLeft(pipeTop, 800);
            }
            else
            {
                Canvas.SetLeft(pipeTop, Canvas.GetLeft(pipeTop) - 5);
                Canvas.SetLeft(pipeBottom, Canvas.GetLeft(pipeTop) - 5);
            }
        }
        private void startGame()
        {
            Canvas.SetTop(mujPrilep, 100);
            gameTimer.Start();
        }
    }
}
