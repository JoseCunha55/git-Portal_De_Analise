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
    public partial class Analise : Page
    {
        public Analise()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void hypInicadorCNAT_Click(object sender, RoutedEventArgs e)
        {
            frAnalise.Navigate(new Uri("/Views/IndicadorCNATCurso.xaml", UriKind.Relative));
        }

        private void hypIndicadorAll_Click(object sender, RoutedEventArgs e)
        {
            frAnalise.Navigate(new Uri("/Views/IndicadoresAll.xaml", UriKind.Relative));
        }

        private void hypIndicadorLicen_Click(object sender, RoutedEventArgs e)
        {
            frAnalise.Navigate(new Uri("/Views/IndicadorLicenciaturas.xaml", UriKind.Relative));
        }

        private void hypPreEvasao_Click(object sender, RoutedEventArgs e)
        {
            frAnalise.Navigate(new Uri("/Views/ProbabilidadeSucesso.xaml", UriKind.Relative));
        }

        private void hypPreEvasaoEtinia_Click(object sender, RoutedEventArgs e)
        {
            frAnalise.Navigate(new Uri("/Views/ProbabilidadeSucessoTema.xaml", UriKind.Relative));
        }

        private void hypPreEvasaoEscola_Click(object sender, RoutedEventArgs e)
        {
            frAnalise.Navigate(new Uri("/Views/ProbabilidadeSucessoEscola.xaml", UriKind.Relative));
        }

        private void hypPreEvasaoRenda_Click(object sender, RoutedEventArgs e)
        {
            frAnalise.Navigate(new Uri("/Views/ProbabilidadeSucessoRenda.xaml", UriKind.Relative));
        }
    }
}
