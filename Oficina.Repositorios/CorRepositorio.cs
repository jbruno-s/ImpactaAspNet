using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Configuration.ConfigurationManager;

namespace Oficina.Repositorios
{
    public class CorRepositorio : RepositorioBase
    {   //ToDo Add novo metodo na classe Path. implementar método de extensão.
        //private string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
        //      AppSettings["caminhoArquivoCor"]);//@"Dados\Cor.txt";

        private string caminhoArquivo;

        public CorRepositorio()
        {
            caminhoArquivo = base.obterCaminhoCompleto("caminhoArquivoCor");
        }

        //Todo: OO - Polimorfismo por sobrecarga.
        public List<Cor> Selecionar()
        {
            var cores = new List<Cor>();

            foreach (var linha in File.ReadAllLines(caminhoArquivo))//ou @"Dados\Cor.txt" 
            {   //Cor cor = new Cor();// objeto, padrão minusculo. =
                var cor = new Cor();

                cor.Id = Convert.ToInt32(linha.Substring(0, 5));
                cor.Nome = linha.Substring(5);

                cores.Add(cor);
            }

            return cores;
        }

        public Cor Selecionar(int id)
        {   
            //int? x = null; se precisar ser null

            Cor cor = null;

            foreach (var linha in File.ReadAllLines(caminhoArquivo))
            {
                var linhaId = linha.Substring(0, 5);

                if (Convert.ToInt32(linhaId) == id)
                {
                    cor = new Cor();

                    cor.Id = Convert.ToInt32(linha.Substring(0, 5));
                    cor.Nome = linha.Substring(5);

                    break;
                }
            }

            return cor;
        }
    }
}
