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
    public partial class EvasaoPorCampusAno : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        PagedCollectionView collectionView = null;

        int strAno = 0;
        String strCampus = null;
        public EvasaoPorCampusAno()
        {
            InitializeComponent();

            strAno = 2010;
            strCampus = "Campus Apodi";

            client.GetEvadidosPorCampusAnoCompleted += Client_GetEvadidosPorCampusAnoCompleted;
            client.GetEvadidosPorCampusAnoAsync(strCampus,strAno);

        }

        private void Client_GetEvadidosPorCampusAnoCompleted(object sender, GetEvadidosPorCampusAnoCompletedEventArgs e)
        {
            collectionView = new PagedCollectionView(e.Result);
            collectionView.PageSize = 10;

            this.DataContext = collectionView;
           
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (rb2005.IsChecked == true)
            {
                strAno = 2005;
                client.GetEvadidosPorCampusAnoAsync(strCampus, strAno);
            }
            if (rb2006.IsChecked == true)
            {
                strAno = 2006;
                client.GetEvadidosPorCampusAnoAsync(strCampus, strAno);
            }
            if (rb2007.IsChecked == true)
            {
                strAno = 2007;
                client.GetEvadidosPorCampusAnoAsync(strCampus, strAno);
            }
            if (rb2008.IsChecked == true)
            {
                strAno = 2008;
                client.GetEvadidosPorCampusAnoAsync(strCampus, strAno);
            }
            if (rb2009.IsChecked == true)
            {
                strAno = 2009;
                client.GetEvadidosPorCampusAnoAsync(strCampus, strAno);
            }
            if (rb2010.IsChecked == true)
            {
                strAno = 2010;
                client.GetEvadidosPorCampusAnoAsync(strCampus, strAno);
            }
            if (rb2011.IsChecked == true)
            {
                strAno = 2011;
                client.GetEvadidosPorCampusAnoAsync(strCampus, strAno);
            }
            if (rb2012.IsChecked == true)
            {
                strAno = 2012;
                client.GetEvadidosPorCampusAnoAsync(strCampus, strAno);
            }
            if (rb2013.IsChecked == true)
            {
                strAno = 2013;
                client.GetEvadidosPorCampusAnoAsync(strCampus, strAno);
            }
            if (rb2014.IsChecked == true)
            {
                strAno = 2014;
                client.GetEvadidosPorCampusAnoAsync(strCampus, strAno);
            }
        }

        private void cboCampus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null)
            {
                ComboBoxItem cbi = (ComboBoxItem)((ComboBox)sender).SelectedItem;
                strCampus = cbi.Content.ToString();
                client.GetEvadidosPorCampusAnoAsync(strCampus,strAno);
            }
        }
    }
}
