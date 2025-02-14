using CTeEmissor.Dominio.Model;

namespace CTeEmissor.Testes.Helper
{
    public class CargaBuilder
    {
        private int _quantidade;
        private int _pesoUnitario;
        private int _pesoBrutoTotal;
        private int _volume;

        public CargaBuilder Default()
        {
            _quantidade = 3;
            _pesoUnitario = 2;
            _pesoBrutoTotal = _pesoUnitario * _quantidade;
            _volume = 3;

            return this;
        }

        public Carga Build()
        {
            return new Carga(_quantidade, _pesoUnitario, _volume);
        }
    }
}
