using DIO_Series.Dominio.Util;
using guilh.OneDrive.Documentos.BootCamp_MRV.Dominio.Entidade;

namespace DIO_Series.Dominio.Interfaces
{
    public interface IServico
    {
         RetornoGenerico Lista();
         RetornoGenerico RetornarPorId(int id);
         RetornoGenerico Insere(Serie entidade);
         RetornoGenerico Excluir(int id);
         RetornoGenerico Atualizar(int id, Serie entidade);
         RetornoGenerico ProximoId();
    }
}