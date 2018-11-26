using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetVS2017.Capitulo01.VetoresColecoes.Testes
{
    [TestClass]
    public class ColecoesTeste
    {
        [TestMethod]
        public void ListTest()
        {
            var inteiros = new List<int>(50) {2, 1, 2, 6, 125 };
            inteiros.Add(22); // insere no proximo espaço vazio
            //inteiros[12] = 89;

            var maisInteiros = new List<int> { 21, 72, 14, 6 };

            inteiros.AddRange(maisInteiros);

            inteiros.Insert(0, 29); //esse coloca no indice pode escolher o lugar

            inteiros.Remove(2); //remove o elemento
            inteiros.RemoveAt(8); //remove o indice
            inteiros.Sort();

            //var primeiro = inteiros[0];
            var primeiro = inteiros.FirstOrDefault();
            var ultimo = inteiros[inteiros.Count - 1];
            var estaVazio = inteiros.Count == 0;

            foreach (var inteiro in inteiros)
            {
                Console.WriteLine($"{inteiros.IndexOf(inteiro)}: {inteiro}");
            }

            for (int i = 0; i < inteiros.Count; i++)
            {
                Console.WriteLine($"Para cada inteiros = {i}: {inteiros[i] }");

            }

        }

        [TestMethod]
        public void DictionaryTeste()
        {
            var feriados = new Dictionary<DateTime, string>();

            feriados.Add(new DateTime(2018, 12, 25), "Natal");
            feriados.Add(new DateTime(2019, 1, 1), "Ano Novo");
            feriados.Add(new DateTime(2019, 1, 25), "Niver SP");
            //feriados.Add(new DateTime(2019, 1, 25), "Niver Sobrinho");

            var natal = feriados[new DateTime(2018, 12, 25)];

            foreach (var feriado in feriados)
            {
                //Console.WriteLine(string.Format("{0}: {1}", feriado.Key.ToShortDateString(), feriado.Value));
                //Console.WriteLine(string.Format("{0:dd/MM/yyyy}: {1}", feriado.Key, feriado.Value));
                Console.WriteLine(string.Format("{0}: {1}", feriado.Key.ToString("dd/MM/yyyy"), feriado.Value));
            }

            Console.WriteLine(feriados.ContainsKey(Convert.ToDateTime("25/12/2018")));
            Console.WriteLine(feriados.ContainsValue("Ano Novo"));
        }
    }
}
