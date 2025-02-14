using CTeEmissor.Dominio.Model;
using CTeEmissor.Repositorio;
using CTeEmissor.Testes.Helper;
using NUnit.Framework;

namespace CTeEmissor.Testes;

[TestFixture]
public class AliquotaTeste
{
    public IAliquotaRepositorio _repo;
    private List<Aliquota> _aliquotas;
    public Aliquota _aliquota;

    [SetUp]
    public void Setup()
    {
        _repo = new AliquotaRepositorio();
        _aliquota = new AliquotaBuilder().Default().Build();

        _aliquotas = _repo.ObterAliquotas();
    }

    [TestCase("MS", 17)]
    public void DeveRetornarPorcentagemDeAliquotaPorEstado(string estado, decimal porcentagem)
    {
        var aliquota = _aliquotas.FirstOrDefault(a => a.Estado == estado);

        Assert.That(aliquota.Porcentagem, Is.EqualTo(porcentagem));
    }
}
