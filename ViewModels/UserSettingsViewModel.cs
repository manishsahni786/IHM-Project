using MireWpf.Models;
using Prism.Commands;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Input;

namespace MireWpf.ViewModels
{
    public class UserSettingsViewModel : BaseViewModel, IRegion
    {
        #region parameters
        public MainWindowViewModel _parent;
        private int _autoZoom;
        private int _fullFit;
        private int _showVoile;
        private int _showSaut;
        private int _showMinMax;
        private int _showPosition;
        private int _unitLength;
        private int _unitLength_0;
        private int _unitLength_1;
        private int _unitWeight;
        private int _unitWeight_0;
        private int _unitWeight_1;
        private int _unitWeight_2;
        private int _unitWeight_3;
        private int _realtimeTension;
        private int _realtimeTime;
        private int _tensionData;
        private int _tensionLeftRight;
        private int _calculOffset;
        private int _jointureInvisible;
        private int _autorefresh;
        private int _errasseScratchs;
        private int _teacher;
        private int _celebrate;
        private int _dataPerParts;
        private int _dataPerUser;
        private int _autoPrint;
        private int _barcode;
        private int _name;
        private int _date;
        private int _finalValue;
        private int _torqueMini;
        private int _torqueMaxi;
        private int _ZD420;
        private int _mitutoyo;
        private int _mahr;
        private int _identityManual;
        private int _unitType;

        private int _chartTypeBlock;
        private int _chartTypeXY;
        private int _chartTypeRadar;

        private int _manual1;
        private int _manual2;
        private int _manual3;
        private int _manual4;

        private bool _showParamsPopUp = false;
        private bool _showShutPopUp = false;

        private string _label1;
        private int _checkBoxParam1;

        private string _label2;
        private int _checkBoxParam2;

        private string _label3;
        private int _checkBoxParam3;

        private string _label4;
        private int _checkBoxParam4;

        private string _label5;
        private int _checkBoxParam5;
        #endregion

        #region fields
        public int ChartTypeBlock
        {
            get { return _chartTypeBlock; }
            set
            {
                _chartTypeBlock = value;

                if (value == 1)
                {
                    _chartTypeXY = 0;
                    _chartTypeRadar = 0;
                    Properties.Settings.Default["SettingsChartType"] = 0;
                    Properties.Settings.Default.Save();
                }
                OnPropertyChanged();
            }
        }

        public int ChartTypeXY
        {
            get { return _chartTypeXY; }
            set
            {
                _chartTypeXY = value;

                if (value == 1)
                {
                    _chartTypeBlock = 0;
                    _chartTypeRadar = 0;
                    Properties.Settings.Default["SettingsChartType"] = 1;
                    Properties.Settings.Default.Save();
                }
                OnPropertyChanged();
            }
        }

        public int ChartTypeRadar
        {
            get { return _chartTypeRadar; }
            set
            {
                _chartTypeRadar = value;

                if (value == 1)
                {
                    _chartTypeXY = 0;
                    _chartTypeBlock = 0;
                    Properties.Settings.Default["SettingsChartType"] = 2;
                    Properties.Settings.Default.Save();
                }
                OnPropertyChanged();
            }
        }

        public int AutoZoom
        {
            get { return _autoZoom; }
            set
            {
                _autoZoom = value;
                _parent.SetTwincatValue("AutoZOOM", value);
                OnPropertyChanged();
            }
        }

        public int FullFit
        {
            get { return _fullFit; }
            set
            {
                _fullFit = value;
                _parent.SetTwincatValue("Full_fit", value);
                OnPropertyChanged();
            }
        }

        public int ShowVoile
        {
            get { return _showVoile; }
            set
            {
                _showVoile = value;
                OnPropertyChanged();
            }
        }

        public int UnitType
        {
            get { return _unitType; }
            set
            {
                _unitType = value;
                OnPropertyChanged();
            }
        }

