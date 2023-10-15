﻿using MireWpf.ViewModels;
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
using System.Globalization;

namespace MireWpf.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class SpokeView : UserControl
    {
        public SpokeViewModel ViewModel { get { return DataContext as SpokeViewModel; } }

        public SpokeView()
        {
            InitializeComponent();
        }

        private TextBox targetTextBox;
        private string memory;
        private bool bParse;
        private float fValnum;
        int Choix;

        private void run_MouseEnter(object sender, KeyboardEventArgs e)
        {
            if (ViewModel.EditMode == 1)
            {
                Choix = 1;
                popLink.IsOpen = false;

                popLink.PlacementTarget = (UIElement)e.Source;
                popLink.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                popLink.IsOpen = true;
                targetTextBox = sender as TextBox;
                memory = targetTextBox.Text;
                keypadScreen.Text = targetTextBox.Text;
                targetTextBox.Text = "";
            }
        }

        private DataGridCell targetDataGridCell;
        private TextBlock targetDataTextBlock;
        private void run_MouseEnterData(object sender, KeyboardEventArgs e)
        {
            if (ViewModel.EditMode == 1)
            {
                Choix = 2;
                popLink.IsOpen = false;

                popLink.PlacementTarget = (UIElement)e.Source;
                popLink.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                popLink.IsOpen = true;
                targetDataGridCell = sender as DataGridCell;
                targetDataTextBlock = (TextBlock)targetDataGridCell.Content;
                memory = targetDataTextBlock.Text;
                keypadScreen.Text = targetDataTextBlock.Text; ;
                targetDataTextBlock.Text = "";
            }
        }

        private void lnk_Click(object sender, RoutedEventArgs e)
        {
            popLink.IsOpen = false;
            targetTextBox = null;
        }

        private void key_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)e.OriginalSource;
            string s = btn.Content.ToString();

            int index1;


            switch (s)
            {
                case "Cancel":
                    if (Choix == 1)
                    {
                        targetTextBox.Text = memory;
                    }
                    else if (Choix == 2)
                    {
                        targetDataTextBlock.Text = memory;
                    }
                    popLink.IsOpen = false;
                    targetTextBox = null;
                    keypadScreen.Text = "";
                    keypadScreen.Focus();
                    break;
                case "<":
                    if (keypadScreen.Text != "")
                    {
                        keypadScreen.Text = keypadScreen.Text.Remove(keypadScreen.Text.Length - 1);
                    }
                    keypadScreen.Focus();
                    break;
                case "Clear":
                    keypadScreen.Text = "";
                    keypadScreen.Focus();
                    break;
                case "Enter":
                    if (keypadScreen.Text == "")
                    {
                        if (Choix == 1)
                        {
                            targetTextBox.Text = "0";
                        }
                        else if (Choix == 2)
                        {
                            targetDataTextBlock.Text = "0";
                        }
                    }
                    else
                    {
                        if (Choix == 1)
                        {
                            targetTextBox.Text = keypadScreen.Text;
                        }
                        else if (Choix == 2)
                        {
                            targetDataTextBlock.Text = keypadScreen.Text;
                        } 
                    }
                    popLink.IsOpen = false;
                    targetTextBox = null;
                    keypadScreen.Text = "";
                    keypadScreen.Focus();
                    break;
                case "_-":
                    bParse = float.TryParse(keypadScreen.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out fValnum);
                    if (bParse == true)
                    {
                        fValnum = fValnum * (-1);
                    }
                    keypadScreen.Text = fValnum.ToString();
                    keypadScreen.Text = keypadScreen.Text.Replace(',', '.'); //To replace the , with the . if the system uses coma instead of periods.
                    keypadScreen.Focus();
                    break;

                case "_.":
                    index1 = keypadScreen.Text.IndexOf('.');
                    if (index1 == -1)
                    {

                        keypadScreen.Text += '.';
                        keypadScreen.Focus();
                        break;
                    }
                    else
                    {
                        keypadScreen.Focus();
                        break;
                    }

                case "_1":
                    keypadScreen.Text += '1';
                    keypadScreen.Focus();
                    break;

                case "_2":
                    keypadScreen.Text += '2';
                    keypadScreen.Focus();
                    break;
                case "_3":
                    keypadScreen.Text += '3';
                    keypadScreen.Focus();
                    break;
                case "_4":
                    keypadScreen.Text += '4';
                    keypadScreen.Focus();
                    break;
                case "_5":
                    keypadScreen.Text += '5';
                    keypadScreen.Focus();
                    break;
                case "_6":
                    keypadScreen.Text += '6';
                    keypadScreen.Focus();
                    break;
                case "_7":
                    keypadScreen.Text += '7';
                    keypadScreen.Focus();
                    break;
                case "_8":
                    keypadScreen.Text += '8';
                    keypadScreen.Focus();
                    break;
                case "_9":
                    keypadScreen.Text += '9';
                    keypadScreen.Focus();
                    break;
                case "_0":
                    keypadScreen.Text += '0';
                    keypadScreen.Focus();
                    break;
                default:
                    keypadScreen.Text += s;
                    keypadScreen.Focus();
                    break;
            }

        }
    }
}
