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
using System.Windows.Data;
using System.Windows.Controls.DataVisualization;
using System.Runtime.InteropServices.Automation;
using Microsoft.CSharp;

namespace Portal_De_Analise.Views
{
    public partial class ConsultaADHoc : Page
    {
        //Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        //PagedCollectionView collectionView = null;
        public ConsultaADHoc()
        {
            InitializeComponent();

            //client.GetKPIIndicadorDeEnsinoCompleted += Client_GetKPIIndicadorDeEnsinoCompleted;
            //client.GetKPIIndicadorDeEnsinoAsync();
        }

        private void Client_GetKPIIndicadorDeEnsinoCompleted(object sender, GetKPIIndicadorDeEnsinoCompletedEventArgs e)
        {
            //this.MyDataGrid.ItemsSource = e.Result;

            //this.MyDataGrid.ColumnsHierarchy.AutoResize(VIBlend.Silverlight.Controls.AutoResizeMode.FIT_ITEM_CONTENT);
            //this.MyDataGrid.Refresh();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
