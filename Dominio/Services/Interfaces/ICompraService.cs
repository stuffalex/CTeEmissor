using CTeEmissor.Dominio.Model.Dto;
using CTeEmissor.Dominio.Model;

namespace CTeEmissor.Dominio.Services.Interfaces
{
    public interface ICompraService
    {
        Compra Gerar(CompraDto compraDto, string estadoOrigem);
    }
}
