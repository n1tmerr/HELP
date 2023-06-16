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

namespace PR4
{
    /// <summary>
    /// Логика взаимодействия для countryadd.xaml
    /// </summary>
    public partial class countryadd : Window
    {
        Entities db;

        public Countryy countryy { get; private set; }
        public countryadd(Entities db, object country)
        {
            InitializeComponent();
            this.db = db;
            var a = country as Countryy;
            if(a is Countryy)
            {
                countryy = a;
                DataContext = countryy;
            }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
