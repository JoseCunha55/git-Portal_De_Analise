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
    public partial class RepetenciaPorCurso : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        PagedCollectionView collectionView = null;

        int iAno = 2010;
        public RepetenciaPorCurso()
        {
            InitializeComponent();

            client.GetReprovadosPorCursoAnoCompleted += Client_GetReprovadosPorCursoAnoCompleted;
            client.GetReprovadosPorCursoAnoAsync(iAno);
        }

        private void Client_GetReprovadosPorCursoAnoCompleted(object sender, GetReprovadosPorCursoAnoCompletedEventArgs e)
        {
            collectionView = new PagedCollectionView(e.Result);
            collectionView.PageSize = 5;

            DataContext = collectionView;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (rb2000.IsChecked == true)
            {
                iAno = 2000;
                client.GetReprovadosPorCursoAnoAsync(iAno);
            }
            if (rb2001.IsChecked == true)
            {
                iAno = 2001;
                client.GetReprovadosPorCursoAnoAsync(iAno);
            }
            if (rb2002.IsChecked == true)
            {
                iAno = 2002;
                client.GetReprovadosPorCursoAnoAsync(iAno);
            }
            if (rb2003.IsChecked == true)
            {
                iAno = 2003;
                client.GetReprovadosPorCursoAnoAsync(iAno);
            }
            if (rb2004.IsChecked == true)
            {
                iAno = 2004;
                client.GetReprovadosPorCursoAnoAsync(iAno);
            }
            if (rb2005.IsChecked == true)
            {
                iAno = 2005;
                client.GetReprovadosPorCursoAnoAsync(iAno);
            }
            if (rb2006.IsChecked == true)
            {
                iAno = 2006;
                client.GetReprovadosPorCursoAnoAsync(iAno);
            }
            if (rb2007.IsChecked == true)
            {
                iAno = 2007;
                client.GetReprovadosPorCursoAnoAsync(iAno);
            }
            if (rb2008.IsChecked == true)
            {
                iAno = 2008;
                client.GetReprovadosPorCursoAnoAsync(iAno);
            }
            if (rb2009.IsChecked == true)
            {
                iAno = 2009;
                client.GetReprovadosPorCursoAnoAsync(iAno);
            }
            if (rb2010.IsChecked == true)
            {
                iAno = 2010;
                client.GetReprovadosPorCursoAnoAsync(iAno);
            }
            if (rb2011.IsChecked == true)
            {
                iAno = 2011;
                client.GetReprovadosPorCursoAnoAsync(iAno);
            }
            if (rb2012.IsChecked == true)
            {
                iAno = 2012;
                client.GetReprovadosPorCursoAnoAsync(iAno);
            }
            if (rb2013.IsChecked == true)
            {
                iAno = 2013;
                client.GetReprovadosPorCursoAnoAsync(iAno);
            }
            if (rb2014.IsChecked == true)
            {
                iAno = 2014;
                client.GetReprovadosPorCursoAnoAsync(iAno);
            }
        }
    }
}
