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
    /// Caer.xaml 的交互逻辑
    /// </summary>
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
        }

        public static string[] Suits = { "Club", "Diamond", "Heart", "Spade" };


       //Get获取依赖属性值，Set设置依赖属性值
        public string Suit
        {
            get { return (string)GetValue(SuitProperty); }
            set { SetValue(SuitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Suit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SuitProperty =
            DependencyProperty.Register("Suit", typeof(string), typeof(Card),
                new PropertyMetadata("Club", new PropertyChangedCallback(OnSuitChanged)),
                new ValidateValueCallback(ValidateSuit));



        public int Rank
        {
            get { return (int)GetValue(RankProperty); }
            set { SetValue(RankProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Rank.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RankProperty =
            DependencyProperty.Register("Rank", typeof(int), typeof(Card), new PropertyMetadata(1),
                                        new ValidateValueCallback(ValidateRank));

        //是否有效
        private static bool ValidateSuit(object value)
        {
            string suitValueString = (string)value;

            if(suitValueString != "Club" && suitValueString !="Diamond"
                &&suitValueString != "Heart" && suitValueString !="Spade")
            {
                return false;
            }
            return true;
        }

        private static bool ValidateRank(object value)
        {
            int rankValueInt = (int)value;
            if(rankValueInt < 1 || rankValueInt > 12)
            {
                return false;
            }
            return true;
        }

        private static void OnSuitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Card)d).SetTextColor();
        }

        private void SetTextColor()
        {
            if(Suit == "Club" || Suit == "Spade")
            {
                RankLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                SuitLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                RanklabelInverted.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
            else
            {
                RankLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                SuitLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                RanklabelInverted.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
        }
    }
}
