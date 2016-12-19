using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Portal_De_Analise
{
    public partial class About : Page
    {
        public About()
        {
            InitializeComponent();

            txtEvasaoUm.Text = "Dados do Instituto Brasileiro de Geografia e Estatística (IBGE) divulgados nesta quarta-feira colocam a taxa de abandono escolar como um";
            txtEvasaoUm.Text = txtEvasaoUm.Text + " dos principais fatores para o fraco desempenho do Brasil em indicadores educacionais quando comparado a outras nações.";
            txtEvasaoDois.Text = txtEvasaoDois.Text + "De acordo com o IBGE, apesar de o País ter registrado uma queda de 11,5% na taxa de abandono do ensino de 2001 para 2011 entre jovens";
            txtEvasaoDois.Text = txtEvasaoDois.Text + "com 18 e 24 anos, essa média ainda é três vezes maior do que o percentual verificado em 29 países europeus. ";
            txtEvasaoTres.Text = "O IBGE, que analisou dados da Pesquisa Nacional por Amostra de Domicílios (Pnad), mostrou que o percentual de jovens que não haviam";
            txtEvasaoTres.Text = txtEvasaoTres.Text + " completado o ensino médio e que não estavam estudando passou de 43,8% em 2001 para 32,2% em 2011. Em países como Suíça, Polônia,";
            txtEvasaoTres.Text = txtEvasaoTres.Text + " Áustria, Irlanda, Dinamarca e Bélgica, a taxa de abandono dos estudos é de menos de 10%. Itália, França e Alemanha tem percentuais inferiores a 15%. ";
            txtEvasaoQua.Text = "Ainda de acordo com o IBGE, em 2011 o abandono escolar atingia mais da metade dos jovens de 18 e 24 anos pertencentes à fatia mais pobre da população, enquanto no quinto mais rico essa proporção era de apenas 9,6%.";
            txtEvasaoQui.Text = "Na análise dos dados, o instituto utilizou um estudo feito em países da Organização para a Cooperação e Desenvolvimento Econômico ";
            txtEvasaoQui.Text = txtEvasaoQui.Text + "(OECD), que confirma a maior vulnerabilidade dos jovens que não concluíram o ensino médio em relação ao acesso às oportunidades de ";
            txtEvasaoQui.Text = txtEvasaoQui.Text + "qualificação e ao emprego estável. Eles vivenciam maiores chances de desemprego, também sofrem com empregos instáveis, inseguros e de ";
            txtEvasaoQui.Text = txtEvasaoQui.Text + "baixa remuneração, aponta o estudo.";

            txtEvasaoSex.Text = "Por isso, os jovens que abandonaram a escola sem completar o ensino médio tornaram-se o problema mais grave a ser enfrentado pela ";
            txtEvasaoSex.Text = txtEvasaoSex.Text + "política educacional desses países atualmente, diz o IBGE na análise.";
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}