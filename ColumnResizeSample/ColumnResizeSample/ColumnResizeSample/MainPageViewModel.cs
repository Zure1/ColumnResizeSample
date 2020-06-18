using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ColumnResizeSample
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isLongData;
        public ICommand ChangeDataCommand { get; set; }

        private List<string> _shortDataList;
        private List<string> _longDataList;

        private ObservableCollection<string> _myList;
        public ObservableCollection<string> MyList
        {
            get { return _myList; }
            set
            {
                if (_myList != value)
                {
                    _myList = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyList"));
                }
            }
        }

        public MainPageViewModel()
        {
            _shortDataList = new List<string>()
            {
                "abcee",
                "abc",
                "abc",
                "abc",
                "abc",
                "abcg",
                "abc",
                "abc",
                "abc",
                "abc",
            };

            _longDataList = new List<string>()
            {
                "long text 123",
                "long text 1231231123123",
                "long text 123",
                "long text 123",
                "long text 123",
                "long text 123",
                "long t 123",
                "long text 123",
                "long text 1231111",
                "long text 123"
            };

            ChangeDataCommand = new Command(
                execute: () =>
                {
                    MessagingCenter.Send(this, "ResetColSize");

                    if (_isLongData)
                    {
                        MyList = new ObservableCollection<string>(_shortDataList);
                        _isLongData = false;
                    }
                    else
                    {
                        MyList = new ObservableCollection<string>(_longDataList);
                        _isLongData = true;
                    }
                });

            MyList = new ObservableCollection<string>(_shortDataList);
        }
    }
}
