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

namespace Portal_De_Analise.Views
{
    public partial class RelEvasao : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        PagedCollectionView view = null;
        public RelEvasao()
        {
            InitializeComponent();

            client.RelEvadidosPorCampusAnoCompleted += Client_RelEvadidosPorCampusAnoCompleted;
            client.RelEvadidosPorCampusAnoAsync();
        }

        private void Client_RelEvadidosPorCampusAnoCompleted(object sender, RelEvadidosPorCampusAnoCompletedEventArgs e)
        {
            view = new PagedCollectionView(e.Result);
            view.PageSize = 10;
            dgRelEvasao.ItemsSource = view;
            this.DataContext = view;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
