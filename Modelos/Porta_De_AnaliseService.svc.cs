using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Collections.Generic;
using Portal_De_Analise.Web.Models;
using System.Data;
using Microsoft.AnalysisServices.AdomdClient;
using System.Windows;
using System.Data.Entity;
using Microsoft.AnalysisServices.Hosting;
using Microsoft.AnalysisServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices.Automation;
using System.Collections;

namespace Portal_De_Analise.Web.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Porta_De_AnaliseService
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["MeuBanco"] as ConnectionStringSettings;

        private static dynamic excel = null;

        [OperationContract]
        public List<EvasaoCursoAno> GetEvadidosPorCursoAno(int pAno)
        {
            List<EvasaoCursoAno> lista = new List<EvasaoCursoAno>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd = new SqlCommand("sp_EvasaoPorCursoAno", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ano", pAno);

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            EvasaoCursoAno evasao = new EvasaoCursoAno();
                            evasao.Ano = Convert.ToInt16(rd["Ano"]);
                            evasao.Curso = rd["Curso"].ToString();
                            evasao.Evadidos = Convert.ToInt16(rd["Tota_Evadidos"]);

                            lista.Add(evasao);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public void SaveEvadidosPorCursoAno(EvasaoCursoAno obj)
        {
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_AtualizarEvaPorCursoAno", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ano", obj.Ano);
                    cmd.Parameters.AddWithValue("@Curso", obj.Curso);
                    cmd.Parameters.AddWithValue("@Tota_Evadidos", obj.Evadidos);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        [OperationContract]
        public List<ConsultaMDX> GetQueryMDX()
        {
            List<ConsultaMDX> lista = new List<ConsultaMDX>();

            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Select * From [DDSEducacional].[dbo].[ConsultasMDX]", con);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader rd = null;
                    try
                    {
                        con.Open();
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while(rd.Read())
                        {
                            ConsultaMDX mdx = new ConsultaMDX();
                            mdx.ConMDXID = rd["ConMDXID"].ToString();
                            mdx.Titulo = rd["Titulo"].ToString();
                            mdx.MDX = rd["MDX"].ToString();

                            lista.Add(mdx);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }
        [OperationContract]
        public List<EvasaoPorCampusAno> GetEvadidosPorCampusAno(string pCampus, int pAno)
        {
            List<EvasaoPorCampusAno> lista = new List<EvasaoPorCampusAno>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd = new SqlCommand("sp_EvasaoPorCampusAno", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Campus", pCampus);
                    cmd.Parameters.AddWithValue("@Ano", pAno);

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            EvasaoPorCampusAno evasao = new EvasaoPorCampusAno();
                            evasao.Campus = rd["Campus"].ToString();
                            evasao.Ano = Convert.ToInt16(rd["Ano"]);
                            evasao.Situacao = rd["Situacao"].ToString();
                            evasao.Total_Situacao = Convert.ToInt16(rd["Total"]);
                            evasao.Total_Aluno = Convert.ToInt16(rd["TotalAluno"]);
                            evasao.Percentual = Convert.ToDecimal(rd["Percentual"]);

                            lista.Add(evasao);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<ReprovadosPorDiscCurso> GetReprovadosPorCursoDisciplinaAno(string pCurso, int pAno)
        {
            List<ReprovadosPorDiscCurso> lista = new List<ReprovadosPorDiscCurso>();

            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd = new SqlCommand("sp_ReprovadosPorDiscipliaECurso", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Curso", pCurso);
                    cmd.Parameters.AddWithValue("@Ano", pAno);

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            ReprovadosPorDiscCurso reprovados = new ReprovadosPorDiscCurso();
                            reprovados.Disciplina = rd["Desc_Disciplina"].ToString();
                            reprovados.Ano = Convert.ToInt16(rd["Ano_Let"]);
                            reprovados.Semestre = Convert.ToInt16(rd["Periodo_Let"]);
                            reprovados.Situacao = rd["Situacao_Matricula_Pauta"].ToString();
                            reprovados.Total = Convert.ToInt16(rd["Total"]);
                            lista.Add(reprovados);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<Curso> GetCursos(int pAno)
        {
            List<Curso> lista = new List<Curso>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd = new SqlCommand("sp_Cursos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ano", pAno);
                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            Curso cursos = new Curso();
                            cursos.Cursos = rd["Desc_Curso"].ToString();
                            lista.Add(cursos);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<ObjSilgaCurso> GetSilgaCursos(int pAno)
        {
            List<ObjSilgaCurso> lista = new List<ObjSilgaCurso>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd = new SqlCommand("sp_GetSiglaCursoDS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ano", pAno);
                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            ObjSilgaCurso siglaCursos = new ObjSilgaCurso();
                            siglaCursos.SiglaCurso = rd["Sigla_Curso"].ToString();
                            lista.Add(siglaCursos);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<ReprovadosPorCampus> GetReprovadosPorCampus(string pCampus)
        {
            List<ReprovadosPorCampus> lista = new List<ReprovadosPorCampus>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd = new SqlCommand("sp_ReprovadosPorCampus", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Campus", pCampus);

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            ReprovadosPorCampus reprovadosCampus = new ReprovadosPorCampus();
                            reprovadosCampus.Campus = rd["Campus"].ToString();
                            reprovadosCampus.Curso = rd["Curso"].ToString();
                            reprovadosCampus.Situacao = rd["Situacao"].ToString();
                            reprovadosCampus.Ano = Convert.ToInt16(rd["AnoLetivo"]);
                            reprovadosCampus.Semestre = Convert.ToInt16(rd["PeriodoLetivo"]);
                            reprovadosCampus.Total = Convert.ToInt16(rd["Total"]);

                            lista.Add(reprovadosCampus);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<ReprovadoPorCurso> GetReprovadosPorCursoAno(int pAno)
        {
            List<ReprovadoPorCurso> lista = new List<ReprovadoPorCurso>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd = new SqlCommand("sp_ReprovadosPorCurso", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ano", pAno);

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            ReprovadoPorCurso reprovado = new ReprovadoPorCurso();
                            reprovado.Curso = rd["Curso"].ToString();
                            reprovado.Situacao = rd["Situacao"].ToString();
                            reprovado.Ano = Convert.ToInt16(rd["Ano"]);
                            reprovado.Total = Convert.ToInt16(rd["Total"]);

                            lista.Add(reprovado);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<KPIDesempenhoAluno> GetKPIDesempenhoAluno(string pTurma)
        {
            List<KPIDesempenhoAluno> lista = new List<KPIDesempenhoAluno>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd = new SqlCommand("sp_KPIDesempenhoAluno", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Turma", pTurma);

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            KPIDesempenhoAluno kpiAluno = new KPIDesempenhoAluno();
                            kpiAluno.Matricula = rd["Matricula"].ToString();
                            kpiAluno.Turma = rd["Turma"].ToString();
                            kpiAluno.SiglaCurso = rd["SiglaCurso"].ToString();
                            kpiAluno.Campus = rd["Campus"].ToString();
                            kpiAluno.AnoLetivo = rd["AnoLetivo"].ToString();
                            kpiAluno.PeriodoLetivo = Convert.ToInt16(rd["PeriodoLetivo"]);
                            kpiAluno.Rendimento = Convert.ToDecimal(rd["Rendimento"]);

                            lista.Add(kpiAluno);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<KPIAlunoAno> GetKPIAlunoAno(string pTurma)
        {
            List<KPIAlunoAno> lista = new List<KPIAlunoAno>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd = new SqlCommand("sp_KPIAluno", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Turma", pTurma);

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            KPIAlunoAno kpiAluno = new KPIAlunoAno();
                            kpiAluno.DescricaoCurso = rd["DESCRICAO_CURSO"].ToString();
                            kpiAluno.Turma = rd["Turma"].ToString();
                            kpiAluno.Disciplina = rd["DESCRICAO_DISCIPLINA"].ToString();
                            kpiAluno.Campus = rd["DESCRICAO_INSTITUICAO"].ToString();
                            kpiAluno.Matricula = rd["Matricula"].ToString();
                            kpiAluno.NomeAluno = rd["NOME_ALUNO"].ToString();
                            kpiAluno.AnoLetivo = Convert.ToInt16(rd["ANO_LETIVO"]);
                            kpiAluno.PeriodoLetivo = Convert.ToInt16(rd["PERIODO_LETIVO"]);
                            kpiAluno.Media = Convert.ToDecimal(rd["Media_DIARIO"]);

                            lista.Add(kpiAluno);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<ObjTurma> GetTurma()
        {
            List<ObjTurma> lista = new List<ObjTurma>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd = new SqlCommand("Select Distinct Turma FROM TB_AS_BoletimEscolar Order by 1", con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            ObjTurma turma = new ObjTurma();
                            turma.Turma = rd["Turma"].ToString();

                            lista.Add(turma);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<ObjMatricula> GetMatricula(string pTurma)
        {
            List<ObjMatricula> lista = new List<ObjMatricula>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd = new SqlCommand("sp_GetMatricula", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Turma", pTurma);

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            ObjMatricula matricula = new ObjMatricula();
                            matricula.Matricula = rd["Matricula"].ToString();

                            lista.Add(matricula);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<TurmaMatricula> GetTurmaMatricula(string pCampus)
        {
            List<TurmaMatricula> lista = new List<TurmaMatricula>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd = new SqlCommand("sp_GetTurmaMatricula", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Campus", pCampus);

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            TurmaMatricula turmaMatricula = new TurmaMatricula();

                            turmaMatricula.Turma = rd["Turma"].ToString();
                            turmaMatricula.Matricula = rd["Matricula"].ToString();

                            lista.Add(turmaMatricula);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<CuboEvaConES> ADOMDGetCubeEvaConEntradaSaida()
        {
            List<CuboEvaConES> lista = null;

            using (AdomdConnection con = new AdomdConnection("Data Source=JoseAntonio-PC;Integrated Security=SSPI;Initial Catalog=UMinhoD"))
            {
                try
                {
                    con.Open();

                    string query = "select non empty CrossJoin([Dim CURSOS].[DESC CURSO].children, ";
                    query = query + "[Dim INSTITUICOES].[DESC INSTITUICAO].children ) on rows,";
                    query = query + "{[Measures].[Total Concluido], [Measures].[Total Evadido],";
                    query = query + "[Measures].[PercetualConclusão],[Measures].[PercetualConclusão],";
                    query = query + "[Measures].[TotalEvaCon]} ON Columns from[Cubo Fato Evidados Entrada Saida]";

                    using (AdomdCommand cmd = new AdomdCommand(query, con))
                    {
                        using (AdomdDataReader dr = cmd.ExecuteReader())
                        {
                            lista = new List<CuboEvaConES>();

                            while (dr.Read())
                            {
                                CuboEvaConES EvaConES = new CuboEvaConES();
                                EvaConES.Curso = dr[0].ToString();
                                EvaConES.Campus = dr[1].ToString();
                                EvaConES.Concluidos = Convert.ToDecimal(dr[2]);
                                EvaConES.Evadidos = Convert.ToDecimal(dr[3]);
                                EvaConES.PerConclusao = (Convert.ToDecimal(dr[2]) / (Convert.ToDecimal(dr[2]) + Convert.ToDecimal(dr[3])));
                                EvaConES.PerEvadidos = (Convert.ToDecimal(dr[3]) / (Convert.ToDecimal(dr[2]) + Convert.ToDecimal(dr[3])));
                                EvaConES.TotalEvaCon = Convert.ToInt16(dr[2]) + Convert.ToInt16(dr[3]);

                                lista.Add(EvaConES);
                            }
                        }
                        return lista;
                    }
                }
                catch (AdomdException e)
                {
                    throw new Exception("AdomdError: " + e.Message);
                }
                finally
                {
                    con.Close();
                }
            }

        }

        [OperationContract]
        public List<IndicadorAll> GetIndicadoresAll()
        {
            List<IndicadorAll> lista = new List<IndicadorAll>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd = new SqlCommand("Select * from INDICADORES_SUAP", con);

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            IndicadorAll indAll = new IndicadorAll();
                            indAll.Indicadores = rd["Indicadores"].ToString();
                            indAll.ANO_2005 = Convert.ToDecimal(rd["Ano_2005"]);
                            indAll.ANO_2006 = Convert.ToDecimal(rd["Ano_2006"]);
                            indAll.ANO_2007 = Convert.ToDecimal(rd["Ano_2007"]);
                            indAll.ANO_2008 = Convert.ToDecimal(rd["Ano_2008"]);
                            indAll.ANO_2009 = Convert.ToDecimal(rd["Ano_2009"]);
                            indAll.ANO_2010 = Convert.ToDecimal(rd["Ano_2010"]);
                            indAll.ANO_2011 = Convert.ToDecimal(rd["Ano_2011"]);
                            indAll.ANO_2012 = Convert.ToDecimal(rd["Ano_2012"]);
                            indAll.ANO_2013 = Convert.ToDecimal(rd["Ano_2013"]);
                            indAll.ANO_2014 = Convert.ToDecimal(rd["Ano_2014"]);
                            indAll.Média = Convert.ToDecimal(rd["Média"]);

                            lista.Add(indAll);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<IndicadorCNATCurso> GetIndicadoresCampusCurso()
        {
            List<IndicadorCNATCurso> lista = new List<IndicadorCNATCurso>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd = new SqlCommand("Select * from [Indicadores de Ensino CNATCusro_SUAP]", con);

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            IndicadorCNATCurso indCNATCurso = new IndicadorCNATCurso();
                            indCNATCurso.Indicadores = rd["Indicadores"].ToString();
                            indCNATCurso.ANO_2005 = Convert.ToDecimal(rd["2005"]);
                            indCNATCurso.ANO_2006 = Convert.ToDecimal(rd["2006"]);
                            indCNATCurso.ANO_2007 = Convert.ToDecimal(rd["2007"]);
                            indCNATCurso.ANO_2008 = Convert.ToDecimal(rd["2008"]);
                            indCNATCurso.ANO_2009 = Convert.ToDecimal(rd["2009"]);
                            indCNATCurso.ANO_2010 = Convert.ToDecimal(rd["2010"]);
                            indCNATCurso.ANO_2011 = Convert.ToDecimal(rd["2011"]);
                            indCNATCurso.ANO_2012 = Convert.ToDecimal(rd["2012"]);
                            indCNATCurso.ANO_2013 = Convert.ToDecimal(rd["2013"]);
                            indCNATCurso.ANO_2014 = Convert.ToDecimal(rd["2014"]);
                            indCNATCurso.ANO_2015 = Convert.ToDecimal(rd["2015"]);
                            indCNATCurso.Média = Convert.ToDecimal(rd["Média"]);
                            indCNATCurso.Campus = rd["Campus"].ToString();
                            indCNATCurso.Curso = rd["Curso"].ToString();

                            lista.Add(indCNATCurso);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<IndicadorLicenciaturas> GetIndicadoresLicenciaturas()
        {
            List<IndicadorLicenciaturas> lista = new List<IndicadorLicenciaturas>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd = new SqlCommand("Select * from IndicadorEvasaoLicenciaturas_SUAP", con);

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            IndicadorLicenciaturas indLinc = new IndicadorLicenciaturas();
                            indLinc.Curso = rd["Curso"].ToString();
                            indLinc.TotalEvadidos = Convert.ToInt16(rd["TotalEvadidos"]);
                            indLinc.TotalConcluidos = Convert.ToInt16(rd["TotalConcluidos"]);
                            indLinc.TotalAlunos = Convert.ToInt16(rd["TotalAlunos"]);
                            indLinc.TaxaEvasao = Convert.ToDecimal(rd["TaxaEvasao"]);
                            indLinc.TaxaConclusao = Convert.ToDecimal(rd["TaxaConclusao"]);

                            lista.Add(indLinc);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<ProbalidadeSucesso> GetProbalidadeSucesso()
        {
            List<ProbalidadeSucesso> lista = new List<ProbalidadeSucesso>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd = new SqlCommand("Select * from TB_ProbalidadeSucesso", con);

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            ProbalidadeSucesso probSucesso = new ProbalidadeSucesso();
                            probSucesso.Matricula = rd["Matricula"].ToString();
                            probSucesso.NumeroReprovacoes = Convert.ToInt16(rd["NumeroReprovacoes"]);
                            probSucesso.Sucesso = ((Math.Pow(probSucesso.NumeroReprovacoes, 1)) * (Math.Pow(Math.E, -probSucesso.NumeroReprovacoes)) / 1) * 100.00;
                            probSucesso.InSucesso = 100.00 - probSucesso.Sucesso;

                            lista.Add(probSucesso);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<ProbabilidadeSucessoEtnia> GetProbabilidadeSucessoEtnia()
        {
            List<ProbabilidadeSucessoEtnia> lista = new List<ProbabilidadeSucessoEtnia>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd =
                        new SqlCommand("Select * from TB_ProbabilidadeSucessoEtnia where Matricula !='EtniaBarnca' and Matricula !='EtniaPreta' and Matricula!='EtniaParda' and Matricula!='EtniaAmarela'", con);

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            ProbabilidadeSucessoEtnia psEtnia = new ProbabilidadeSucessoEtnia();
                            psEtnia.Matricula = rd["Matricula"].ToString();
                            psEtnia.Tema = rd["Tema"].ToString();
                            psEtnia.Reprovacao = Convert.ToInt16(rd["Reprovacao"]);
                            psEtnia.Sucesso = ((Math.Pow(psEtnia.Reprovacao, 1)) * (Math.Pow(Math.E, -psEtnia.Reprovacao)) / 1) * 100.00;
                            psEtnia.InSucesso = 100.00 - psEtnia.Sucesso;

                            lista.Add(psEtnia);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<ProbabilidadeSucessoEscola> GetProbabilidadeSucessoEscola()
        {
            List<ProbabilidadeSucessoEscola> lista = new List<ProbabilidadeSucessoEscola>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd =
                        new SqlCommand("select * from TB_ProbabilidadeSucessoEscola where Matricula !='EscolaPrivada' and Matricula !='Pública Estadual' and Matricula!='Pública Federal' and Matricula!='Pública Municipal'", con);

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            ProbabilidadeSucessoEscola psEscola = new ProbabilidadeSucessoEscola();
                            psEscola.Matricula = rd["Matricula"].ToString();
                            psEscola.Tema = rd["Tema"].ToString();
                            psEscola.Reprovacao = Convert.ToInt16(rd["Reprovacao"]);
                            psEscola.Sucesso = ((Math.Pow(psEscola.Reprovacao, 1)) * (Math.Pow(Math.E, -psEscola.Reprovacao)) / 1) * 100.00;
                            psEscola.InSucesso = 100.00 - psEscola.Sucesso;

                            lista.Add(psEscola);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<ProbabilidadeSucessoRenda> GetProbabilidadeSucessoRenda()
        {
            List<ProbabilidadeSucessoRenda> lista = new List<ProbabilidadeSucessoRenda>();
            if (getString != null)
            {
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    SqlDataReader rd = null;
                    SqlCommand cmd =
                        new SqlCommand("Select * from vProbabilidadeRendaFamiliar", con);

                    con.Open();
                    try
                    {
                        rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rd.Read())
                        {
                            ProbabilidadeSucessoRenda psRenda = new ProbabilidadeSucessoRenda();
                            psRenda.Matricula = rd["Matricula"].ToString();
                            psRenda.Tema = rd["Tema"].ToString();
                            psRenda.Reprovacao = Convert.ToInt16(rd["Reprovacao"]);
                            psRenda.Sucesso = ((Math.Pow(psRenda.Reprovacao, 1)) * (Math.Pow(Math.E, -psRenda.Reprovacao)) / 1) * 100.00;
                            psRenda.InSucesso = 100.00 - psRenda.Sucesso;

                            lista.Add(psRenda);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return lista;
        }

        [OperationContract]
        public List<String> GetAMOCubos(string bancoAnalise)
        {
            String ConnStr;
            ConnStr = @"Provider=SQLNCLI11.1;Data Source=JoseAntonio-PC;Integrated Security=SSPI;Initial Catalog=UMinhoD";

            List<string> listaCubo = new List<string>();

            using (Server server = new Server())
            {
                try
                {
                    server.Connect(ConnStr);
                    Microsoft.AnalysisServices.Database db = server.Databases[bancoAnalise];

                    //Loop through every cube
                    foreach (Cube cubo in db.Cubes)
                    {
                        //Write the cube name
                        listaCubo.Add(cubo.Name);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro: " + ex.Message);
                }
                finally
                {
                    server.Disconnect();
                    server.Dispose();
                }
            }
            return listaCubo;
        }

        [OperationContract]
        public List<String> GetAMODimensoes(string bancoAnalise)
        {
            String ConnStr;
            ConnStr = @"Provider=SQLNCLI11.1;Data Source=JoseAntonio-PC;Integrated Security=SSPI;Initial Catalog=UMinhoD";

            List<string> listaDim = new List<string>();

            using (AdomdConnection conn = new AdomdConnection(ConnStr))
            {
                try
                {
                    conn.Open();
                    //Loop through every cube
                    foreach (CubeDef cubo in conn.Cubes)
                    {
                        //skip hidden cubes
                        if (cubo.Name.StartsWith("$"))
                            continue;

                        foreach (Microsoft.AnalysisServices.AdomdClient.Dimension dim in cubo.Dimensions)
                        {
                            listaDim.Add(dim.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return listaDim;
        }

        [OperationContract]
        public List<string> GetAMODataBases()
        {
            String ConnStr;
            ConnStr = @"Provider=SQLNCLI11.1;Data Source=JoseAntonio-PC;Integrated Security=SSPI;Initial Catalog=UMinhoD";

            List<string> lista = new List<string>();

            using (Server server = new Microsoft.AnalysisServices.Server())
            {
                server.Connect(ConnStr);

                Microsoft.AnalysisServices.Database database = server.Databases["UMinhoD"];

                foreach (Microsoft.AnalysisServices.Database bancos in server.Databases)
                {

                    lista.Add(bancos.Name);
                }
            }
            return lista;
        }

        [OperationContract]
        public Microsoft.AnalysisServices.MeasureEnumerator GetCuboMedidas(string bancoName, string cubo)
        {
            String ConnStr;
            ConnStr = @"Provider=SQLNCLI11.1;Data Source=JoseAntonio-PC;Integrated Security=SSPI;Initial Catalog=UMinhoD";

            using (Server server = new Microsoft.AnalysisServices.Server())
            {
                server.Connect(ConnStr);
                string NewBanco = bancoName;
                Microsoft.AnalysisServices.Database database = server.Databases[NewBanco];
                Cube Mycubo = database.Cubes.FindByName(cubo);

                Microsoft.AnalysisServices.MeasureEnumerator mycol = Mycubo.AllMeasures;
                return mycol;

            }
        }

        [OperationContract]
        public List<string> GetDimensoes(string bancoName, string cubo)
        {
            String ConnStr;
            ConnStr = @"Provider=SQLNCLI11.1;Data Source=JoseAntonio-PC;Integrated Security=SSPI;Initial Catalog=UMinhoD";

            using (Server server = new Microsoft.AnalysisServices.Server())
            {
                server.Connect(ConnStr);

                Microsoft.AnalysisServices.Database database = server.Databases[bancoName];

                Cube Mycubo = database.Cubes.FindByName(cubo);

                List<string> lista = new List<string>();

                foreach (Microsoft.AnalysisServices.Dimension dim in Mycubo.Dimensions)
                {
                    lista.Add(dim.Name);
                }
                return lista;
            }
        }

        [OperationContract]
        public void ProcessarCubo(string bancoAnalise)
        {
            String ConnStr;
            ConnStr = @"Provider=SQLNCLI11.1;Data Source=JoseAntonio-PC;Integrated Security=SSPI;Initial Catalog=UMinhoD";

            using (Server server = new Server())
            {
                try
                {
                    server.Connect(ConnStr);
                    Microsoft.AnalysisServices.Database db = server.Databases[bancoAnalise];

                    //Loop through every cube
                    foreach (Cube cubo in db.Cubes)
                    {
                        //Write the cube name
                        cubo.Process(ProcessType.ProcessFull);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro: " + ex.Message);
                }
                finally
                {
                    server.Disconnect();
                    server.Dispose();
                }
            }
        }

        [OperationContract]
        public void ProcessarDimensoes(string bancoAnalise)
        {
            String ConnStr;
            ConnStr = @"Provider=SQLNCLI11.1;Data Source=JoseAntonio-PC;Integrated Security=SSPI;Initial Catalog=UMinhoD";

            using (Server server = new Server())
            {
                try
                {
                    server.Connect(ConnStr);
                    Microsoft.AnalysisServices.Database db = server.Databases[bancoAnalise];

                    //Loop through every cube
                    foreach (Microsoft.AnalysisServices.Dimension dim in db.Dimensions)
                    {
                        //Write the cube name
                        dim.Process(ProcessType.ProcessUpdate);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro: " + ex.Message);
                }
                finally
                {
                    server.Disconnect();
                    server.Dispose();
                }
            }
        }

        [OperationContract]
        public void ProcessarGrupoCuboMedidas(string bancoAnalise)
        {
            String ConnStr;
            ConnStr = @"Provider=SQLNCLI11.1;Data Source=JoseAntonio-PC;Integrated Security=SSPI;Initial Catalog=UMinhoD";

            using (Server server = new Server())
            {
                try
                {
                    server.Connect(ConnStr);
                    Microsoft.AnalysisServices.Database db = server.Databases[bancoAnalise];

                    //Loop through every cube
                    foreach (Cube cubo in db.Cubes)
                    {
                        foreach(MeasureGroup medida in cubo.MeasureGroups)
                        {
                            medida.Process(ProcessType.ProcessFull);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro: " + ex.Message);
                }
                finally
                {
                    server.Disconnect();
                    server.Dispose();
                }
            }
        }

        [OperationContract]
        public List<string> GetCuboMedidas2(string bancoAnalise, string cuboName)
        {
            String ConnStr;
            ConnStr = @"Provider=SQLNCLI11.1;Data Source=JoseAntonio-PC;Integrated Security=SSPI;Initial Catalog=UMinhoD";

            List<string> lista = new List<string>();

            using (Server server = new Server())
            {
                try
                {
                    server.Connect(ConnStr);
                    Microsoft.AnalysisServices.Database db = server.Databases[bancoAnalise];

                    //Loop through every cube
                    foreach (Cube cubo in db.Cubes)
                    {
                        if (cubo.ToString() == cuboName)
                        { 
                            foreach (MeasureGroup medida in cubo.MeasureGroups)
                            {
                                lista.Add(medida.Name);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro: " + ex.Message);
                }
                finally
                {
                    server.Disconnect();
                    server.Dispose();
                }
            }
            return lista;
        }
        [OperationContract]
        public void AbrirPBI ()
        {
            System.Diagnostics.Process.Start(@"C:\Program Files\Microsoft Power BI Desktop\bin\PBIDesktop.exe");
        }

        [OperationContract]
        public void AbrirExcel()
        {
            System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office16\Excel.exe");
            ////dynamic excel;
            ////cria a aplicação
            //excel = AutomationFactory.CreateObject("Excel.Application");
            ////deixando a aplicação visível
            //excel.Visible = true;
            //// Criando um novo arquivo para a aplicação
            //// Lembrando que um workbook é um conjunto de planilhas
            //dynamic workbook = excel.workbooks;
            //workbook = excel.add;

            //// Pega a planilha que acabamos de criar
            //dynamic sheet = excel.ActiveSheet;
        }
        
        [OperationContract]
        public List<ObjAMO> ExecutarMDXQuery(string bancoAnalise, string query)
        {
            String ConnStr;
            ConnStr = @"Provider=SQLNCLI11.1;Data Source=JoseAntonio-PC;Integrated Security=SSPI;Initial Catalog=UMinhoD";

            List<ObjAMO> lista = new List<ObjAMO>();

            using (AdomdConnection conmd = new AdomdConnection(ConnStr))
            {
               conmd.Open();

               //criar um comando, usando essa conexão
               AdomdCommand cmd = new AdomdCommand(query, conmd);
               cmd.CommandType = CommandType.Text;
               cmd.CommandTimeout = 120;
               AdomdDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);

               while (rd.Read())
                {
                    ObjAMO obAMO = new ObjAMO();
                    obAMO.ColunaA = rd[0].ToString();
                    obAMO.ColunaB = rd[1].ToString();
                    obAMO.ColunaC = Convert.ToInt16(rd[2]);
                    obAMO.ColunaD = Convert.ToInt16(rd[3]);
                    obAMO.ColunaPAp = Convert.ToDecimal( (100.00 * obAMO.ColunaC )/ (obAMO.ColunaC + obAMO.ColunaD));
                    obAMO.ColunaPRp = Convert.ToDecimal( (100.00 * obAMO.ColunaD )/ (obAMO.ColunaC + obAMO.ColunaD));

                    lista.Add(obAMO);
                }
               
            }
            return lista;
        }

        [OperationContract]
        public ArrayList GetTableMDXQuery(string bancoAnalise, string query)
        {
            String ConnStr;
            ConnStr = @"Provider=SQLNCLI11.1;Data Source=JoseAntonio-PC;Integrated Security=SSPI;Initial Catalog=UMinhoD";

            //DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ArrayList lista = new ArrayList();

            using (AdomdConnection conmd = new AdomdConnection(ConnStr))
            {
                try
                {
                    conmd.Open();

                    //criar um comando, usando essa conexão
                    AdomdCommand cmd = conmd.CreateCommand();
                    cmd.CommandText = query;
                    
                    AdomdDataAdapter da = new AdomdDataAdapter(cmd);
                    da.Fill(ds);

                    foreach (DataRow dtrow in ds.Tables[0].Rows)
                    {
                        lista.Add(dtrow);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro: " + ex.Message);
                }
                finally
                {
                    conmd.Close();
                }
            }
            return lista;
        }
    }
}
