using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ColumnResizeSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private double _colSize = 0.0;
        private List<ColumnDefinition> _columns = new List<ColumnDefinition>();

        public MainPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<MainPageViewModel>(this, "ResetColSize", (sender) =>
            {
                _colSize = 0.0;
            });
        }

        private void Label_Value_SizeChanged(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var label = (Label)sender;
                var grid = (Grid)label.Parent;
                var column = grid.ColumnDefinitions[0];
                if (!_columns.Contains(column))
                {
                    _columns.Add(column);
                }
                var adjustments = new List<ColumnDefinition>();
                if (label.Width > _colSize)
                {
                    _colSize = label.Width;
                    adjustments.AddRange(_columns);
                }
                else
                {
                    adjustments.Add(column);
                }
                foreach (var col in adjustments)
                {
                    col.Width = new GridLength(_colSize);
                }
            });
        }
    }
}
