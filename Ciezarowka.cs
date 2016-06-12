using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojazdy
{
    class Ciezarowka : Pojazd //klasa 1
        //dziedziczenie
    {
        //propercje
        public int MaxLiczbaTon { get; set; }

        public Ciezarowka() { }
        public Ciezarowka(string marka, string nrRejestracyjny, int liczbaKol, int maxLiczbaTon)
        {
            this.Marka = marka;
            this.NrRejestracyjny = nrRejestracyjny;
            this.LiczbaKol = liczbaKol;
            this.MaxLiczbaTon = maxLiczbaTon;
        }
        
        //polimorfizm
        public override string wypisz()
        {
            return "Ciężarówka o marce " + this.Marka
                + ", nr rej. " + NrRejestracyjny
                + ", liczbie kół " + LiczbaKol + " i maksymalnej liczbie ton "
                + MaxLiczbaTon;
        }
    }
}
