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

namespace Pojazdy
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Ciezarowka> listaCiezarowek = new ObservableCollection<Ciezarowka>();
        private ObservableCollection<SamochodOsobowy> listaSamochodow = new ObservableCollection<SamochodOsobowy>();

        //enum
        enum Pojazdy
        {
            Ciężarówka,
            Samochód
        }
        public MainWindow()
        {
            InitializeComponent();
            comboBox.SelectedIndex = 1;
            comboBox.Items.Add(Pojazdy.Ciężarówka);
            comboBox.Items.Add(Pojazdy.Samochód);
            listaCiezarowek.Add(new Ciezarowka("Volvo", "GDA1234", 6, 20));
            listaCiezarowek.Add(new Ciezarowka("Iveco", "GAD4321", 8, 15));
            listaSamochodow.Add(new SamochodOsobowy("Opel Corsa", "BS1234", 4, 450));
            listaSamochodow.Add(new SamochodOsobowy("Ford Focus", "WE1111", 4, 500));
            listaSamochodow.Add(new SamochodOsobowy("VW Golf", "BAU3753", 4, 320));

            this.ciezarowki.ItemsSource = listaCiezarowek;
            this.samochody.ItemsSource = listaSamochodow;

            
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            //wyjątek
            try
            {
                if (markaTB.Text == "" || nrRejestracyjnyTB.Text == "" || liczbaKolTB.Text == "")
                {
                    Exception niewypelnione = new Exception("Marka, nr rejestracyjny i liczba kół muszą być podane.");
                    throw niewypelnione;
                }
                if (maxLiczbaTonTB.IsEnabled == true) //ciezarowka
                {
                    Ciezarowka ciezarowka = new Ciezarowka();
                    ciezarowka.Marka = markaTB.Text;
                    ciezarowka.NrRejestracyjny = nrRejestracyjnyTB.Text;
                    ciezarowka.LiczbaKol = int.Parse(liczbaKolTB.Text);
                    ciezarowka.MaxLiczbaTon = int.Parse(maxLiczbaTonTB.Text);
                    MessageBox.Show("Dodano nową ciężarówkę!");
                    maxLiczbaTonTB.Clear();
                    listaCiezarowek.Add(ciezarowka);
                }
                else if (pojemnoscBagaznikaTB.IsEnabled == true) //samochod
                {
                    SamochodOsobowy sam = new SamochodOsobowy();
                    sam.Marka = markaTB.Text;
                    sam.NrRejestracyjny = nrRejestracyjnyTB.Text;
                    sam.LiczbaKol = int.Parse(liczbaKolTB.Text);
                    sam.PojemnoscBagaznika = int.Parse(pojemnoscBagaznikaTB.Text);
                    MessageBox.Show("Dodano nowy samochód!");
                    pojemnoscBagaznikaTB.Clear();
                    listaSamochodow.Add(sam);
                }
                markaTB.Clear();
                nrRejestracyjnyTB.Clear();
                liczbaKolTB.Clear();
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedItem.ToString() == Pojazdy.Ciężarówka.ToString())
            {
                maxLiczbaTonTB.IsEnabled = true;
                pojemnoscBagaznikaTB.IsEnabled = false;
            }
            if (comboBox.SelectedItem.ToString() == Pojazdy.Samochód.ToString())
            {
                pojemnoscBagaznikaTB.IsEnabled = true;
                maxLiczbaTonTB.IsEnabled = false;
            }

        }

        private void liczbaKolTB_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(liczbaKolTB.Text, "[^0-9]"))
            {
                MessageBox.Show("Wpisz wartość numeryczną.");
                liczbaKolTB.Clear();
            }
        }

        private void maxLiczbaTonTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(maxLiczbaTonTB.Text, "[^0-9]"))
            {
                MessageBox.Show("Wpisz wartość numeryczną.");
                maxLiczbaTonTB.Clear();
            }
        }

        private void pojemnoscBagaznikaTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(pojemnoscBagaznikaTB.Text, "[^0-9]"))
            {
                MessageBox.Show("Wpisz wartość numeryczną.");
                pojemnoscBagaznikaTB.Clear();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SamochodOsobowy sam = this.samochody.SelectedItem as SamochodOsobowy;
            int index = -1;
            if(sam != null)
            {
                for(int i = 0; i < listaSamochodow.Count; i++)
                {
                    if (sam == listaSamochodow[i]) index = i;
                }
                if (index != -1) listaSamochodow.RemoveAt(index);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Ciezarowka ciez = this.ciezarowki.SelectedItem as Ciezarowka;
            int index = -1;
            if (ciez != null)
            {
                for (int i = 0; i < listaCiezarowek.Count; i++)
                {
                    if (ciez == listaCiezarowek[i]) index = i;
                }
                if (index != -1) listaCiezarowek.RemoveAt(index);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            wypisywanie.Clear();
            for (int i = 0; i < listaCiezarowek.Count; i++)
            {
                wypisywanie.Text += listaCiezarowek[i].wypisz() + "\n";
            }
            for (int i = 0; i < listaSamochodow.Count; i++)
            {
                wypisywanie.Text += listaSamochodow[i].wypisz() + "\n";
            }
        }
    }
}
