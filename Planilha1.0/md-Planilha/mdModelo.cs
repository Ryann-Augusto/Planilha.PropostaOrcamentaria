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
        private decimal _propFaturamento;
        private decimal _realiFaturamento;
        private decimal _proposta;
        private decimal _realizado;
        private decimal _propTotal;
        private decimal _realiTotal;
        private decimal _propResultado;
        private decimal _realiResultado;
        private bool _mensagem;

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

        private decimal _totalPropJaneiro;
        private decimal _totalRealiJaneiro;
        private decimal _totalPropFevereiro;
        private decimal _totalRealiFevereiro;
        private decimal _totalPropMarco;
        private decimal _totalRealiMarco;
        private decimal _totalPropAbril;
        private decimal _totalRealiAbril;
        private decimal _totalPropMaio;
        private decimal _totalRealiMaio;
        private decimal _totalPropJunho;
        private decimal _totalRealiJunho;
        private decimal _totalPropJulho;
        private decimal _totalRealiJulho;
        private decimal _totalPropAgosto;
        private decimal _totalRealiAgosto;
        private decimal _totalPropSetembro;
        private decimal _totalRealiSetembro;
        private decimal _totalPropOutubro;
        private decimal _totalRealiOutubro;
        private decimal _totalPropNovembro;
        private decimal _totalRealiNovembro;
        private decimal _totalPropDezembro;
        private decimal _totalRealiDezembro;

        //Tabela Resultado
        private decimal _faturamentoPropResult;
        private decimal _faturamentoRealiResult;

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

        public decimal PropFaturamento
        {
            get { return _propFaturamento; }
            set { _propFaturamento = value; }
        }

        public decimal RealiFaturamento
        {
            get { return _realiFaturamento; }
            set { _realiFaturamento = value; }
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

        public decimal PropTotal
        {
            get { return _propTotal; }
            set { _propTotal = value; }
        }

        public decimal RealiTotal
        {
            get { return _realiTotal; }
            set { _realiTotal = value /*Somar todos os dados da tabela*/; }
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

        public bool Mensagem
        {
            get { return _mensagem; }
            set { _mensagem = value; }
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
        public decimal TotalPropJaneiro
        {
            get { return _totalPropJaneiro; }
            set { _totalPropJaneiro = value; }
        }

        public decimal TotalRealiJaneiro
        {
            get { return _totalRealiJaneiro; }
            set { _totalRealiJaneiro = value; }
        }

        public decimal TotalPropFevereiro
        {
            get { return _totalPropFevereiro; }
            set { _totalPropFevereiro = value; }
        }

        public decimal TotalRealiFevereiro
        {
            get { return _totalRealiFevereiro; }
            set { _totalRealiFevereiro = value; }
        }

        public decimal TotalPropMarco
        {
            get { return _totalPropMarco; }
            set { _totalPropMarco = value; }
        }

        public decimal TotalRealiMarco
        {
            get { return _totalRealiMarco; }
            set { _totalRealiMarco = value; }
        }

        public decimal TotalPropAbril
        {
            get { return _totalPropAbril; }
            set { _totalPropAbril = value; }
        }

        public decimal TotalRealiAbril
        {
            get { return _totalRealiAbril; }
            set { _totalRealiAbril = value; }
        }

        public decimal TotalPropMaio
        {
            get { return _totalPropMaio; }
            set { _totalPropMaio = value; }
        }

        public decimal TotalRealiMaio
        {
            get { return _totalRealiMaio; }
            set { _totalRealiMaio = value; }
        }

        public decimal TotalPropJunho
        {
            get { return _totalPropJunho; }
            set { _totalPropJunho = value; }
        }

        public decimal TotalRealiJunho
        {
            get { return _totalRealiJunho; }
            set { _totalRealiJunho = value; }
        }

        public decimal TotalPropJulho
        {
            get { return _totalPropJulho; }
            set { _totalPropJulho = value; }
        }

        public decimal TotalRealiJulho
        {
            get { return _totalRealiJulho; }
            set { _totalRealiJulho = value; }
        }

        public decimal TotalPropAgosto
        {
            get { return _totalPropAgosto; }
            set { _totalPropAgosto= value; }
        }

        public decimal TotalRealiAgosto
        {
            get { return _totalRealiAgosto; }
            set { _totalRealiAgosto = value; }
        }

        public decimal TotalPropSetembro
        {
            get { return _totalPropSetembro; }
            set { _totalPropSetembro= value; }
        }

        public decimal TotalRealiSetembro
        {
            get { return _totalRealiSetembro; }
            set { _totalRealiSetembro = value; }
        }

        public decimal TotalPropOutubro
        {
            get { return _totalPropOutubro; }
            set { _totalPropOutubro= value; }
        }

        public decimal TotalRealiOutubro
        {
            get { return _totalRealiOutubro; }
            set { _totalRealiOutubro = value; }
        }

        public decimal TotalPropNovembro
        {
            get { return _totalPropNovembro; }
            set { _totalPropNovembro= value; }
        }

        public decimal TotalRealiNovembro
        {
            get { return _totalRealiNovembro; }
            set { _totalRealiNovembro = value; }
        }

        public decimal TotalPropDezembro
        {
            get { return _totalPropDezembro; }
            set { _totalPropDezembro = value; }
        }

        public decimal TotalRealiDezembro
        {
            get { return _totalRealiDezembro; }
            set { _totalRealiDezembro = value; }
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
    }
}
