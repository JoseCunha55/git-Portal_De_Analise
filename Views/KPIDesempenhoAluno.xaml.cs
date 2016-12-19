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
    public partial class KPIDesempenhoAluno : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        PagedCollectionView collectionView = null;

        string strTurma = "20101.06401.1AV";
        public KPIDesempenhoAluno()
        {
            InitializeComponent();

            client.GetTurmaCompleted += Client_GetTurmaCompleted;
            client.GetTurmaAsync();

            client.GetKPIDesempenhoAlunoCompleted += Client_GetKPIDesempenhoAlunoCompleted;
            client.GetKPIDesempenhoAlunoAsync(strTurma);
        }

        private void Client_GetTurmaCompleted(object sender, GetTurmaCompletedEventArgs e)
        {
            cboTurma.ItemsSource = e.Result.ToList();
        }

        private void Client_GetKPIDesempenhoAlunoCompleted(object sender, GetKPIDesempenhoAlunoCompletedEventArgs e)
        {
            collectionView = new PagedCollectionView(e.Result);

            //Agrupado por Campus
            collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Campus"));
            //Dentro campus, agrupado por Sigla do curso
            collectionView.GroupDescriptions.Add(new PropertyGroupDescription("SiglaCurso"));
            
            collectionView.PageSize = 40;

            DataContext = collectionView;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void cboTurma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(((ComboBox)sender).SelectedItem != null )
            {
                //ComboBoxItem cbi = (ComboBoxItem)((ComboBox)sender).SelectedItem;
                strTurma = cboTurma.SelectedValue.ToString();
                client.GetKPIDesempenhoAlunoAsync(strTurma);
            }
        }

        private void cboTurma_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
