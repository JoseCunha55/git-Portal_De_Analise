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
    public partial class IndicadorLicenciaturas : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        public IndicadorLicenciaturas()
        {
            InitializeComponent();

            client.GetIndicadoresLicenciaturasCompleted += Client_GetIndicadoresLicenciaturasCompleted;
            client.GetIndicadoresLicenciaturasAsync();
        }

        private void Client_GetIndicadoresLicenciaturasCompleted(object sender, GetIndicadoresLicenciaturasCompletedEventArgs e)
        {
            DataContext = e.Result;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
