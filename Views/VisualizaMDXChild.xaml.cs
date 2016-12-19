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

namespace Portal_De_Analise.Views
{
    public partial class VisualizaMDXChild : ChildWindow
    {
        public VisualizaMDXChild()
        {
            InitializeComponent();

            string query = "select non empty CrossJoin([Dim CURSOS].[DESC CURSO].children,";
            query = query + "[Dim INSTITUICOES].[DESC INSTITUICAO].children ) on rows,";
            query = query + "{[Measures].[Total Concluido], [Measures].[Total Evadido],";
            query = query + "[Measures].[PercetualConclusão],[Measures].[PercetualConclusão],";
            query = query + "[Measures].[TotalEvaCon]}ON Columns from[Cubo Fato Evidados Entrada Saida]";

            txtMDX.Text = query;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

