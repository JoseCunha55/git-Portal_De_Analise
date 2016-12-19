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
using System.Text;

namespace Portal_De_Analise.Views
{
    public partial class VisualizaSintaxMDX : ChildWindow
    {
        StringBuilder sintaxeMDX = new System.Text.StringBuilder();
        StringBuilder demo1MDX = new StringBuilder();

        public VisualizaSintaxMDX()
        {
            InitializeComponent();
            sintaxeMDX.Append("[ WITH  <SELECT WITH clause> [ , <SELECT WITH clause> ... ] ]");
            sintaxeMDX.Append("SELECT[* | ( < SELECT query axis clause >");
            sintaxeMDX.Append("[ , < SELECT query axis clause > ... ] ) ]");
            sintaxeMDX.Append("FROM < SELECT subcube clause>");
            sintaxeMDX.Append("[ < SELECT slicer axis clause > ]");
            sintaxeMDX.Append("[ < SELECT cell property list clause > ]");

            txtSintax.Text = sintaxeMDX.ToString();

            demo1MDX.Append("SELECT non empty CrossJoin([Dim CURSOS].[DESC CURSO].children,");
            demo1MDX.Append("[Dim INSTITUICOES].[DESC INSTITUICAO].children ) on rows,");
            demo1MDX.Append("{[Measures].[Total Concluido], [Measures].[Total Evadido],");
            demo1MDX.Append("[Measures].[PercetualConclusão],[Measures].[PercetualConclusão],");
            demo1MDX.Append("[Measures].[TotalEvaCon]}ON Columns");
            demo1MDX.Append("from[Cubo Fato Evidados Entrada Saida]");

            txtDemo1MDX.Text = demo1MDX.ToString();
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

