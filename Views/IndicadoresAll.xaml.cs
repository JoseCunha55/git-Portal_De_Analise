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
using Portal_De_Analise.Portal_De_AnaliseServiceReference;

namespace Portal_De_Analise.Views
{
    public partial class IndicadoresAll : Page
    {
        Porta_De_AnaliseServiceClient cliente = new Porta_De_AnaliseServiceClient();

        public IndicadoresAll()
        {
            InitializeComponent();

            cliente.GetIndicadoresAllCompleted += Cliente_GetIndicadoresAllCompleted;
            cliente.GetIndicadoresAllAsync();
        }

        private void Cliente_GetIndicadoresAllCompleted(object sender, GetIndicadoresAllCompletedEventArgs e)
        {
            dgIndicadorAll.ItemsSource = e.Result;
            DataContext = e.Result;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
