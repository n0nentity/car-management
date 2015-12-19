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
using MahApps.Metro.Controls;

namespace car_management.View
{
    /// <summary>
    /// Interaktionslogik für NewCarRefuelWindow.xaml
    /// </summary>
    public partial class NewCarRefuelWindow : MetroWindow
    {
        public NewCarRefuelWindow()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }


    }
}
