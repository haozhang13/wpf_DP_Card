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

namespace Wpf_Card
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        private Card Card;
        private Point offset;
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ContentGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.Source is Card)
            {
                Card = (Card)e.Source;
                offset = Mouse.GetPosition(Card);
                contentGrid.Children.Remove(Card);
            }
            else
            {
                Card = new Card
                {
                    Suit = Card.Suits[random.Next(0, 4)],
                    Rank = random.Next(1, 13)
                };

                Card.HorizontalAlignment = HorizontalAlignment.Left;
                Card.VerticalAlignment = VerticalAlignment.Top;
                offset = new Point(50, 75);
            }

            contentGrid.Children.Add(Card);
            PositionCard();
        }

        private void PositionCard()
        {
            Point pt = Mouse.GetPosition(this);
            Card.Margin = new Thickness(pt.X - offset.X, pt.Y - offset.Y, 0, 0);
        }

        private void ContentGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Card = null;
        }

        private void ContentGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if(Card != null)
            {
                PositionCard();
            }
        }
    }
}
