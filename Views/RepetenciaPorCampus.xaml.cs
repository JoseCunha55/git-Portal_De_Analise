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


namespace Portal_De_Analise.Views
{
    public partial class RepetenciaPorCampus : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        PagedCollectionView collectionView = null;

        string strCampus = "Campus Natal-Central";
        public RepetenciaPorCampus()
        {
            InitializeComponent();

            client.GetReprovadosPorCampusCompleted += Client_GetReprovadosPorCampusCompleted;
            client.GetReprovadosPorCampusAsync(strCampus);
        }

        private void Client_GetReprovadosPorCampusCompleted(object sender, GetReprovadosPorCampusCompletedEventArgs e)
        {
            collectionView = new PagedCollectionView(e.Result);
            collectionView.PageSize = 5;

            DataContext = collectionView;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private void cboCampus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(((ComboBox)sender).SelectedItem!=null)
            {
                ComboBoxItem cbi = (ComboBoxItem)((ComboBox)sender).SelectedItem;
                client.GetReprovadosPorCampusAsync(cbi.Content.ToString());
            }
        }
    }
}
