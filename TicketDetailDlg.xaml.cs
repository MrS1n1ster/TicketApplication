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
using System.Windows.Shapes;
using _03_Ticketsystem;

namespace _06_Ticketsystem_WPF
{
    /// <summary>
    /// Interaktionslogik für TicketDetailDlg.xaml
    /// </summary>
    public partial class TicketDetailDlg : Window
    {
        private DialogMode dlg;
        //private Ticket t;
        public TicketDetailDlg(DialogMode dlg)
        {
            this.dlg = dlg;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            if(this.dlg == DialogMode.Neu)
            {
                this.Title = "Neues Ticket anlegen";
                this.date.Content = DateTime.Now;

                womboSta.IsEnabled = false;
                womboSta.SelectedIndex = 0;
      
            }
            else
            {
                this.Title = "Ticket bearbeiten";
                womboSta.IsEnabled = true;
                btnKu.IsEnabled = false;
                wombocombo.IsEnabled = false;

                /*this.wombocombo.Items.Add(t.Kunde);
                this.wombocombo.SelectedIndex = 0;
                this.womboSta.Items.Add(TicketStatus.InBearbeitung);
                this.womboSta.Items.Add(TicketStatus.Geloest);
                this.womboSta.Items.Add(TicketStatus.Neu);
                this.womboSta.SelectedItem = t.Status;
                this.tbBesch.Text = t.Beschreibung;*/
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel model = FindResource("mvmodel") as MainViewModel;
            //if(String.IsNullOrWhiteSpace(tbBesch.Text))
            if (model.SelTi.Beschreibung.Trim() == String.Empty)
            {
                MessageBox.Show("Die Fehlerbeschreibung darf nicht leer sein!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            /*if(this.wombocombo.SelectedItem == null)
            {
                MessageBox.Show("Bitte wählen Sie einen Kunden aus!");
                return;
            }*/
            else
            {
                model.SelTi.Speichern();
                this.DialogResult = true;
                this.Close();
            }
        }
        private void btnEscape_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnKu_Click(object sender, RoutedEventArgs e)
        {
            Kunde k = new Kunde();
            KundeDetaildlg kdlg = new KundeDetaildlg(k);
            bool? res = kdlg.ShowDialog();

            if(res == true)
            {
                this.wombocombo.Items.Add(k);
                this.wombocombo.SelectedItem = k;
            }
                
        }
    }
}
