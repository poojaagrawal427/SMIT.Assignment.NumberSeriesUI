using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Mime;
using System.Text;
using System.Windows;


namespace SMIT.Assignment.Numbers
{
    public class NumberModel : DependencyObject
    {
        public static NumberModel Instance { get; private set; }

        static NumberModel()
        {
            if (Instance == null)
                Instance = new NumberModel();
        }


        private ObservableCollection<string> _series = new ObservableCollection<string>();
        public ObservableCollection<string> Series
        {
            get { return this.Dispatcher.Invoke(() => (ObservableCollection<string>)GetValue(SeriesProperty)); }
            set
            {
                this.Dispatcher.Invoke(() =>
                    {
                        if (value != null && value.Count > 0)
                        {
                            _series.Add(value[0]);
                        }
                        else
                        {
                            _series = new ObservableCollection<string>();

                        }
                        SetValue(SeriesProperty, _series);
                    }
                );
            }
        }

        public static readonly DependencyProperty SeriesProperty =
            DependencyProperty.Register("Series", typeof(ObservableCollection<string>), typeof(NumberModel), new PropertyMetadata(new ObservableCollection<string>() { "Series" }));

    }
}
