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
    public partial class KPIAlunoPorDisciplina : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        PagedCollectionView collectionView = null;

        string strTurma = "20131.1.8413.1V";
        public KPIAlunoPorDisciplina()
        {
            InitializeComponent();

            client.GetTurmaCompleted += Client_GetTurmaCompleted;
            client.GetTurmaAsync();

            client.GetKPIAlunoAnoCompleted += Client_GetKPIAlunoAnoCompleted;
            client.GetKPIAlunoAnoAsync(strTurma);
        }

        private void Client_GetTurmaCompleted(object sender, GetTurmaCompletedEventArgs e)
        {
            cboTurma.ItemsSource = e.Result.ToList();
        }

        private void Client_GetKPIAlunoAnoCompleted(object sender, GetKPIAlunoAnoCompletedEventArgs e)
        {
            collectionView = new PagedCollectionView(e.Result);
            collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Matricula"));
            collectionView.PageSize = 20;
            DataContext = collectionView;
         
            dgKPIAlunoDisciplina.ItemsSource = collectionView;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
        }

        private void cboTurma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null)
            {
                //ComboBoxItem cbi = (ComboBoxItem)((ComboBox)sender).SelectedItem;
                strTurma = cboTurma.SelectedValue.ToString();
                client.GetKPIAlunoAnoAsync(strTurma);
            }
        }
    }
}
