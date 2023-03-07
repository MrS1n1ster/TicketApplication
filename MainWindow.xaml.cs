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
using System.Windows.Navigation;
using System.Windows.Shapes;
using _03_Ticketsystem;

namespace _06_Ticketsystem_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum DialogMode { Neu, Bearbeiten};
    public partial class MainWindow : Window
    {
        private MainViewModel model;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void FillListBox()
        {
            /*tListe.Items.Clear();
            List<Ticket> lst = Ticket.AlleLesen();
            foreach(Ticket t in lst)
            {
                this.tListe.Items.Add(t);
            }*/
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //nachdem mehrere Methoden Zugriff aus das MainViewModel benötigen
            //speichern wir uns gleich zu Beginn die Referenz
             model= FindResource("mvmodel") as MainViewModel;
            /*List<Ticket> lst = Ticket.AlleLesen();
            foreach(Ticket t in lst)
            {
                this.tListe.Items.Add(t);         
            }
            this.btnloesch.IsEnabled = false;
            this.btnBearb.IsEnabled = false;*/
        }

        private void btnloesch_Click(object sender, RoutedEventArgs e)
        {
            Ticket ? t = tListe.SelectedItem as Ticket;
            if(t == null)
            {
                return;
            }
            MessageBoxResult r = MessageBox.Show("Wollen Sie das Ticket wirklich löschen?", "Ticketsystem", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (r == MessageBoxResult.Yes)
            {
                model.LstTi.Remove(model.SelTi);   
            }
        }

        private void tListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*if(tListe.SelectedItem != null)
            {
                this.btnloesch.IsEnabled = true;
                this.btnBearb.IsEnabled = true;
            }
            else
            {
                this.btnBearb.IsEnabled = false;
                this.btnloesch.IsEnabled = false;
            }
            //this.btnBearb.IsEnabled = tListe.SelectedItem != null;
            //this.btnloesch.IsEnabled = tListe.SelectedItem != null;*/
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("Wollen Sie wirklich beenden?", "Ticketsystem", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (r == MessageBoxResult.No)
                e.Cancel = true;
            else
                Environment.Exit(0);
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            this.model.SelTi = new Ticket();
            //dlg.ShowDialog() öffnet den Dialog modal (=Hauptfenster ist nicht bedienbar)
            TicketDetailDlg dlg = new TicketDetailDlg(DialogMode.Neu);

            //Der Rückgabewert von ShowDialog ist identisch mit dem
            //im TicketDetailDlg gesetzten Wert für "DialogResult"
            bool? res = dlg.ShowDialog();

            if(res== true)
                FillListBox();
        }

        private void btnBearb_Click(object sender, RoutedEventArgs e)
        {
            if (model.SelTi == null)
                return;
            TicketDetailDlg dlg1 = new TicketDetailDlg(DialogMode.Bearbeiten);
            dlg1.ShowDialog();
        }
    }
}
