using System;
using System.Collections.Generic;
using DIO_Series.Servico;
using guilh.OneDrive.Documentos.BootCamp_MRV.Dominio.Entidade;
using guilh.OneDrive.Documentos.BootCamp_MRV.Dominio.Enum;

namespace DIO_Series
{
    class Program
    {
        static SerieServico _servico = new SerieServico();

        static void Main(string[] args)
        {
            try
            {
                string opcaoUsuario = ObterOpcaoUsuario();

                while (opcaoUsuario != "X")
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            var listaSerie = _servico.Lista();

                            if (!listaSerie.Sucesso)
                            {
                                Console.WriteLine("Não existe serie cadastradas");
                            }
                            else
                            {
                                foreach (var item in (List<Serie>)listaSerie.Objeto)
                                {
                                    Console.WriteLine(item);
                                    Console.WriteLine();
                                }
                            }
                            break;

                        case "2":
                            Console.WriteLine("Segue abaixo as opções de genêro");
                            foreach (int i in Enum.GetValues(typeof(Genero)))
                            {
                                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                            }
                            Console.Write("Digite o gênero entre as opções acima: ");

                            int entradaGenero = int.Parse(Console.ReadLine());

                            Console.Write("Digite o Título da Série: ");
                            string entradaTitulo = Console.ReadLine();

                            Console.Write("Digite o Ano de Início da Série: ");
                            var confirmaEntradaAno = int.Parse(Console.ReadLine());
                            if (confirmaEntradaAno > DateTime.Today.Year)
                            {
                                Console.WriteLine("Você digitou uma data do futuro");
                                break;
                            }
                            int entradaAno = confirmaEntradaAno;

                            Console.Write("Digite a Descrição da Série: ");
                            string entradaDescricao = Console.ReadLine();

                            Serie novaSerie = new Serie
                            (
                                id: (int)_servico.ProximoId().Objeto,
                                genero: (Genero)entradaGenero,
                                titulo: entradaTitulo,
                                ano: entradaAno,
                                descricao: entradaDescricao
                            );
                            var inserirSerie = _servico.Insere(novaSerie);
                            Console.WriteLine(inserirSerie.Mensagem);
                            break;

                        case "3":
                            Console.Write("Digite o id da série: ");
                            int indiceSerie = int.Parse(Console.ReadLine());

                            foreach (int i in Enum.GetValues(typeof(Genero)))
                            {
                                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                            }
                            Console.Write("Digite o gênero entre as opções acima: ");
                            int entradaDeGenero = int.Parse(Console.ReadLine());

                            Console.Write("Digite o Título da Série: ");
                            string entradaDeTitulo = Console.ReadLine();

                            Console.Write("Digite o Ano de Início da Série: ");
                            int entradaDeAno = int.Parse(Console.ReadLine());
                            if(entradaDeAno > DateTime.Today.Year)
                            {
                                Console.WriteLine("Você digitou um ano do futuro");
                                break;
                            }

                            Console.Write("Digite a Descrição da Série: ");
                            string entradaDaDescricao = Console.ReadLine();

                            Serie atualizaSerie = new Serie
                            (
                                id: indiceSerie,
                                genero: (Genero)entradaDeGenero,
                                titulo: entradaDeTitulo,
                                ano: entradaDeAno,
                                descricao: entradaDaDescricao
                            );
                            var alterarSerie = _servico.Atualizar(indiceSerie, atualizaSerie);
                            Console.WriteLine(alterarSerie.Mensagem);
                            break;

                        case "4":
                            Console.Write("Digite o id da série: ");
                            var idSerie = int.Parse(Console.ReadLine());

                            Console.WriteLine($"Você tem certeza que deseja exluir a série{_servico.RetornarPorId(idSerie).Objeto}");
                            Console.WriteLine("Digite S para confirmar ou N para cancelar!");
                            var confirmaExclusao = Console.ReadLine();

                            if (confirmaExclusao.ToUpper() == "S")
                            {
                                var excluirSerie = _servico.Excluir(idSerie);
                                Console.WriteLine(excluirSerie.Mensagem);                                
                                break;
                            }
                            else
                            {                                
                                break;
                            }

                        case "5":
                            Console.Write("Digite o id da série: ");
                            int idDaSerie = int.Parse(Console.ReadLine());

                            var obterSerie = _servico.RetornarPorId(idDaSerie);

                            Console.WriteLine(obterSerie.Mensagem);
                            Console.WriteLine(obterSerie.Objeto);
                            break;

                        case "C":
                            Console.Clear();
                            break;

                        default:
                            throw new ArgumentOutOfRangeException("Você digitou uma opção que não é valida :(");
                    }

                    opcaoUsuario = ObterOpcaoUsuario();
                }

                Console.WriteLine();
                Console.WriteLine("Obrigado por utilizar nossos servicos");
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("Algo deu errado, por favor, comece de novo! :(");
                Console.ReadLine();
            }

        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine();
            Console.WriteLine("1- Listar série");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
