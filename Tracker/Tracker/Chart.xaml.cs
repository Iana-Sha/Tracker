using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tracker
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chart : ContentPage
    {
        public List<Record> records { get; set; }
        public Chart(List<Record> recs)
        {
            InitializeComponent();

            records = recs;
            BindingContext = this;
            

        }
    }
}