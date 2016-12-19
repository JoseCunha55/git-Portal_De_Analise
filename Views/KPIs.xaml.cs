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
    public partial class KPIs : Page
    {
        public KPIs()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void hypKPIDesempenhoAluno_Click(object sender, RoutedEventArgs e)
        {
            frKPIs.Navigate(new Uri("/Views/KPIDesempenhoAluno.xaml", UriKind.Relative));
        }

        private void hypKPIAlunoPorDisciplina_Click(object sender, RoutedEventArgs e)
        {
            frKPIs.Navigate(new Uri("/Views/KPIAlunoPorDisciplina.xaml", UriKind.Relative));
        }
    }
}
