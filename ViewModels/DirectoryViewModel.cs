using MireWpf.Models;
using Prism.Commands;
//using System;
//using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace MireWpf.ViewModels
{


   
    public class DirectoryViewModel : BaseViewModel, IRegion
    {
        #region Favourites Table Data Class
        public class Favourite : ObservableCollection<Favourite>
        {
            private int _favourite;
            private int _index;
            private int _roue;
            private string _name;
            

            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(""));
                }
            }
            public int Fav
            {
                get { return _favourite; }
                set
                {
                    _favourite = value;
                    OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(""));
                }
            }
            public int Index
            {
                get { return _index; }
                set
                {
                    _index = value;
                    OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(""));
                }
            }
            public int Roue
            {
                get { return _roue; }
                set
                {
                    _roue = value;
                    OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(""));
                }
            }

            public Favourite() { }
        }
        #endregion

        #region parameters
        public MainWindowViewModel _parent;
        private int _editMode = 0;
        private bool _loadMode = false;
        private bool _focusDataGrid = false;
        private bool _admin = false;
        private bool _showHubWindow = false;
        private bool _showPerimeterWindow = false;
        private bool _showSymmetryWindow = false;
        private bool _hubIncrease = false;
        private bool _hubDecrease = false;
        private bool _showShutPopUp = false;
        private bool _showStabilizationPopUp = false;
        private bool _showSavePopUp = false;

        private int _fR_Selecteur_FR;
        private string _fR_String_Name;
        private int _fR_AV_AR;
        private int _fR_circ;
        private float _fR_Pos_Broche;
        private float _fR_Off7_Deport;
        private string _fR_DS_Name;
        private int _fR_DS_Nb_Rayon;
        private string _fR_DS_Date;
        private int _fR_Type_Roue;
        private int _fR_Type_CAS;
        private float _fR_ToleranceVoile_Step1;
        private float _fR_ToleranceVoile_Step2;
        private float _fR_ToleranceVoile_Step3;
        private float _fR_ToleranceVoile_Step4;
        private float _fR_ToleranceVoile_Step5;
        private float _fR_ToleranceSaut_Step1;
        private float _fR_ToleranceSaut_Step2;
        private float _fR_ToleranceSaut_Step3;
        private float _fR_ToleranceSaut_Step4;
        private float _fR_ToleranceSaut_Step5;
        private float _fR_ToleranceDeport_Step1;
        private float _fR_ToleranceDeport_Step2;
        private float _fR_ToleranceDeport_Step3;
        private float _fR_ToleranceDeport_Step4;
        private float _fR_ToleranceDeport_Step5;
        private int _fR_TolTR_RMin_G_Step1;
        private int _fR_TolTR_RMin_G_Step2;
        private int _fR_TolTR_RMin_G_Step3;
        private int _fR_TolTR_RMin_G_Step4;
        private int _fR_TolTR_RMin_G_Step5;
        private int _fR_TolTR_RMax_G_Step1;
        private int _fR_TolTR_RMax_G_Step2;
        private int _fR_TolTR_RMax_G_Step3;
        private int _fR_TolTR_RMax_G_Step4;
        private int _fR_TolTR_RMax_G_Step5;
        private int _fR_TolTR_MoyMin_G_Step1;
        private int _fR_TolTR_MoyMin_G_Step2;
        private int _fR_TolTR_MoyMin_G_Step3;
        private int _fR_TolTR_MoyMin_G_Step4;
        private int _fR_TolTR_MoyMin_G_Step5;
        private int _fR_TolTR_MoyMax_G_Step1;
        private int _fR_TolTR_MoyMax_G_Step2;
        private int _fR_TolTR_MoyMax_G_Step3;
        private int _fR_TolTR_MoyMax_G_Step4;
        private int _fR_TolTR_MoyMax_G_Step5;
        private int _fR_TolTR_RMin_D_Step1;
        private int _fR_TolTR_RMin_D_Step2;
        private int _fR_TolTR_RMin_D_Step3;
        private int _fR_TolTR_RMin_D_Step4;
        private int _fR_TolTR_RMin_D_Step5;
        private int _fR_TolTR_RMax_D_Step1;
        private int _fR_TolTR_RMax_D_Step2;
        private int _fR_TolTR_RMax_D_Step3;
        private int _fR_TolTR_RMax_D_Step4;
        private int _fR_TolTR_RMax_D_Step5;
        private int _fR_TolTR_MoyMin_D_Step1;
        private int _fR_TolTR_MoyMin_D_Step2;
        private int _fR_TolTR_MoyMin_D_Step3;
        private int _fR_TolTR_MoyMin_D_Step4;
        private int _fR_TolTR_MoyMin_D_Step5;
        private int _fR_TolTR_MoyMax_D_Step1;
        private int _fR_TolTR_MoyMax_D_Step2;
        private int _fR_TolTR_MoyMax_D_Step3;
        private int _fR_TolTR_MoyMax_D_Step4;
        private int _fR_TolTR_MoyMax_D_Step5;
        private int _fR_CAS_Pression_Step1;
        private int _fR_CAS_Pression_Step2;
        private int _fR_CAS_Pression_Step3;
        private int _fR_CAS_Pression_Step4;
        private int _fR_CAS_Pression_Step5;
        private int _fR_CAS_NB_de_tour_Step1;
        private int _fR_CAS_NB_de_tour_Step2;
        private int _fR_CAS_NB_de_tour_Step3;
        private int _fR_CAS_NB_de_tour_Step4;
        private int _fR_CAS_NB_de_tour_Step5;
        private int _fR_Seuil_Star_1;
        private int _fR_Seuil_Star_2;
        private int _fR_Seuil_Star_3;
        private int _fR_Pair_ID;
        private int _fR_Favorite;
        private int _fS_Selecteur_FR;
        private string _fS_String_Name;
        private int _fS_AV_AR;
        private int _fS_circ;
        private float _fS_Pos_Broche;
        private float _fS_Off7_Deport;
        private string _fS_DS_Name;
        private int _fS_DS_Nb_Rayon;
        private string _fS_DS_Date;
        private int _fS_Type_Roue;
        private float _fS_Off7_Volontaire;
        private float _fS_ToleranceVoile_Step1;
        private float _fS_ToleranceVoile_Step2;
        private float _fS_ToleranceVoile_Step3;
        private float _fS_ToleranceVoile_Step4;
        private float _fS_ToleranceVoile_Step5;
        private float _fS_ToleranceSaut_Step1;
        private float _fS_ToleranceSaut_Step2;
        private float _fS_ToleranceSaut_Step3;
        private float _fS_ToleranceSaut_Step4;
        private float _fS_ToleranceSaut_Step5;
        private float _fS_ToleranceDeport_Step1;
        private float _fS_ToleranceDeport_Step2;
        private float _fS_ToleranceDeport_Step3;
        private float _fS_ToleranceDeport_Step4;
        private float _fS_ToleranceDeport_Step5;
        private int _fS_TolTR_RMin_G_Step1;
        private int _fS_TolTR_RMin_G_Step2;
        private int _fS_TolTR_RMin_G_Step3;
        private int _fS_TolTR_RMin_G_Step4;
        private int _fS_TolTR_RMin_G_Step5;
        private int _fS_TolTR_RMax_G_Step1;
        private int _fS_TolTR_RMax_G_Step2;
        private int _fS_TolTR_RMax_G_Step3;
        private int _fS_TolTR_RMax_G_Step4;
        private int _fS_TolTR_RMax_G_Step5;
        private int _fS_TolTR_MoyMin_G_Step1;
        private int _fS_TolTR_MoyMin_G_Step2;
        private int _fS_TolTR_MoyMin_G_Step3;
        private int _fS_TolTR_MoyMin_G_Step4;
        private int _fS_TolTR_MoyMin_G_Step5;
        private int _fS_TolTR_MoyMax_G_Step1;
        private int _fS_TolTR_MoyMax_G_Step2;
        private int _fS_TolTR_MoyMax_G_Step3;
        private int _fS_TolTR_MoyMax_G_Step4;
        private int _fS_TolTR_MoyMax_G_Step5;
        private int _fS_TolTR_RMin_D_Step1;
        private int _fS_TolTR_RMin_D_Step2;
        private int _fS_TolTR_RMin_D_Step3;
        private int _fS_TolTR_RMin_D_Step4;
        private int _fS_TolTR_RMin_D_Step5;
        private int _fS_TolTR_RMax_D_Step1;
        private int _fS_TolTR_RMax_D_Step2;
        private int _fS_TolTR_RMax_D_Step3;
        private int _fS_TolTR_RMax_D_Step4;
        private int _fS_TolTR_RMax_D_Step5;
        private int _fS_TolTR_MoyMin_D_Step1;
        private int _fS_TolTR_MoyMin_D_Step2;
        private int _fS_TolTR_MoyMin_D_Step3;
        private int _fS_TolTR_MoyMin_D_Step4;
        private int _fS_TolTR_MoyMin_D_Step5;
        private int _fS_TolTR_MoyMax_D_Step1;
        private int _fS_TolTR_MoyMax_D_Step2;
        private int _fS_TolTR_MoyMax_D_Step3;
        private int _fS_TolTR_MoyMax_D_Step4;
        private int _fS_TolTR_MoyMax_D_Step5;
        private int _fS_CAS_Pression_Step1;
        private int _fS_CAS_Pression_Step2;
        private int _fS_CAS_Pression_Step3;
        private int _fS_CAS_Pression_Step4;
        private int _fS_CAS_Pression_Step5;
        private float _fS_CAS_NB_de_tour_Step1;
        private float _fS_CAS_NB_de_tour_Step2;
        private float _fS_CAS_NB_de_tour_Step3;
        private float _fS_CAS_NB_de_tour_Step4;
        private float _fS_CAS_NB_de_tour_Step5;
        private int _fS_Seuil_Star_1;
        private int _fS_Seuil_Star_2;
        private int _fS_Seuil_Star_3;
        private int _fS_Pair_ID;
        private int _fS_Favorite;
        private float _ecartement_Broche;
        private int _teach_Perim_Circ;
        private float _offsetRecordValue1;
        private float _offsetRecordValue2;
        private float _offsetActuel;
        private float _offsetCalcul;
        private float _offsetCorrection;
        private int _Offset_State;
        #endregion

        #region fields
        //_showHubWindow
        public bool Admin
        {
            get { return _admin; }
            set
            {
                _admin = value;
                OnPropertyChanged();
            }
        }
        public bool ShowHubWindow
        {
            get { return _showHubWindow; }
            set
            {
                _showHubWindow = value;
                OnPropertyChanged();
                if (value)
                    _parent.SetTwincatValue("PopupId", (short)1);
                else
                    _parent.SetTwincatValue("PopupId", (short)0);
            }
        }
        public bool ShowPerimeterWindow
        {
            get { return _showPerimeterWindow; }
            set
            {
                _showPerimeterWindow = value;
                OnPropertyChanged();
                if (value)
                    _parent.SetTwincatValue("PopupId", (short)2);
                else
                    _parent.SetTwincatValue("PopupId", (short)0);
            }
        }
        public bool ShowSymmetryWindow
        {
            get { return _showSymmetryWindow; }
            set
            {
                _showSymmetryWindow = value;
                OnPropertyChanged();
                if (value)
                    _parent.SetTwincatValue("PopupId", (short)3);
                else
                    _parent.SetTwincatValue("PopupId", (short)0);
            }
        }
        public bool HubIncrease
        {
            get { return _hubIncrease; }
            set
            {
                _hubIncrease = value;
                OnPropertyChanged();
            }
        }
        public bool HubDecrease
        {
            get { return _hubDecrease; }
            set
            {
                _hubDecrease = value;
                OnPropertyChanged();
            }
        }

        public int EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;
                OnPropertyChanged();

                if (value == 0)
                {
                    refreshFR = true;
                    
                }
            }
        }

        public int DirectorySelectedIndex
        {
            get { return FS_Selecteur_FR - 1; }
            set
            {
                FS_Selecteur_FR = value + 1;
                OnPropertyChanged();
            }
        }

        public bool FocusDataGrid
        {
            get { return _focusDataGrid; }
            set
            {
                _focusDataGrid = value;
                OnPropertyChanged();
            }
        }
        
        public int FR_Selecteur_FR { get { return _fR_Selecteur_FR; } set { System.Console.WriteLine("Début trop d'variables : {0:HH:mm:ss.fff}", System.DateTime.Now); _fR_Selecteur_FR = value; OnPropertyChanged(); } }
        public string FR_String_Name { get { return _fR_String_Name; } set { _fR_String_Name = value; OnPropertyChanged(); } }
        public int FR_AV_AR { get { return _fR_AV_AR; } set { _fR_AV_AR = value; OnPropertyChanged(); } }
        public int FR_circ { get { return _fR_circ; } set { _fR_circ = value; OnPropertyChanged(); } }
        public float FR_Pos_Broche { get { return _fR_Pos_Broche; } set { _fR_Pos_Broche = value; OnPropertyChanged(); } }
        public float FR_Off7_Deport { get { return _fR_Off7_Deport; } set { _fR_Off7_Deport = value; OnPropertyChanged(); } }
        public string FR_DS_Name { get { return _fR_DS_Name; } set { _fR_DS_Name = value; OnPropertyChanged(); } }
        public int FR_DS_Nb_Rayon { get { return _fR_DS_Nb_Rayon; } set { _fR_DS_Nb_Rayon = value; OnPropertyChanged(); } }
        public string FR_DS_Date { get { return _fR_DS_Date; } set { _fR_DS_Date = value; OnPropertyChanged(); } }
        public int FR_Type_Roue { get { return _fR_Type_Roue; } set { _fR_Type_Roue = value; OnPropertyChanged(); } }
        public int FR_Type_CAS { get { return _fR_Type_CAS; } set { _fR_Type_CAS = value; OnPropertyChanged(); } }
        public float FR_ToleranceVoile_Step1 { get { return _fR_ToleranceVoile_Step1; } set { _fR_ToleranceVoile_Step1 = value; OnPropertyChanged(); } }
        public float FR_ToleranceVoile_Step2 { get { return _fR_ToleranceVoile_Step2; } set { _fR_ToleranceVoile_Step2 = value; OnPropertyChanged(); } }
        public float FR_ToleranceVoile_Step3 { get { return _fR_ToleranceVoile_Step3; } set { _fR_ToleranceVoile_Step3 = value; OnPropertyChanged(); } }
        public float FR_ToleranceVoile_Step4 { get { return _fR_ToleranceVoile_Step4; } set { _fR_ToleranceVoile_Step4 = value; OnPropertyChanged(); } }
        public float FR_ToleranceVoile_Step5 { get { return _fR_ToleranceVoile_Step5; } set { _fR_ToleranceVoile_Step5 = value; OnPropertyChanged(); } }
        public float FR_ToleranceSaut_Step1 { get { return _fR_ToleranceSaut_Step1; } set { _fR_ToleranceSaut_Step1 = value; OnPropertyChanged(); } }
        public float FR_ToleranceSaut_Step2 { get { return _fR_ToleranceSaut_Step2; } set { _fR_ToleranceSaut_Step2 = value; OnPropertyChanged(); } }
        public float FR_ToleranceSaut_Step3 { get { return _fR_ToleranceSaut_Step3; } set { _fR_ToleranceSaut_Step3 = value; OnPropertyChanged(); } }
        public float FR_ToleranceSaut_Step4 { get { return _fR_ToleranceSaut_Step4; } set { _fR_ToleranceSaut_Step4 = value; OnPropertyChanged(); } }
        public float FR_ToleranceSaut_Step5 { get { return _fR_ToleranceSaut_Step5; } set { _fR_ToleranceSaut_Step5 = value; OnPropertyChanged(); } }
        public float FR_ToleranceDeport_Step1 { get { return _fR_ToleranceDeport_Step1; } set { _fR_ToleranceDeport_Step1 = value; OnPropertyChanged(); } }
        public float FR_ToleranceDeport_Step2 { get { return _fR_ToleranceDeport_Step2; } set { _fR_ToleranceDeport_Step2 = value; OnPropertyChanged(); } }
        public float FR_ToleranceDeport_Step3 { get { return _fR_ToleranceDeport_Step3; } set { _fR_ToleranceDeport_Step3 = value; OnPropertyChanged(); } }
        public float FR_ToleranceDeport_Step4 { get { return _fR_ToleranceDeport_Step4; } set { _fR_ToleranceDeport_Step4 = value; OnPropertyChanged(); } }
        public float FR_ToleranceDeport_Step5 { get { return _fR_ToleranceDeport_Step5; } set { _fR_ToleranceDeport_Step5 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMin_G_Step1 { get { return _fR_TolTR_RMin_G_Step1; } set { _fR_TolTR_RMin_G_Step1 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMin_G_Step2 { get { return _fR_TolTR_RMin_G_Step2; } set { _fR_TolTR_RMin_G_Step2 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMin_G_Step3 { get { return _fR_TolTR_RMin_G_Step3; } set { _fR_TolTR_RMin_G_Step3 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMin_G_Step4 { get { return _fR_TolTR_RMin_G_Step4; } set { _fR_TolTR_RMin_G_Step4 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMin_G_Step5 { get { return _fR_TolTR_RMin_G_Step5; } set { _fR_TolTR_RMin_G_Step5 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMax_G_Step1 { get { return _fR_TolTR_RMax_G_Step1; } set { _fR_TolTR_RMax_G_Step1 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMax_G_Step2 { get { return _fR_TolTR_RMax_G_Step2; } set { _fR_TolTR_RMax_G_Step2 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMax_G_Step3 { get { return _fR_TolTR_RMax_G_Step3; } set { _fR_TolTR_RMax_G_Step3 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMax_G_Step4 { get { return _fR_TolTR_RMax_G_Step4; } set { _fR_TolTR_RMax_G_Step4 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMax_G_Step5 { get { return _fR_TolTR_RMax_G_Step5; } set { _fR_TolTR_RMax_G_Step5 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMin_G_Step1 { get { return _fR_TolTR_MoyMin_G_Step1; } set { _fR_TolTR_MoyMin_G_Step1 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMin_G_Step2 { get { return _fR_TolTR_MoyMin_G_Step2; } set { _fR_TolTR_MoyMin_G_Step2 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMin_G_Step3 { get { return _fR_TolTR_MoyMin_G_Step3; } set { _fR_TolTR_MoyMin_G_Step3 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMin_G_Step4 { get { return _fR_TolTR_MoyMin_G_Step4; } set { _fR_TolTR_MoyMin_G_Step4 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMin_G_Step5 { get { return _fR_TolTR_MoyMin_G_Step5; } set { _fR_TolTR_MoyMin_G_Step5 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMax_G_Step1 { get { return _fR_TolTR_MoyMax_G_Step1; } set { _fR_TolTR_MoyMax_G_Step1 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMax_G_Step2 { get { return _fR_TolTR_MoyMax_G_Step2; } set { _fR_TolTR_MoyMax_G_Step2 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMax_G_Step3 { get { return _fR_TolTR_MoyMax_G_Step3; } set { _fR_TolTR_MoyMax_G_Step3 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMax_G_Step4 { get { return _fR_TolTR_MoyMax_G_Step4; } set { _fR_TolTR_MoyMax_G_Step4 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMax_G_Step5 { get { return _fR_TolTR_MoyMax_G_Step5; } set { _fR_TolTR_MoyMax_G_Step5 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMin_D_Step1 { get { return _fR_TolTR_RMin_D_Step1; } set { _fR_TolTR_RMin_D_Step1 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMin_D_Step2 { get { return _fR_TolTR_RMin_D_Step2; } set { _fR_TolTR_RMin_D_Step2 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMin_D_Step3 { get { return _fR_TolTR_RMin_D_Step3; } set { _fR_TolTR_RMin_D_Step3 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMin_D_Step4 { get { return _fR_TolTR_RMin_D_Step4; } set { _fR_TolTR_RMin_D_Step4 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMin_D_Step5 { get { return _fR_TolTR_RMin_D_Step5; } set { _fR_TolTR_RMin_D_Step5 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMax_D_Step1 { get { return _fR_TolTR_RMax_D_Step1; } set { _fR_TolTR_RMax_D_Step1 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMax_D_Step2 { get { return _fR_TolTR_RMax_D_Step2; } set { _fR_TolTR_RMax_D_Step2 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMax_D_Step3 { get { return _fR_TolTR_RMax_D_Step3; } set { _fR_TolTR_RMax_D_Step3 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMax_D_Step4 { get { return _fR_TolTR_RMax_D_Step4; } set { _fR_TolTR_RMax_D_Step4 = value; OnPropertyChanged(); } }
        public int FR_TolTR_RMax_D_Step5 { get { return _fR_TolTR_RMax_D_Step5; } set { _fR_TolTR_RMax_D_Step5 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMin_D_Step1 { get { return _fR_TolTR_MoyMin_D_Step1; } set { _fR_TolTR_MoyMin_D_Step1 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMin_D_Step2 { get { return _fR_TolTR_MoyMin_D_Step2; } set { _fR_TolTR_MoyMin_D_Step2 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMin_D_Step3 { get { return _fR_TolTR_MoyMin_D_Step3; } set { _fR_TolTR_MoyMin_D_Step3 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMin_D_Step4 { get { return _fR_TolTR_MoyMin_D_Step4; } set { _fR_TolTR_MoyMin_D_Step4 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMin_D_Step5 { get { return _fR_TolTR_MoyMin_D_Step5; } set { _fR_TolTR_MoyMin_D_Step5 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMax_D_Step1 { get { return _fR_TolTR_MoyMax_D_Step1; } set { _fR_TolTR_MoyMax_D_Step1 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMax_D_Step2 { get { return _fR_TolTR_MoyMax_D_Step2; } set { _fR_TolTR_MoyMax_D_Step2 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMax_D_Step3 { get { return _fR_TolTR_MoyMax_D_Step3; } set { _fR_TolTR_MoyMax_D_Step3 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMax_D_Step4 { get { return _fR_TolTR_MoyMax_D_Step4; } set { _fR_TolTR_MoyMax_D_Step4 = value; OnPropertyChanged(); } }
        public int FR_TolTR_MoyMax_D_Step5 { get { return _fR_TolTR_MoyMax_D_Step5; } set { _fR_TolTR_MoyMax_D_Step5 = value; OnPropertyChanged(); } }
        public int FR_CAS_Pression_Step1 { get { return _fR_CAS_Pression_Step1; } set { _fR_CAS_Pression_Step1 = value; OnPropertyChanged(); } }
        public int FR_CAS_Pression_Step2 { get { return _fR_CAS_Pression_Step2; } set { _fR_CAS_Pression_Step2 = value; OnPropertyChanged(); } }
        public int FR_CAS_Pression_Step3 { get { return _fR_CAS_Pression_Step3; } set { _fR_CAS_Pression_Step3 = value; OnPropertyChanged(); } }
        public int FR_CAS_Pression_Step4 { get { return _fR_CAS_Pression_Step4; } set { _fR_CAS_Pression_Step4 = value; OnPropertyChanged(); } }
        public int FR_CAS_Pression_Step5 { get { return _fR_CAS_Pression_Step5; } set { _fR_CAS_Pression_Step5 = value; OnPropertyChanged(); } }
        public int FR_CAS_NB_de_tour_Step1 { get { return _fR_CAS_NB_de_tour_Step1; } set { _fR_CAS_NB_de_tour_Step1 = value; OnPropertyChanged(); } }
        public int FR_CAS_NB_de_tour_Step2 { get { return _fR_CAS_NB_de_tour_Step2; } set { _fR_CAS_NB_de_tour_Step2 = value; OnPropertyChanged(); } }
        public int FR_CAS_NB_de_tour_Step3 { get { return _fR_CAS_NB_de_tour_Step3; } set { _fR_CAS_NB_de_tour_Step3 = value; OnPropertyChanged(); } }
        public int FR_CAS_NB_de_tour_Step4 { get { return _fR_CAS_NB_de_tour_Step4; } set { _fR_CAS_NB_de_tour_Step4 = value; OnPropertyChanged(); } }
        public int FR_CAS_NB_de_tour_Step5 { get { return _fR_CAS_NB_de_tour_Step5; } set { _fR_CAS_NB_de_tour_Step5 = value; OnPropertyChanged(); } }
        public int FR_Seuil_Star_1 { get { return _fR_Seuil_Star_1; } set { _fR_Seuil_Star_1 = value; OnPropertyChanged(); } }
        public int FR_Seuil_Star_2 { get { return _fR_Seuil_Star_2; } set { _fR_Seuil_Star_2 = value; OnPropertyChanged(); } }
        public int FR_Seuil_Star_3 { get { return _fR_Seuil_Star_3; } set { _fR_Seuil_Star_3 = value; OnPropertyChanged(); } }
        public int FR_Pair_ID { get { return _fR_Pair_ID; } set { _fR_Pair_ID = value; OnPropertyChanged(); } }
        public int FR_Favorite { get { return _fR_Favorite; } set { _fR_Favorite = value; OnPropertyChanged(); } }
        public int FS_Selecteur_FR { get { return _fS_Selecteur_FR; } set { _fS_Selecteur_FR = value; OnPropertyChanged(); } }
        public string FS_String_Name { get { return _fS_String_Name; } set { _fS_String_Name = value; OnPropertyChanged(); } }
        public int FS_AV_AR { get { return _fS_AV_AR; } set { _fS_AV_AR = value; OnPropertyChanged(); } }
        public int FS_circ { get { return _fS_circ; } set { _fS_circ = value; OnPropertyChanged(); } }
        public float FS_Pos_Broche { get { return _fS_Pos_Broche; } set { _fS_Pos_Broche = value; OnPropertyChanged(); } }
        public float FS_Off7_Deport { get { return _fS_Off7_Deport; } set { _fS_Off7_Deport = value; OnPropertyChanged(); } }
        public string FS_DS_Name { get { return _fS_DS_Name; } set { _fS_DS_Name = value; OnPropertyChanged(); } }
        public int FS_DS_Nb_Rayon { get { return _fS_DS_Nb_Rayon; } set { _fS_DS_Nb_Rayon = value; OnPropertyChanged(); } }
        public string FS_DS_Date { get { return _fS_DS_Date; } set { _fS_DS_Date = value; OnPropertyChanged(); } }
        public int FS_Type_Roue { get { return _fS_Type_Roue; } set { _fS_Type_Roue = value; OnPropertyChanged(); } }
        public float FS_Off7_Volontaire { get { return _fS_Off7_Volontaire; } set { _fS_Off7_Volontaire = value; OnPropertyChanged(); } }
        public float FS_ToleranceVoile_Step1 { get { return _fS_ToleranceVoile_Step1; } set { _fS_ToleranceVoile_Step1 = value; OnPropertyChanged(); } }
        public float FS_ToleranceVoile_Step2 { get { return _fS_ToleranceVoile_Step2; } set { _fS_ToleranceVoile_Step2 = value; OnPropertyChanged(); } }
        public float FS_ToleranceVoile_Step3 { get { return _fS_ToleranceVoile_Step3; } set { _fS_ToleranceVoile_Step3 = value; OnPropertyChanged(); } }
        public float FS_ToleranceVoile_Step4 { get { return _fS_ToleranceVoile_Step4; } set { _fS_ToleranceVoile_Step4 = value; OnPropertyChanged(); } }
        public float FS_ToleranceVoile_Step5 { get { return _fS_ToleranceVoile_Step5; } set { _fS_ToleranceVoile_Step5 = value; OnPropertyChanged(); } }
        public float FS_ToleranceSaut_Step1 { get { return _fS_ToleranceSaut_Step1; } set { _fS_ToleranceSaut_Step1 = value; OnPropertyChanged(); } }
        public float FS_ToleranceSaut_Step2 { get { return _fS_ToleranceSaut_Step2; } set { _fS_ToleranceSaut_Step2 = value; OnPropertyChanged(); } }
        public float FS_ToleranceSaut_Step3 { get { return _fS_ToleranceSaut_Step3; } set { _fS_ToleranceSaut_Step3 = value; OnPropertyChanged(); } }
        public float FS_ToleranceSaut_Step4 { get { return _fS_ToleranceSaut_Step4; } set { _fS_ToleranceSaut_Step4 = value; OnPropertyChanged(); } }
        public float FS_ToleranceSaut_Step5 { get { return _fS_ToleranceSaut_Step5; } set { _fS_ToleranceSaut_Step5 = value; OnPropertyChanged(); } }
        public float FS_ToleranceDeport_Step1 { get { return _fS_ToleranceDeport_Step1; } set { _fS_ToleranceDeport_Step1 = value; OnPropertyChanged(); } }
        public float FS_ToleranceDeport_Step2 { get { return _fS_ToleranceDeport_Step2; } set { _fS_ToleranceDeport_Step2 = value; OnPropertyChanged(); } }
        public float FS_ToleranceDeport_Step3 { get { return _fS_ToleranceDeport_Step3; } set { _fS_ToleranceDeport_Step3 = value; OnPropertyChanged(); } }
        public float FS_ToleranceDeport_Step4 { get { return _fS_ToleranceDeport_Step4; } set { _fS_ToleranceDeport_Step4 = value; OnPropertyChanged(); } }
        public float FS_ToleranceDeport_Step5 { get { return _fS_ToleranceDeport_Step5; } set { _fS_ToleranceDeport_Step5 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMin_G_Step1 { get { return _fS_TolTR_RMin_G_Step1; } set { _fS_TolTR_RMin_G_Step1 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMin_G_Step2 { get { return _fS_TolTR_RMin_G_Step2; } set { _fS_TolTR_RMin_G_Step2 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMin_G_Step3 { get { return _fS_TolTR_RMin_G_Step3; } set { _fS_TolTR_RMin_G_Step3 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMin_G_Step4 { get { return _fS_TolTR_RMin_G_Step4; } set { _fS_TolTR_RMin_G_Step4 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMin_G_Step5 { get { return _fS_TolTR_RMin_G_Step5; } set { _fS_TolTR_RMin_G_Step5 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMax_G_Step1 { get { return _fS_TolTR_RMax_G_Step1; } set { _fS_TolTR_RMax_G_Step1 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMax_G_Step2 { get { return _fS_TolTR_RMax_G_Step2; } set { _fS_TolTR_RMax_G_Step2 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMax_G_Step3 { get { return _fS_TolTR_RMax_G_Step3; } set { _fS_TolTR_RMax_G_Step3 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMax_G_Step4 { get { return _fS_TolTR_RMax_G_Step4; } set { _fS_TolTR_RMax_G_Step4 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMax_G_Step5 { get { return _fS_TolTR_RMax_G_Step5; } set { _fS_TolTR_RMax_G_Step5 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMin_G_Step1 { get { return _fS_TolTR_MoyMin_G_Step1; } set { _fS_TolTR_MoyMin_G_Step1 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMin_G_Step2 { get { return _fS_TolTR_MoyMin_G_Step2; } set { _fS_TolTR_MoyMin_G_Step2 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMin_G_Step3 { get { return _fS_TolTR_MoyMin_G_Step3; } set { _fS_TolTR_MoyMin_G_Step3 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMin_G_Step4 { get { return _fS_TolTR_MoyMin_G_Step4; } set { _fS_TolTR_MoyMin_G_Step4 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMin_G_Step5 { get { return _fS_TolTR_MoyMin_G_Step5; } set { _fS_TolTR_MoyMin_G_Step5 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMax_G_Step1 { get { return _fS_TolTR_MoyMax_G_Step1; } set { _fS_TolTR_MoyMax_G_Step1 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMax_G_Step2 { get { return _fS_TolTR_MoyMax_G_Step2; } set { _fS_TolTR_MoyMax_G_Step2 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMax_G_Step3 { get { return _fS_TolTR_MoyMax_G_Step3; } set { _fS_TolTR_MoyMax_G_Step3 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMax_G_Step4 { get { return _fS_TolTR_MoyMax_G_Step4; } set { _fS_TolTR_MoyMax_G_Step4 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMax_G_Step5 { get { return _fS_TolTR_MoyMax_G_Step5; } set { _fS_TolTR_MoyMax_G_Step5 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMin_D_Step1 { get { return _fS_TolTR_RMin_D_Step1; } set { _fS_TolTR_RMin_D_Step1 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMin_D_Step2 { get { return _fS_TolTR_RMin_D_Step2; } set { _fS_TolTR_RMin_D_Step2 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMin_D_Step3 { get { return _fS_TolTR_RMin_D_Step3; } set { _fS_TolTR_RMin_D_Step3 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMin_D_Step4 { get { return _fS_TolTR_RMin_D_Step4; } set { _fS_TolTR_RMin_D_Step4 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMin_D_Step5 { get { return _fS_TolTR_RMin_D_Step5; } set { _fS_TolTR_RMin_D_Step5 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMax_D_Step1 { get { return _fS_TolTR_RMax_D_Step1; } set { _fS_TolTR_RMax_D_Step1 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMax_D_Step2 { get { return _fS_TolTR_RMax_D_Step2; } set { _fS_TolTR_RMax_D_Step2 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMax_D_Step3 { get { return _fS_TolTR_RMax_D_Step3; } set { _fS_TolTR_RMax_D_Step3 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMax_D_Step4 { get { return _fS_TolTR_RMax_D_Step4; } set { _fS_TolTR_RMax_D_Step4 = value; OnPropertyChanged(); } }
        public int FS_TolTR_RMax_D_Step5 { get { return _fS_TolTR_RMax_D_Step5; } set { _fS_TolTR_RMax_D_Step5 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMin_D_Step1 { get { return _fS_TolTR_MoyMin_D_Step1; } set { _fS_TolTR_MoyMin_D_Step1 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMin_D_Step2 { get { return _fS_TolTR_MoyMin_D_Step2; } set { _fS_TolTR_MoyMin_D_Step2 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMin_D_Step3 { get { return _fS_TolTR_MoyMin_D_Step3; } set { _fS_TolTR_MoyMin_D_Step3 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMin_D_Step4 { get { return _fS_TolTR_MoyMin_D_Step4; } set { _fS_TolTR_MoyMin_D_Step4 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMin_D_Step5 { get { return _fS_TolTR_MoyMin_D_Step5; } set { _fS_TolTR_MoyMin_D_Step5 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMax_D_Step1 { get { return _fS_TolTR_MoyMax_D_Step1; } set { _fS_TolTR_MoyMax_D_Step1 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMax_D_Step2 { get { return _fS_TolTR_MoyMax_D_Step2; } set { _fS_TolTR_MoyMax_D_Step2 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMax_D_Step3 { get { return _fS_TolTR_MoyMax_D_Step3; } set { _fS_TolTR_MoyMax_D_Step3 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMax_D_Step4 { get { return _fS_TolTR_MoyMax_D_Step4; } set { _fS_TolTR_MoyMax_D_Step4 = value; OnPropertyChanged(); } }
        public int FS_TolTR_MoyMax_D_Step5 { get { return _fS_TolTR_MoyMax_D_Step5; } set { _fS_TolTR_MoyMax_D_Step5 = value; OnPropertyChanged(); } }
        public int FS_CAS_Pression_Step1 { get { return _fS_CAS_Pression_Step1; } set { _fS_CAS_Pression_Step1 = value; OnPropertyChanged(); } }
        public int FS_CAS_Pression_Step2 { get { return _fS_CAS_Pression_Step2; } set { _fS_CAS_Pression_Step2 = value; OnPropertyChanged(); } }
        public int FS_CAS_Pression_Step3 { get { return _fS_CAS_Pression_Step3; } set { _fS_CAS_Pression_Step3 = value; OnPropertyChanged(); } }
        public int FS_CAS_Pression_Step4 { get { return _fS_CAS_Pression_Step4; } set { _fS_CAS_Pression_Step4 = value; OnPropertyChanged(); } }
        public int FS_CAS_Pression_Step5 { get { return _fS_CAS_Pression_Step5; } set { _fS_CAS_Pression_Step5 = value; OnPropertyChanged(); } }
        public float FS_CAS_NB_de_tour_Step1 { get { return _fS_CAS_NB_de_tour_Step1; } set { _fS_CAS_NB_de_tour_Step1 = value; OnPropertyChanged(); } }
        public float FS_CAS_NB_de_tour_Step2 { get { return _fS_CAS_NB_de_tour_Step2; } set { _fS_CAS_NB_de_tour_Step2 = value; OnPropertyChanged(); } }
        public float FS_CAS_NB_de_tour_Step3 { get { return _fS_CAS_NB_de_tour_Step3; } set { _fS_CAS_NB_de_tour_Step3 = value; OnPropertyChanged(); } }
        public float FS_CAS_NB_de_tour_Step4 { get { return _fS_CAS_NB_de_tour_Step4; } set { _fS_CAS_NB_de_tour_Step4 = value; OnPropertyChanged(); } }
        public float FS_CAS_NB_de_tour_Step5 { get { return _fS_CAS_NB_de_tour_Step5; } set { _fS_CAS_NB_de_tour_Step5 = value; OnPropertyChanged(); } }
        public int FS_Seuil_Star_1 { get { return _fS_Seuil_Star_1; } set { _fS_Seuil_Star_1 = value; OnPropertyChanged(); } }
        public int FS_Seuil_Star_2 { get { return _fS_Seuil_Star_2; } set { _fS_Seuil_Star_2 = value; OnPropertyChanged(); } }
        public int FS_Seuil_Star_3 { get { return _fS_Seuil_Star_3; } set { _fS_Seuil_Star_3 = value; OnPropertyChanged(); } }
        public int FS_Pair_ID { get { return _fS_Pair_ID; } set { _fS_Pair_ID = value; OnPropertyChanged(); } }
        public int FS_Favorite { get { return _fS_Favorite; } set { _fS_Favorite = value; OnPropertyChanged(); } }
        public float Ecartement_Broche { get { return _ecartement_Broche; } set { _ecartement_Broche = value; OnPropertyChanged(); } }
        public int Teach_Perim_Circ { get { return _teach_Perim_Circ; } set { _teach_Perim_Circ = value; OnPropertyChanged(); } }
        public float OffsetRecordValue1 { get { return _offsetRecordValue1; } set { _offsetRecordValue1 = value; OnPropertyChanged(); } }
        public float OffsetRecordValue2 { get { return _offsetRecordValue2; } set { _offsetRecordValue2 = value; OnPropertyChanged(); } }
        public float OffsetActuel { get { return _offsetActuel; } set { _offsetActuel = value; OnPropertyChanged(); } }
        public float OffsetCalcul { get { return _offsetCalcul; } set { _offsetCalcul = value; OnPropertyChanged(); } }
        public float OffsetCorrection { get { return _offsetCorrection; } set { _offsetCorrection = value; OnPropertyChanged(); } }
        public int Offset_State { get { return _Offset_State; } set { System.Console.WriteLine("Fin trop d'variables : {0:HH:mm:ss.fff}", System.DateTime.Now); _Offset_State = value; OnPropertyChanged(); } }

        public bool ShowShutPopUp
        {
            get { return _showShutPopUp; }
            set
            {
                _showShutPopUp = value;
                OnPropertyChanged();
            }
        }

        public bool ShowStabilizationPopUp
        {
            get { return _showStabilizationPopUp; }
            set
            {
                _showStabilizationPopUp = value;
                OnPropertyChanged();
            }
        }

        public bool ShowSavePopUp
        {
            get { return _showSavePopUp; }
            set
            {
                _showSavePopUp = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ICommand AvArChangeCommand { get; set; }
        private void OnAvArChangeCommand()
        {
            if (EditMode == 1)
                FR_AV_AR = (FR_AV_AR + 1) % 3;
            _parent.SetTwincatValue("FR_AV_AR", FR_AV_AR);
        }

        public ICommand TypeRoueChangeCommand { get; set; }
        private void OnTypeRoueChangeCommand()
        {
            if (EditMode == 1)
                FR_Type_Roue = (FR_Type_Roue + 1) % 6;
            _parent.SetTwincatValue("FR_Type_Roue", FR_Type_Roue);
        }

        public ICommand TypeCASChangeCommand { get; set; }
        private void OnTypeCASChangedCommand()
        {
            if (EditMode == 1)
                FR_Type_CAS = (FR_Type_CAS + 1) % 2;
            _parent.SetTwincatValue("FR_CAS_Entree", FR_Type_CAS);
        }

        public ICommand FavChangeCommand { get; set; }
        private void OnFavChangeCommand()
        {
            if (EditMode == 1)
                FR_Favorite = (FR_Favorite + 1) % 2;
            _parent.SetTwincatValue("FR_Favorite", FR_Favorite);
        }

        public ICommand SpokeScreenCommand { get; set; }
        private void OnSpokeScreenCommand()
        {
            if (EditMode == 1)
                _parent.OpenSpokeScreen();
        
        }

        public ICommand UpdateValueCommand { get; set; }
        private void OnUpdateValueCommand(string parameter)
        {
            switch (parameter)
            {
                case "FR_String_Name": _parent.SetTwincatValue(parameter, FR_String_Name, 21); break;
                case "FR_Pos_Broche": _parent.SetTwincatValue(parameter, FR_Pos_Broche); break;
                case "FR_Off7_Deport": _parent.SetTwincatValue(parameter, FR_Off7_Deport); break;
                case "FR_circ": _parent.SetTwincatValue(parameter, FR_circ); break;
                case "FR_DS_Nb_Rayon": _parent.SetTwincatValue(parameter, FR_DS_Nb_Rayon); break;
                case "FR_Seuil_Star_1": _parent.SetTwincatValue(parameter, FR_Seuil_Star_1); break;
                case "FR_Seuil_Star_2": _parent.SetTwincatValue(parameter, FR_Seuil_Star_2); break;
                case "FR_Seuil_Star_3": _parent.SetTwincatValue(parameter, FR_Seuil_Star_3); break;
                case "FR_ToleranceVoile_Step1": _parent.SetTwincatValue(parameter, FR_ToleranceVoile_Step1); break;
                case "FR_ToleranceSaut_Step1": _parent.SetTwincatValue(parameter, FR_ToleranceSaut_Step1); break;
                case "FR_ToleranceDeport_Step1": _parent.SetTwincatValue(parameter, FR_ToleranceDeport_Step1); break;
                case "FR_TolTR_MoyMin_G_Step1": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMin_G_Step1); break;
                case "FR_TolTR_MoyMax_D_Step1": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMax_D_Step1); break;
                case "FR_TolTR_RMax_G_Step1": _parent.SetTwincatValue(parameter, FR_TolTR_RMax_G_Step1); break;
                case "FR_TolTR_RMax_D_Step1": _parent.SetTwincatValue(parameter, FR_TolTR_RMax_D_Step1); break;
                case "FR_TolTR_MoyMax_G_Step1": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMax_G_Step1); break;
                case "FR_TolTR_MoyMin_D_Step1": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMin_D_Step1); break;
                case "FR_TolTR_RMin_G_Step1": _parent.SetTwincatValue(parameter, FR_TolTR_RMin_G_Step1); break;
                case "FR_TolTR_RMin_D_Step1": _parent.SetTwincatValue(parameter, FR_TolTR_RMin_D_Step1); break;
                case "FR_CAS_NB_de_tour_Step1": _parent.SetTwincatValue(parameter, FR_CAS_NB_de_tour_Step1); break;
                case "FR_CAS_Pression_Step1": _parent.SetTwincatValue(parameter, FR_CAS_Pression_Step1); break;
                case "FR_ToleranceVoile_Step2": _parent.SetTwincatValue(parameter, FR_ToleranceVoile_Step2); break;
                case "FR_ToleranceSaut_Step2": _parent.SetTwincatValue(parameter, FR_ToleranceSaut_Step2); break;
                case "FR_ToleranceDeport_Step2": _parent.SetTwincatValue(parameter, FR_ToleranceDeport_Step2); break;
                case "FR_TolTR_MoyMin_G_Step2": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMin_G_Step2); break;
                case "FR_TolTR_MoyMax_D_Step2": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMax_D_Step2); break;
                case "FR_TolTR_RMax_G_Step2": _parent.SetTwincatValue(parameter, FR_TolTR_RMax_G_Step2); break;
                case "FR_TolTR_RMax_D_Step2": _parent.SetTwincatValue(parameter, FR_TolTR_RMax_D_Step2); break;
                case "FR_TolTR_MoyMax_G_Step2": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMax_G_Step2); break;
                case "FR_TolTR_MoyMin_D_Step2": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMin_D_Step2); break;
                case "FR_TolTR_RMin_G_Step2": _parent.SetTwincatValue(parameter, FR_TolTR_RMin_G_Step2); break;
                case "FR_TolTR_RMin_D_Step2": _parent.SetTwincatValue(parameter, FR_TolTR_RMin_D_Step2); break;
                case "FR_CAS_NB_de_tour_Step2": _parent.SetTwincatValue(parameter, FR_CAS_NB_de_tour_Step2); break;
                case "FR_CAS_Pression_Step2": _parent.SetTwincatValue(parameter, FR_CAS_Pression_Step2); break;
                case "FR_ToleranceVoile_Step3": _parent.SetTwincatValue(parameter, FR_ToleranceVoile_Step3); break;
                case "FR_ToleranceSaut_Step3": _parent.SetTwincatValue(parameter, FR_ToleranceSaut_Step3); break;
                case "FR_ToleranceDeport_Step3": _parent.SetTwincatValue(parameter, FR_ToleranceDeport_Step3); break;
                case "FR_TolTR_MoyMin_G_Step3": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMin_G_Step3); break;
                case "FR_TolTR_MoyMax_D_Step3": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMax_D_Step3); break;
                case "FR_TolTR_RMax_G_Step3": _parent.SetTwincatValue(parameter, FR_TolTR_RMax_G_Step3); break;
                case "FR_TolTR_RMax_D_Step3": _parent.SetTwincatValue(parameter, FR_TolTR_RMax_D_Step3); break;
                case "FR_TolTR_MoyMax_G_Step3": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMax_G_Step3); break;
                case "FR_TolTR_MoyMin_D_Step3": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMin_D_Step3); break;
                case "FR_TolTR_RMin_G_Step3": _parent.SetTwincatValue(parameter, FR_TolTR_RMin_G_Step3); break;
                case "FR_TolTR_RMin_D_Step3": _parent.SetTwincatValue(parameter, FR_TolTR_RMin_D_Step3); break;
                case "FR_CAS_NB_de_tour_Step3": _parent.SetTwincatValue(parameter, FR_CAS_NB_de_tour_Step3); break;
                case "FR_CAS_Pression_Step3": _parent.SetTwincatValue(parameter, FR_CAS_Pression_Step3); break;
                case "FR_ToleranceVoile_Step4": _parent.SetTwincatValue(parameter, FR_ToleranceVoile_Step4); break;
                case "FR_ToleranceSaut_Step4": _parent.SetTwincatValue(parameter, FR_ToleranceSaut_Step4); break;
                case "FR_ToleranceDeport_Step4": _parent.SetTwincatValue(parameter, FR_ToleranceDeport_Step4); break;
                case "FR_TolTR_MoyMin_G_Step4": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMin_G_Step4); break;
                case "FR_TolTR_MoyMax_D_Step4": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMax_D_Step4); break;
                case "FR_TolTR_RMax_G_Step4": _parent.SetTwincatValue(parameter, FR_TolTR_RMax_G_Step4); break;
                case "FR_TolTR_RMax_D_Step4": _parent.SetTwincatValue(parameter, FR_TolTR_RMax_D_Step4); break;
                case "FR_TolTR_MoyMax_G_Step4": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMax_G_Step4); break;
                case "FR_TolTR_MoyMin_D_Step4": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMin_D_Step4); break;
                case "FR_TolTR_RMin_G_Step4": _parent.SetTwincatValue(parameter, FR_TolTR_RMin_G_Step4); break;
                case "FR_TolTR_RMin_D_Step4": _parent.SetTwincatValue(parameter, FR_TolTR_RMin_D_Step4); break;
                case "FR_CAS_NB_de_tour_Step4": _parent.SetTwincatValue(parameter, FR_CAS_NB_de_tour_Step4); break;
                case "FR_CAS_Pression_Step4": _parent.SetTwincatValue(parameter, FR_CAS_Pression_Step4); break;
                case "FR_ToleranceVoile_Step5": _parent.SetTwincatValue(parameter, FR_ToleranceVoile_Step5); break;
                case "FR_ToleranceSaut_Step5": _parent.SetTwincatValue(parameter, FR_ToleranceSaut_Step5); break;
                case "FR_ToleranceDeport_Step5": _parent.SetTwincatValue(parameter, FR_ToleranceDeport_Step5); break;
                case "FR_TolTR_MoyMin_G_Step5": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMin_G_Step5); break;
                case "FR_TolTR_MoyMax_D_Step5": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMax_D_Step5); break;
                case "FR_TolTR_RMax_G_Step5": _parent.SetTwincatValue(parameter, FR_TolTR_RMax_G_Step5); break;
                case "FR_TolTR_RMax_D_Step5": _parent.SetTwincatValue(parameter, FR_TolTR_RMax_D_Step5); break;
                case "FR_TolTR_MoyMax_G_Step5": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMax_G_Step5); break;
                case "FR_TolTR_MoyMin_D_Step5": _parent.SetTwincatValue(parameter, FR_TolTR_MoyMin_D_Step5); break;
                case "FR_TolTR_RMin_G_Step5": _parent.SetTwincatValue(parameter, FR_TolTR_RMin_G_Step5); break;
                case "FR_TolTR_RMin_D_Step5": _parent.SetTwincatValue(parameter, FR_TolTR_RMin_D_Step5); break;
                case "FR_CAS_NB_de_tour_Step5": _parent.SetTwincatValue(parameter, FR_CAS_NB_de_tour_Step5); break;
                case "FR_CAS_Pression_Step5": _parent.SetTwincatValue(parameter, FR_CAS_Pression_Step5); break;
                case "FR_Pair_ID": _parent.SetTwincatValue(parameter, FR_Pair_ID); break;
            }
        }

        #region LoadButton
        public ICommand LoadWheelCommand { get; set; }
        private void OnLoadWheelCommand()
        {
            _loadMode = true;

            _parent.SetTwincatValue<int>("FR_dde_Load", 1);
           
          
          
            System.Threading.Thread.Sleep(1000);

            refreshFR = true;
            _loadMode = false;
        }
        #endregion

        #region SaveButton
        public ICommand SaveWheelCommand { get; set; }
        private void OnSaveWheelCommand()
        {
            _loadMode = true;
            _parent.DirectoryEditMode = 0;

            _parent.SetTwincatValue<int>("FR_dde_Save", 1);
            System.Threading.Thread.Sleep(2000);

            refreshDirectory = true;
            refreshFS = true;
            refreshFR = true;
            _loadMode = false;
        }
        #endregion

        public ICommand DirectorySelectionChangeCommand { get; set; }
        private void OnDirectorySelectionChangeCommand(int? index)
        {
            if (index.HasValue && index.Value > -1)
            {
                _parent.SetActiveWheelId((short)index.Value);
                refreshFS = true;
            }
        }
        
        public ICommand ShowHubCommand { get; set; }
        private void OnShowHubCommand()
        {
            ShowHubWindow = true;
        }

        public ICommand HubDecreaseCommand { get; set; }
        private void OnHubDecreaseCommand()
        {
            _parent.SetTwincatValue("BP_Serrage", (short)1);
            HubDecrease = true;
            HubIncrease = false;
        }

        public ICommand HubIncreaseCommand { get; set; }
        private void OnHubIncreaseCommand()
        {
            _parent.SetTwincatValue("BP_Desserrage", (short)1);
            HubDecrease = false;
            HubIncrease = true;
        }

        public ICommand HubOkCommand { get; set; }
        private void OnHubOkCommand()
        {
            _parent.SetTwincatValue("Teach_Clamp_Valid", (short)1);
           
            ShowHubWindow = false;
            refreshFR = true;
            _parent.SetTwincatValue("BP_Serrage", (short)0);
            _parent.SetTwincatValue("BP_Desserrage", (short)0);
            HubDecrease = false;
            HubIncrease = false;

        }

        public ICommand HubCancelCommand { get; set; }
        private void OnHubCancelCommand()
        {
            _parent.SetTwincatValue("Teach_Clamp_Cancel", (short)1);
            ShowHubWindow = false;
            refreshFR = true;
            _parent.SetTwincatValue("BP_Serrage", (short)0);
            _parent.SetTwincatValue("BP_Desserrage", (short)0);
            HubDecrease = false;
            HubIncrease = false;
        }

        public ICommand ShowPerimeterCommand { get; set; }
        private void OnShowPerimeterCommand()
        {
            ShowPerimeterWindow = true;
        }

        public ICommand ShowSymmetryCommand { get; set; }
        private void OnShowSymmetryCommand()
        {
            if (EditMode == 1)
                ShowSymmetryWindow = true;
        }

        public ICommand PerimeterOkCommand { get; set; }
        private void OnPerimeterOkCommand()
        {
            _parent.SetTwincatValue("Teach_Perim_Valid", (short)1);
            ShowPerimeterWindow = false;
            refreshFR = true;
        }

        public ICommand PerimeterCancelCommand { get; set; }
        private void OnPerimeterCancelCommand()
        {
            _parent.SetTwincatValue("Teach_Perim_Cancel", (short)1);
            ShowPerimeterWindow = false;
            refreshFR = true;
        }

        public ICommand SymmetryOkCommand { get; set; }
        private void OnSymmetryOkCommand()
        {
            _parent.SetTwincatValue("Offset_Valid", (short)1);
            ShowSymmetryWindow = false;
            refreshFR = true;
        }

        public ICommand SymmetryCancelCommand { get; set; }
        private void OnSymmetryCancelCommand()
        {
            _parent.SetTwincatValue("Offset_Cancel", (short)1);
            ShowSymmetryWindow = false;
            refreshFR = true;
        }

        public ICommand PrintShutPopUpCommand { get; set; }
        private void OnPrintShutPopUpCommand()
        {
            ShowShutPopUp = true;
        }

        public ICommand ShutPopUpOkCommand { get; set; }
        private void OnShutPopUpOkCommand()
        {
            _parent.Shutdown();
        }

        public ICommand ShutPopUpCancelCommand { get; set; }
        private void OnShutPopUpCancelCommand()
        {
            ShowShutPopUp = false;
        }

        public ICommand ShowStabilizationCommand { get; set; }
        private void OnShowStabilizationCommand()
        {
            //if (EditMode == 1)
                ShowStabilizationPopUp = true;
        }

        public ICommand StabilizationCloseCommand { get; set; }
        private void OnStabilizationCloseCommand()
        {
            ShowStabilizationPopUp = false;
        }

        public ICommand ShowSavePopUpCommand { get; set; }
        private void OnShowSavePopUpCommand()
        {
            ShowSavePopUp = true;
        }

        public ICommand SavePopUpOkCommand { get; set; }
        private void OnSavePopUpOkCommand()
        {
            OnSaveWheelCommand();
            ShowSavePopUp = false;
        }

        public ICommand SavePopUpCancelCommand { get; set; }
        private void OnSavePopUpCancelCommand()
        {
            ShowSavePopUp = false;
        }

       

        public ObservableCollection<Favourite> ListFavourites { get; set; }

        public DirectoryViewModel()
        {
            //System.Console.WriteLine("Début DirectoryViewModel : {0:HH:mm:ss.fff}", System.DateTime.Now);
            ListFavourites = new ObservableCollection<Favourite>();

            AvArChangeCommand = new DelegateCommand(OnAvArChangeCommand);
            TypeRoueChangeCommand = new DelegateCommand(OnTypeRoueChangeCommand);
            TypeCASChangeCommand = new DelegateCommand(OnTypeCASChangedCommand);
            FavChangeCommand = new DelegateCommand(OnFavChangeCommand);
            LoadWheelCommand = new DelegateCommand(OnLoadWheelCommand);
            SaveWheelCommand = new DelegateCommand(OnSaveWheelCommand);
            DirectorySelectionChangeCommand = new DelegateCommand<int?>(OnDirectorySelectionChangeCommand);
            UpdateValueCommand = new DelegateCommand<string>(OnUpdateValueCommand);
            SpokeScreenCommand = new DelegateCommand(OnSpokeScreenCommand);

            ShowHubCommand = new DelegateCommand(OnShowHubCommand);
            HubDecreaseCommand = new DelegateCommand(OnHubDecreaseCommand);
            HubIncreaseCommand = new DelegateCommand(OnHubIncreaseCommand);
            HubOkCommand = new DelegateCommand(OnHubOkCommand);
            HubCancelCommand = new DelegateCommand(OnHubCancelCommand);

            ShowPerimeterCommand = new DelegateCommand(OnShowPerimeterCommand);
            PerimeterOkCommand = new DelegateCommand(OnPerimeterOkCommand);
            PerimeterCancelCommand = new DelegateCommand(OnPerimeterCancelCommand);

            ShowSymmetryCommand = new DelegateCommand(OnShowSymmetryCommand);
            SymmetryOkCommand = new DelegateCommand(OnSymmetryOkCommand);
            SymmetryCancelCommand = new DelegateCommand(OnSymmetryCancelCommand);

            PrintShutPopUpCommand = new DelegateCommand(OnPrintShutPopUpCommand);
            ShutPopUpOkCommand = new DelegateCommand(OnShutPopUpOkCommand);
            ShutPopUpCancelCommand = new DelegateCommand(OnShutPopUpCancelCommand);

            ShowStabilizationCommand = new DelegateCommand(OnShowStabilizationCommand);
            StabilizationCloseCommand = new DelegateCommand(OnStabilizationCloseCommand);

            ShowSavePopUpCommand = new DelegateCommand(OnShowSavePopUpCommand);
            SavePopUpOkCommand = new DelegateCommand(OnSavePopUpOkCommand);
            SavePopUpCancelCommand = new DelegateCommand(OnSavePopUpCancelCommand);

            //System.Console.WriteLine("  Fin DirectoryViewModel : {0:HH:mm:ss.fff}", System.DateTime.Now);
            //System.Console.WriteLine("");
        }

        private bool firstRefresh = true;
        private bool refreshDirectory = false;
        public bool refreshFR = false;
        private bool refreshFS = false;

        




        public void Refresh(DUT_AP ap, DUT_PA pa)
        {
            //System.Console.WriteLine("Début Refresh : {0:HH:mm:ss.fff}", System.DateTime.Now);
            #region first assignment
            if (firstRefresh)
            {
                Refresh_Directory();

                DirectorySelectedIndex = pa.FS_Selecteur_FR - 1;
                OnDirectorySelectionChangeCommand(pa.FS_Selecteur_FR - 1);
                FocusDataGrid = true;

                Refresh_FR_Data(pa);
                Refresh_FS_Data(pa);

                firstRefresh = false;

            }
            #endregion
            #region regular updates
            else
            {
                if (refreshDirectory)
                {
                    Refresh_Directory();
                    refreshDirectory = false;
                }

                if (refreshFR)
                {
                    Refresh_FR_Data(pa);
                    refreshFR = false;
                }

                if (refreshFS)
                {
                    Refresh_FS_Data(pa);
                    refreshFS = false;
                }
            }
            #endregion

            if (ShowHubWindow)
                Ecartement_Broche = pa.Ecartement_Broche;

            if (ShowPerimeterWindow)
                Teach_Perim_Circ = pa.Teach_Perim_Circ;

            if (ShowSymmetryWindow)
            {
                OffsetRecordValue1 = pa.OffsetRecordValue1;
                OffsetRecordValue2 = pa.OffsetRecordValue2;
                OffsetActuel = pa.OffsetActuel;
                OffsetCalcul = pa.OffsetCalcul;
                OffsetCorrection = pa.OffsetCorrection;
                Offset_State = pa.Offset_State;
            }
            //System.Console.WriteLine("  Fin Refresh : {0:HH:mm:ss.fff}", System.DateTime.Now);
            //System.Console.WriteLine("");
        }

        private void Refresh_Directory()
        {
            //System.Console.WriteLine("Début Refresh_Directory : {0:HH:mm:ss.fff}", System.DateTime.Now);
            var ihm_directory = _parent.GetDirectoryData();
            if (ihm_directory.HasValue)
            {
                if (ListFavourites.Count == 0)
                {
                    for (int i = 0; i < ihm_directory.Value.ListNames.Length; i++)
                    {
                        Favourite fav = new Favourite();
                        fav.Fav = ihm_directory.Value.ListFavs[i];
                        fav.Name = ihm_directory.Value.ListNames[i];
                        fav.Index = ihm_directory.Value.ListNumRecettes[i];
                        fav.Roue = ihm_directory.Value.Liste_Roue_AV_ARs[i];
                        ListFavourites.Add(fav);
                    }
                }
                else
                {
                    for (int i = 0; i < ihm_directory.Value.ListNames.Length; i++)
                    {
                        ListFavourites[i].Fav = ihm_directory.Value.ListFavs[i];
                        ListFavourites[i].Name = ihm_directory.Value.ListNames[i];
                        ListFavourites[i].Index = ihm_directory.Value.ListNumRecettes[i];
                        ListFavourites[i].Roue = ihm_directory.Value.Liste_Roue_AV_ARs[i];
                    }
                }
            }
            //System.Console.WriteLine("  Fin Refresh_Directory : {0:HH:mm:ss.fff}", System.DateTime.Now);
            //System.Console.WriteLine("");
        }

        private void Refresh_FS_Data(DUT_PA pa)
        {
            //System.Console.WriteLine("Début Refresh_FS_Data : {0:HH:mm:ss.fff}", System.DateTime.Now);
            if (_loadMode)
                return;

            FS_Selecteur_FR = pa.FS_Selecteur_FR;
            FS_String_Name = pa.FS_String_Name;
            FS_AV_AR = pa.FS_AV_AR;
            FS_circ = pa.FS_circ;
            FS_Pos_Broche = pa.FS_Pos_Broche;
            FS_Off7_Deport = pa.FS_Off7_Deport;
            FS_DS_Name = pa.FS_DS_Name;
            FS_DS_Nb_Rayon = pa.FS_DS_Nb_Rayon;
            FS_DS_Date = pa.FS_DS_Date;
            FS_Type_Roue = pa.FS_Type_Roue;
            FS_Off7_Volontaire = pa.FS_Off7_Volontaire;
            FS_ToleranceVoile_Step1 = pa.FS_ToleranceVoile_Step1;
            FS_ToleranceVoile_Step2 = pa.FS_ToleranceVoile_Step2;
            FS_ToleranceVoile_Step3 = pa.FS_ToleranceVoile_Step3;
            FS_ToleranceVoile_Step4 = pa.FS_ToleranceVoile_Step4;
            FS_ToleranceVoile_Step5 = pa.FS_ToleranceVoile_Step5;
            FS_ToleranceSaut_Step1 = pa.FS_ToleranceSaut_Step1;
            FS_ToleranceSaut_Step2 = pa.FS_ToleranceSaut_Step2;
            FS_ToleranceSaut_Step3 = pa.FS_ToleranceSaut_Step3;
            FS_ToleranceSaut_Step4 = pa.FS_ToleranceSaut_Step4;
            FS_ToleranceSaut_Step5 = pa.FS_ToleranceSaut_Step5;
            FS_ToleranceDeport_Step1 = pa.FS_ToleranceDeport_Step1;
            FS_ToleranceDeport_Step2 = pa.FS_ToleranceDeport_Step2;
            FS_ToleranceDeport_Step3 = pa.FS_ToleranceDeport_Step3;
            FS_ToleranceDeport_Step4 = pa.FS_ToleranceDeport_Step4;
            FS_ToleranceDeport_Step5 = pa.FS_ToleranceDeport_Step5;
            FS_TolTR_RMin_G_Step1 = pa.FS_TolTR_RMin_G_Step1;
            FS_TolTR_RMin_G_Step2 = pa.FS_TolTR_RMin_G_Step2;
            FS_TolTR_RMin_G_Step3 = pa.FS_TolTR_RMin_G_Step3;
            FS_TolTR_RMin_G_Step4 = pa.FS_TolTR_RMin_G_Step4;
            FS_TolTR_RMin_G_Step5 = pa.FS_TolTR_RMin_G_Step5;
            FS_TolTR_RMax_G_Step1 = pa.FS_TolTR_RMax_G_Step1;
            FS_TolTR_RMax_G_Step2 = pa.FS_TolTR_RMax_G_Step2;
            FS_TolTR_RMax_G_Step3 = pa.FS_TolTR_RMax_G_Step3;
            FS_TolTR_RMax_G_Step4 = pa.FS_TolTR_RMax_G_Step4;
            FS_TolTR_RMax_G_Step5 = pa.FS_TolTR_RMax_G_Step5;
            FS_TolTR_MoyMin_G_Step1 = pa.FS_TolTR_MoyMin_G_Step1;
            FS_TolTR_MoyMin_G_Step2 = pa.FS_TolTR_MoyMin_G_Step2;
            FS_TolTR_MoyMin_G_Step3 = pa.FS_TolTR_MoyMin_G_Step3;
            FS_TolTR_MoyMin_G_Step4 = pa.FS_TolTR_MoyMin_G_Step4;
            FS_TolTR_MoyMin_G_Step5 = pa.FS_TolTR_MoyMin_G_Step5;
            FS_TolTR_MoyMax_G_Step1 = pa.FS_TolTR_MoyMax_G_Step1;
            FS_TolTR_MoyMax_G_Step2 = pa.FS_TolTR_MoyMax_G_Step2;
            FS_TolTR_MoyMax_G_Step3 = pa.FS_TolTR_MoyMax_G_Step3;
            FS_TolTR_MoyMax_G_Step4 = pa.FS_TolTR_MoyMax_G_Step4;
            FS_TolTR_MoyMax_G_Step5 = pa.FS_TolTR_MoyMax_G_Step5;
            FS_TolTR_RMin_D_Step1 = pa.FS_TolTR_RMin_D_Step1;
            FS_TolTR_RMin_D_Step2 = pa.FS_TolTR_RMin_D_Step2;
            FS_TolTR_RMin_D_Step3 = pa.FS_TolTR_RMin_D_Step3;
            FS_TolTR_RMin_D_Step4 = pa.FS_TolTR_RMin_D_Step4;
            FS_TolTR_RMin_D_Step5 = pa.FS_TolTR_RMin_D_Step5;
            FS_TolTR_RMax_D_Step1 = pa.FS_TolTR_RMax_D_Step1;
            FS_TolTR_RMax_D_Step2 = pa.FS_TolTR_RMax_D_Step2;
            FS_TolTR_RMax_D_Step3 = pa.FS_TolTR_RMax_D_Step3;
            FS_TolTR_RMax_D_Step4 = pa.FS_TolTR_RMax_D_Step4;
            FS_TolTR_RMax_D_Step5 = pa.FS_TolTR_RMax_D_Step5;
            FS_TolTR_MoyMin_D_Step1 = pa.FS_TolTR_MoyMin_D_Step1;
            FS_TolTR_MoyMin_D_Step2 = pa.FS_TolTR_MoyMin_D_Step2;
            FS_TolTR_MoyMin_D_Step3 = pa.FS_TolTR_MoyMin_D_Step3;
            FS_TolTR_MoyMin_D_Step4 = pa.FS_TolTR_MoyMin_D_Step4;
            FS_TolTR_MoyMin_D_Step5 = pa.FS_TolTR_MoyMin_D_Step5;
            FS_TolTR_MoyMax_D_Step1 = pa.FS_TolTR_MoyMax_D_Step1;
            FS_TolTR_MoyMax_D_Step2 = pa.FS_TolTR_MoyMax_D_Step2;
            FS_TolTR_MoyMax_D_Step3 = pa.FS_TolTR_MoyMax_D_Step3;
            FS_TolTR_MoyMax_D_Step4 = pa.FS_TolTR_MoyMax_D_Step4;
            FS_TolTR_MoyMax_D_Step5 = pa.FS_TolTR_MoyMax_D_Step5;
            FS_CAS_Pression_Step1 = pa.FS_CAS_Pression_Step1;
            FS_CAS_Pression_Step2 = pa.FS_CAS_Pression_Step2;
            FS_CAS_Pression_Step3 = pa.FS_CAS_Pression_Step3;
            FS_CAS_Pression_Step4 = pa.FS_CAS_Pression_Step4;
            FS_CAS_Pression_Step5 = pa.FS_CAS_Pression_Step5;
            FS_CAS_NB_de_tour_Step1 = pa.FS_CAS_NB_de_tour_Step1;
            FS_CAS_NB_de_tour_Step2 = pa.FS_CAS_NB_de_tour_Step2;
            FS_CAS_NB_de_tour_Step3 = pa.FS_CAS_NB_de_tour_Step3;
            FS_CAS_NB_de_tour_Step4 = pa.FS_CAS_NB_de_tour_Step4;
            FS_CAS_NB_de_tour_Step5 = pa.FS_CAS_NB_de_tour_Step5;
            FS_Seuil_Star_1 = pa.FS_Seuil_Star_1;
            FS_Seuil_Star_2 = pa.FS_Seuil_Star_2;
            FS_Seuil_Star_3 = pa.FS_Seuil_Star_3;
            FS_Pair_ID = pa.FS_Pair_ID;
            FS_Favorite = pa.FS_Favorite;

            //System.Console.WriteLine("  Fin Refresh_FS_Data : {0:HH:mm:ss.fff}", System.DateTime.Now);
            //System.Console.WriteLine("");
        }

        private void Refresh_FR_Data(DUT_PA pa)
        {
            //System.Console.WriteLine("Début Refresh_FR_Data : {0:HH:mm:ss.fff}", System.DateTime.Now);
            if (_loadMode)
                return;

            FR_Selecteur_FR = pa.FR_Selecteur_FR;
            FR_String_Name = pa.FR_String_Name;
            FR_AV_AR = pa.FR_AV_AR;
            FR_circ = pa.FR_circ;
            FR_Pos_Broche = pa.FR_Pos_Broche;
            FR_Off7_Deport = pa.FR_Off7_Deport;
            FR_DS_Name = pa.FR_DS_Name;
            FR_DS_Nb_Rayon = pa.FR_DS_Nb_Rayon;
            FR_DS_Date = pa.FR_DS_Date;
            FR_Type_Roue = pa.FR_Type_Roue;
            FR_Type_CAS = pa.FR_Nb_CAS_entree;
            FR_ToleranceVoile_Step1 = pa.FR_ToleranceVoile_Step1;
            FR_ToleranceVoile_Step2 = pa.FR_ToleranceVoile_Step2;
            FR_ToleranceVoile_Step3 = pa.FR_ToleranceVoile_Step3;
            FR_ToleranceVoile_Step4 = pa.FR_ToleranceVoile_Step4;
            FR_ToleranceVoile_Step5 = pa.FR_ToleranceVoile_Step5;
            FR_ToleranceSaut_Step1 = pa.FR_ToleranceSaut_Step1;
            FR_ToleranceSaut_Step2 = pa.FR_ToleranceSaut_Step2;
            FR_ToleranceSaut_Step3 = pa.FR_ToleranceSaut_Step3;
            FR_ToleranceSaut_Step4 = pa.FR_ToleranceSaut_Step4;
            FR_ToleranceSaut_Step5 = pa.FR_ToleranceSaut_Step5;
            FR_ToleranceDeport_Step1 = pa.FR_ToleranceDeport_Step1;
            FR_ToleranceDeport_Step2 = pa.FR_ToleranceDeport_Step2;
            FR_ToleranceDeport_Step3 = pa.FR_ToleranceDeport_Step3;
            FR_ToleranceDeport_Step4 = pa.FR_ToleranceDeport_Step4;
            FR_ToleranceDeport_Step5 = pa.FR_ToleranceDeport_Step5;
            FR_TolTR_RMin_G_Step1 = pa.FR_TolTR_RMin_G_Step1;
            FR_TolTR_RMin_G_Step2 = pa.FR_TolTR_RMin_G_Step2;
            FR_TolTR_RMin_G_Step3 = pa.FR_TolTR_RMin_G_Step3;
            FR_TolTR_RMin_G_Step4 = pa.FR_TolTR_RMin_G_Step4;
            FR_TolTR_RMin_G_Step5 = pa.FR_TolTR_RMin_G_Step5;
            FR_TolTR_RMax_G_Step1 = pa.FR_TolTR_RMax_G_Step1;
            FR_TolTR_RMax_G_Step2 = pa.FR_TolTR_RMax_G_Step2;
            FR_TolTR_RMax_G_Step3 = pa.FR_TolTR_RMax_G_Step3;
            FR_TolTR_RMax_G_Step4 = pa.FR_TolTR_RMax_G_Step4;
            FR_TolTR_RMax_G_Step5 = pa.FR_TolTR_RMax_G_Step5;
            FR_TolTR_MoyMin_G_Step1 = pa.FR_TolTR_MoyMin_G_Step1;
            FR_TolTR_MoyMin_G_Step2 = pa.FR_TolTR_MoyMin_G_Step2;
            FR_TolTR_MoyMin_G_Step3 = pa.FR_TolTR_MoyMin_G_Step3;
            FR_TolTR_MoyMin_G_Step4 = pa.FR_TolTR_MoyMin_G_Step4;
            FR_TolTR_MoyMin_G_Step5 = pa.FR_TolTR_MoyMin_G_Step5;
            FR_TolTR_MoyMax_G_Step1 = pa.FR_TolTR_MoyMax_G_Step1;
            FR_TolTR_MoyMax_G_Step2 = pa.FR_TolTR_MoyMax_G_Step2;
            FR_TolTR_MoyMax_G_Step3 = pa.FR_TolTR_MoyMax_G_Step3;
            FR_TolTR_MoyMax_G_Step4 = pa.FR_TolTR_MoyMax_G_Step4;
            FR_TolTR_MoyMax_G_Step5 = pa.FR_TolTR_MoyMax_G_Step5;
            FR_TolTR_RMin_D_Step1 = pa.FR_TolTR_RMin_D_Step1;
            FR_TolTR_RMin_D_Step2 = pa.FR_TolTR_RMin_D_Step2;
            FR_TolTR_RMin_D_Step3 = pa.FR_TolTR_RMin_D_Step3;
            FR_TolTR_RMin_D_Step4 = pa.FR_TolTR_RMin_D_Step4;
            FR_TolTR_RMin_D_Step5 = pa.FR_TolTR_RMin_D_Step5;
            FR_TolTR_RMax_D_Step1 = pa.FR_TolTR_RMax_D_Step1;
            FR_TolTR_RMax_D_Step2 = pa.FR_TolTR_RMax_D_Step2;
            FR_TolTR_RMax_D_Step3 = pa.FR_TolTR_RMax_D_Step3;
            FR_TolTR_RMax_D_Step4 = pa.FR_TolTR_RMax_D_Step4;
            FR_TolTR_RMax_D_Step5 = pa.FR_TolTR_RMax_D_Step5;
            FR_TolTR_MoyMin_D_Step1 = pa.FR_TolTR_MoyMin_D_Step1;
            FR_TolTR_MoyMin_D_Step2 = pa.FR_TolTR_MoyMin_D_Step2;
            FR_TolTR_MoyMin_D_Step3 = pa.FR_TolTR_MoyMin_D_Step3;
            FR_TolTR_MoyMin_D_Step4 = pa.FR_TolTR_MoyMin_D_Step4;
            FR_TolTR_MoyMin_D_Step5 = pa.FR_TolTR_MoyMin_D_Step5;
            FR_TolTR_MoyMax_D_Step1 = pa.FR_TolTR_MoyMax_D_Step1;
            FR_TolTR_MoyMax_D_Step2 = pa.FR_TolTR_MoyMax_D_Step2;
            FR_TolTR_MoyMax_D_Step3 = pa.FR_TolTR_MoyMax_D_Step3;
            FR_TolTR_MoyMax_D_Step4 = pa.FR_TolTR_MoyMax_D_Step4;
            FR_TolTR_MoyMax_D_Step5 = pa.FR_TolTR_MoyMax_D_Step5;
            FR_CAS_Pression_Step1 = pa.FR_CAS_Pression_Step1;
            FR_CAS_Pression_Step2 = pa.FR_CAS_Pression_Step2;
            FR_CAS_Pression_Step3 = pa.FR_CAS_Pression_Step3;
            FR_CAS_Pression_Step4 = pa.FR_CAS_Pression_Step4;
            FR_CAS_Pression_Step5 = pa.FR_CAS_Pression_Step5;
            FR_CAS_NB_de_tour_Step1 = pa.FR_CAS_NB_de_tour_Step1;
            FR_CAS_NB_de_tour_Step2 = pa.FR_CAS_NB_de_tour_Step2;
            FR_CAS_NB_de_tour_Step3 = pa.FR_CAS_NB_de_tour_Step3;
            FR_CAS_NB_de_tour_Step4 = pa.FR_CAS_NB_de_tour_Step4;
            FR_CAS_NB_de_tour_Step5 = pa.FR_CAS_NB_de_tour_Step5;
            FR_Seuil_Star_1 = pa.FR_Seuil_Star_1;
            FR_Seuil_Star_2 = pa.FR_Seuil_Star_2;
            FR_Seuil_Star_3 = pa.FR_Seuil_Star_3;
            FR_Pair_ID = pa.FR_Pair_ID;
            FR_Favorite = pa.FR_Favorite;

            //System.Console.WriteLine("  Fin Refresh_FR_Data : {0:HH:mm:ss.fff}", System.DateTime.Now);
            //System.Console.WriteLine("");
        }

        private DelegateCommand showKeyboardPopUpCommand;

        public ICommand ShowKeyboardPopUpCommand
        {
            get
            {
                if (showKeyboardPopUpCommand == null)
                {
                    showKeyboardPopUpCommand = new DelegateCommand(ShowKeyboardPopUp);
                }

                return showKeyboardPopUpCommand;
            }
        }

        private void ShowKeyboardPopUp()
        {
        }
        private int _LableTextHeight = 45;
        private int _LableTextWidth = 70;

        public int Labletextheight { get { return _LableTextHeight; } }
        public int Labletextwidth { get  { return _LableTextWidth; } }

    }
}
