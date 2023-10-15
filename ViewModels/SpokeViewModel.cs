using MireWpf.Models;
using Prism.Commands;
using System;
//using System;
//using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MireWpf.ViewModels
{
    public class SpokeViewModel : BaseViewModel, IRegion
    {
        #region Spoke Table Data Class
        public class Spoke : ObservableCollection<Spoke>
        {
            private int _index;
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
            public int Index
            {
                get { return _index; }
                set
                {
                    _index = value;
                    OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(""));
                }
            }

            public Spoke() { }
        }

        public class Calib : ObservableCollection<Calib>
        {
            private int _index;
            private float _comparator;
            private float _peson;

            public float Comparator
            {
                get { return _comparator; }
                set
                {
                    _comparator = value;
                    OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(""));
                }
            }
            public float Peson
            {
                get { return _peson; }
                set
                {
                    _peson = value;
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

            public Calib() { }
        }

        public class RectItem
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Width { get; set; }
            public double Height { get; set; }
        }
        #endregion

        #region parameters
        public MainWindowViewModel _parent;
        private int _editMode = 0;
        private bool _loadMode = false;
        private bool _focusDataGrid = false;
        private bool _admin = false;

        public int _spokeDataSelector;
        public int _bP_CalibrationModif;
        public int _dataSpokeNum;
        public string _dataSpokeName;
        public float _regrPoliOrdre0;
        public float _regrPoliOrdre1;
        public float _regrPoliOrdre2;
        public float _accuracy;
        public string _dS_Date;
        public string _dS_Validity;
        public int _cal_NB_Mesure;
        public int _bP_Calculate;
        public int _calibRayon_BP_Compute;
        public int _CalibRun;
        public float _calMesurePeson;
        public float _calMesureTension;
        public int _calNumPesonCrs;
        public int _calNumTensiometreCrs;
        private int _dmdCalibRun;

        private PointCollection _chart_point_collection;

        private bool _showShutPopUp = false;
        #endregion

        #region fields
        public bool Admin
        {
            get { return _admin; }
            set
            {
                _admin = value;
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

        public int SpokeSelectedIndex
        {
            get { return SpokeDataSelector - 1; }
            set
            {
                SpokeDataSelector = value + 1;
                OnPropertyChanged();
            }
        }

        public int SpokeRayonSelectedIndex
        {
            get { return CalNumPesonCrs - 1; }
            set
            {
                CalNumPesonCrs = value + 1;
                OnPropertyChanged();
            }
        }

        public int SpokeDataSelector
        {
            get { return _spokeDataSelector; }
            set
            {
                _spokeDataSelector = value;
                OnPropertyChanged();
            }
        }


        public int BP_CalibrationModif
        {
            get { return _bP_CalibrationModif; }
            set
            {
                _bP_CalibrationModif = value;
                OnPropertyChanged();
            }
        }

        
        public int DataSpokeNum
        {
            get { return _dataSpokeNum; }
            set
            {
                _dataSpokeNum = value;
                OnPropertyChanged();
            }
        }

        
        public string DataSpokeName
        {
            get { return _dataSpokeName; }
            set
            {
                _dataSpokeName = value;
                OnPropertyChanged();
            }
        }

        
        public float RegrPoliOrdre0
        {
            get { return _regrPoliOrdre0; }
            set
            {
                _regrPoliOrdre0 = value;
                OnPropertyChanged();
            }
        }

        
        public float RegrPoliOrdre1
        {
            get { return _regrPoliOrdre1; }
            set
            {
                _regrPoliOrdre1 = value;
                OnPropertyChanged();
            }
        }

        
        public float RegrPoliOrdre2
        {
            get { return _regrPoliOrdre2; }
            set
            {
                _regrPoliOrdre2 = value;
                OnPropertyChanged();
            }
        }

        
        public float Accuracy
        {
            get { return _accuracy; }
            set
            {
                _accuracy = value;
                OnPropertyChanged();
            }
        }

        
        public string DS_Date
        {
            get { return _dS_Date; }
            set
            {
                _dS_Date = value;
                OnPropertyChanged();
            }
        }

        
        public string DS_Validity
        {
            get { return _dS_Validity; }
            set
            {
                _dS_Validity = value;
                OnPropertyChanged();
            }
        }

        
        public int Cal_NB_Mesure
        {
            get { return _cal_NB_Mesure; }
            set
            {
                _cal_NB_Mesure = value;
                OnPropertyChanged();
            }
        }

        public int DmdCalibRun
        {
            get { return _dmdCalibRun; }
            set
            {
                _dmdCalibRun = value;
                OnPropertyChanged();
            }
        }

        public int BP_Calculate
        {
            get { return _bP_Calculate; }
            set
            {
                _bP_Calculate = value;
                OnPropertyChanged();
            }
        }

        
        public int CalibRayon_BP_Compute
        {
            get { return _calibRayon_BP_Compute; }
            set
            {
                _calibRayon_BP_Compute = value;
                OnPropertyChanged();
            }
        }
        public int CalibRun
        {
            get { return _CalibRun; }
            set
            {
                _CalibRun = value;
                OnPropertyChanged();
            }
        }

        public float CalMesurePeson
        {
            get { return _calMesurePeson; }
            set
            {
                _calMesurePeson = value;
                OnPropertyChanged();
            }
        }

        
        public float CalMesureTension
        {
            get { return _calMesureTension; }
            set
            {
                _calMesureTension = value;
                OnPropertyChanged();
            }
        }

        
        public int CalNumPesonCrs
        {
            get { return _calNumPesonCrs; }
            set
            {
                _calNumPesonCrs = value;
                OnPropertyChanged();
            }
        }

        
        public int CalNumTensiometreCrs
        {
            get { return _calNumTensiometreCrs; }
            set
            {
                _calNumTensiometreCrs = value;
                OnPropertyChanged();
            }
        }

        public PointCollection ChartPointCollection
        {
            get { return _chart_point_collection; }
            set
            {
                _chart_point_collection = value;
                OnPropertyChanged();
            }
        }

        public bool ShowShutPopUp
        {
            get { return _showShutPopUp; }
            set
            {
                _showShutPopUp = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ObservableCollection<RectItem> RectItems { get; set; }

        public ICommand UpdateValueCommand { get; set; }
        private void OnUpdateValueCommand(string parameter)
        {
            switch (parameter)
            {
                case "DataSpokeName": _parent.SetTwincatValue(parameter, DataSpokeName, 21, "IHM4."); break;
                case "RegrPoliOrdre2": _parent.SetTwincatValue(parameter, RegrPoliOrdre2, 0, "IHM4."); break;
                case "RegrPoliOrdre1": _parent.SetTwincatValue(parameter, RegrPoliOrdre1, 0, "IHM4."); break;
                case "RegrPoliOrdre0": _parent.SetTwincatValue(parameter, RegrPoliOrdre0, 0, "IHM4."); break;
                case "DS_Validity": _parent.SetTwincatValue(parameter, DS_Validity, 21, "IHM4."); break;
            }
        }

        public ICommand SpokeSelectionChangeCommand { get; set; }
        private void OnSpokeSelectionChangeCommand(int? index)
        {
            if (index.HasValue && index.Value > -1)
            {
                _parent.SetTwincatValue("SpokeDataSelector", (short)index.Value, 0, "IHM4.");
                refreshData = true;
            }
        }

        public ICommand SpokeRayonSelectionChangeCommand { get; set; }
        private void OnSpokeRayonSelectionChangeCommand(int? index)
        {
            if (index.HasValue && index.Value > -1)
            {
                _parent.SetTwincatValue("CalNumPesonCrs", (short)index.Value, 0, "IHM4.");
                _parent.SetTwincatValue("CalNumTensiometreCrs", (short)index.Value, 0, "IHM4.");
            }
        }
        
        public ICommand CalibCommand { get; set; }
        private void OnCalibCommand()
        {
            DmdCalibRun = (DmdCalibRun + 1) % 2;
             if (DmdCalibRun == 0)
            { _parent.SetTwincatValue("CalibRun", (int)0, 0, "IHM4.");
            }
             else
            {
                _parent.SetTwincatValue("CalibRun", (int)1, 0, "IHM4.");
            }

            refreshData = true;
        }

        public ICommand ComputeCommand { get; set; }
        private void OnComputeCommand()
        {
            _parent.SetTwincatValue("CalibRayon_BP_Compute", (int)1, 0, "IHM4.");
            DmdCalibRun = 0;
            _parent.SetTwincatValue("CalibRun", (int)0, 0, "IHM4.");
            refreshData = true;
        }

        public ICommand EditAcceptCommand { get; set; }
        private void OnEditAcceptCommand()
        {
            _parent.SetTwincatValue("BP_Calculate", (int)1, 0, "IHM4.");
            DmdCalibRun = 0;
            _parent.SetTwincatValue("CalibRun", (int)0, 0, "IHM4.");
            _parent.SpokeEditMode = 0;
            _parent.SetTwincatValue("BP_CalibrationModif", (int)0, 0, "IHM4.");
            refreshList = true;
            refreshData = true;
        }

        public ICommand SpokeOkCommand { get; set; }
        private void OnSpokeOkCommand()
        {
            _parent.SetTwincatValue("FR_DS_Num", SpokeDataSelector);
            _parent.SetTwincatValue("FR_DS_Name", DataSpokeName, 21);
            _parent.SetTwincatValue("FR_DS_Date", DS_Date, 21);
            _parent.CloseSpokeScreen(true);
        }

        public ICommand SpokeCancelCommand { get; set; }
        private void OnSpokeCancelCommand()
        {
            _parent.CloseSpokeScreen(false);
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

        public ObservableCollection<Spoke> ListSpokes { get; set; }
        public ObservableCollection<Calib> ListCalib { get; set; }

        public SpokeViewModel()
        {
            ListSpokes = new ObservableCollection<Spoke>();
            ListCalib = new ObservableCollection<Calib>();
            RectItems = new ObservableCollection<RectItem>();

            SpokeSelectionChangeCommand = new DelegateCommand<int?>(OnSpokeSelectionChangeCommand);
            SpokeRayonSelectionChangeCommand = new DelegateCommand<int?>(OnSpokeRayonSelectionChangeCommand); 
            UpdateValueCommand = new DelegateCommand<string>(OnUpdateValueCommand);

            ComputeCommand = new DelegateCommand(OnComputeCommand);
            CalibCommand = new DelegateCommand(OnCalibCommand);
            EditAcceptCommand = new DelegateCommand(OnEditAcceptCommand);
            SpokeOkCommand = new DelegateCommand(OnSpokeOkCommand);
            SpokeCancelCommand = new DelegateCommand(OnSpokeCancelCommand);

            PrintShutPopUpCommand = new DelegateCommand(OnPrintShutPopUpCommand);

            ShutPopUpOkCommand = new DelegateCommand(OnShutPopUpOkCommand);
            ShutPopUpCancelCommand = new DelegateCommand(OnShutPopUpCancelCommand);
        }

        private bool firstRefresh = true;
        public bool refreshList = false;
        public bool refreshData = true;

        public void Refresh()
        {
            DUT_IHM_DataSpoke? spk = _parent.GetSpokeData();

            #region first assignment
            if (firstRefresh)
            {
                if (spk.HasValue)
                {
                    Refresh_Directory(spk.Value);

                    SpokeSelectedIndex = spk.Value.SpokeDataSelector - 1;
                    OnSpokeSelectionChangeCommand(spk.Value.SpokeDataSelector - 1); 
                    SpokeRayonSelectedIndex = spk.Value.CalNumPesonCrs - 1;
                    OnSpokeRayonSelectionChangeCommand(spk.Value.CalNumPesonCrs - 1);
                    FocusDataGrid = true;

                    Refresh_Data(spk.Value);
                    firstRefresh = false;
                }
            }
            #endregion
            #region regular updates
            else
            {
                if (spk.HasValue)
                {
                    if (spk.Value.AP_CalRefresh != spk.Value.PA_CalRefreshed)
                    {
                        refreshData = true;
                        refreshList = true;
                        _parent.SetTwincatValue("PA_CalRefreshed", (short)spk.Value.AP_CalRefresh, 0, "IHM4.");
                        RefreshChart(spk.Value);
                    }

                    if (refreshList)
                    {
                        Refresh_Directory(spk.Value);
                        refreshList = false;
                    }

                    if (refreshData)
                    {
                        Refresh_Data(spk.Value);
                        refreshData = false;
                    }
                }
            }
            #endregion
        }

        public void RefreshChart(DUT_IHM_DataSpoke spk)
        {
            int pointCount = 200;
            double areaWidth = 920;
            double areaHeight = 275;
            double xMax = 5.0;
            double yMax = 200;
            int Start_Value;
                        
            double unitX = areaWidth / pointCount;
            double unitXval = xMax / pointCount;

            PointCollection coll = new PointCollection();
            Start_Value =(int)spk.Profil_CalR_Tensiometre[0];
            for (int i = 0; i < pointCount; i++)
            {
                double x = i * unitX;
                double xVal = i * unitXval;
                double yVal = RegrPoliOrdre2 * xVal * xVal + RegrPoliOrdre1 * xVal + RegrPoliOrdre0;
                if (yVal > 0 && yVal < yMax)
                {
                    double y = areaHeight - (yVal * areaHeight / yMax);
                    coll.Add(new Point(x, y));
                }
            }
            ChartPointCollection = coll;
            
            RectItems.Clear();
            for (int i = 0; i < spk.Cal_NB_Mesure; i++)
            {
                double x = spk.Profil_CalR_Tensiometre[i] * areaWidth / xMax;
                double y = areaHeight - (spk.Profil_CalR_Peson[i] * areaHeight / yMax);
                if (spk.Profil_CalR_Peson[i] > 0 && spk.Profil_CalR_Peson[i] < yMax)
                    RectItems.Add(new RectItem()
                    {
                        X = x - 5,
                        Y = y - 5,
                        Width = 10,
                        Height = 10
                    });
            }
        }

        private void Refresh_Directory(DUT_IHM_DataSpoke spk)
        {
            if (ListSpokes.Count == 0)
            {
                for (int i = 0; i < spk.ListNames.Length; i++)
                {
                    Spoke spoke = new Spoke();
                    spoke.Name = spk.ListNames[i];
                    spoke.Index = spk.ListNumbers[i];
                    ListSpokes.Add(spoke);
                }
            }
            else
            {
                for (int i = 0; i < spk.ListNames.Length; i++)
                {
                    ListSpokes[i].Name = spk.ListNames[i];
                    ListSpokes[i].Index = spk.ListNumbers[i];
                }
            }
        }

        private void Refresh_Data(DUT_IHM_DataSpoke spk)
        {
            if (_loadMode)
                return;

            SpokeDataSelector = spk.SpokeDataSelector;
            BP_CalibrationModif = spk.BP_CalibrationModif;
            DataSpokeNum = spk.DataSpokeNum;
            Accuracy = spk.Accuracy;
            DS_Date = spk.DS_Date;
            Cal_NB_Mesure = spk.Cal_NB_Mesure;
            BP_Calculate = spk.BP_Calculate;
            CalibRayon_BP_Compute = spk.CalibRayon_BP_Compute;
            CalibRun = spk.CalibRun;
            CalMesurePeson = spk.CalMesurePeson;
            CalMesureTension = spk.CalMesureTension;
            CalNumPesonCrs = spk.CalNumPesonCrs;
            CalNumTensiometreCrs = spk.CalNumTensiometreCrs;

            DataSpokeName = spk.DataSpokeName;
            RegrPoliOrdre0 = spk.RegrPoliOrdre0;
            RegrPoliOrdre1 = spk.RegrPoliOrdre1;
            RegrPoliOrdre2 = spk.RegrPoliOrdre2;
            DS_Validity = spk.DS_Validity;

            if (Cal_NB_Mesure != ListCalib.Count)
            {
                ListCalib.Clear();
                for (int i = 0; i < Cal_NB_Mesure; i++)
                {
                    ListCalib.Add(new Calib()
                    {
                        Index = i + 1,
                        Comparator = spk.CalComparator[i],
                        Peson = spk.CalPeson[i]
                    });
                }
            }
            else
            {
                for (int i = 0; i < Cal_NB_Mesure; i++)
                {
                    ListCalib[i].Comparator = spk.CalComparator[i];
                    ListCalib[i].Peson = spk.CalPeson[i];
                }
            }
            if (Cal_NB_Mesure < 20)
                for (int i = Cal_NB_Mesure; i < 20; i++)
                    ListCalib.Add(new Calib()
                    {
                        Index = i + 1,
                        Comparator = 0,
                        Peson = 0
                    });
        }



        private void testing()
        {
            Debug.WriteLine("testing");
        }
    }
}
