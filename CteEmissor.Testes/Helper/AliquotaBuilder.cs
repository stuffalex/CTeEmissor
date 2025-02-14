using CTeEmissor.Dominio.Model;

namespace CTeEmissor.Testes.Helper
{
    public class AliquotaBuilder
    {
        private string _estado;
        private decimal _porcentagem;

        public Aliquota Build()
        {
            return new Aliquota(_estado, _porcentagem);
        }

        public AliquotaBuilder Default()
        {
            _estado = "MS";
            _porcentagem = 17;

            return this;
        }

        public AliquotaBuilder ComEstado(string estado)
        {
            _estado = estado;
            return this;
        }

        public AliquotaBuilder ComPorcentagem(decimal porcentagem)
        {
            _porcentagem = porcentagem;
            return this;
        }
    }
}
