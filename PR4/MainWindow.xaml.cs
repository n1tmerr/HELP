using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PR4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities db;
        public ObservableCollection<Permit> permits { get; set; }
        public ObservableCollection<Cityy> cityys { get; set; }
        public ObservableCollection<Countryy> countryys { get; set; }
        public ObservableCollection<Routee> routees { get; set; }
        public ObservableCollection<Servicce> Servicces { get; set; }
        public ObservableCollection<Hotell> Hotells { get; set; }
        public ObservableCollection<Humann> humanns { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            db = new Entities();
            permits = new ObservableCollection<Permit>(db.Permit);
            List.ItemsSource = permits;
            cityys = new ObservableCollection<Cityy>(db.Cityy);
            List2.ItemsSource = cityys;

            humanns = new ObservableCollection<Humann>(db.Humann);
            List4.ItemsSource = humanns;

            Servicces = new ObservableCollection<Servicce>(db.Servicce);
            List7.ItemsSource = Servicces;

            Hotells = new ObservableCollection<Hotell>(db.Hotell);
            List6.ItemsSource = Hotells;

            routees = new ObservableCollection<Routee>(db.Routee);
            List5.ItemsSource = routees;

            countryys = new ObservableCollection<Countryy>(db.Countryy);
            List3.ItemsSource = countryys;

            

        }
        

        

       

        private void Update()
        {
            permits = new ObservableCollection<Permit>(db.Permit);
            List.ItemsSource = permits;
            cityys = new ObservableCollection<Cityy>(db.Cityy);
            List2.ItemsSource = cityys;
            countryys = new ObservableCollection<Countryy>(db.Countryy);
            List3.ItemsSource = countryys;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add win = new Add(db, new Permit());
            if (win.ShowDialog() == true)
            {
                Permit permit = win.Permit;
                db.Permit.Add(permit);
                try
                {
                    db.SaveChanges();
                }
                catch { }
                Update();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Permit permits = List.SelectedItem as Permit;
            if (permits == null) return;
            Add entry = new Add(db, new Permit
            {
                Id = permits.Id,
                Route = permits.Route,
                Hotell = permits.Hotell,
                Humann = permits.Humann,

            });
            if (entry.ShowDialog() == true)
            {
                permits = db.Permit.Find(entry.Permit.Id);
                if (permits != null)
                {
                    permits.Id = permits.Id;
                    permits.Route = permits.Route;
                    permits.Hotell = permits.Hotell;
                    permits.Humann = permits.Humann;
                    db.SaveChanges();
                    List.Items.Refresh();
                }

            }
           

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Permit permits = List.SelectedItem as Permit;
            if (permits == null) return;
            try
            {
                db.Permit.Remove(permits);
                db.SaveChanges();
                Update();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            
        }

       

        private void List2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            countryadd win = new countryadd(db, new Countryy());
            if (win.ShowDialog() == true)
            {
                Countryy countryy = win.countryy;
                db.Countryy.Add(countryy);
                try
                {
                    db.SaveChanges();
                }
                catch { }
                Update();

            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Countryy countryy = List3.SelectedItem as Countryy;
            if (countryy == null) return;
            try
            {
                db.Countryy.Remove(countryy);
                db.SaveChanges();
            }
            catch { }
            DataContext = db.Countryy.ToList();
        }
    }
}

  

