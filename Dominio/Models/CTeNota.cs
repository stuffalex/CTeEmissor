using CTeEmissor.Dominio.Base;

namespace CTeEmissor.Dominio.Models
{
    public class CTeNota : EntidadeBase<CTeNota>
    {
        public CTeNota(Compra compra, double valorFrete, double valorIcms, double valorTotal)
        {
            Compra = compra;
            ValorFrete = valorFrete;
            ValorIcms = valorIcms;
            ValorTotal = valorTotal;
        }

        public Compra Compra { get; private set; }
        public double ValorTotal { get; private set; }
        public double ValorFrete => CalculaFretePorPeso(Compra);
        public double ValorIcms => CalculaIcms(Compra);


        private double CalculaFretePorPeso(Compra compra)
        {
            var tarifa = compra.Viagem.TarifaPorPeso;
            var peso = compra.Carga.PesoBrutoTotal;

            return (tarifa * peso) + compra.Viagem.DespesasAdicionais;
        }
        private double CalculaIcms(Compra compra)
        {
            var aliquota = 
            var porcentagem = (100 - aliquota) / 100;
            var baseDoCalculo = ValorFrete/(porcentagem);
            return baseDoCalculo * baseDoCalculo;
        }
    }
}
