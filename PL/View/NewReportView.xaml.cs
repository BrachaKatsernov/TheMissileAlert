﻿using BE;
using PL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Text.RegularExpressions;

namespace PL
{
    /// <summary>
    /// Interaction logic for NewReportUC.xaml
    /// </summary>
    public partial class NewReportView : UserControl
    {
        private ReportVM CurrentVM { get; set; }
        private AssessmentAndlFallsVM PredictionAndRealFalls { get; set; }

        public NewReportView()
        {
            InitializeComponent();
            CurrentVM = new ReportVM();
            this.DataContext = CurrentVM;
            SaveButton.IsEnabled = false;
            TimeDatePicker.Text = DateTime.Now.ToString();
            PredictionAndRealFalls = AssessmentAndlFallsVM.Instance;
        }


        private void SaveEnableCheck(object sender, RoutedEventArgs routedEventArgs)
        {

            SaveButton.IsEnabled =
                                   NameTextBox.Text != "" &&
                                   NoiseIntensityTextBox.Text != "" &&
                                  NumOfExplosionsTextBox.Text != ""
                                 ;
        }

        private void CancelButton_Loaded(object sender, RoutedEventArgs e)
        {
            NameTextBox.Text = "";
            NoiseIntensityTextBox.Text = "";
            NumOfExplosionsTextBox.Text = "";
            NameTextBox.Text = "";
            TimeDatePicker.Text = "";

        }


        private void CancelButton_ButtonClick(object sender, EventArgs e)
        {

            Clear();
        }

        private void SaveButton_ButtonClick(object sender, EventArgs e)
        {
           
                TimeDatePicker.Background = Brushes.White;
                SaveButton.IsEnabled = false;
                SaveButton.Command = CurrentVM.Add;
                Report CurrentfallReport;//what about add location??

                CurrentfallReport = new Report(Convert.ToDateTime(TimeDatePicker.Text), NameTextBox.Text, new Location_(AddressTextBox.CompleteBox.Text), Convert.ToInt32(NoiseIntensityTextBox.Text), Convert.ToInt32(NumOfExplosionsTextBox.Text));
                Clear();
                SaveButton.CommandParameter = CurrentfallReport;
           
        }

        private void NoiseIntensityTextBox_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void NumberValidationTextBox1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            if (e.Handled == false)
            {
                try
                {
                    double dVal = Convert.ToDouble(NoiseIntensityTextBox.Text.Trim().Insert(NoiseIntensityTextBox.SelectionStart, (e.Text).ToString()));
                    if (dVal < 0 || dVal > 10)
                    {
                        e.Handled = true;
                        return;
                    }
                }
                catch
                {
                    //skip
                    return;
                }
            }
        }

        private void Clear()
        {
            NameTextBox.Text = "";
            NoiseIntensityTextBox.Text = "";
            NumOfExplosionsTextBox.Text = "";
            AddressTextBox.CompleteBox.Text = "";
            TimeDatePicker.Text = "";
            TimeDatePicker.Background = Brushes.White;
        }

        private void TimeDatePicker_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TimeDatePicker.Background = Brushes.White;
        }

        private void TimeDatePicker_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            TimeDatePicker.Background = Brushes.White;
        }

        private void TimeDatePicker_DragEnter(object sender, DragEventArgs e)
        {
            TimeDatePicker.Background = Brushes.White;
        }
    }
}