        public int ShowSaut
        {
            get { return _showSaut; }
            set
            {
                _showSaut = value;
                OnPropertyChanged();
            }
        }

        public int ShowMinMax
        {
            get { return _showMinMax; }
            set
            {
                _showMinMax = value;
                OnPropertyChanged();
            }
        }

        public int ShowPosition
        {
            get { return _showPosition; }
            set
            {
                _showPosition = value;
                OnPropertyChanged();
            }
        }

        public int UnitLength
        {
            get { return _unitLength; }
            set
            {
                _unitLength = value;
                if (value == 0)
                {
                    UnitLength_0 = 1;
                    UnitLength_1 = 0;
                }
                else if (value == 1)
                {
                    UnitLength_0 = 0;
                    UnitLength_1 = 1;
                }
                OnPropertyChanged();
            }
        }

        public int UnitLength_0
        {
            get { return _unitLength_0; }
            set
            {
                _unitLength_0 = value;
                if (value == 1)
                {
                    _unitLength_1 = 0;
                    _parent.SetTwincatValue("L_SI", (int)0);
                    Properties.Settings.Default["SettingsUnitType"] = 0;
                    Properties.Settings.Default.Save();
                }
                    
                OnPropertyChanged();
            }
        }

        public int UnitLength_1
        {
            get { return _unitLength_1; }
            set
            {
                _unitLength_1 = value;
                if (value == 1)
                {
                    _unitLength_0 = 0;
                    _parent.SetTwincatValue("L_SI", (int)1);
                    Properties.Settings.Default["SettingsUnitType"] = 1;
                    Properties.Settings.Default.Save();
                }
                   
                OnPropertyChanged();
            }
        }

        public int UnitWeight
        {
            get { return _unitWeight; }
            set
            {
                _unitWeight = value;
                if (value == 0)
                {
                    UnitWeight_0 = 1;
                    UnitWeight_1 = 0;
                    UnitWeight_2 = 0;
                    UnitWeight_3 = 0;
                }
                else if (value == 1)
                {
                    UnitWeight_0 = 0;
                    UnitWeight_1 = 1;
                    UnitWeight_2 = 0;
                    UnitWeight_3 = 0;
                }
                else if (value == 2)
                {
                    UnitWeight_0 = 0;
                    UnitWeight_1 = 0;
                    UnitWeight_2 = 1;
                    UnitWeight_3 = 0;
                }
                else if (value == 3)
                {
                    UnitWeight_0 = 0;
                    UnitWeight_1 = 0;
                    UnitWeight_2 = 0;
                    UnitWeight_3 = 1;
                }
                OnPropertyChanged();
            }
        }

        public int UnitWeight_0
        {
            get { return _unitWeight_0; }
            set
            {
                _unitWeight_0 = value;
                if (value == 1)
                    _parent.SetTwincatValue("T_SI", (int)0);
                OnPropertyChanged();
            }
        }

        public int UnitWeight_1
        {
            get { return _unitWeight_1; }
            set
            {
                _unitWeight_1 = value;
                if (value == 1)
                    _parent.SetTwincatValue("T_SI", (int)1);
                OnPropertyChanged();
            }
        }

        public int UnitWeight_2
        {
            get { return _unitWeight_2; }
            set
            {
                _unitWeight_2 = value;
                if (value == 1)
                    _parent.SetTwincatValue("T_SI", (int)2);
                OnPropertyChanged();
            }
        }

        public int UnitWeight_3
        {
            get { return _unitWeight_3; }
            set
            {
                _unitWeight_3 = value;
                if (value == 1)
                    _parent.SetTwincatValue("T_SI", (int)3);
                OnPropertyChanged();
            }
        }

        public int RealtimeTension
        {
            get { return _realtimeTension; }
            set
            {
                _realtimeTension = value;
                _parent.SetTwincatValue("Real_Time_Tension", value);
                OnPropertyChanged();
            }
        }

