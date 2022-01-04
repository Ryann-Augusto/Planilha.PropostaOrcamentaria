﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace md_Planilha
{
    public class mdResultado
    {
        List<mdValores> lista = new List<mdValores>();
        List<mdValores> lista2 = new List<mdValores>();

        public List<mdValores> Listarfaturamento(int Ano, int Cod)
        {

            int[] categoria = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int Cat in categoria)
            {
                var planilhaDB = new Dal_Planilha.resultadoDal();
                foreach (DataRow row2 in planilhaDB.ResultadoDois(Ano, Cat, Cod).Rows)
                {
                    decimal FaturamentoProp = Convert.ToDecimal(row2["faturamento_PropDois"]);
                    decimal FaturamentoReali = Convert.ToDecimal(row2["faturamento_RealiDois"]);
                    foreach (DataRow row in planilhaDB.ResultadoUm(Ano, Cat, Cod).Rows)
                    {

                        var planilha = new mdValores();
                        planilha.Categoria = Convert.ToString(row["categoria"]);
                        planilha.FaturamentoPropResult = FaturamentoProp + Convert.ToDecimal(row["faturamento_PropUm"]);
                        planilha.FaturamentoRealiResult = FaturamentoReali + Convert.ToDecimal(row["faturamento_RealiUm"]);

                        lista.Add(planilha);

                        new Dal_Planilha.resultadoDal().AlterarResultado(Ano, Cod, Cat, planilha.FaturamentoPropResult, planilha.FaturamentoRealiResult);
                    }
                }
            }
            return lista;
        }

        public static mdValores TotalPropResultados(int Ano, int Cod)
        {
            try
            {
                var planilha = new mdValores();
                var planilhaDB = new Dal_Planilha.resultadoDal();
                foreach (DataRow row in planilhaDB.totalPropResultados(Ano, Cod).Rows)
                {
                    planilha.PropResultado = Convert.ToDecimal(row["PropResultado"]);

                    new Dal_Planilha.resultadoDal().AlterarTotalProposta(Ano, Cod, planilha.PropResultado);
                }
                return planilha;
            }
            catch (Exception ez)
            {
                ez = new Exception("Não hà informações suficiente para montar a planilha!");
                throw new Exception(ez.Message);
            }
        }

        public static mdValores TotalRealiResultados(int Ano, int Cod)
        {
            try
            {
                var planilha = new mdValores();
                var planilhaDB = new Dal_Planilha.resultadoDal();
                foreach (DataRow row in planilhaDB.totalRealiResultados(Ano, Cod).Rows)
                {
                    planilha.RealiResultado = Convert.ToDecimal(row["RealiResultado"]);

                    new Dal_Planilha.resultadoDal().AlterarTotalRealizado(Ano, Cod, planilha.RealiResultado);
                }
                return planilha;
            }
            catch (Exception ez)
            {
                ez = new Exception("Não hà informações suficiente para montar a planilha!");
                throw new Exception(ez.Message);
            }
        }

        public List<mdValores> sobreFaturamento(int Ano, int Cod)
        {
            try
            {
                var planilhaDB = new Dal_Planilha.resultadoDal();

                int[] categoria = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                foreach (int Cat in categoria)
                {
                    foreach (DataRow row in planilhaDB.sobreFaturamento(Ano, Cod, Cat).Rows)
                    {
                        var planilha = new mdValores();
                        planilha.SobreFaturamento = Convert.ToDecimal(row["sobreFaturamento"]);
                        lista.Add(planilha);

                        new Dal_Planilha.resultadoDal().AlterarSobreFat(Ano, Cod, Cat, planilha.SobreFaturamento);
                    }
                }
                return lista;
            }
            catch (Exception ez)
            {
                ez = new Exception("Não hà informações suficiente para montar a planilha!");
                throw new Exception(ez.Message);
            }
        }

        public static mdValores TotalSobreFaturamento(int Ano, int Cod)
        {
            try
            {
                var planilha = new mdValores();
                var planilhaDB = new Dal_Planilha.resultadoDal();
                foreach (DataRow row in planilhaDB.totalSobreFaturamento(Ano, Cod).Rows)
                {
                    planilha.TotalSobreFaturamento = Convert.ToDecimal(row["Total_SobreFaturamento"]);
                }
                return planilha;
            }
            catch (Exception ez)
            {
                ez = new Exception("Não hà informações suficiente para montar a planilha!");
                throw new Exception(ez.Message);
            }
        }

        public List<mdValores> contribDespesas(int Ano, int Cod)
        {
            try
            {
                var planilhaDB = new Dal_Planilha.resultadoDal();
                var planilhaDB2 = new Dal_Planilha.ValoresDal();
                foreach (DataRow row in planilhaDB2.CodigoDasCategorias(Cod).Rows)
                {
                    var planilha = new mdValores();
                    planilha.Codigo = Convert.ToInt32(row["pl_codigo"]);
                    lista.Add(planilha);
                }

                foreach (var Cat in lista.ToArray())
                {
                    foreach (DataRow row in planilhaDB.contribuicaoDespesas(Ano, Cod, Cat.Codigo).Rows)
                    {
                        var planilha = new mdValores();
                        planilha.ContribuicaoDespesas = Convert.ToDecimal(row["contribDespesas"]);
                        lista2.Add(planilha);

                        new Dal_Planilha.resultadoDal().AlterarContribDespesas(Ano, Cod, Cat.Codigo, planilha.ContribuicaoDespesas);
                    }
                }
                return lista2;
            }
            catch (Exception ez)
            {
                ez = new Exception("Não hà informações suficiente para montar a planilha!");
                throw new Exception(ez.Message);
            }
        }

        public static mdValores TotalContribDespesas(int Ano, int Cod)
        {
            try
            {
                var planilha = new mdValores();
                var planilhaDB = new Dal_Planilha.resultadoDal();
                foreach (DataRow row in planilhaDB.totalContribDespesas(Ano, Cod).Rows)
                {
                    planilha.TotalContribDespesas = Convert.ToDecimal(row["totalContribDespesas"]);
                }
                return planilha;
            }
            catch (Exception ez)
            {
                ez = new Exception("Não hà informações suficiente para montar a planilha!");
                throw new Exception(ez.Message);
            }

        }

        public static mdValores PropostaTabResultado(int Ano, int Cod)
        {
            try
            {
                var planilha = new mdValores();
                var planilhaDB = new Dal_Planilha.resultadoDal();
                foreach (DataRow row in planilhaDB.propostaTabResultado(Ano, Cod).Rows)
                {
                    planilha.PropostaTabResultado = Convert.ToDecimal(row["PropostaTabResultado"]);

                    new Dal_Planilha.resultadoDal().AlterarPropTabResultado(Cod, Ano, planilha.PropostaTabResultado);
                }
                return planilha;
            }
            catch (Exception ez)
            {
                ez = new Exception("Não hà informações suficiente para montar a planilha!");
                throw new Exception(ez.Message);
            }

        }

        public static mdValores RealizadoTabResultado(int Ano, int Cod)
        {
            try
            {
                var planilha = new mdValores();
                var planilhaDB = new Dal_Planilha.resultadoDal();
                foreach (DataRow row in planilhaDB.realizadoTabResultado(Ano, Cod).Rows)
                {
                    planilha.RealizadoTabResultado = Convert.ToDecimal(row["realiTabResultado"]);

                    new Dal_Planilha.resultadoDal().AlterarRealiTabResultado(Cod, Ano, planilha.RealizadoTabResultado);
                }
                return planilha;
            }
            catch (Exception ez)
            {
                ez = new Exception("Não hà informações suficiente para montar a planilha!");
                throw new Exception(ez.Message);
            }
        }

        public static mdValores MetaProposta(int Ano, int Cod)
        {
            try
            {
                var planilha = new mdValores();
                var planilhaDB = new Dal_Planilha.resultadoDal();
                foreach (DataRow row in planilhaDB.MetaProposta(Ano, Cod).Rows)
                {
                    planilha.MetaProposta = Convert.ToDecimal(row["Meta_Proposta"]);
                }
                return planilha;
            }
            catch (Exception ez)
            {
                ez = new Exception("Não hà informações suficiente para montar a planilha!");
                throw new Exception(ez.Message);
            }
        }

        public static mdValores MetaRealizada(int Ano, int Cod)
        {
            try
            {
                var planilha = new mdValores();
                var planilhaDB = new Dal_Planilha.resultadoDal();
                foreach (DataRow row in planilhaDB.MetaRealizada(Ano, Cod).Rows)
                {
                    planilha.MetaRealizada = Convert.ToDecimal(row["Meta_Realizada"]);
                }
                return planilha;
            }
            catch (Exception ez)
            {
                ez = new Exception("Não hà informações suficiente para montar a planilha!");
                throw new Exception(ez.Message);
            }
        }
    }
}
