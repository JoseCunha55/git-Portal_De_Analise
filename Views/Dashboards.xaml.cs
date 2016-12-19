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
    public partial class Dashboards : Page
    {
        public Dashboards()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            frDashboards.Navigate(new Uri("/Views/DashboardAbertura.xaml", UriKind.Relative));
        }

        private void hypRepetencia_Click(object sender, RoutedEventArgs e)
        {

        }

        private void hypEvasao_Click(object sender, RoutedEventArgs e)
        {

        }

        private void hypRepPorCampus_Click(object sender, RoutedEventArgs e)
        {
            frDashboards.Navigate(new Uri("/Views/RepetenciaPorCampus.xaml", UriKind.Relative));
        }

        private void hypRepPorCurso_Click(object sender, RoutedEventArgs e)
        {
            frDashboards.Navigate(new Uri("/Views/RepetenciaPorCurso.xaml", UriKind.Relative));
        }

        private void hypRepPorDisciplina_Click(object sender, RoutedEventArgs e)
        {
            frDashboards.Navigate(new Uri("/Views/RepetenciaPorDisciplina.xaml", UriKind.Relative));
        }

        
        private void hypEvasaoPorCampus_Click(object sender, RoutedEventArgs e)
        {
            frDashboards.Navigate(new Uri("/Views/EvasaoPorCampusAno.xaml", UriKind.Relative));
        }

        private void hypEvasaoPorCurso_Click(object sender, RoutedEventArgs e)
        {
            frDashboards.Navigate(new Uri("/Views/EvasaoPorCursoAno.xaml", UriKind.Relative));
        }
    }
}
