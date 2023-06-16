using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        Entities db;
        public Permit Permit { get; private set; }
        public Humann Humann { get; private set; }

        public Routee Routee { get; private set;  }
        public Hotell Hotell { get; private set; }

        public Add(Entities db, object permit)
        {

            InitializeComponent();
            this.db = db;
            
            var a = permit as Humann;
            if (a is Humann)
            {

                Humann = a;
                
                DataContext = Humann;



            }
            var b = permit as Routee;
            if (b is Routee)
            {
                Routee = b;
                
                DataContext = Routee;

            }
            var c = permit as Hotell;
            if (c is Hotell)
            {
                Hotell = c;

                DataContext = Hotell;

            }

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
