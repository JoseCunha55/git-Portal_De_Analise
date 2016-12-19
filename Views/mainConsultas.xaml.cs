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
using System.Runtime.InteropServices.Automation;

namespace Portal_De_Analise.Views
{
    public partial class mainConsultas : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        public mainConsultas()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void hypEvaConEntradaSaida_Click(object sender, RoutedEventArgs e)
        {
            frConsultas.Navigate(new Uri("/Views/Consultas.xaml", UriKind.Relative));
        }

        private void hypReprovados_Click(object sender, RoutedEventArgs e)
        {
            frConsultas.Navigate(new Uri("/Views/MDXEvadidos.xaml", UriKind.Relative));
        }

        private void hypMDXADHoc_Click(object sender, RoutedEventArgs e)
        {
            frConsultas.Navigate(new Uri("/Views/ConsultasMDX.xaml", UriKind.Relative));
            //frConsultas.Navigate(new Uri("/Views/MDXEvadidosExcel.xaml", UriKind.Relative));
        }

        private void hypExcel_Click(object sender, RoutedEventArgs e)
        {
            //client.AbrirExcelCompleted += Client_AbrirExcelCompleted;
            client.AbrirExcelAsync();
        }

        //private void Client_AbrirExcelCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        //{
        //    MessageBox.Show("Abrindo o Excel, aguarde...!");
        //}

        private void hypPowerBI_Click(object sender, RoutedEventArgs e)
        {
            client.AbrirPBICompleted += Client_AbrirPBICompleted;
            client.AbrirPBIAsync();
        }

        private void Client_AbrirPBICompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Abrindo Power BI, aguarde...!");
        }
    }
}
