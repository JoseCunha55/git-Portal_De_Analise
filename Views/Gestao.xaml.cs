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

namespace Portal_De_Analise.Views
{
    public partial class Gestao : Page
    {
        public Gestao()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void hypKPIs_Click(object sender, RoutedEventArgs e)
        {
            frGestao.Navigate(new Uri("/Views/KPIs.xaml", UriKind.Relative));
        }

        private void hypDashboard_Click(object sender, RoutedEventArgs e)
        {
            frGestao.Navigate(new Uri("/Views/Dashboards.xaml", UriKind.Relative));
        }

        private void hypRelatorio_Click(object sender, RoutedEventArgs e)
        {
            frGestao.Navigate(new Uri("/Views/Relatorios.xaml", UriKind.Relative));
        }

        private void hypConsultas_Click(object sender, RoutedEventArgs e)
        {
            frGestao.Navigate(new Uri("/Views/mainConsultas.xaml", UriKind.Relative));
        }
    }
}
