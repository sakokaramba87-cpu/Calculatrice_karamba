using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculatrice_karamba
{
    public partial class MainWindow : Window
    {
        double premierNombre = 0;
        double deuxiemeNombre = 0;
        string operateur = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private double LireNombre()
        {
            return double.Parse(Ecran.Text);
        }

        private void AfficherNombre(double nombre)
        {
            Ecran.Text = nombre.ToString();
        }

        private void Chiffre_Click(object sender, RoutedEventArgs e)
        {
            Button bouton = (Button)sender;
            string chiffre = bouton.Content.ToString();

            if (Ecran.Text == "0" || Ecran.Text == "Erreur")
            {
                Ecran.Text = chiffre;
            }
            else
            {
                Ecran.Text = Ecran.Text + chiffre;
            }
        }

        private void Virgule_Click(object sender, RoutedEventArgs e)
        {
            if (Ecran.Text == "Erreur")
            {
                Ecran.Text = "0,";
            }
            else if (!Ecran.Text.Contains(",") && !Ecran.Text.Contains("."))
            {
                Ecran.Text = Ecran.Text + ",";
            }
        }

        private void Operateur_Click(object sender, RoutedEventArgs e)
        {
            Button bouton = (Button)sender;

            premierNombre = LireNombre();
            operateur = bouton.Content.ToString();
            Ecran.Text = "0";
        }

        private void Egal_Click(object sender, RoutedEventArgs e)
        {
            deuxiemeNombre = LireNombre();

            if (operateur == "+")
            {
                AfficherNombre(premierNombre + deuxiemeNombre);
            }
            else if (operateur == "−")
            {
                AfficherNombre(premierNombre - deuxiemeNombre);
            }
            else if (operateur == "×")
            {
                AfficherNombre(premierNombre * deuxiemeNombre);
            }
            else if (operateur == "÷")
            {
                if (deuxiemeNombre != 0)
                {
                    AfficherNombre(premierNombre / deuxiemeNombre);
                }
                else
                {
                    Ecran.Text = "Erreur";
                }
            }

            operateur = "";
        }

        private void Effacer_Click(object sender, RoutedEventArgs e)
        {
            Ecran.Text = "0";
            premierNombre = 0;
            deuxiemeNombre = 0;
            operateur = "";
        }

        private void Signe_Click(object sender, RoutedEventArgs e)
        {
            AfficherNombre(LireNombre() * -1);
        }

        private void Pourcentage_Click(object sender, RoutedEventArgs e)
        {
            AfficherNombre(LireNombre() / 100);
        }

        private void Racine_Click(object sender, RoutedEventArgs e)
        {
            double nombre = LireNombre();

            if (nombre >= 0)
            {
                AfficherNombre(Math.Sqrt(nombre));
            }
            else
            {
                Ecran.Text = "Erreur";
            }
        }

        private void Sinus_Click(object sender, RoutedEventArgs e)
        {
            double nombre = LireNombre();
            AfficherNombre(Math.Sin(nombre * Math.PI / 180));
        }

        private void Cosinus_Click(object sender, RoutedEventArgs e)
        {
            double nombre = LireNombre();
            AfficherNombre(Math.Cos(nombre * Math.PI / 180));
        }

        private void Tangente_Click(object sender, RoutedEventArgs e)
        {
            double nombre = LireNombre();
            AfficherNombre(Math.Tan(nombre * Math.PI / 180));
        }
    }
}