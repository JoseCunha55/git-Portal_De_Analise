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
    public partial class ProbabilidadeSucessoEscola : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        PagedCollectionView collection = null;
        public ProbabilidadeSucessoEscola()
        {
            InitializeComponent();

            client.GetProbabilidadeSucessoEscolaCompleted += Client_GetProbabilidadeSucessoEscolaCompleted;
            client.GetProbabilidadeSucessoEscolaAsync();
        }

        private void Client_GetProbabilidadeSucessoEscolaCompleted(object sender, GetProbabilidadeSucessoEscolaCompletedEventArgs e)
        {
            collection = new PagedCollectionView(e.Result);
            collection.PageSize = 20;
            DataContext = collection;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
