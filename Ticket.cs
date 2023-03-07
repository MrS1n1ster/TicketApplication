using System;
using System.Collections.Generic;

namespace _03_Ticketsystem
{
    public enum TicketStatus { Neu, InBearbeitung, Geloest };
    public class Ticket
    {
        public const String PFAD_TICKET_DATEI = "Ticket.csv";


        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private TicketStatus _status;

        public TicketStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private Kunde _kunde;

        public Kunde Kunde
        {
            get { return _kunde; }
            set { _kunde = value; }
        }

        private string _beschreibung;

        public string Beschreibung
        {
            get { return _beschreibung; }
            set { _beschreibung = value; }
        }

        private DateTime _zeitpunkt;

        public DateTime Zeitpunkt
        {
            get { return _zeitpunkt; }
            set { _zeitpunkt = value; }
        }

        public Ticket(int id, TicketStatus status, Kunde kunde, string beschreibung, DateTime zeitpunkt)
        {
            Id = id;
            Status = status;
            Kunde = kunde;
            Beschreibung = beschreibung;
            Zeitpunkt = zeitpunkt;
        }

        public Ticket()
        {
            //default für ein neues Ticket
            this.Zeitpunkt = DateTime.Now;
            this.Status = TicketStatus.Neu;
        }
        //Anmerkung: könnte ggf auch in die Persistenzschicht verlagert werden
        public void Speichern()
        {
            if (this.Id < 1)
                this.Anlegen();
            else
                this.Aendern(); // alle Tickets mit Id > 0 sind bereits in der Datei
        }

        public void Aendern()
        {
            CSVTicket.Aendern(this);
        }
        public void Aendern_v1()
        {
            List<Ticket> lst = Ticket.AlleLesen();

            bool found = false;
            foreach (Ticket t in lst)
            {
                if (t.Id == this.Id)
                {
                    t.Beschreibung = this.Beschreibung;
                    t.Status = this.Status;
                    found = true;
                    break;
                }
            }

            if (!found)
                throw new Exception($"Ticket mit der Id {this.Id} nicht gefunden");

            Ticket.AlleSpeichern(lst);
        }

        public static void AlleSpeichern(List<Ticket> lst)
        {
            CSVTicket.AlleSpeichern(lst);
        }

        public void Anlegen()
        {
            CSVTicket.Anlegen(this);
        }

        public void Loeschen()
        {
            CSVTicket.Loeschen(this);
        }

        public static List<Ticket> AlleLesen()
        {
            return CSVTicket.AlleLesen();
        }

        public static Ticket GetTicketById(int suchId)
        {
            return CSVTicket.GetTicketById(suchId);
        }

        public override string ToString()
        {
            // Möglichkeit 1: Verwendung der ToString()-Methode von Kunde
            // return $"{this.Id}  {this.Zeitpunkt} {this.Kunde} {this.Beschreibung} {this.Status}";

            // Möglichkeit 2: Nur Nachname, Vorname des Kunden
            return $"{this.Id.ToString().PadLeft(3)}  {this.Zeitpunkt.ToShortDateString()} {this.Kunde.Nachname.ToString().PadRight(11)} {this.Kunde.Vorname.ToString().PadRight(10)} {this.Status.ToString().PadRight(15)} {this.Beschreibung} ";
        }

        // Die vom Visual Studio generierte Equals-Methode:
        //public override bool Equals(object obj)
        //{
        //  return obj is Ticket ticket && Id == ticket.Id;
        //}

        public override bool Equals(object obj)
        {
            // Cast Variante 1: wirft Exception, falls obj nicht auf Ticket-Objekt zeigt
            // Ticket t = (Ticket)obj;

            // Cast Variante 2: setzt t auf null, falls obj nicht auf Ticket-Objekt zeigt
            Ticket t = obj as Ticket;

            if (t == null)
                return false;

            // wir legen hier fest, dass zwei Ticket Objekte dann "logisch gleich" sind,
            // wenn deren Id übereinstimmt
            if (this.Id == t.Id)
                return true;
            else
                return false;

            // Kurzschreibweise:
            // return t != null && t.Id == this.Id;
        }

    }
}
