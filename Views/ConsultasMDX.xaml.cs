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
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace Portal_De_Analise.Views
{
    public partial class ConsultasMDX : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        PagedCollectionView collectionView = null;

        string strBanco = "UMinhoD";
        
        string cubo = "Cubo Fato Evidados Entrada Saida.cube";
        
        private bool isDragging;
        private UIElement currentElement;

        private BackgroundWorker backgroundWork = null;

        public ConsultasMDX()
        {
            InitializeComponent();

            isDragging = false;

            client.GetAMODataBasesCompleted += Client_GetAMODataBasesCompleted;
            client.GetAMODataBasesAsync();

            client.GetAMOCubosCompleted += Client_GetAMOCubosCompleted;
            client.GetAMOCubosAsync(strBanco);

            //txtQuery.Text = "Cubo Fato Evidados Entrada Saida.cube";
            txtQuery.Text = txtQuery.Text + "Select non empty crossjoin([Dim CURSOS 2].[DESC CURSO].children,[Dim DISCIPLINAS 1].[DESC DISCIPLINA].children) on rows,";
            txtQuery.Text = txtQuery.Text + "{[Measures].[Total Aprovado Curso Disc Ano MD],[Measures].[Total Reprovado Curso Disc Ano MD]} on columns";
            txtQuery.Text = txtQuery.Text + " from [Cubo Aprovado_Reprovado_Curso_Disciplina]";

            //Chama o método para pegar as consultas MDX da base de dados
            client.GetQueryMDXCompleted += Client_GetQueryMDXCompleted;
            client.GetQueryMDXAsync();
        }

        private void BackgroundWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            myProgressBar.Value = e.ProgressPercentage;
        }

        private void Client_GetQueryMDXCompleted(object sender, GetQueryMDXCompletedEventArgs e)
        {
            //Preeche a combo com as consultas MDX salvas no banco de dados
            cboMDX.ItemsSource = e.Result;
            cboMDX.UpdateLayout();
        }

        private void Client_GetAMOCubosCompleted(object sender, GetAMOCubosCompletedEventArgs e)
        {
            collectionView = new PagedCollectionView(e.Result.ToList());

            ListaAMOCubos.ItemsSource = collectionView;
            ListaAMOCubos.SelectedIndex = 0;
        }

        private void Client_GetAMODataBasesCompleted(object sender, GetAMODataBasesCompletedEventArgs e)
        {
            lstBancos.ItemsSource = e.Result.ToList();
            lstBancos.SelectedIndex = 0;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnProcessarCubo_Click(object sender, RoutedEventArgs e)
        {
            client.ProcessarCuboCompleted += Client_ProcessarCuboCompleted;
            client.ProcessarCuboAsync(strBanco);

            //Inicializa BackgloundWork
            backgroundWork = new BackgroundWorker();
            backgroundWork.DoWork += BackgroundWork_DoWork;
            backgroundWork.WorkerReportsProgress = true;
            backgroundWork.ProgressChanged += BackgroundWork_ProgressChanged;
            backgroundWork.RunWorkerAsync();
        }

        private void Client_ProcessarCuboCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            
            MessageBox.Show("Cubos processados com sucesso.");
        }

        private void btnExecutarMDX_Click(object sender, RoutedEventArgs e)
        {
            client.ExecutarMDXQueryCompleted += Client_ExecutarMDXQueryCompleted;
            client.ExecutarMDXQueryAsync(strBanco, txtQuery.Text);

            //Inicializa BackgloundWork
            backgroundWork = new BackgroundWorker();
            backgroundWork.DoWork += BackgroundWork_DoWork;
            backgroundWork.WorkerReportsProgress = true;
            backgroundWork.ProgressChanged += BackgroundWork_ProgressChanged;
            backgroundWork.RunWorkerAsync();

            //client.GetTableMDXQueryCompleted += Client_GetTableMDXQueryCompleted;
            //client.GetTableMDXQueryAsync(strBanco, txtQuery.Text);
        }

        private void BackgroundWork_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i=1; i <= 90; i++)
            {
                backgroundWork.ReportProgress(i);
                Thread.Sleep(300);
            }
        }

        private void Client_GetTableMDXQueryCompleted(object sender, GetTableMDXQueryCompletedEventArgs e)
        {
            collectionView = new PagedCollectionView(e.Result);
            dgMDX.ItemsSource = collectionView;
        }

        private void Client_ExecutarMDXQueryCompleted(object sender, ExecutarMDXQueryCompletedEventArgs e)
        {
            collectionView = new PagedCollectionView(e.Result);
            collectionView.PageSize = 15;
            collectionView.GroupDescriptions.Add(new PropertyGroupDescription("ColunaA"));
            this.DataContext = collectionView;
        }

        private void ListaAMOCubos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender != null)
            {
                //Localizar os grupos de medidas do cubo.
                client.GetCuboMedidas2Completed += Client_GetCuboMedidas2Completed;
                string cubo = ListaAMOCubos.SelectedValue.ToString();
                client.GetCuboMedidas2Async(strBanco, cubo);

                //Localizar as dimensões do cubo.
                client.GetAMODimensoesCompleted += Client_GetAMODimensoesCompleted;
                client.GetAMODimensoesAsync(strBanco, cubo);
            }
            else
            {
                MessageBox.Show("Atenção!, não nenhuma informação foi passada.");
            }

        }

        private void Client_GetCuboMedidas2Completed(object sender, GetCuboMedidas2CompletedEventArgs e)
        {
            //Atualizar a lista de grupo de medidas do cubo passado como parâmetro
            ListaAMOMedidas.ItemsSource = e.Result;
            ListaAMOMedidas.SelectedIndex = 0;
        }

        private void Client_GetAMODimensoesCompleted(object sender, GetAMODimensoesCompletedEventArgs e)
        {
            //ListaAMODimensao.ItemsSource = e.Result;
            //ListaAMODimensao.SelectedIndex = 0;
            treeDimensions.ItemsSource = e.Result;
        }

        private void Client_GetCuboMedidasCompleted(object sender, GetCuboMedidasCompletedEventArgs e)
        {
            //Atualizar a lista de grupo de medidas do cubo passado como parâmetro
            //ListaAMOMedidas.ItemsSource = e.Result;
            //ListaAMOMedidas.SelectedIndex = 0;
        }

        private void lstBancos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            strBanco = lstBancos.SelectedItem.ToString();

            client.GetAMOCubosAsync(strBanco);
        }

        private void ListaAMOMedidas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListaAMODimensao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnProcessarGrupoMedidas_Click(object sender, RoutedEventArgs e)
        {
            client.ProcessarGrupoCuboMedidasCompleted += Client_ProcessarGrupoMedidasCompleted;
            client.ProcessarGrupoCuboMedidasAsync(strBanco, cubo);
        }

        private void Client_ProcessarGrupoMedidasCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Grupos de medidas do cubo: " + cubo + "foi processado com sucesso.");
        }

        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(typeof(ListBox)))
            {
                
            }
        }

        private void ListBoxDragDropTarget_ItemDroppedOnTarget(object sender, ItemDragEventArgs e)
        {
            e.Cancel = true; e.Handled = true;
            if(isDragging && currentElement != null && (currentElement as TextBox) != null)
            {
                isDragging = false;
                (currentElement as TextBox).Text = ((System.Collections.ObjectModel.SelectionCollection)(e.Data))[0].Item.ToString();
            }
        }

        private void ListBoxDragDropTarget_ItemDragStarting(object sender, ItemDragEventArgs e)
        {
            isDragging = true;
        }

        private void TextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            currentElement = null;
        }

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            currentElement = txtQuery;
        }

        private void btnSintaxe_Click(object sender, RoutedEventArgs e)
        {
            VisualizaSintaxMDX childSintaxMDX = new VisualizaSintaxMDX();

            childSintaxMDX.Show();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProcessarDim_Click(object sender, RoutedEventArgs e)
        {
            client.ProcessarDimensoesCompleted += Client_ProcessarDimensoesCompleted;
            client.ProcessarDimensoesAsync(strBanco);
        }

        private void Client_ProcessarDimensoesCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Dimensões processadas com sucesso.");
        }
    }
}
