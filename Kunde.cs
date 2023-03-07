using System;
using System.Collections.Generic;

namespace _03_Ticketsystem
{
    public class Kunde : Person //Klasse Kunde wird von Person abgeleitet (=vererbt)
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }

        }

        public void Anlegen()
        {
            CSVKunde.Anlegen(this);
        }

        public static List<Kunde> Allelesen()
        {
            //Wegen der Schichtentrennung wird der Aufruf hier nur durchgereicht
            return CSVKunde.Allelesen();
        }

        public override string ToString()
        {
            //return $"{Id} {Geschlecht} {Vorname} {Nachname} {GebDatum.ToShortDateString()} {Alter} Jahre";
            //return $"{Id} " + base.ToString();
            return $"{Vorname} {Nachname}";
        }

        /*public static Kunde GetKundeById_Variante1(int suchId)
        {
            List<Kunde> lst = Kunde.Allelesen();
            Kunde erg = null;
            foreach (Kunde k in lst) // kürzer: Kunde.Allelesen())
            {
                if (k.Id == suchId)
                {
                    erg = k;
                    break;
                }
            }

            if (erg == null)
                throw new Exception($"Kunde mit Id {suchId} existiert nicht");

            return erg;
        }*/
        public override bool Equals(object? obj)
        {
            Kunde k = obj as Kunde;
            return k != null && k.Id == this.Id;
        }
        public static Kunde GetKundeById(int suchId)
        {
            return CSVKunde.GetKundeById(suchId);
        }
    }
}
