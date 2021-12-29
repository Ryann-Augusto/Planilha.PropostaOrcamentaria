using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace md_Planilha
{
    public class mdModelo
    {
        private int _codigo;
        private int _ano;
        private string _mes;
        private string _categoria;
        private decimal _proposta;
        private decimal _realizado;

        //Tabela Proposta/Realizado
        private decimal _janProposta;
        private decimal _janRealizado;
        private decimal _fevProposta;
        private decimal _fevRealizado;
        private decimal _marProposta;
        private decimal _marRealizado;
        private decimal _abrProposta;
        private decimal _abrRealizado;
        private decimal _maiProposta;
        private decimal _maiRealizado;
        private decimal _junProposta;
        private decimal _junRealizado;
        private decimal _julProposta;
        private decimal _julRealizado;
        private decimal _agoProposta;
        private decimal _agoRealizado;
        private decimal _setProposta;
        private decimal _setRealizado;
        private decimal _outProposta;
        private decimal _outRealizado;
        private decimal _novProposta;
        private decimal _novRealizado;
        private decimal _dezProposta;
        private decimal _dezRealizado;

        //Tabela Total
        private decimal _totalProposta;
        private decimal _totalRealizado;
        private decimal _totalPropResultado;
        private decimal _totalRealiResultado;

        //Tabela Resultado
        private decimal _faturamentoPropResult;
        private decimal _faturamentoRealiResult;
        private decimal _sobreFaturamento;
        private decimal _propResultado;
        private decimal _realiResultado;
        private decimal _totalSobreFaturamento;
        private decimal _contribuicaoDespesas;
        private decimal _totalcontribDespesas;
        private decimal _propostaTabResultado;
        private decimal _realizadoTabResultado;

        //Metas
        private decimal _metaProposta;
        private decimal _metaRealizada;


        //Tabela Usuario
        private int _codigoUsuario;
        private string _nomeUsuario;
        private string _emailUsuario;
        private string _senhaUsuario;
        private string _confirmsenhaUsuario;
        private int _nivelUsuario;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public int Ano
        {
            get { return _ano; }
            set { _ano = value; }
        }

        public string Mes
        {
            get { return _mes; }
            set { _mes = value; }
        }

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        public decimal Proposta
        {
            get { return _proposta; }
            set { _proposta = value; }
        }

        public decimal Realizado
        {
            get { return _realizado; }
            set { _realizado = value; }
        }        

        //Metodos que irão receber cada mês das tabelas e formar a tabela principal
        public decimal JanProposta
        {
            get { return _janProposta; }
            set { _janProposta = value; }
        }

        public decimal JanRealizado
        {
            get { return _janRealizado; }
            set { _janRealizado = value; }
        }

        public decimal FevProposta
        {
            get { return _fevProposta; }
            set { _fevProposta = value; }
        }

        public decimal FevRealizado
        {
            get { return _fevRealizado; }
            set { _fevRealizado = value; }
        }

        public decimal MarProposta
        {
            get { return _marProposta; }
            set { _marProposta = value; }
        }

        public decimal MarRealizado
        {
            get { return _marRealizado; }
            set { _marRealizado = value; }
        }

        public decimal AbrProposta
        {
            get { return _abrProposta; }
            set { _abrProposta = value; }
        }

        public decimal AbrRealizado
        {
            get { return _abrRealizado; }
            set { _abrRealizado = value; }
        }

        public decimal MaiProposta
        {
            get { return _maiProposta; }
            set { _maiProposta = value; }
        }

        public decimal MaiRealizado
        {
            get { return _maiRealizado; }
            set { _maiRealizado = value; }
        }

        public decimal JunProposta
        {
            get { return _junProposta; }
            set { _junProposta = value; }
        }

        public decimal JunRealizado
        {
            get { return _junRealizado; }
            set { _junRealizado = value; }
        }

        public decimal JulProposta
        {
            get { return _julProposta; }
            set { _julProposta = value; }
        }

        public decimal JulRealizado
        {
            get { return _julRealizado; }
            set { _julRealizado = value; }
        }

        public decimal AgoProposta
        {
            get { return _agoProposta; }
            set { _agoProposta = value; }
        }

        public decimal AgoRealizado
        {
            get { return _agoRealizado; }
            set { _agoRealizado = value; }
        }

        public decimal SetProposta
        {
            get { return _setProposta; }
            set { _setProposta = value; }
        }

        public decimal SetRealizado
        {
            get { return _setRealizado; }
            set { _setRealizado = value; }
        }

        public decimal OutProposta
        {
            get { return _outProposta; }
            set { _outProposta = value; }
        }

        public decimal OutRealizado
        {
            get { return _outRealizado; }
            set { _outRealizado = value; }
        }

        public decimal NovProposta
        {
            get { return _novProposta; }
            set { _novProposta = value; }
        }

        public decimal NovRealizado
        {
            get { return _novRealizado; }
            set { _novRealizado = value; }
        }

        public decimal DezProposta
        {
            get { return _dezProposta; }
            set { _dezProposta = value; }
        }

        public decimal DezRealizado
        {
            get { return _dezRealizado; }
            set { _dezRealizado = value; }
        }


        //Inicia as variáveis do TOTAL
        public decimal TotalProposta
        {
            get { return _totalProposta ; }
            set { _totalProposta = value; }
        }

        public decimal TotalRealizado
        {
            get { return _totalRealizado; }
            set { _totalRealizado= value; }
        }

        public decimal TotalPropResultado
        {
            get { return _totalPropResultado; }
            set { _totalPropResultado = value; }
        }

        public decimal TotalRealiResultado
        {
            get { return _totalRealiResultado; }
            set { _totalRealiResultado = value; }
        }

        //Tabela Resultado
        public decimal FaturamentoPropResult
        {
            get { return _faturamentoPropResult; }
            set { _faturamentoPropResult = value; }
        }

        public decimal FaturamentoRealiResult
        {
            get { return _faturamentoRealiResult; }
            set { _faturamentoRealiResult = value; }
        }

        //Linha Resultado abaixo do total da tabela Resultado
        public decimal PropostaTabResultado
        {
            get { return _propostaTabResultado; }
            set { _propostaTabResultado = value; }
        }

        public decimal RealizadoTabResultado
        {
            get { return _realizadoTabResultado; }
            set { _realizadoTabResultado = value; }
        }

        //Metas
        public decimal MetaProposta
        {
            get { return _metaProposta; }
            set { _metaProposta = value; }
        }

        public decimal MetaRealizada
        {
            get { return _metaRealizada; }
            set { _metaRealizada = value; }
        }


        //Início do Sobre

        public decimal SobreFaturamento
        {
            get { return _sobreFaturamento; }
            set { _sobreFaturamento = value; }
        }
        public decimal PropResultado
        {
            get { return _propResultado; }
            set { _propResultado = value; }
        }

        public decimal RealiResultado
        {
            get { return _realiResultado; }
            set { _realiResultado = value; }
        }

        public decimal TotalSobreFaturamento
        {
            get { return _totalSobreFaturamento; }
            set { _totalSobreFaturamento = value; }
        }

        //Inicio contribuição despesas
        public decimal ContribuicaoDespesas
        {
            get { return _contribuicaoDespesas; }
            set { _contribuicaoDespesas = value; }
        }

        public decimal TotalContribDespesas
        {
            get { return _totalcontribDespesas; }
            set { _totalcontribDespesas = value; }
        }

        //Inicio Usuarios
        public int CodigoUsuario
        {
            get { return _codigoUsuario; }
            set { _codigoUsuario = value; }
        }

        public string NomeUsuario
        {
            get { return _nomeUsuario; }
            set { _nomeUsuario = value; }
        }

        public string EmailUsuario
        {
            get { return _emailUsuario; }
            set { _emailUsuario = value; }
        }

        public string SenhaUsuario
        {
            get { return _senhaUsuario; }
            set { _senhaUsuario = value; }
        }

        public string ConfirmSenhaUsuario
        {
            get { return _confirmsenhaUsuario; }
            set { _confirmsenhaUsuario = value; }
        }

        public int NivelUsuario
        {
            get { return _nivelUsuario; }
            set { _nivelUsuario = value; }
        }
    }
}
