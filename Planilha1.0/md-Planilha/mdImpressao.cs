﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace md_Planilha
{
    public class mdImpressao
    {

        List<mdJaneiro> lista = new List<mdJaneiro>();

        public List<mdJaneiro> PrimeiroTotal(int Ano, int Cod)
        {
            string[] meses = { "tbl_janeiro", "tbl_fevereiro", "tbl_marco", "tbl_abril", "tbl_maio", "tbl_junho" };
            foreach (string Mes in meses)
            {

                var planilhaDB = new Dal_Planilha.CriarPlanilhaDal();
                foreach (DataRow row in planilhaDB.ListarTotal(Ano, Cod, Mes).Rows)
                {
                    var planilha = new mdJaneiro();
                    planilha.TotalProposta = Convert.ToDecimal(row["jan_propTotal"]);
                    planilha.TotalRealizado = Convert.ToDecimal(row["jan_realiTotal"]);
                    lista.Add(planilha);

                    new Dal_Planilha.CriarPlanilhaDal().AlterarTotalPropReali(Ano, Cod, Mes, planilha.TotalProposta, planilha.TotalRealizado);
                }
            }
            return lista;
        }

        public List<mdJaneiro> SegundoTotal(int Ano, int Cod)
        {
            string[] meses = { "tbl_julho", "tbl_agosto", "tbl_setembro", "tbl_outubro", "tbl_novembro", "tbl_dezembro" };
            foreach (string Mes in meses)
            {

                var planilhaDB = new Dal_Planilha.CriarPlanilhaDal();
                foreach (DataRow row in planilhaDB.ListarTotal(Ano, Cod, Mes).Rows)
                {
                    var planilha = new mdJaneiro();
                    planilha.TotalProposta = Convert.ToDecimal(row["jan_propTotal"]);
                    planilha.TotalRealizado = Convert.ToDecimal(row["jan_realiTotal"]);
                    lista.Add(planilha);

                    new Dal_Planilha.CriarPlanilhaDal().AlterarTotalPropReali(Ano, Cod, Mes, planilha.TotalProposta, planilha.TotalRealizado);
                }
            }
            return lista;
        }

        public List<mdJaneiro> PrimeiroResultado(int Ano, int Cod)
        {
            string[] meses = { "tbl_janeiro", "tbl_fevereiro", "tbl_marco", "tbl_abril", "tbl_maio", "tbl_junho" };
            foreach (string Mes in meses)
            {

                var planilhaDB = new Dal_Planilha.CriarPlanilhaDal();
                foreach (DataRow row in planilhaDB.ListarTotalResultado(Ano, Cod, Mes).Rows)
                {
                    var planilha = new mdJaneiro();
                    planilha.TotalPropResultado = Convert.ToDecimal(row["totalProp_result"]);
                    planilha.TotalRealiResultado = Convert.ToDecimal(row["totalReali_result"]);
                    lista.Add(planilha);
                }
            }
            return lista;
        }

        public List<mdJaneiro> SegundoResultado(int Ano, int Cod)
        {
            string[] meses = { "tbl_julho", "tbl_agosto", "tbl_setembro", "tbl_outubro", "tbl_novembro", "tbl_dezembro" };
            foreach (string Mes in meses)
            {

                var planilhaDB = new Dal_Planilha.CriarPlanilhaDal();
                foreach (DataRow row in planilhaDB.ListarTotalResultado(Ano, Cod, Mes).Rows)
                {
                    var planilha = new mdJaneiro();
                    planilha.TotalPropResultado = Convert.ToDecimal(row["totalProp_result"]);
                    planilha.TotalRealiResultado = Convert.ToDecimal(row["totalReali_result"]);
                    lista.Add(planilha);
                }
            }
            return lista;
        }
    }
}
