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

namespace Advent2017
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int LastDay = 12;
        public int Day;
        private readonly MainView _mainView;
        public MainWindow()
        {
            InitializeComponent();
            _mainView = DataContext as MainView;
            InputBox.Focus();
            Day = LastDay;
            DayBox.Text = Day.ToString();
        }

        private void InputBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                switch (Day)
                {
                    case 1:
                        Day1 day1 = new Day1(InputBox.Text, _mainView);
                        OutputBox.Text = day1.Result();
                        break;
                    case 2:
                        Day2 day2 = new Day2(InputBox.Text);
                        OutputBox.Text = day2.Result();
                        break;
                    case 3:
                        Day3 day3 = new Day3(InputBox.Text);
                        OutputBox.Text = day3.Result();
                        break;
                    case 4:
                        Day4 day4 = new Day4(InputBox.Text);
                        OutputBox.Text = day4.Result();
                        break;
                    case 5:
                        Day5 day5 = new Day5(InputBox.Text);
                        OutputBox.Text = day5.Result();
                        break;
                    case 6:
                        Day6 day6 = new Day6(InputBox.Text);
                        OutputBox.Text = day6.Result();
                        break;
                    case 7:
                        Day7 day7 = new Day7(InputBox.Text);
                        OutputBox.Text = day7.Result();
                        break;
                    case 8:
                        Day8 day8 = new Day8(InputBox.Text);
                        OutputBox.Text = day8.Result();
                        break;
                    case 9:
                        Day9 day9 = new Day9(InputBox.Text);
                        OutputBox.Text = day9.Result();
                        break;
                    case 10:
                        Day10 day10 = new Day10(InputBox.Text);
                        OutputBox.Text = day10.Result();
                        break;
                    case 11:
                        Day11 day11 = new Day11(InputBox.Text);
                        OutputBox.Text = day11.Result();
                        break;
                    case 12:
                        Day12 day12 = new Day12(InputBox.Text);
                        OutputBox.Text = day12.Result();
                        break;
                    default:
                        OutputBox.Text = "oops, no day choosen";
                        break;
                }
            }
        }

        private void DayBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    Day = Int32.Parse(DayBox.Text);
                    DayBox.Text = Day.ToString();
                }
                catch
                {
                    DayBox.Text = Day.ToString();
                }
            }

        }
    }
}
