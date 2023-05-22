using DIO_Series.Dominio.Interfaces;
using DIO_Series.Dominio.Util;
using guilh.OneDrive.Documentos.BootCamp_MRV.DIO_Series.Repositorio;
using guilh.OneDrive.Documentos.BootCamp_MRV.Dominio.Entidade;

namespace DIO_Series.Servico
{
    public class SerieServico : IServico
    {
        static SerieRepositorio _repositorio = new SerieRepositorio();

        public SerieServico()
        {}
        public RetornoGenerico Atualizar(int id, Serie entidade)
        {
            var verificarSerie = _repositorio.RetornarPorId(id);

            if(verificarSerie == null)
            {
                return new RetornoGenerico("Não existe serie com esse id", false, null);
            }
            else
            {
                _repositorio.Atualizar(id, entidade);
                return new RetornoGenerico("Serie editada com sucesso", true, null);
            }
        }

        public RetornoGenerico Excluir(int id)
        {
            var verificarSerie = _repositorio.RetornarPorId(id);

            if(verificarSerie == null)
            {
                return new RetornoGenerico("Não existe serie com esse id", false, null);
            }
            else
            {
                _repositorio.Excluir(id);
                return new RetornoGenerico("Serie excluida com sucesso", true, null);
            }			
        }

        public RetornoGenerico Insere(Serie entidade)
        {
            _repositorio.Insere(entidade);

            return new RetornoGenerico("Serie inserida com sucesso", true, null);
        }

        public RetornoGenerico Lista()
        {
            var lista = _repositorio.Lista();

            if(lista.Count == 0)
            {
                return new RetornoGenerico("Não existe série cadastrada", false, null);
            }
            else
            {
                return new RetornoGenerico("Series obtidas com sucesso", true, lista);
            }
        }

        public RetornoGenerico ProximoId()
        {
            return new RetornoGenerico
            (
                "novo id obtido com sucesso",
                 true,
                 _repositorio.ProximoId()
            );
        }

        public RetornoGenerico RetornarPorId(int id)
        {
            var verificarSerie = _repositorio.RetornarPorId(id);

            if(verificarSerie == null)
            {
                return new RetornoGenerico("Não existe serie com esse id", false, null);
            }
            else
            {
               return new RetornoGenerico("Serie obtida com sucesso", true, verificarSerie); 
            }
        }
    }
}