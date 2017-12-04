﻿using System;
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
        int LastDay = 4;
        public int Day;
        public MainView _mainView;
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
                        Day1 day1 = new Day1(InputBox.Text);
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
