using _03_Ticketsystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace _06_Ticketsystem_WPF
{
    public class MainViewModel : BaseModel
    {
        private ObservableCollection<Ticket> _lstTi;
        public ObservableCollection<Ticket> LstTi
        {
            get { return _lstTi; }
            set { _lstTi = value; OnPropertyChanged("LstTi"); }
        }
        public MainViewModel()
        {
            this.LstTi = new ObservableCollection<Ticket>(Ticket.AlleLesen());
            this.lstKu = new ObservableCollection<Kunde>(Kunde.Allelesen());
            this.LstStatus.Add(TicketStatus.Neu);
            this.LstStatus.Add(TicketStatus.InBearbeitung);
            this.LstStatus.Add(TicketStatus.Geloest);

            //oder trickreiche Wedlich Methode
            /*foreach(TicketStatus s in Enum.GetValues(typeof(TicketStatus)))
            { 
                this.LstStatus.Add(s);
            }*/
        }
        private Ticket _SelTi;
        public Ticket SelTi
        {
            get { return _SelTi; }
            //Verwendung des ternären Operators(bedingte Zuweisung)
            set { _SelTi = value; OnPropertyChanged("SelTi");}
        } 
        private ObservableCollection<Kunde> _lstKu;
        public ObservableCollection<Kunde> lstKu
        {
            get { return _lstKu; }
            set { _lstKu = value; OnPropertyChanged("lstKu"); }
        }
        //nachdem keine Veränderungen (add/remove) an der Liste stattfinden
        //kann eine "normale" List<...> anstelle einer ObservableCollection verwendet werden
        private List<TicketStatus> _lstStatus = new List<TicketStatus>();
        public List<TicketStatus> LstStatus
        {
            get { return _lstStatus; }
            set { _lstStatus = value; OnPropertyChanged("LstStatus"); }
        }

    }
}
