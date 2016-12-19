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
using Visifire.Charts;
using Visifire.Commons;

namespace Portal_De_Analise.Views
{
    public partial class EvasaoPorCursoAno : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        PagedCollectionView collectionView = null;

        int strAno = 2010;
        public EvasaoPorCursoAno()
        {
            InitializeComponent();

            client.GetEvadidosPorCursoAnoCompleted += Client_GetEvadidosPorCursoAnoCompleted;
            client.GetEvadidosPorCursoAnoAsync(strAno);
        }

        private void Client_GetEvadidosPorCursoAnoCompleted(object sender, GetEvadidosPorCursoAnoCompletedEventArgs e)
        {
            collectionView = new PagedCollectionView(e.Result);
            collectionView.PageSize = 10;
            //collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Ano"));
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
                client.GetEvadidosPorCursoAnoAsync(strAno);
            }
            if (rb2006.IsChecked == true)
            {
                strAno = 2006;
                client.GetEvadidosPorCursoAnoAsync(strAno);
            }
            if (rb2007.IsChecked == true)
            {
                strAno = 2007;
                client.GetEvadidosPorCursoAnoAsync(strAno);
            }
            if (rb2008.IsChecked == true)
            {
                strAno = 2008;
                client.GetEvadidosPorCursoAnoAsync(strAno);
            }
            if (rb2009.IsChecked == true)
            {
                strAno = 2009;
                client.GetEvadidosPorCursoAnoAsync(strAno);
            }
            if (rb2010.IsChecked == true)
            {
                strAno = 2010;
                client.GetEvadidosPorCursoAnoAsync(strAno);
            }
            if (rb2011.IsChecked == true)
            {
                strAno = 2011;
                client.GetEvadidosPorCursoAnoAsync(strAno);
            }
            if (rb2012.IsChecked == true)
            {
                strAno = 2012;
                client.GetEvadidosPorCursoAnoAsync(strAno);
            }
            if (rb2013.IsChecked == true)
            {
                strAno = 2013;
                client.GetEvadidosPorCursoAnoAsync(strAno);
            }
            if (rb2014.IsChecked == true)
            {
                strAno = 2014;
                client.GetEvadidosPorCursoAnoAsync(strAno);
            }
        }
    }
}