        public int RealtimeTime
        {
            get { return _realtimeTime; }
            set
            {
                _realtimeTime = value;
                _parent.SetTwincatValue("Real_Time", value);
                OnPropertyChanged();
            }
        }

        public int TensionData
        {
            get { return _tensionData; }
            set
            {
                _tensionData = value;
                _parent.SetTwincatValue("Tension_Array_Data", value);
                OnPropertyChanged();
            }
        }

        public int TensionLeftRight
        {
            get { return _tensionLeftRight; }
            set
            {
                _tensionLeftRight = value;
                _parent.SetTwincatValue("Tension_LR", value);
                OnPropertyChanged();
            }
        }

        public int CalculOffset
        {
            get { return _calculOffset; }
            set
            {
                _calculOffset = value;
                _parent.SetTwincatValue("Calcul_Off7", value);
                OnPropertyChanged();
            }
        }

        public int JointureInvisible
        {
            get { return _jointureInvisible; }
            set
            {
                _jointureInvisible = value;
                _parent.SetTwincatValue("Jointure_Invisible", value);
                OnPropertyChanged();
            }
        }
        public int AutoRefresh
        {
            get { return _autorefresh; }
            set
            {
                _autorefresh = value;
                _parent.SetTwincatValue("Auto_Refresh", value);
                OnPropertyChanged();
            }
        }

        public int ErrasseScratchs
        {
            get { return _errasseScratchs; }
            set
            {
                _errasseScratchs = value;
                _parent.SetTwincatValue("Errase_Scratchs", value);
                OnPropertyChanged();
            }
        }

        public int Teacher
        {
            get { return _teacher; }
            set
            {
                _teacher = value;
                _parent.SetTwincatValue("Teacher", value);
                OnPropertyChanged();
            }
        }

        public int Celebrate
        {
            get { return _celebrate; }
            set
            {
                _celebrate = value;
                _parent.SetTwincatValue("Celebrate", value);
                OnPropertyChanged();
            }
        }

        public int DataPerParts
        {
            get { return _dataPerParts; }
            set
            {
                _dataPerParts = value;
                _parent.SetTwincatValue("Per_parts", value);
                OnPropertyChanged();
            }
        }

        public int DataPerUser
        {
            get { return _dataPerUser; }
            set
            {
                _dataPerUser = value;
                _parent.SetTwincatValue("Per_user", value);
                OnPropertyChanged();
            }
        }

        public int AutoPrint
        {
            get { return _autoPrint; }
            set
            {
                _autoPrint = value;
                _parent.SetTwincatValue("Auto_Print_Wheel_OK", value);
                OnPropertyChanged();
            }
        }

        public int Barcode
        {
            get { return _barcode; }
            set
            {
                _barcode = value;
                _parent.SetTwincatValue("Barcode", value);
                OnPropertyChanged();
            }
        }

        public int Name
        {
            get { return _name; }
            set
            {
                _name = value;
                _parent.SetTwincatValue("Name", value);
                OnPropertyChanged();
            }
        }

        public int Date
        {
            get { return _date; }
            set
            {
                _date = value;
                _parent.SetTwincatValue("Date_Hour", value);
                OnPropertyChanged();
            }
        }

        public int FinalValue
        {
            get { return _finalValue; }
            set
            {
                _finalValue = value;
                _parent.SetTwincatValue("Final_value", value);
                OnPropertyChanged();
            }
        }

        public int TorqueMini
        {
            get { return _torqueMini; }
            set
            {
                _torqueMini = value;
                _parent.SetTwincatValue("TorqueMin", value);
                OnPropertyChanged();
            }
        }

        public int TorqueMaxi
        {
            get { return _torqueMaxi; }
            set
            {
                _torqueMaxi = value;
                _parent.SetTwincatValue("TorqueMax", value);
                OnPropertyChanged();
            }
        }
        public int ZD420
        {
            get { return _ZD420; }
            set
            {
                _ZD420 = value;
                _parent.SetTwincatValue("ZD420", value);
                OnPropertyChanged();
            }
        }

