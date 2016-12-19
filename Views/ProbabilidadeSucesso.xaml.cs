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
    public partial class ProbabilidadeSucesso : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        PagedCollectionView view = null;
        public ProbabilidadeSucesso()
        {
            InitializeComponent();

            client.GetProbalidadeSucessoCompleted += Client_GetProbalidadeSucessoCompleted;
            client.GetProbalidadeSucessoAsync();
        }
        private void Client_GetProbalidadeSucessoCompleted(object sender, GetProbalidadeSucessoCompletedEventArgs e)
        {
            view = new PagedCollectionView(e.Result);
            view.PageSize = 25;
            DataContext = view;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
