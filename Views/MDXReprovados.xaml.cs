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
using System.Runtime.InteropServices.Automation;
using System.Windows.Interop;
using System.Windows.Data;

namespace Portal_De_Analise.Views
{
    public partial class MDXReprovados : Page
    {
        Porta_De_AnaliseServiceClient client = new Porta_De_AnaliseServiceClient();

        
        PagedCollectionView collection = null;
        public MDXReprovados()
        {
            InitializeComponent();

            //String query = "Select non empty CrossJoin([Dim CURSOS 2].[DESC CURSO].children,";
            //query = query + "[Dim DISCIPLINAS 1].[DESC DISCIPLINA].children) on rows,";
            //query = query + "{[Measures].[Total Aprovado Curso Disc Ano MD], [Measures].[Total Reprovado Curso Disc Ano MD]} on columns";
            //query = query + " FROM [Cubo Aprovado_Reprovado_Curso_Disciplina]";
            //String query = "SELECT NON EMPTY ({[Measures].[Total Aprovado Curso Disc Ano MD],[Measures].[Total Reprovado Curso Disc Ano MD] }) on COLUMNS,";
            //query = query + "NON EMPTY([Dim CURSOS 2].[DESC CURSO].ALLMEMBERS,[Dim DISCIPLINAS 1].[DESC DISCIPLINA].ALLMEMBERS,[Dim DATA 2].[ANO].&[2010]) ON ROWS";
            //query = query + " FROM [Cubo Aprovado_Reprovado_Curso_Disciplina]";
            //CarregarGrid();

            //client.ADOMDGetAprReprCursoDiscCompleted += Client_ADOMDGetAprReprCursoDiscCompleted;
            //client.ADOMDGetAprReprCursoDiscAsync(query);
            //client.GetDataCompleted += Client_GetDataCompleted;
            //client.GetDataAsync(query);
            //client.GetMDXAprReprCursoDiscCompleted += Client_GetMDXAprReprCursoDiscCompleted;
            //client.GetMDXAprReprCursoDiscAsync();
            client.GetAprReprCursoDisciplinaCompleted += Client_GetAprReprCursoDisciplinaCompleted;
            client.GetAprReprCursoDisciplinaAsync();

        }

        private void Client_GetAprReprCursoDisciplinaCompleted(object sender, GetAprReprCursoDisciplinaCompletedEventArgs e)
        {
            collection = new PagedCollectionView(e.Result);
            collection.PageSize = 15;
            collection.GroupDescriptions.Add(new PropertyGroupDescription("Curso"));

            dgCliente.ItemsSource = collection;

            this.DataContext = collection;
            client.CloseAsync();
        }

        private void Client_GetMDXAprReprCursoDiscCompleted(object sender, GetMDXAprReprCursoDiscCompletedEventArgs e)
        {
            collection = new PagedCollectionView((System.Collections.IEnumerable)e.Result);
            dgCliente.ItemsSource = collection;

            client.CloseAsync();
        }

        private void Client_GetDataCompleted(object sender, GetDataCompletedEventArgs e)
        {
            collection = new PagedCollectionView((System.Collections.IEnumerable)e.Result);
            dgCliente.ItemsSource = collection;

            client.CloseAsync();
        }

        private void Client_ADOMDGetAprReprCursoDiscCompleted(object sender, ADOMDGetAprReprCursoDiscCompletedEventArgs e)
        {
            collection = new PagedCollectionView((System.Collections.IEnumerable)e.Result);
            dgCliente.ItemsSource = collection;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            //Abrir o Excel
            
            dynamic excel;
            //Criando uma novo aplicação Excel
            excel = AutomationFactory.CreateObject("Excel.Application");
            //Deixando a aplicação visível
            excel.Visible = true;
            // Criando um novo arquivo para a aplicação
            // Lembrando que um workbook é um conjunto de planilhas
            dynamic workbook = excel.workbooks;
            workbook.Add();
            // Pega a planilha que acabamos de criar
            dynamic sheet = excel.ActiveSheet;
            // Criando o título
            sheet.Cells[1, 1].Value = "Exporta Cubo";
            // Fonte negrito
            sheet.Cells[1, 1].Font.Bold = true;
            // Mesclando as celulas
            sheet.Range("A1:C1").Merge();
            // Centralizando o alinhamento horizontal
            sheet.Range("A1:C1").HorizontalAlignment = -4108;
            // Criando as colunas (lembrando as celulas das planilhas começam com o índice 1
            for (int coluna = 1; coluna <= dgCliente.Columns.Count; coluna++)
            {
                sheet.Cells[3, coluna].Value = dgCliente.Columns[coluna - 1].Header;
                sheet.Cells[3, coluna].Font.Bold = true;
                // Cor do Interior: Cinza
                sheet.Cells[3, coluna].Interior.Color = 14540253;
            }

            // Criando as linhas
            int linha = 4;
            foreach (AprReprCursoDisc apr in dgCliente.ItemsSource)
            {
                sheet.Cells[linha, 1].Value = apr.Curso;
                sheet.Cells[linha, 2].Value = apr.Disciplina;
                sheet.Cells[linha, 3].Value = apr.Ano;
                sheet.cells[linha, 4].value = apr.Aprovados;
                sheet.cells[linha, 5].value = apr.Reprovados;

                // Se o indice da linha for par, a cor será verde
                // caso contrário a cor será azul
                sheet.Cells[linha, 1].Interior.Color =
                sheet.Cells[linha, 2].Interior.Color =
                sheet.Cells[linha, 3].Interior.Color = (linha % 2 == 0) ? 13434828 : 16772300;

                linha++;
            }

        }

        private void CarregarGrid()
        {
            // Criando lista de Clientes
            List<Cliente> lstClientes = new List<Cliente>();
            // Alimentando a lista
            lstClientes.Add(new Cliente { Codigo = 1, Nome = "Victor Rodrigues", Cidade = "São Paulo" });
            lstClientes.Add(new Cliente { Codigo = 2, Nome = "Renata Nahum", Cidade = "Bueno Aires" });
            lstClientes.Add(new Cliente { Codigo = 3, Nome = "Adilson Santana", Cidade = "Kiev" });
            lstClientes.Add(new Cliente { Codigo = 4, Nome = "Ronaldo Gaucho", Cidade = "Londres" });
            lstClientes.Add(new Cliente { Codigo = 5, Nome = "Marcos Arremar", Cidade = "Miami" });

            // Alimentando o grid com a lista de clientes
            //dgCliente.ItemsSource = lstClientes;
        }
        public static void EjecutaEXE (string ruta)
        {
            using (dynamic shell = AutomationFactory.CreateObject("WScript.shell"))
            {
                shell.Run(@ruta);
            }
        }
       
    }
}
