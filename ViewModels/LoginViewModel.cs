using MireWpf.Models;
using Prism.Commands;
using System.Windows.Controls;
using System.Windows;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Input;

namespace MireWpf.ViewModels
{

    public class LoginViewModel : BaseViewModel, IRegion
    {
        #region parameters
        private string _username01;
        private string _username02;
        private string _username03;
        private string _username04;
        private string _username05;
        private string _username06;
        private string _username07;
        private string _username08;
        private string _username09;
        private string _username10;
        private string _username11;
        private string _username12;
        private string _username13;
        private string _username14;
        private string _username15;
        private int _editMode = 0;
        private int _editUserId = 0;
        private string _editUserName = "";
        private bool _showPasswordWindow = false;
        private bool _showPasswordError = false;
        private string _passwordEntered = "";
        private string _passwordCorrect = "1234";
        private bool _admin = false;
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

        public bool ShowPasswordWindow
        {
            get { return _showPasswordWindow; }
            set
            {
                _showPasswordWindow = value;
                OnPropertyChanged();
            }
        }

        public bool ShowPasswordError
        {
            get { return _showPasswordError; }
            set
            {
                _showPasswordError = value;
                OnPropertyChanged();
            }
        }

        public string PasswordEntered
        {
            get { return _passwordEntered; }
            set
            {
                _passwordEntered = value;
                OnPropertyChanged();
            }
        }

        public string PasswordCorrect
        {
            get { return _passwordCorrect; }
            set
            {
                _passwordCorrect = value;
                OnPropertyChanged();
            }
        }

        public string Username01
        {
            get { return _username01; }
            set
            {
                _username01 = value;
                OnPropertyChanged();
            }
        }

        public string Username02
        {
            get { return _username02; }
            set
            {
                _username02 = value;
                OnPropertyChanged();
            }
        }

        public string Username03
        {
            get { return _username03; }
            set
            {
                _username03 = value;
                OnPropertyChanged();
            }
        }

        public string Username04
        {
            get { return _username04; }
            set
            {
                _username04 = value;
                OnPropertyChanged();
            }
        }

        public string Username05
        {
            get { return _username05; }
            set
            {
                _username05 = value;
                OnPropertyChanged();
            }
        }

        public string Username06
        {
            get { return _username06; }
            set
            {
                _username06 = value;
                OnPropertyChanged();
            }
        }

        public string Username07
        {
            get { return _username07; }
            set
            {
                _username07 = value;
                OnPropertyChanged();
            }
        }

        public string Username08
        {
            get { return _username08; }
            set
            {
                _username08 = value;
                OnPropertyChanged();
            }
        }

        public string Username09
        {
            get { return _username09; }
            set
            {
                _username09 = value;
                OnPropertyChanged();
            }
        }

        public string Username10
        {
            get { return _username10; }
            set
            {
                _username10 = value;
                OnPropertyChanged();
            }
        }

        public string Username11
        {
            get { return _username11; }
            set
            {
                _username11 = value;
                OnPropertyChanged();
            }
        }

        public string Username12
        {
            get { return _username12; }
            set
            {
                _username12 = value;
                OnPropertyChanged();
            }
        }

        public string Username13
        {
            get { return _username13; }
            set
            {
                _username13 = value;
                OnPropertyChanged();
            }
        }

        public string Username14
        {
            get { return _username14; }
            set
            {
                _username14 = value;
                OnPropertyChanged();
            }
        }

