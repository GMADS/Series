using System.Collections.Generic;
using guilh.OneDrive.Documentos.BootCamp_MRV.DIO_Series.Dominio.Interfaces;
using guilh.OneDrive.Documentos.BootCamp_MRV.Dominio.Entidade;

namespace guilh.OneDrive.Documentos.BootCamp_MRV.DIO_Series.Repositorio
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        public List<Serie> listaSerie = new List<Serie>();
        public void Atualizar(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Excluir(int id)
        {
            listaSerie [id].Exclui();
        }

        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornarPorId(int id)
        {
            return listaSerie[id];
        }
    }
}