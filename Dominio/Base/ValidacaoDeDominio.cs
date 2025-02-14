namespace CTeEmissor.Dominio.Base;

public class ValidacaoDeDominio : Exception
{
    public ValidacaoDeDominio(string erro) : base(erro) { }

    public static void Quando(bool temErro, string erro)
    {
        if (temErro) throw new ValidacaoDeDominio(erro);
    }
}