        public string Username15
        {
            get { return _username15; }
            set
            {
                _username15 = value;
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

        public int EditUserId
        {
            get { return _editUserId; }
            set
            {
                _editUserId = value;
                OnPropertyChanged();
            }
        }

        public string EditUserName
        {
            get { return _editUserName; }
            set
            {
                _editUserName = value;
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

        public ICommand SelectUserCommand { get; set; }
        private void OnSelectUserCommand(string userId)
        {
            if (EditMode == 1)
            {
                if (userId != null)
                {
                    int val = 0;
                    if (int.TryParse(userId, out val))
                        SetEditUser(val);
                }
            }
            else
            {
                if (userId == "15")
                {
                    ShowPasswordWindow = true;
                    ShowPasswordError = false;
                }
                else
                    _parent.SelectUser(userId);
            }
        }

        public ICommand SaveUserNameCommand { get; set; }
        private void OnSaveUserNameCommand(string userName)
        {
            _parent.SaveUserName(EditUserId, userName);
            switch (EditUserId)
            {
                case 1: Username01 = userName; break;
                case 2: Username02 = userName; break;
                case 3: Username03 = userName; break;
                case 4: Username04 = userName; break;
                case 5: Username05 = userName; break;
                case 6: Username06 = userName; break;
                case 7: Username07 = userName; break;
                case 8: Username08 = userName; break;
                case 9: Username09 = userName; break;
                case 10: Username10 = userName; break;
                case 11: Username11 = userName; break;
                case 12: Username12 = userName; break;
                case 13: Username13 = userName; break;
                case 14: Username14 = userName; break;
                case 15: Username15 = userName; break;
            }
            _parent.LoginEditMode = 0;
        }

        public ICommand ShutdownCommand { get; set; }
        private void OnShutdownCommand()
        {
            _parent.Shutdown();
        }

        public ICommand PasswordOkCommand { get; set; }
        private void OnPasswordOkCommand()
        {
            if (PasswordEntered == PasswordCorrect)
            {
                _parent.SelectUser("15");
                PasswordEntered = "";
                ShowPasswordWindow = false;
                ShowPasswordError = false;
            }
            else
            {
                ShowPasswordError = true;
                PasswordEntered = "";
            }
        }

        public ICommand PasswordCancelCommand { get; set; }
        private void OnPasswordCancelCommand()
        {
            PasswordEntered = "";
            ShowPasswordWindow = false;
            ShowPasswordError = false;            
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

        public MainWindowViewModel _parent;
        private bool firstRefresh = true;

        public LoginViewModel()
        {
            SelectUserCommand = new DelegateCommand<string>(OnSelectUserCommand);
            SaveUserNameCommand = new DelegateCommand<string>(OnSaveUserNameCommand);
            //ShutdownCommand = new DelegateCommand(OnShutdownCommand);
            PasswordOkCommand = new DelegateCommand(OnPasswordOkCommand);
            PasswordCancelCommand = new DelegateCommand(OnPasswordCancelCommand);

            PrintShutPopUpCommand = new DelegateCommand(OnPrintShutPopUpCommand);

            ShutPopUpOkCommand = new DelegateCommand(OnShutPopUpOkCommand);
            ShutPopUpCancelCommand = new DelegateCommand(OnShutPopUpCancelCommand);
        }

        public void Refresh(DUT_AP ap, DUT_PA pa)
        {
            if (firstRefresh)
            {
                Username01 = pa.ID_Name01;
                Username02 = pa.ID_Name02;
                Username03 = pa.ID_Name03;
                Username04 = pa.ID_Name04;
                Username05 = pa.ID_Name05;
                Username06 = pa.ID_Name06;
                Username07 = pa.ID_Name07;
                Username08 = pa.ID_Name08;
                Username09 = pa.ID_Name09;
                Username10 = pa.ID_Name10;
                Username11 = pa.ID_Name11;
                Username12 = pa.ID_Name12;
                Username13 = pa.ID_Name13;
                Username14 = pa.ID_Name14;
                Username15 = pa.ID_Name15;
                PasswordCorrect = ap.PWD_Admin.ToString();
                firstRefresh = false;
            }
        }

        public void SetEditUser(int userId)
        {
            EditUserId = userId;
            switch (userId)
            {
                case 0: EditUserName = ""; break;
                case 1: EditUserName = Username01; break;
                case 2: EditUserName = Username02; break;
                case 3: EditUserName = Username03; break;
                case 4: EditUserName = Username04; break;
                case 5: EditUserName = Username05; break;
                case 6: EditUserName = Username06; break;
                case 7: EditUserName = Username07; break;
                case 8: EditUserName = Username08; break;
                case 9: EditUserName = Username09; break;
                case 10: EditUserName = Username10; break;
                case 11: EditUserName = Username11; break;
                case 12: EditUserName = Username12; break;
                case 13: EditUserName = Username13; break;
                case 14: EditUserName = Username14; break;
                case 15: EditUserName = Username15; break;
            }
        }
       
    }
}
