using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVVM_Template.Commands;
using WPF_MVVM_Template.EventArgs;
using GalaSoft.MvvmLight.Messaging;
using System.Text.RegularExpressions;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace WPF_MVVM_Template.ViewModel
{
    public class MainUIViewModel : INotifyPropertyChanged, IDataErrorInfo
    {

        
        public RelayCommand FormLoadedCommand { get; set; }
        public RelayCommand CommandBtnClick1 { get; set; }
        public RelayCommand CommandBtnClick2 { get; set; }
        public RelayCommand CommandBtnClick3 { get; set; }
        private string mainUI_BackGround { get; set; }
        private string customerName { get; set; }
        private double amount { get; set; }

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();


        public MainUIViewModel()
        {       
            FormLoadedCommand = new RelayCommand(ExecuteFormLoadedCommand);           
            Messenger.Default.Register<SettingConfirmedEventArgs>(this, OnSettingConfirmed);
            Messenger.Default.Register<SelectedEventArgs>(this, OnSelected);


            CommandBtnClick1 = new RelayCommand(ExecuteCommandBtnClick1);
            CommandBtnClick2 = new RelayCommand(ExecuteCommandBtnClick2);
            CommandBtnClick3 = new RelayCommand(ExecuteCommandBtnClick3);
        }

        private void ExecuteCommandBtnClick1(object obj)
        {
            MainUIBackGround = "Green";
            //string strObj = obj?.ToString();
            //switch(strObj)
            //{
            //    case "BtnClick1": MainUIBackGround = "Green";                    
            //        break;
            //    case "": MessageBox.Show("Clicked Null");  break;
            //}

        }

        private void ExecuteCommandBtnClick2(object obj)
        {
            Messenger.Default.Send(new SettingConfirmedEventArgs("1"));
            //string strObj = obj?.ToString();
            //switch (strObj)
            //{
            //    case "BtnClick2":
            //        Messenger.Default.Send(new SettingConfirmedEventArgs("1"));
            //        break;
            //    case "": MessageBox.Show("Clicked Null"); break;
            //}

        }

        private void ExecuteCommandBtnClick3(object obj)
        {
            Messenger.Default.Send(new SelectedEventArgs());
            //string strObj = obj?.ToString();
            //switch(strObj)
            //{
            //    case "BtnClick1": MainUIBackGround = "Green";                    
            //        break;
            //    case "": MessageBox.Show("Clicked Null");  break;
            //}

        }

        private void ExecuteFormLoadedCommand(Object obj)
        {
            MainUIBackGround = "Gray";
        }


        public  string MainUIBackGround
        {
            get { return mainUI_BackGround; }
            set { mainUI_BackGround = value; OnPropertyChanged(); }
        }


        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; OnPropertyChanged(); }
        }
        public double Amount
        {
            get { return amount; }
            set { amount = value; OnPropertyChanged(); }
        }




        private void OnSettingConfirmed(SettingConfirmedEventArgs obj)
        {
            MainUIBackGround = "Blue"; 
        }

        
        private void OnSelected(SelectedEventArgs obj)
        {
            MainUIBackGround = "Yellow";
            MessageBox.Show("");
           // var resourceStringMap = ResourceManager.Current.MainResourceMap.GetSubtree("Resources");
            ResourceManager rm = new ResourceManager("UsingRESX.Resource1",Assembly.GetExecutingAssembly());
            String strWebsite = rm.GetString("Title", CultureInfo.CurrentCulture);
        }

        public void CloseMainUI()
        {

            Messenger.Default.Unregister<SettingConfirmedEventArgs>(this);
            Messenger.Default.Unregister<SelectedEventArgs>(this);

        }

        // IDataErrorInfo default
        //public string Error => throw new NotImplementedException();
        //public string this[string columnName] => throw new NotImplementedException();


        // Data Validation with the help of IDataErrorInfo
        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch (columnName)
                {
                    case "CustomerName":
                        if (string.IsNullOrEmpty(CustomerName))
                        {
                            result = "Name Required field";
                        }
                        else if (!Regex.IsMatch(CustomerName, @"^[a-zA-Z]+$"))
                        {
                            result = "Should enter alphabets only!!!";
                        }

                        break;
                    case "Amount":                       
                        if (!Regex.IsMatch(Amount.ToString(), @"^[0-9]+$"))
                        {
                            result = "Should enter alphabets only!!!";
                        }
                        else if (string.IsNullOrEmpty(Amount.ToString()))
                        {
                            result = "Amount Required field";
                        }
                        break;

                }
               if (ErrorCollection.ContainsKey(columnName))
                    ErrorCollection[columnName] = result;
                else if (result != null)
                    ErrorCollection.Add(columnName, result);
                OnPropertyChanged("ErrorCollection");

                return result;
            }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }


        // INotifyPropertyChanged default
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
