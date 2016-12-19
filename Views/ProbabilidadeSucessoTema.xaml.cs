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
using System.Windows.Data;
using Portal_De_Analise.Portal_De_AnaliseServiceReference;

namespace Portal_De_Analise.Views
{
    public partial class ProbabilidadeSucessoTema : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();
        PagedCollectionView collection = null;
        public ProbabilidadeSucessoTema()
        {
            InitializeComponent();

            client.GetProbabilidadeSucessoEtniaCompleted += Client_GetProbabilidadeSucessoEtniaCompleted;
            client.GetProbabilidadeSucessoEtniaAsync();
          
        }

        private void Client_GetProbabilidadeSucessoEtniaCompleted(object sender, GetProbabilidadeSucessoEtniaCompletedEventArgs e)
        {
            collection = new PagedCollectionView(e.Result);
            collection.PageSize = 20;
            dgProbSucessoTema.ItemsSource = collection;
            DataContext = collection;
          
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
