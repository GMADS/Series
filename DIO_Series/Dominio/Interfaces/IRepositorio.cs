using System.Collections.Generic;

namespace guilh.OneDrive.Documentos.BootCamp_MRV.DIO_Series.Dominio.Interfaces
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetornarPorId(int id);
         void Insere(T entidade);
         void Excluir(int id);
         void Atualizar(int id, T entidade);
         int ProximoId();
    }
}