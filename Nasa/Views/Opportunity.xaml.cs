using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nasa.Views
{
    /// <summary>
    /// Interaction logic for Opportunity.xaml
    /// </summary>
    public partial class Opportunity : UserControl
    {
        public Opportunity()
        {
            InitializeComponent();
            //DataContext = new Nasa.ViewModels.OpporunityViewModel();
        }
    }
}
