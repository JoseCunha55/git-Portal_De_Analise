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
using System.Runtime.InteropServices.Automation;
using System.Windows.Interop;

namespace Portal_De_Analise.Views
{
    public partial class MDXEvadidosExcel : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        PagedCollectionView collectionView = null;

        string strBanco = "UMinhoD";

        public MDXEvadidosExcel()
        {
            InitializeComponent();

            client.GetAMODataBasesCompleted += Client_GetAMODataBasesCompleted;
            client.GetAMODataBasesAsync();

            client.GetAMOCubosCompleted += Client_GetAMOCubosCompleted;
            client.GetAMOCubosAsync(strBanco);
        }

        private void Client_GetAMOCubosCompleted(object sender, GetAMOCubosCompletedEventArgs e)
        {
            collectionView = new PagedCollectionView(e.Result.ToList());

            ListaAMOCubos.ItemsSource = collectionView;
        }

        private void Client_GetAMODataBasesCompleted(object sender, GetAMODataBasesCompletedEventArgs e)
        {
            lstBancos.ItemsSource = e.Result.ToList();
            lstBancos.SelectedIndex = 0;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void lstBancos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            strBanco = lstBancos.SelectedItem.ToString();

            //client.GetAMOCubosAsync(strBanco);

        }

        private void ListaAMOCubos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnComando2_Click(object sender, RoutedEventArgs e)
        {
            //Abrir o Excel
            //A partir de Excel, o usuário final poderá acessar os Cubos OLAP e fazer
            //consultas Ad Hoc.

            //client.AbrirExcelAsync();
        }

        private void btnProcessarCubo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProcessarGMedidas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExecutarConsultaMDX_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExemploMDX_Click(object sender, RoutedEventArgs e)
        {
            VisualizaSintaxMDX sintax = new Views.VisualizaSintaxMDX();
            sintax.Show();
            //frmConsultas.Navigate(new Uri("/Views/VisualizaMDXChild.xaml", UriKind.Relative));
        }
    }
}
