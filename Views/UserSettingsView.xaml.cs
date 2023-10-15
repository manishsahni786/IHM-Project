using MireWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace MireWpf.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class UserSettingsView : UserControl
    {
        private static int MemoIndexChoixCombobox;

        public UserSettingsViewModel ViewModel { get { return DataContext as UserSettingsViewModel; } }

        public UserSettingsView()
        {
            InitializeComponent();
            LoadComboBox();
        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            Params.Children.Clear();
            ParamPopUp.Height = 250;

            for(int i = 0; i < 5; i++)
            {
                ViewModel._parent.SaveParamLabel(i, "");
                ViewModel._parent.SaveParamData(i, "");
            }

            int nbParams = 0;
            foreach(StackPanel child in Labels.Children)
            {
                CheckBox cb = (CheckBox)child.Children[0];
                TextBox tb = (TextBox)child.Children[1];
                if (cb.IsChecked == true)
                {
                    ViewModel._parent.SaveParamLabel(nbParams, tb.Text);
                    nbParams++;
                    ParamPopUp.Height += 100;
                    StackPanel sp = new StackPanel
                    {
                        Name = "Param" + nbParams,
                        Orientation = Orientation.Horizontal,
                        HorizontalAlignment = HorizontalAlignment.Right
                    };
                    sp.Children.Add(new TextBlock {
                        Text = tb.Text,
                        FontSize = 36,
                        Margin = new Thickness(20,40,20,0)
                    });
                    sp.Children.Add(new TextBox {
                        FontSize = 36,
                        MinWidth = 100,
                        MaxWidth = 900,
                        Margin = new Thickness(20,40,20,0)
                    });
                    Params.Children.Add(sp);
                }
            }
        }*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int nbParams = 0;

            for (int i = 0; i < 5; i++) 
            {
                ViewModel._parent.SaveParamLabel(i, "");
                ViewModel._parent.SaveParamData(i, "");
            }

            foreach (StackPanel child in Labels.Children)
            {
                CheckBox cb = (CheckBox)child.Children[0];
                TextBox tb = (TextBox)child.Children[1];
                if (cb.IsChecked == true)
                {
                    ViewModel._parent.SaveParamLabel(nbParams, tb.Text);
                    nbParams++;
                }
            }
        }

        private void LoadComboBox()
        {
            //On recupere le chemin du répertoire de l'application
            string sPathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string sPathFolderMask = sPathDesktop.Insert(sPathDesktop.Length, "\\PrintMask");
            string sPrintMaskComboBox;

            //Test si le dossier contenant les masques d'impression est crée, si non on le crée dans le répertoire de l'application
            bool bDossierExist;
            bDossierExist = Directory.Exists(sPathFolderMask);
            if (bDossierExist == false)
            {
                //On crée le reprtoire sur le bureau
                DirectoryInfo PrintMaskFolder = Directory.CreateDirectory(sPathFolderMask);
            }

            //Ajout des lignes dans le combobox
            //string[] PrintMask = Directory.GetFiles(sPathFolderMask, "*.prn"); //On récupere tous les fichiers .prn d'impression présent dans le dossier
            string[] PrintMask = Directory.GetFiles(sPathFolderMask, "*.prn"); //On récupere tous les fichiers .prn d'impression présent dans le dossier

            foreach (string sPrintMask in PrintMask)
            {
                sPrintMaskComboBox = sPrintMask.Replace(string.Concat(sPathFolderMask, "\\"), "");
                cbChoixMasque.Items.Add(sPrintMaskComboBox);
            }

            if (cbChoixMasque.SelectedIndex == -1)
            {
                cbChoixMasque.SelectedIndex = MemoIndexChoixCombobox;
            }
        }

        private void cbChoixMasque_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MemoIndexChoixCombobox = cbChoixMasque.SelectedIndex;
        }

        private void label1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
