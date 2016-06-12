using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojazdy
{
    class SamochodOsobowy : Pojazd //klasa 3
        //dziedziczenie
    {
        //propercje
        public double PojemnoscBagaznika { get; set; }

        public SamochodOsobowy() { }

        public SamochodOsobowy(string marka, string nrRejestracyjny, int liczbaKol, int pojemnoscBagaznika)
        {
            this.Marka = marka;
            this.NrRejestracyjny = nrRejestracyjny;
            this.LiczbaKol = liczbaKol;
            this.PojemnoscBagaznika = pojemnoscBagaznika;
        }

        //polimorfizm
        public override string wypisz()
        {
            return "Samochód o marce " + this.Marka 
                + ", nr rej. " + NrRejestracyjny 
                + ", liczbie kół " + LiczbaKol + " i pojemności bagażnika " 
                + PojemnoscBagaznika;
        }
    }
}
