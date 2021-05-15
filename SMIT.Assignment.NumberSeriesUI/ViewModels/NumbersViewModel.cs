using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Input;
using SMIT.Assignment.Numbers;
using SMIT.Assignment.NumberSeriesUI.BaseClass;

namespace SMIT.Assignment.NumberSeriesUI.ViewModels
{
    public class NumbersViewModel : ViewModelBase
    {
        private INumbers numberObj;
        ThreadStart generateThreadStart = null;
        Thread generateThread = null;


        private long _Number;

        public long Number
        {
            get { return _Number; }
            set
            {
                _Number = value;
                RaisePropertyChanged("Number");
            }

        }

        private bool _IsEnabled;

        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set
            {
                _IsEnabled = value;
                RaisePropertyChanged("IsEnabled");
            }

        }


        private ObservableCollection<string> _Series;

        public ObservableCollection<string> Series
        {
            get { return _Series; }
            set
            {
                _Series = value;
                RaisePropertyChanged("Series");
            }
        }

        private ICommand _generateCommand;
        public ICommand GenerateCommand
        {
            get
            {
                if (_generateCommand == null)
                {
                    _generateCommand = new RelayCommand(Generate);
                }
                return _generateCommand;
            }
        }



        public NumbersViewModel()
        {
            numberObj = new Numbers.Numbers();
            generateThreadStart = new ThreadStart(InvokeCalibrationProcess);
            IsEnabled = true;
        }

        private void InvokeCalibrationProcess()
        {
            numberObj.GenerateSeries(Number);
            IsEnabled = true;
        }

        private void Generate(object obj)
        {
            generateThread = new Thread(generateThreadStart);
            generateThread.Start();
            NumberModel.Instance.Series = new ObservableCollection<string>();
            IsEnabled = false;
        }




    }
}
