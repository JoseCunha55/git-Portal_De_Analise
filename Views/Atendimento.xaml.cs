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
using System.Windows.Media.Imaging;
using Portal_De_Analise.Portal_De_AnaliseServiceReference;
using System.Configuration;
using System.Windows.Data;

namespace Portal_De_Analise.Views
{
    public partial class Atendimento : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        PagedCollectionView view = null;

        public Atendimento()
        {
            InitializeComponent();
           
            imagemEduCase.Source = new BitmapImage(new Uri("/images/EduCase.png", UriKind.Relative));
            imageIFRN.Source = new BitmapImage(new Uri("/images/ifrn.jpg", UriKind.Relative));
            imageUM.Source = new BitmapImage(new Uri("/images/um.jpg", UriKind.Relative));

            //client.GetAllBCasosCompleted += Client_GetAllBCasosCompleted;
            //client.GetAllBCasosAsync();
        }

        //private void Client_GetAllBCasosCompleted(object sender, GetAllBCasosCompletedEventArgs e)
        //{
        //    view = new PagedCollectionView(e.Result);
        //    view.PageSize = 1;
        //    DataContext = view;
        //}


        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            client.SavarBCasoCompleted += Client_SavarBCasoCompleted;
            BCasos caso = new BCasos();
            caso.MATRICULA = txtMatricula.Text;
            caso.NOME = txtNome.Text;
            caso.SEXO = txtSexo.Text;
            caso.TELEFONE = txtTelefone.Text;
            caso.EMAIL = txtEmail.Text;
            caso.CURSO = txtCurso.Text;
            caso.PERIODO = Convert.ToInt16( txtPeriodo.Text );
            caso.DATA = Convert.ToDateTime( dtData.DisplayDate);
            caso.OBSERVACOES = txtObservacoes.Text;
            caso.contexto = txtContexto.Text;
            caso.atendidoPor = txtAtendidoPor.Text;
            client.SavarBCasoAsync(caso);
        }

        private void Client_SavarBCasoCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Caso foi salvo com Sucesso.");
        }
    }
}
