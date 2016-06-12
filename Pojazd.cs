using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojazdy
{
    //interface
    interface IPojazd
    {
        string wypisz();
    }
    public abstract class Pojazd : IPojazd //klasa 2
    {
        //propercje
        public virtual string Marka { get; set; }
        public virtual string NrRejestracyjny { get; set; }
        public virtual int LiczbaKol { get; set; }
        

        //polimorfizm
        public virtual string wypisz()
        {
            return "Jestem pojazdem.";
        }
    }
}