        public int Mitutoyo
        {
            get { return _mitutoyo; }
            set
            {
                _mitutoyo = value;
                if (value == 1)
                {
                    _mahr = 0;
                    Properties.Settings.Default.Save();
                }
                _parent.SetTwincatValue("Mitutoyo", value);
                OnPropertyChanged();
            }
        }

        public int Mahr
        {
            get { return _mahr; }
            set
            {
                _mahr = value;
                if (value == 1)
                {
                    _mitutoyo = 0;
                    Properties.Settings.Default.Save();
                }
                _parent.SetTwincatValue("Mahr", value);
                OnPropertyChanged();
            }
        }


        public int IdentityManual
        {
            get { return _identityManual; }
            set
            {
                _identityManual = value;
                _parent.SetTwincatValue("IDManual", value);
                OnPropertyChanged();
            }
        }

        public int Manual1
        {
            get { return _manual1; }
            set
            {
                _manual1 = value;
                OnPropertyChanged();
            }
        }

        public int Manual2
        {
            get { return _manual2; }
            set
            {
                _manual2 = value;
                OnPropertyChanged();
            }
        }

        public int Manual3
        {
            get { return _manual3; }
            set
            {
                _manual3 = value;
                OnPropertyChanged();
            }
        }

        public int Manual4
        {
            get { return _manual4; }
            set
            {
                _manual4 = value;
                OnPropertyChanged();
            }
        }

