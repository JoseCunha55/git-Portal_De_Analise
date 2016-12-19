using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Browser;

namespace Portal_De_Analise.Views
{
    public partial class RBC : Page
    {
        private object frrbc;

        public RBC()
        {
            InitializeComponent();
            //webContentRBC.Navigate(new Uri(Application.Current.Host.Source, "http://localhost:3000"));

            //HtmlPage.Window.Invoke("http://localhost:3000", "");
            //frRBC.Navigate(new Uri("/Views/Casos.xaml", UriKind.Relative));

        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void hypRBCCasos_Click(object sender, RoutedEventArgs e)
        {
            frRBC.Navigate(new Uri("/Views/Atendimento.xaml", UriKind.Relative));

            //HtmlPage.Window.Invoke("http://localhost:3000", "");
            //frRBC.Navigate(new Uri("/Views/Casos.xaml", UriKind.Relative));
        }

        private void hypRBCAtendimento_Click(object sender, RoutedEventArgs e)
        {
            frRBC.Navigate(new Uri("/Views/Atendimento.xaml", UriKind.Relative));
        }

        private void hypRBCReports_Click(object sender, RoutedEventArgs e)
        {
            frRBC.Navigate(new Uri("/Views/Encaminhamentos.xaml", UriKind.Relative));
        }

        private void hypRBCDemandas_Click(object sender, RoutedEventArgs e)
        {
            frRBC.Navigate(new Uri("/Views/Demandas.xaml", UriKind.Relative));
        }
    }
}
