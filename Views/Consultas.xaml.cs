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
using System.Windows.Browser;
using Portal_De_Analise.Portal_De_AnaliseServiceReference;
using System.Windows.Data;

namespace Portal_De_Analise.Views
{
    public partial class Consultas : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        PagedCollectionView collectionView = null;

        dynamic excel = false; 
        public Consultas()
        {
            InitializeComponent();

            client.ADOMDGetCubeEvaConEntradaSaidaCompleted += Client_ADOMDGetCubeEvaConEntradaSaidaCompleted;
            client.ADOMDGetCubeEvaConEntradaSaidaAsync();
           
        }

        private void Client_ADOMDGetCubeEvaConEntradaSaidaCompleted(object sender, ADOMDGetCubeEvaConEntradaSaidaCompletedEventArgs e)
        {
            collectionView = new PagedCollectionView(e.Result);
            collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Campus"));
            collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Curso"));
            MyPiv.ItemsSource = collectionView;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            //HtmlPage.Window.Invoke("AlertaJS", "Silverlight");
            HtmlPage.Window.Invoke("run", "DTExec.exe");
        }
    }
}
