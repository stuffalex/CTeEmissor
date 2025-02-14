using CTeEmissor.Dominio.Base;

namespace CTeEmissor.Dominio.Models
{
    public class Compra : EntidadeBase<Compra>
    {
        public string NomeComprador { get; set; }
        public Carga Carga { get; private set; }
        public Viagem Viagem { get; set; }

        public Compra(string nomeComprador, Carga carga, Viagem viagem)
        {
            NomeComprador = nomeComprador;
            Viagem = viagem;
            Carga = carga;
        }
    }
}
