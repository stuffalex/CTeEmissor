using CTeEmissor.Base;

namespace CTeEmissor.Dominio.Model;

public class Carga : EntidadeBase<Carga>
{
    public Carga()
    {

    }
    public Carga(int quantidade, int pesoUnitario, int volume)
    {
        Quantidade = quantidade;
        PesoUnitario = pesoUnitario;
        PesoBrutoTotal = pesoUnitario * quantidade;
        Volume = volume;
    }

    public int Quantidade { get; private set; }
    public int PesoUnitario { get; private set; }
    public int PesoBrutoTotal { get; private set; }
    public int Volume { get; private set; }

}