        public bool ShowParamsPopUp
        {
            get { return _showParamsPopUp; }
            set
            {
                _showParamsPopUp = value;
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

        public string Label1
        {
            get { return _label1; }
            set
            {
                _label1 = value;
                OnPropertyChanged();
            }
        }

        public int CheckBoxParam1
        {
            get { return _checkBoxParam1; }
            set
            {
                _checkBoxParam1 = value;
                OnPropertyChanged();
            }
        }

        public string Label2
        {
            get { return _label2; }
            set
            {
                _label2 = value;
                OnPropertyChanged();
            }
        }

        public int CheckBoxParam2
        {
            get { return _checkBoxParam2; }
            set
            {
                _checkBoxParam2 = value;
                OnPropertyChanged();
            }
        }

        public string Label3
        {
            get { return _label3; }
            set
            {
                _label3 = value;
                OnPropertyChanged();
            }
        }

        public int CheckBoxParam3
        {
            get { return _checkBoxParam3; }
            set
            {
                _checkBoxParam3 = value;
                OnPropertyChanged();
            }
        }

        public string Label4
        {
            get { return _label4; }
            set
            {
                _label4 = value;
                OnPropertyChanged();
            }
        }

        public int CheckBoxParam4
        {
            get { return _checkBoxParam4; }
            set
            {
                _checkBoxParam4 = value;
                OnPropertyChanged();
            }
        }

        public string Label5
        {
            get { return _label5; }
            set
            {
                _label5 = value;
                OnPropertyChanged();
            }
        }

        public int CheckBoxParam5
        {
            get { return _checkBoxParam5; }
            set
            {
                _checkBoxParam5 = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ICommand ModifyAppSettingsCommand { get; set; }
        private void OnModifyAppSettingsCommand(AppSettingsCommandParameters parameter)
        {
            int value = 0;
            if (parameter.value)
                value = 1;

            Properties.Settings.Default[parameter.settingName] = value;
            Properties.Settings.Default.Save();
        }

        public ICommand ModifyAppSettingsIntCommand { get; set; }
        private void OnModifyAppSettingsIntCommand(AppSettingsIntCommandParameters parameter)
        {
            Properties.Settings.Default[parameter.settingName] = parameter.intValue;
            Properties.Settings.Default.Save();
        }

        public ICommand Manual1Command { get; set; }
        private void OnManual1Command()
        {
            Manual1 = (Manual1 + 1) % 2;
            if (Manual1 == 0)
            {
                _parent.SetTwincatValue("BPManual_Debridage", (short)1);
                _parent.SetTwincatValue("BPManual_Bridage", (short)0);
            }
            else
            {
                _parent.SetTwincatValue("BPManual_Debridage", (short)0);
                _parent.SetTwincatValue("BPManual_Bridage", (short)1);
            }
        }

        public ICommand Manual2Command { get; set; }
        private void OnManual2Command()
        {
            Manual2 = (Manual2 + 1) % 2;
            if (Manual2 == 0)
            {
                _parent.SetTwincatValue("BPManual_Voile_UP", (short)1);
                _parent.SetTwincatValue("BPManual_Voile_Down", (short)0);
            }
            else
            {
                _parent.SetTwincatValue("BPManual_Voile_UP", (short)0);
                _parent.SetTwincatValue("BPManual_Voile_Down", (short)1);
            }
        }

        public ICommand Manual3Command { get; set; }
        private void OnManual3Command()
        {
            Manual3 = (Manual3 + 1) % 2;
            if (Manual3 == 0)
            {
                _parent.SetTwincatValue("BPManual_Saut_UP", (short)1);
                _parent.SetTwincatValue("BPManual_Saut_Down", (short)0);
            }
            else
            {
                _parent.SetTwincatValue("BPManual_Saut_UP", (short)0);
                _parent.SetTwincatValue("BPManual_Saut_Down", (short)1);
            }
        }

        public ICommand Manual4Command { get; set; }
        private void OnManual4Command()
        {
            Manual4 = (Manual4 + 1) % 3;
            if (Manual4 == 0)
            {
                _parent.SetTwincatValue("BPManual_Center", (short)1);
                _parent.SetTwincatValue("BPManual_CAS_Left", (short)0);
                _parent.SetTwincatValue("BPManual_CAS_Right", (short)0);
            }
            else if (Manual4 == 1)
            {
                _parent.SetTwincatValue("BPManual_Center", (short)0);
                _parent.SetTwincatValue("BPManual_CAS_Left", (short)0);
                _parent.SetTwincatValue("BPManual_CAS_Right", (short)1);
            }
            else
            {
                _parent.SetTwincatValue("BPManual_Center", (short)0);
                _parent.SetTwincatValue("BPManual_CAS_Left", (short)1);
                _parent.SetTwincatValue("BPManual_CAS_Right", (short)0);
            }
        }

        public ICommand ShowParamsPopUpCommand { get; set; }
        private void OnShowParamsPopUpCommand()
        {
            ShowParamsPopUp = true;
        }

        public ICommand ParamsPopUpOkCommand { get; set; }
        private void OnParamsPopUpOkCommand()
        {
            //impression
            ShowParamsPopUp = false;
        }

        public ICommand ParamsPopUpCancelCommand { get; set; }
        private void OnParamsPopUpCancelCommand()
        {
            ShowParamsPopUp = false;
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

        public UserSettingsViewModel()
        {
            //get these 5 values from application config
            int chartType = 0, showVoile = 1, showSaut = 1, showMinMax = 1, showPosition = 1, unitType = 0;
            int.TryParse(Properties.Settings.Default["SettingsChartType"].ToString(), out chartType);
            if (chartType == 0)
                ChartTypeBlock = 1;
            else if (chartType == 1)
                ChartTypeXY = 1;
            else
                ChartTypeRadar = 1;
            int.TryParse(Properties.Settings.Default["SettingsUnitType"].ToString(), out unitType);
            UnitType = unitType;
            int.TryParse(Properties.Settings.Default["SettingsShowVoile"].ToString(), out showVoile);
            ShowVoile = showVoile;
            int.TryParse(Properties.Settings.Default["SettingsShowSaut"].ToString(), out showSaut);
            ShowSaut = showSaut;
            int.TryParse(Properties.Settings.Default["SettingsShowMinMax"].ToString(), out showMinMax);
            ShowMinMax = showMinMax;
            int.TryParse(Properties.Settings.Default["SettingsShowPosition"].ToString(), out showPosition);
            ShowPosition = showPosition;

            ModifyAppSettingsIntCommand = new DelegateCommand<AppSettingsIntCommandParameters>(OnModifyAppSettingsIntCommand);
            ModifyAppSettingsCommand = new DelegateCommand<AppSettingsCommandParameters>(OnModifyAppSettingsCommand);

            Manual1Command = new DelegateCommand(OnManual1Command);
            Manual2Command = new DelegateCommand(OnManual2Command);
            Manual3Command = new DelegateCommand(OnManual3Command);
            Manual4Command = new DelegateCommand(OnManual4Command);

            ShowParamsPopUpCommand = new DelegateCommand(OnShowParamsPopUpCommand);

            ParamsPopUpOkCommand = new DelegateCommand(OnParamsPopUpOkCommand);
            ParamsPopUpCancelCommand = new DelegateCommand(OnParamsPopUpCancelCommand);

            PrintShutPopUpCommand = new DelegateCommand(OnPrintShutPopUpCommand);

            ShutPopUpOkCommand = new DelegateCommand(OnShutPopUpOkCommand);
            ShutPopUpCancelCommand = new DelegateCommand(OnShutPopUpCancelCommand);
        }
        
        bool firstRefresh = true;

        public void Refresh(DUT_PA pa)
        {
            if (firstRefresh)
            {
                AutoZoom = pa.AutoZOOM;
                FullFit = pa.Full_fit;
                UnitLength = pa.L_SI;
                UnitWeight = pa.T_SI;
                RealtimeTension = pa.Real_Time_Tension;
                RealtimeTime = pa.Real_Time;
                TensionData = pa.Tension_Array_Data;
                TensionLeftRight = pa.Tension_LR;
                CalculOffset = pa.Calcul_Off7;
                JointureInvisible = pa.Jointure_Invisible;
                AutoRefresh = pa.Auto_Refresh;
                ErrasseScratchs = pa.Errase_Scratchs;
                Teacher = pa.Teacher;
                Celebrate = pa.Celebrate;
                DataPerParts = pa.Per_parts;
                DataPerUser = pa.Per_user;
                AutoPrint = pa.Auto_Print_Wheel_OK;
                Barcode = pa.Barcode;
                Name = pa.Name;
                Date = pa.Date_Hour;
                FinalValue = pa.Final_value;
                TorqueMini = pa.TorqueMin;
                TorqueMaxi = pa.TorqueMax;
                ZD420 = pa.ZD420;
                IdentityManual = pa.IDManual;
                Mitutoyo = pa.Mitutoyo;
                Mahr = pa.Mahr;
                firstRefresh = false;

                if (pa.ParamLabel00 == "")
                {
                    Label1 = "Label 1";
                    CheckBoxParam1 = 0;
                }
                else
                {
                    Label1 = pa.ParamLabel00;
                    CheckBoxParam1 = 1;
                }

                if (pa.ParamLabel01 == "")
                {
                    Label2 = "Label 2";
                    CheckBoxParam2 = 0;
                }
                else
                {
                    Label2 = pa.ParamLabel01;
                    CheckBoxParam2 = 1;
                }

                if (pa.ParamLabel02 == "")
                {
                    Label3 = "Label 3";
                    CheckBoxParam3 = 0;
                }
                else
                {
                    Label3 = pa.ParamLabel02;
                    CheckBoxParam3 = 1;
                }

                if (pa.ParamLabel03 == "")
                {
                    Label4 = "Label 4";
                    CheckBoxParam4 = 0;
                }
                else
                {
                    Label4 = pa.ParamLabel03;
                    CheckBoxParam4 = 1;
                }

                if (pa.ParamLabel04 == "")
                {
                    Label5 = "Label 5";
                    CheckBoxParam5 = 0;
                }
                else
                {
                    Label5 = pa.ParamLabel04;
                    CheckBoxParam5 = 1;
                }
            }
        }
    }
}
