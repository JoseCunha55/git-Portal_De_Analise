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
    public partial class RepetenciaPorDisciplina : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        PagedCollectionView collectionView = null;

        string strCurso = null;
        int iAno = 2010;
        public RepetenciaPorDisciplina()
        {
            InitializeComponent();
            client.GetCursosCompleted += Client_GetCursosCompleted;
            client.GetCursosAsync(iAno);

            client.GetReprovadosPorCursoDisciplinaAnoCompleted += Client_GetReprovadosPorCursoDisciplinaAnoCompleted;
        }

        private void Client_GetCursosCompleted(object sender, GetCursosCompletedEventArgs e)
        {
            cboCursos.ItemsSource  = e.Result;
        }

        private void Client_GetReprovadosPorCursoDisciplinaAnoCompleted(object sender, GetReprovadosPorCursoDisciplinaAnoCompletedEventArgs e)
        {
            collectionView = new PagedCollectionView(e.Result);
            collectionView.PageSize = 5;
   
            DataContext  = collectionView;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
  
        }
        private void cboCursos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            strCurso = Convert.ToString(cboCursos.SelectedValue);

            client.GetReprovadosPorCursoDisciplinaAnoAsync(strCurso, iAno);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (rb2009.IsChecked == true)
            {
                iAno = 2009;
                client.GetReprovadosPorCursoDisciplinaAnoAsync(strCurso, iAno);
            }
            if (rb2010.IsChecked == true)
            {
                iAno = 2010;
                client.GetReprovadosPorCursoDisciplinaAnoAsync(strCurso, iAno);
            }
            if (rb2011.IsChecked == true)
            {
                iAno = 2011;
                client.GetReprovadosPorCursoDisciplinaAnoAsync(strCurso, iAno);
            }
            if (rb2012.IsChecked == true)
            {
                iAno = 2012;
                client.GetReprovadosPorCursoDisciplinaAnoAsync(strCurso, iAno);
            }
            if (rb2013.IsChecked == true)
            {
                iAno = 2013;
                client.GetReprovadosPorCursoDisciplinaAnoAsync(strCurso, iAno);
            }
            if (rb2014.IsChecked == true)
            {
                iAno = 2014;
                client.GetReprovadosPorCursoDisciplinaAnoAsync(strCurso, iAno);
            }
        }
    }
}
