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
using System.Windows.Shapes;
using EduScore.ViewModels;
using EduScoreDatabase;

namespace EduScore.Views
{
    /// <summary>
    /// Interaction logic for Oceny.xaml
    /// </summary>
    public partial class Oceny : Window
    {
        public Oceny(EduScoreContext context)
        {
            InitializeComponent();
            DataContext = new OcenyVM(context);
        }
    }
}
