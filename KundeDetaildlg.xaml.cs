using _03_Ticketsystem;
using System;
using System.Windows;

namespace _06_Ticketsystem_WPF
{
    /// <summary>
    /// Interaktionslogik für KundeDetaildlg.xaml
    /// </summary>
    public partial class KundeDetaildlg : Window
    {
        private Kunde k;
        public KundeDetaildlg(Kunde k)
        {
            this.k = k;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = "Kunden anlegen";
            this.geschlecht.Items.Add(Gender.männlich);
            this.geschlecht.Items.Add(Gender.weiblich);
            this.geschlecht.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (kname.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Bitte Nachnamen eingeben!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (kvname.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Bitte Vornamen eingeben!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (datum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Bitte Geburtsdatum auswählen!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            /*else if(geschlecht.SelectedItem == null)
            {
                MessageBox.Show("Bitte wählen Sie ein geschlecht aus!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }*/
            {
                try
                {
                    DateTime dt = Convert.ToDateTime(this.datum.Text);
                    if (dt.AddYears(16) > DateTime.Today)
                        MessageBox.Show("Das Mindestalter beträgt 16 Jahre", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                catch (Exception)
                {
                    MessageBox.Show("Bitte korrektes Datum eingeben!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                this.datum.DisplayDateEnd = DateTime.Today.AddYears(-100);
                this.datum.DisplayDateStart = DateTime.Today.AddYears(-16);

                this.k.Nachname = this.kname.Text;
                this.k.Vorname = this.kvname.Text;
                //string datumV = this.datum.Text;
                this.k.GebDatum = Convert.ToDateTime(this.datum.Text);
                this.k.Geschlecht = (Gender)geschlecht.SelectedItem;

                this.k.Anlegen();

                this.DialogResult = true;
                this.Close();
            }
        }

        private void Esc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
