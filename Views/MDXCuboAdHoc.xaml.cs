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
using System.Runtime.InteropServices.Automation;
using Portal_De_Analise.Portal_De_AnaliseServiceReference;

namespace Portal_De_Analise.Views
{
    public partial class MDXCuboAdHoc : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        public MDXCuboAdHoc()
        {
            InitializeComponent();

        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnAnalysisServices_Click(object sender, RoutedEventArgs e)
        {
            //Abre o programa externo (Power BI).
            //Através dessa ferramenta o usuário final pode acessar os cubos OLAP e fazer consultas Ad Hoc.
            client.AbrirPBIAsync();
        }
    }
}
