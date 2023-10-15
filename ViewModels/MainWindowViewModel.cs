using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using MireWpf.Models;
using NLog;
using Prism.Commands;
using TwinCAT.Ads;
using System.Diagnostics;
using Phidget22;
using Phidget22.Events;
using Microsoft.VisualBasic.ApplicationServices;
using TwinCAT.TypeSystem;

namespace MireWpf.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private TcAdsClient _tcClient;
        private DispatcherTimer _dataTimer;
        private int _hVar;
        private int _hVar_wheel_directory;
        private int _hVar_graph;
        private int _hVar_spoke;
        private string _interval;
        private string _ficheRoueName;
        private string _TrackID;
        private string _userName = "";
        private IRegion _currentRegion;
        private int _roueAv = 1;
        private EScreen _currentScreen = EScreen.MireScreen;
        private int _activeUserId = 0;

        private int _loginEditMode = 0;
        private int _directoryEditMode = 0;
        private int _spokeEditMode = 0;
        private int _admin = 0;

        private bool _mireShowShutPopUp = false;
        private bool _loginShowShutPopUp = false;
        private bool _userSettingsShowShutPopUp = false;
        private bool _directoryShowShutPopUp = false;
        private bool _spokeShowShutPopUp = false;

        private MireViewModel _mireViewModel;
        private LoginViewModel _loginViewModel;
        private UserSettingsViewModel _userSettingsViewModel;
        private DirectoryViewModel _directoryViewModel;
        private SpokeViewModel _spokeViewModel;

        private VoltageRatioInput _vri;



        public MireViewModel MireViewModel
        {
            get { return _mireViewModel; }
            set
            {
                _mireViewModel = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel LoginViewModel
        {
            get { return _loginViewModel; }
            set
            {
                _loginViewModel = value;
                OnPropertyChanged();
            }
        }

        public UserSettingsViewModel UserSettingsViewModel
        {
            get { return _userSettingsViewModel; }
            set
            {
                _userSettingsViewModel = value;
                OnPropertyChanged();
            }
        }

        public DirectoryViewModel DirectoryViewModel
        {
            get { return _directoryViewModel; }
            set
            {
                _directoryViewModel = value;
                OnPropertyChanged();
            }
        }

        public SpokeViewModel SpokeViewModel
        {
            get { return _spokeViewModel; }
            set
            {
                _spokeViewModel = value;
                OnPropertyChanged();
            }
        }

        public EScreen CurrentScreen
        {
            get { return _currentScreen; }
            set
            {
                _currentScreen = value;
                OnPropertyChanged();
            }
        }

        public string Interval
        {
            get { return _interval; }
            set
            {
                _interval = value;
                OnPropertyChanged();
            }
        }

        public string FicheRoueName
        {
            get { return _ficheRoueName; }
            set
            {
                _ficheRoueName = value;
                OnPropertyChanged();
            }
        }
        public string TrackID
        {
            get { return _TrackID; }
            set
            {
                _TrackID = value;
                OnPropertyChanged();
            }
        }
        public int RoueAV
        {
            get { return _roueAv; }
            set
            {
                _roueAv = value;
                OnPropertyChanged();
            }
        }

        public IRegion CurrentRegion
        {
            get { return _currentRegion; }
            set
            {
                //System.Console.WriteLine("Début set CurrentRegion : {0:HH:mm:ss.fff}", System.DateTime.Now);
                _currentRegion = value;
                OnPropertyChanged();
                //System.Console.WriteLine("  Fin set CurrentRegion : {0:HH:mm:ss.fff}", System.DateTime.Now);
            }
        }

        public int LoginEditMode
        {
            get { return _loginEditMode; }
            set
            {
                _loginEditMode = value;
                OnPropertyChanged();
                LoginViewModel.EditMode = value;
                LoginViewModel.SetEditUser(value);
            }
        }

        public int DirectoryEditMode
        {
            get { return _directoryEditMode; }
            set
            {
                _directoryEditMode = value;
                OnPropertyChanged();
                DirectoryViewModel.EditMode = value;
            }
        }

        public int SpokeEditMode
        {
            get { return _spokeEditMode; }
            set
            {
                _spokeEditMode = value;
                OnPropertyChanged();
                SpokeViewModel.EditMode = value;
            }
        }

        public int Admin
        {
            get { return _admin; }
            set
            {
                _admin = value;
                OnPropertyChanged();
            }
        }

        public int ActiveUserID
        {
            get { return _activeUserId; }
            set
            {
                _activeUserId = value;
                OnPropertyChanged();
                if (value == 15)
                    Admin = 1;
                else
                    Admin = 0;
            }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public bool MireShowShutPopUp
        {
            get { return _mireShowShutPopUp; }
            set
            {
                _mireShowShutPopUp = value;
                OnPropertyChanged();
                MireViewModel.ShowShutPopUp = value;
            }
        }

        public bool LoginShowShutPopUp
        {
            get { return _loginShowShutPopUp; }
            set
            {
                _loginShowShutPopUp = value;
                OnPropertyChanged();
                LoginViewModel.ShowShutPopUp = value;
            }
        }

        public bool UserSettingsShowShutPopUp
        {
            get { return _userSettingsShowShutPopUp; }
            set
            {
                _userSettingsShowShutPopUp = value;
                OnPropertyChanged();
                UserSettingsViewModel.ShowShutPopUp = value;
            }
        }

        public bool DirectoryShowShutPopUp
        {
            get { return _directoryShowShutPopUp; }
            set
            {
                _directoryShowShutPopUp = value;
                OnPropertyChanged();
                DirectoryViewModel.ShowShutPopUp = value;
            }
        }

        public bool SpokeShowShutPopUp
        {
            get { return _spokeShowShutPopUp; }
            set
            {
                _spokeShowShutPopUp = value;
                OnPropertyChanged();
                SpokeViewModel.ShowShutPopUp = value;
            }
        }
        public ICommand SwitchScreenCommand { get; set; }
        public ICommand IntervalChangedCommand { get; set; }
        private void OnIntervalChanged()
        {
            int interval;
            if (int.TryParse(Interval, out interval))
                _dataTimer.Interval = TimeSpan.FromMilliseconds(interval);
        }

        public ICommand ChangeRoueCommand { get; set; }
        private void OnChangeRoue()
        {
            //short val = 1;
            ////var handle = _tcClient.CreateVariableHandle("Var_IHM.IHM.PA.Dde_Changement_roue");
            ////var handle = 10;
            //_tcClient.WriteAny(handle, val);
        }

        public ICommand PrintCommand { get; set; }
        public string ZPLLabelMaker(int iLine, string Data)
        {
            String sFS = "^FS";
            String sLine = iLine.ToString();
            return " ^FO10," + sLine + "^FD" + Data + sFS;
        }
        private void OnPrint()
        {
            //short val = 1;
            ////var handle = _tcClient.CreateVariableHandle("Var_IHM.IHM.PA.Print_sticker");
            //_tcClient.WriteAny(handle, val);
            String Printer = "ZD420";
            String Data = "E177272340618B3110A0000";
            String LblStart = "^XA";

            //Personalisation client pour exemple
            String lblLogo = "^FO60,60^GFA,1463,1463,19,gWFC::::gMFI0MFCgLF8I01LFCgKFEK07KFCgKF8K01KFCgKF001F800KFCgJFE01IF803JFCgJFC07IFE01JFCgJF80KF80JFCgJF03KFC0JFCgIFE07KFE07IFCgIFE0MF03IFCIFC01FE00PFC0FC1IFC07F83IFCIFC00FE00PFC0FC1IF807FC1IFCIFC00FC00PFC0F83IF007FC0IFCIFC00FC00PFC0F83FFC007FE0IFCIFC00FC00PFC0FF7FF8007FF0IFCIFC007C00FE07IF03FC0C1IFI07FF07FFCIFC007800F8I07C007CI07FCI07FF07FFCIFC007800FJ078003CI03F8I07FF07FFCIFC003800EJ07I01CI03FCI07FF87FFCIFC003I0CJ06J0CI01FCI07FF83FFCIFC003I0CJ04J0CI01FEI07FF83FFCIFC001I0803004030040201FFI07FF83FFCIFC001I080FC0407C040701FFI07FF83FFCIFC04J080FC040FE040F01FFI07FF83FFCIFC04008081FCI0IFC0F81FFI07FF83FFCIFC04008081FCI0IFC0F81FFI07FF87FFCIFC04008080FCI0FE0C0F81FFI07FF87FFCIFC06008080FC0407C040F81FFI07FF07FFCIFC060180807004038040F81FFI07FF07FFCIFC060180CJ04J0C0F81FFI07FF0IFCIFC070180CJ06J0C0F81FFI07FE0IFCIFC070380EJ07I01C0F81FFI07FE0IFCIFC070380FJ078003C0F81FFI07FC1IFCIFC070380F8I07C007C0F81FF003FFC1IFCIFE0F87C1FC060FF01FC0F83FF7JF83IFCgRF03IFCgJF03KFE07IFCgJF01KFC0JFCgJF80KF01JFCgJFC03IFC03JFCgJFE00IF007JFCgKF8L0KFCgKFCK03KFCgLFK0LFCgLFCI03LFCgMFC03MFCgWFC:::,:::gWFC::VF9gFCPFBF7EFE0DF26F98306F3NFCPFBE7C7CF9F66793FI67NFCPF9E7C79F9F647B3E7667NFCPF1C797BF9E6C3B3E670OFCPF1C7I3F806C9B060F1OFCOFE4A7033F9E6DC33E1F9OFCOFE426033FBE4DC37E9FBOFCOFEE64F9BFBECDE27ECF3OFCOFCEF5F98F3EC9F606CE7OFCOFDFF1FDC33ED9FE06E6PFCgWFC::^FS";
            String lblPolice = "^CFA,20";
            String lblTex1 = "^FO230,150^FDQRcode^FS";
            String lblQR = "^FO232,180^BQN,2,4^FDMM,A" + Data + "^FS";
            String lblTex2 = "^FO400,150^FDDataMatrix^FS";
            String lblDM = "^FO402,180^BXN,5,200^FD" + Data + "^FS";
            String lblTex3 = "^FO100,300^FDData:" + Data + "^FS";
            String lblSquare = "^FO50,50 ^GB500,300,6^FS";

            String LblEnd = "^XZ";
            String DataPrint = LblStart + lblLogo + lblPolice + lblTex1 + lblTex2 + lblQR + lblDM + lblTex3 + lblSquare + LblEnd;

            /*Demande Waifre
            -Numéro de la roue;
            -Nom de l’opérateur;
            -Date et heure;
            -Valeurs de voile, saut et déport;
            -Tension de tous les rayons;
            -Tension moyenne;
            -Tension minimum;
            -Tension maximum.*/
            lblPolice = "^CFA,22";
            String NumWheel = Data;
            String sFS = "^FS";
            String lblTexNumWheel = "^FO10,40^FDNumber: " + NumWheel + sFS;
            String Operator = "John Doe";
            String lblOperator = "^FO10,80^FDOperator: " + Operator + sFS;
            String Horodatage = "13/08/2020 14h18m05s";
            String lblHT = "^FO10,120^FDHt: " + Horodatage + sFS;
            String ValVoile = MireViewModel.RoueVoileVal.ToString("00.000");
            String ValSaut = MireViewModel.RoueSautVal.ToString("00.000");
            String ValDeport = MireViewModel.RoueDeportVal.ToString("00.000");
            String lblValRoue = "^FO10,160^FDSide: " + ValVoile + "  Jump: " + ValSaut + " Offset " + ValDeport + sFS;
            String SpokeLMin = MireViewModel.Rayon_Info0.ToString("00.000");
            String SpokeLMax = MireViewModel.Rayon_Info1.ToString("00.000");
            String SpokeLMoy = MireViewModel.RayonMin.ToString("00.000");
            String SpokeRMin = MireViewModel.Rayon_Info2.ToString("00.000");
            String SpokeRMax = MireViewModel.Rayon_Info3.ToString("00.000");
            String SpokeRMoy = MireViewModel.RayonMax.ToString("00.000");
            String lblSpokeL = "^FO10,200^FDSpoke Left Min: " + SpokeLMin + "  Max: " + SpokeLMax + " Avg: " + SpokeLMoy + sFS;
            String lblSpokeR = "^FO10,240^FDSpoke Right Min: " + SpokeRMin + "  Max: " + SpokeRMax + " Avg: " + SpokeRMoy + sFS;
            String[] TBLSpoke = { "44", "45", "43", "52", "48", "44", "44", "44", "44", "44", "45", "43", "52", "48", "44", "44", "44", "44", "44", "45", "43", "52", "48", "44", "44", "44", "44", "44", "45", "43", "52", "48", "44", "44", "44", "44", "44", "45", "43", "52", "48", "44", "47" };
            String lblSpoke0 = "^FO10,280^FDSpoke 1: " + TBLSpoke[0] + sFS;
            String lblSpoke1 = "^FO10,320^FDSpoke 2: " + TBLSpoke[1] + sFS;

            String[] TBLData = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            String[] TBLZPL = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int iLine = 10;
            int NbData = 42;
            int NbSpoke = MireViewModel.CellTensionRayon1.Count + MireViewModel.CellTensionRayon2.Count;
            int index = 0;
            string VarTension = "0.00";

            //Affectation des DATA
            TBLData[0] = "Number: " + TrackID;
            TBLData[1] = "Operator: " + UserName;
            TBLData[2] = "Date: " + DateTime.Now + sFS;
            TBLData[3] = "Side: " + ValVoile + "  Jump: " + ValSaut + " Offset: " + ValDeport;
            TBLData[4] = "Spoke Left Min: " + SpokeLMin + "  Max: " + SpokeLMax + " Avg: " + SpokeLMoy;
            TBLData[5] = "Spoke Right Min: " + SpokeRMin + "  Max: " + SpokeRMax + " Avg: " + SpokeRMoy;
            for (index = 1; index <= NbSpoke; index++)
            {
                VarTension = MireViewModel.TensionToPrint[index].ToString();

                TBLData[5 + index] = "Spoke" + index.ToString("00") + ": " + VarTension;
            }

            for (index = 0; index <= NbData; index++)
            {
                iLine = index * 35 + 30;
                TBLZPL[index] = ZPLLabelMaker(iLine, TBLData[index]);
            }
            DataPrint = LblStart +
                        lblPolice;
            for (index = 0; index <= NbData; index++)
            {
                DataPrint = DataPrint + TBLZPL[index];
            }
            DataPrint = DataPrint + LblEnd;
            /*     DataPrint = LblStart +
                             lblPolice +
                             lblTexNumWheel +
                             lblOperator+
                             lblHT +
                             lblValRoue +
                             lblSpokeL +
                             lblSpokeR +
                             lblSpoke0 +
                             lblSpoke1 +
                             LblEnd;*/
            try
            {
                RawPrinterHelper.SendStringToPrinter(Printer, DataPrint);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error printer" + Environment.NewLine + ex.ToString());
                return;
            }
            // try
            //  {

            //     Process.Start(@"c:\\mach1\\data\\Report.bat");
            //     }
            //     catch
            //     {
            //         MessageBox.Show("Could not find help file at C:\\mach1\\data\\Report.bat !");

            // Ods doc = new Ods("c:\\mach1\\data\\mdmreport.ods");
            // Ods.OoExe = @"C:\Program Files\OpenOffice 4\program\soffice.exe";
            //modify input fields

            //doc.Inputs["fieldname"] = "field value";

            //or

            //Ods.OdsCell cell = doc.Tables["1"]["AE42"];
            //for (int i = 0; i < cell.Column; i++)
            //{
            //    doc.Tables["1"][cell.Row, i].Value = i.ToString();
            //    doc.Tables["1"][cell.Row + 1, i].Value = i.ToString();
            //}                

            //doc.Save("Resources\\Report\\mdmreport1.ods");
            // doc.OpenInOo();

            // doc.Print();
            //  }
            // catch (Exception ex)
            {
                //   MessageBox.Show("Report template is not ready yet!" + Environment.NewLine + ex.ToString());
                //   return;
            }
        }

        public ICommand EditUsersCommand { get; set; }
        private void OnEditUsersCommand()
        {
            LoginEditMode = 1;
        }

        public ICommand EditSpokeCommand { get; set; }
        private void OnEditSpokeCommand()
        {
            if (SpokeEditMode == 1)
            {
                SpokeEditMode = 0;
                ////var handle = _tcClient.CreateVariableHandle("Var_IHM.IHM4.BP_CalibrationModif");
                ////var handle = 10;
                //_tcClient.WriteAny(handle, (short)0);
            }
            else
            {
                SpokeEditMode = 10;
                ////var handle = _tcClient.CreateVariableHandle("Var_IHM.IHM4.BP_CalibrationModif");
                ////var handle = 10;
                //_tcClient.WriteAny(handle, (short)1);
            }
        }

        public ICommand EditDirectoryCommand { get; set; }
        private void OnEditDirectoryCommand()
        {
            if (DirectoryEditMode == 0)
                DirectoryEditMode = 1;
            else
                DirectoryEditMode = 0;
        }

        public ICommand DeleteSpokeCommand { get; set; }
        private void OnDeleteSpokeCommand()
        {
            ////var handle = _tcClient.CreateVariableHandle("Var_IHM.IHM4.BP_DS_Delete");
            ////var handle = 10;
            //_tcClient.WriteAny(handle, (short)1);
            SpokeViewModel.refreshList = true;
            SpokeViewModel.refreshData = true;
            SpokeEditMode = 0;
        }

        public ICommand HelpCommand { get; set; }
        private void OnHelpCommand()
        {
            try
            {
                Process.Start(@"c:\\mach1\\ressource\\help.pdf");
            }
            catch
            {
                MessageBox.Show("Could not find help file at C:\\mach1\\ressource\\help.pdf !");
            }
        }

        public ICommand PrintScreenShutPopUpCommand { get; set; }
        public void OnPrintScreenShutPopUpCommand()
        {
            switch (CurrentScreen)
            {
                case EScreen.MireScreen:
                    MireShowShutPopUp = true;
                    break;
                case EScreen.LoginScreen:
                    LoginShowShutPopUp = true;
                    break;
                case EScreen.SettingsScreen:
                    UserSettingsShowShutPopUp = true;
                    break;
                case EScreen.DirectoryScreen:
                    DirectoryShowShutPopUp = true;
                    break;
                case EScreen.SpokeScreen:
                    SpokeShowShutPopUp = true;
                    break;
            }
        }

        /*ShutPopUpCommand { get; set; }
        private void OnPrintMireShutPopUpCommand()
        {
            MireShowShutPopUp = true;
        }

        public ICommand PrintLoginShutPopUpCommand { get; set; }
        private void OnPrintLoginShutPopUpCommand()
        {
            LoginShowShutPopUp = true;
        }

        public ICommand PrintUserSettingsShutPopUpCommand { get; set; }
        private void OnPrintUserSettingsShutPopUpCommand()
        {
            UserSettingsShowShutPopUp = true;
        }

        public ICommand PrintDirectoryShutPopUpCommand { get; set; }
        private void OnPrintDirectoryShutPopUpCommand()
        {
            DirectoryShowShutPopUp = true;
        }

        public ICommand PrintSpokeShutPopUpCommand { get; set; }
        private void OnPrintSpokeShutPopUpCommand()
        {
            SpokeShowShutPopUp = true;
        }*/

        /*public ICommand ShutPopUpOkCommand { get; set; }
        private void OnShutPopUpOkCommand()
        {
            Shutdown();
        }

        public ICommand ShutPopUpCancelCommand { get; set; }
        private void OnShutPopUpCancelCommand()
        {
            MireShowShutPopUp = false;
        }*/

        public MainWindowViewModel()
        {
            try
            {
                MireViewModel = new MireViewModel();
                MireViewModel._parent = this;

                LoginViewModel = new ViewModels.LoginViewModel();
                LoginViewModel._parent = this;

                UserSettingsViewModel = new UserSettingsViewModel();
                UserSettingsViewModel._parent = this;

                DirectoryViewModel = new DirectoryViewModel();
                DirectoryViewModel._parent = this;

                SpokeViewModel = new SpokeViewModel();
                SpokeViewModel._parent = this;
            }
            catch (Exception err)
            {
                MessageBox.Show("Erreur initialisation MireViewModel" + err.Message);
            }

            SwitchScreenCommand = new DelegateCommand<EScreen?>(OnSwitchScreen);
            IntervalChangedCommand = new DelegateCommand(OnIntervalChanged);
            ChangeRoueCommand = new DelegateCommand(OnChangeRoue);
            PrintCommand = new DelegateCommand(OnPrint);
            HelpCommand = new DelegateCommand(OnHelpCommand);

            EditUsersCommand = new DelegateCommand(OnEditUsersCommand);
            EditDirectoryCommand = new DelegateCommand(OnEditDirectoryCommand);
            EditSpokeCommand = new DelegateCommand(OnEditSpokeCommand);
            DeleteSpokeCommand = new DelegateCommand(OnDeleteSpokeCommand);

            PrintScreenShutPopUpCommand = new DelegateCommand(OnPrintScreenShutPopUpCommand);

            /*ShutPopUpOkCommand = new DelegateCommand(OnShutPopUpOkCommand);
            ShutPopUpCancelCommand = new DelegateCommand(OnShutPopUpCancelCommand);*/

            try
            {
                _tcClient = new TcAdsClient();
                _tcClient.Connect(851);
            }
            catch (Exception err)
            {
                MessageBox.Show("Erreur initialisation TcAdsClient et connexion" + err.Message);
            }

            try
            {
                //_hVar = _tcClient.CreateVariableHandle("Var_IHM.IHM");
                _hVar = 10;
                //_hVar_wheel_directory = _tcClient.CreateVariableHandle("Var_IHM.IHM3");
                _hVar_wheel_directory = 10;
                //_hVar_graph = _tcClient.CreateVariableHandle("Var_IHM.IHM2");
                _hVar_graph = 10;
                //_hVar_spoke = _tcClient.CreateVariableHandle("Var_IHM.IHM4");
                _hVar_spoke = 10;
            }
            catch (Exception err)
            {
                MessageBox.Show(" _hVar = _tcClient.CreateVariableHandle " + err.Message);
                //LogManager.GetCurrentClassLogger().Debug(err);
            }

            SetTwincatValue("Num_Refresh", (int)0);
            SetTwincatValue("PA_CalRefreshed", (int)0, 0, "IHM4.");

            //this commented part fills twincat graph data with random values
            //int[] xcirc = new int[2000];
            //int[] yvoil = new int[2000];
            //int[] ysaut = new int[2000];
            //Random rnd = new Random(DateTime.Now.Millisecond);
            //int lastValue1 = rnd.Next(600) - 300;
            //int lastValue2 = rnd.Next(600) - 300;
            //for (int i = 0; i < 2000; i++)
            //{
            //    xcirc[i] = (int)(i * 1.5);

            //    yvoil[i] = lastValue1;
            //    if (rnd.Next() % 2 == 0)
            //        lastValue1++;
            //    else
            //        lastValue1--;

            //    ysaut[i] = lastValue2;
            //    if (rnd.Next() % 2 == 0)
            //        lastValue2++;
            //    else
            //        lastValue2--;
            //}
            //var hArr = _tcClient.CreateVariableHandle("Var_IHM.IHM2.xCirc");
            //_tcClient.WriteAny(hArr, xcirc);
            //var hArr2 = _tcClient.CreateVariableHandle("Var_IHM.IHM2.yVoile");
            //_tcClient.WriteAny(hArr2, yvoil);
            //var hArr3 = _tcClient.CreateVariableHandle("Var_IHM.IHM2.ySaut");
            //_tcClient.WriteAny(hArr3, ysaut);
            //Environment.Exit(0);

            //_vri = new VoltageRatioInput();

            int iResult = 0;
            ////var handle = _tcClient.CreateVariableHandle("Config.Num_Serial_Phidget");
            // //var handle = 10;
            //string sResult = _tcClient.ReadAny(handle, typeof(int)).ToString();
            string sResult = "10";
            bool bParse = int.TryParse(sResult, out iResult);
           // _vri.DeviceSerialNumber = iResult;//583344;//548546;

           // _vri.Channel = 2;

            try
            {
           //     _vri.Open(5000);
           //     _vri.Attach += attach;
            }
            catch (PhidgetException e)
            {
                SetTwincatValue("Load_Cell", (float)-10000);
            }

            Interval = "50";
            _dataTimer = new DispatcherTimer();
            _dataTimer.Interval = TimeSpan.FromMilliseconds(50);
            _dataTimer.Tick += DataTimerOnTick;
            _dataTimer.Start();

            CurrentRegion = MireViewModel;
        }

        private void OnSwitchScreen(EScreen? obj)
        {
            //System.Console.WriteLine("Début OnSwitchScreen : {0:HH:mm:ss.fff}", System.DateTime.Now);
            if (CurrentScreen == EScreen.SpokeScreen && obj.HasValue && obj.Value == EScreen.MireScreen)
            {
                SpokeEditMode = 0;
                CurrentScreen = EScreen.DirectoryScreen;
                CurrentRegion = DirectoryViewModel;
                return;
            }

            LoginViewModel.EditUserId = 0;
            LoginEditMode = 0;
            DirectoryEditMode = 0;

            if (obj.HasValue)
            {
                CurrentScreen = obj.Value;
                if (MireViewModel.ChartTypeTension == 1)
                {
                    System.Console.WriteLine("TensionChart Off : {0:HH:mm:ss.fff}", System.DateTime.Now);
                    MireViewModel.ChartTypeTension = 0;
                    MireViewModel.ChartType = MireViewModel._actualChart;
                    Properties.Settings.Default["SettingsChartType"] = MireViewModel._actualChart;
                    Properties.Settings.Default.Save();
                }
                switch (obj.Value)
                {
                    case EScreen.DirectoryScreen:
                        //System.Console.WriteLine("Début appel DirectoryScreen : {0:HH:mm:ss.fff}", System.DateTime.Now);
                        CurrentRegion = DirectoryViewModel;
                        //System.Console.WriteLine("  Fin appel DirectoryScreen : {0:HH:mm:ss.fff}", System.DateTime.Now);
                        break;
                    case EScreen.SettingsScreen:
                        CurrentRegion = UserSettingsViewModel;
                        break;
                    case EScreen.ShutdownScreen:
                        //Shutdown();
                        break;
                    case EScreen.MireScreen:
                        CurrentRegion = MireViewModel;
                        MireViewModel.RefreshLayout();
                        break;
                    case EScreen.LoginScreen:
                        CurrentRegion = LoginViewModel;
                        break;
                }
            }
            //System.Console.WriteLine("  Fin OnSwitchScreen : {0:HH:mm:ss.fff}", System.DateTime.Now);
        }

        public void OpenSpokeScreen()
        {
            CurrentScreen = EScreen.SpokeScreen;
            CurrentRegion = SpokeViewModel;
        }

        public void CloseSpokeScreen(bool refresh)
        {
            CurrentScreen = EScreen.DirectoryScreen;
            CurrentRegion = DirectoryViewModel;
            if (refresh)
                DirectoryViewModel.refreshFR = true;
        }

        private void DataTimerOnTick(object sender, EventArgs eventArgs)
        {
            _dataTimer.Stop();

            try
            {
                // DUT_IHM RED = new DUT_IHM();
                //  var ihm = RED;

                // DUT_PA pa = ihm.PA;  // Retrieve the AP property

                // Assigning the value "Prince" to the Operator_ID field
                //   pa.Operator_ID = 15;

                //  ihm.PA = pa;  // Assign the modified AP property back to RED


                var ihm = MyVariable;


                // var tcStruct = _tcClient.ReadAny(_hVar, typeof(DUT_IHM));
                //   Console.WriteLine(tcStruct);

                // var ihm = (DUT_IHM)tcStruct;  

                ActiveUserID = ihm.PA.Operator_ID;
                if (CurrentRegion != MireViewModel)
                {
                    MireViewModel.ModeMesureTension = 0;
                    SetTwincatValue("ModeMesureTension", 0);
                }

                if (CurrentRegion == MireViewModel)
                {
                    FicheRoueName = ihm.AP.Fiche_Roue_Name;
                    TrackID = ihm.AP.TrackID;
                    RoueAV = ihm.AP.Mode_Roue_Arriere;
                    MireViewModel.Refresh(ihm.AP, ihm.PA);
                    SetLabelUserID(ActiveUserID, ihm.PA);
                    /*if (MireViewModel.ChartType == 3)
                    {
                        MireViewModel.RefreshTensionChart();
                    }*/
                }
                else if (CurrentRegion == LoginViewModel)
                {
                    FicheRoueName = MireWpf.Properties.Resources.LogTitle;
                    RoueAV = 0;
                    LoginViewModel.Refresh(ihm.AP, ihm.PA);
                }
                else if (CurrentRegion == UserSettingsViewModel)
                {
                    FicheRoueName = MireWpf.Properties.Resources.USTitle;
                    RoueAV = 0;
                    UserSettingsViewModel.Refresh(ihm.PA);
                }
                else if (CurrentRegion == DirectoryViewModel)
                {
                    FicheRoueName = MireWpf.Properties.Resources.DirTitle;
                    RoueAV = 0;
                    DirectoryViewModel.Refresh(ihm.AP, ihm.PA);
                }
                else if (CurrentRegion == SpokeViewModel)
                {
                    FicheRoueName = MireWpf.Properties.Resources.SPTitle;
                    RoueAV = 0;

                    if (SpokeViewModel.DmdCalibRun == 1)
                    {
                        try
                        {
                            SetTwincatValue("Load_Cell", (float)((_vri.VoltageRatio - 0.000027) / 0.00001029));
                        }
                        catch (PhidgetException e)
                        {
                            if (ihm.PA.Load_Cell == -10000)
                            {
                                try
                                {
                                    _vri.Open(5000);
                                    _vri.Attach += attach;
                                }
                                catch (PhidgetException ex)
                                {
                                    SetTwincatValue("Load_Cell", (float)-10000);
                                    //   MessageBox.Show(" Error Phidget :  " + ex);
                                }
                            }
                            else
                            {
                                SetTwincatValue("Load_Cell", (float)-10001);
                                //  MessageBox.Show(" Error Phidget 2 " + e);
                            }
                        }
                    }

                    SpokeViewModel.Refresh();
                }
            }
            catch (Exception err)
            {
                LogManager.GetCurrentClassLogger().Debug(err);

            }

            //     _dataTimer.Start();
        }

        public DUT_IHM_AP_Curves? GetGraphData()
        {
            try
            {
                var tcStruct = _tcClient.ReadAny(_hVar_graph, typeof(DUT_IHM_AP_Curves));
                return (DUT_IHM_AP_Curves)tcStruct;
            }
            catch (Exception err)
            {
                LogManager.GetCurrentClassLogger().Debug(err);
            }
            return null;
        }

        public DUT_IHM_AP_List_Recipe? GetDirectoryData()
        {
            try
            {
                var tcStruct = _tcClient.ReadAny(_hVar_wheel_directory, typeof(DUT_IHM_AP_List_Recipe));
                return (DUT_IHM_AP_List_Recipe)tcStruct;
            }
            catch (Exception err)
            {
                LogManager.GetCurrentClassLogger().Debug(err);
            }
            return null;
        }

        public DUT_IHM_DataSpoke? GetSpokeData()
        {
            try
            {
                var tcStruct = _tcClient.ReadAny(_hVar_spoke, typeof(DUT_IHM_DataSpoke));
                return (DUT_IHM_DataSpoke)tcStruct;
            }
            catch (Exception err)
            {
                LogManager.GetCurrentClassLogger().Debug(err);
            }
            return null;
        }

        public void SelectUser(string userId)
        {
            if (userId != null)
            {
                short val = 1;
                if (short.TryParse(userId, out val))
                {
                    ////var handle = _tcClient.CreateVariableHandle("Var_IHM.IHM.PA.Operator_ID");
                    // //var handle = 10;
                    //_tcClient.WriteAny(handle, val);
                  DUT_PA pa = MyVariable.PA;
                    pa.Operator_ID = val;
                }
            }

            if (userId == "15")
            {
                Admin = 1;
                DirectoryViewModel.Admin = true;
                SpokeViewModel.Admin = true;
                LoginViewModel.Admin = true;
            }
            else
            {
                Admin = 0;
                DirectoryViewModel.Admin = false;
                SpokeViewModel.Admin = false;
                LoginViewModel.Admin = false;
            }

            CurrentRegion = MireViewModel;
            CurrentScreen = EScreen.MireScreen;
        }

        public void SaveUserName(int userId, string userName)
        {
            string var = "Var_IHM.IHM.PA.ID_Name" + userId.ToString().PadLeft(2, '0');
            // //var handle = _tcClient.CreateVariableHandle("MAIN.handle") ;
            // //var handle = 10;

            // AdsStream adsStream = new AdsStream(20);
            // AdsBinaryWriter writer = new AdsBinaryWriter(adsStream);
            // writer.WritePlcString(userName, 20);
            // _tcClient.Write(handle, adsStream);
          

        }

        public void SaveParamLabel(int labelId, string labelName)
        {
            string var = "Var_IHM.IHM.PA.ParamLabel0" + labelId.ToString();
            ////var handle = _tcClient.CreateVariableHandle(var);
            // //var handle = 10;

            // AdsStream adsStream = new AdsStream(20);
            //  AdsBinaryWriter writer = new AdsBinaryWriter(adsStream);
            //  writer.WritePlcString(labelName, 20);
            // _tcClient.Write(handle, adsStream);
        }

        public void SaveParamData(int dataID, string dataContent)
        {
            string var = "Var_IHM.IHM.PA.ParamData0" + dataID.ToString();
            ////var handle = _tcClient.CreateVariableHandle(var);
            // //var handle = 10;

            // AdsStream adsStream = new AdsStream(20);
            // AdsBinaryWriter writer = new AdsBinaryWriter(adsStream);
            // writer.WritePlcString(dataContent, 20);
            //  _tcClient.Write(handle, adsStream);
        }

        public void Shutdown()
        {
            //short val = 1;
            ////var handle = _tcClient.CreateVariableHandle("Var_IHM.IHM.PA.dde_ShutDown");
            //var handle = 10;
            //_tcClient.WriteAny(handle, val);
            Application.Current.Shutdown();
        }

        public void SetActiveWheelId(short value)
        {
            //var handle = _tcClient.CreateVariableHandle("Var_IHM.IHM.PA.FS_Selecteur_FR");

            //_tcClient.WriteAny(handle, value);
            DUT_PA pa = MyVariable.PA;
            pa.FS_Selecteur_FR = Convert.ToUInt16(value);
        }

        public void SetActiveSpokeId(short value)
        {
            ////var handle = _tcClient.CreateVariableHandle("Var_IHM.IHM4.SpokeDataSelector");

            //_tcClient.WriteAny(handle, value);
           

        }

        public void SetSelecteurRayon(string parameter)
        {
            if (parameter == "-")
            {
                ////var handle = _tcClient.CreateVariableHandle("Var_IHM.IHM.PA.Selecteur_Rayon_DEC");

                //_tcClient.WriteAny(handle, (short)1);
                DUT_PA pa = MyVariable.PA;
                pa.Selecteur_Rayon_DEC = 1;
            }
            else if (parameter == "+")
            {
                ////var handle = _tcClient.CreateVariableHandle("Var_IHM.IHM.PA.Selecteur_Rayon_INC");
              
                //_tcClient.WriteAny(handle, (short)1);

                DUT_PA pa = MyVariable.PA;
                pa.Selecteur_Rayon_DEC = 1;
            }
            else
            {
                short val = 0;
                short.TryParse(parameter, out val);
                ////var handle = _tcClient.CreateVariableHandle("Var_IHM.IHM.PA.Selecteur_Rayon");

                //_tcClient.WriteAny(handle, val);
                DUT_PA pa = MyVariable.PA;
                pa.Selecteur_Rayon_DEC = val;
            }
            if (parameter == "A")
            {
                ////var handle = _tcClient.CreateVariableHandle("Var_IHM.IHM.PA.Selecteur_Rayon_Auto");

                //_tcClient.WriteAny(handle, (short)1);
                DUT_PA pa = MyVariable.PA;
                pa.Selecteur_Rayon_DEC = 1;
            }
        }

        public void SetTwincatValue<T>(string parameterName, T value, int stringSize = 0, string IHMFrameName = "IHM.PA.")
        {
            if (typeof(T) == typeof(string))
            {
                ////var handle = _tcClient.CreateVariableHandle("Var_IHM." + IHMFrameName + parameterName);
                //     //var handle = 10;
                //  AdsStream adsStream = new AdsStream(stringSize);
                //  AdsBinaryWriter writer = new AdsBinaryWriter(adsStream);
                //     writer.WritePlcString(value.ToString(), stringSize);
                //    _tcClient.Write(handle, adsStream);
              

            }
            else if (typeof(T) == typeof(int) || typeof(T) == typeof(short))
            {
                short val = 0;
                short.TryParse(value.ToString(), out val);
                ////var handle = _tcClient.CreateVariableHandle("Var_IHM." + IHMFrameName + parameterName);
                //var handle = 10;
                //_tcClient.WriteAny(handle, val);
            }
            else if (typeof(T) == typeof(float))
            {
                float val = (float)(object)value;
                ////var handle = _tcClient.CreateVariableHandle("Var_IHM." + IHMFrameName + parameterName);
                //var handle = 10;
                //_tcClient.WriteAny(handle, val);
            }
        }

        public void SetPrintDataSheet()
        {

            ////var handle = _tcClient.CreateVariableHandle("Var_IHM.IHM.PA.Print_DataSheet");

            //_tcClient.WriteAny(handle, val);

        }

        public void SetIDValue(string IDValue)
        {
            ////var handle = _tcClient.CreateVariableHandle("Var_IHM.IHM.PA.IDValue");

            //  AdsStream adsStream = new AdsStream(20);
            //  AdsBinaryWriter writer = new AdsBinaryWriter(adsStream);
            //writer.WritePlcString(IDValue, 20);
            //   _tcClient.Write(handle, adsStream);
            DUT_PA pa = MyVariable.PA;
            pa.IDValue = IDValue;
        }
        public void SetLabelUserID(int ActiveuserId, DUT_PA pa)
        {
            switch (ActiveuserId)
            {
                case 0: UserName = ""; break;
                case 1: UserName = pa.ID_Name01; break;
                case 2: UserName = pa.ID_Name02; break;
                case 3: UserName = pa.ID_Name03; break;
                case 4: UserName = pa.ID_Name04; break;
                case 5: UserName = pa.ID_Name05; break;
                case 6: UserName = pa.ID_Name06; break;
                case 7: UserName = pa.ID_Name07; break;
                case 8: UserName = pa.ID_Name08; break;
                case 9: UserName = pa.ID_Name09; break;
                case 10: UserName = pa.ID_Name10; break;
                case 11: UserName = pa.ID_Name11; break;
                case 12: UserName = pa.ID_Name12; break;
                case 13: UserName = pa.ID_Name13; break;
                case 14: UserName = pa.ID_Name14; break;
                case 15: UserName = pa.ID_Name15; break;
            }
        }

        public void SetPrintIDPopUp()
        {

            ////var handle = _tcClient.CreateVariableHandle("Var_IHM.IHM.PA.Print_IDPopUp");

            //_tcClient.WriteAny(handle, val);
           
        }

        //Declare the event handler
        void attach(object sender, Phidget22.Events.AttachEventArgs e)
        {
            //You can access the Phidget that fired the event by typecasting "sender"
            //to the appropriate Phidget object type.
            //Replace "DigitalInput" with the object for your Phidget.
            VoltageRatioInput ph = ((VoltageRatioInput)sender);
            int deviceSerial = ph.DeviceSerialNumber;
        }

        DUT_IHM MyVariable = new DUT_IHM
        {

        };
        



    }


}
