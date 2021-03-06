﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspNetVS2017.Capitulo01.VetoresColecoes.Testes
{
    [TestClass]
    public class VetoresTestes
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            var strings = new string[10];
            strings[0] = "A";
            strings[9] = "B";

            var decimais = new decimal[] { 0.5m, 78, 1.59m };

            //decimal[] novoDecimais = { 2, 3, 5.9m }; // outra maneira de criar vetor (var não é possível).

            foreach (var @decimal in decimais)
            {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine($"Tamanho do vetor: {decimais.Length}");

        }

        [TestMethod]
        public void RedimensionamentoTeste()
        {
            var decimais = new decimal[] { 0.5m, 78, 1.59m };

            Array.Resize(ref decimais, 5);

            decimais[3] = 20.01m;
        }

        [TestMethod]
        public void OrdenacaoTeste()
        {
            var decimais = new decimal[] { 35.89m, 0.5m, 78, 1.59m };

            Array.Sort(decimais);

            Assert.AreEqual(decimais[0], 0.5m);

        }

        [TestMethod]
        public void ParamsTeste()
        {
            var decimais = new decimal[] { 35.89m, 0.5m, 28, 1.59m };

            Console.WriteLine(Media(decimais));
            Console.WriteLine(Media(2, 8, 9.8m, 4.23m));
        }

        [TestMethod]
        public void TodaStringEhUmVetorTeste()
        {
            const string nome = "Hejlsberg";

            Assert.AreEqual(nome[0], 'H');

            foreach (var @char in nome)
            {
                Console.WriteLine(@char);
            }
        }

        private decimal Media(decimal valor1, decimal valor2 )
        {
            return (valor1 + valor2) / 2;
        }

        private decimal Media(params decimal[] decimais)
        {
            return decimais.Average();//também funciona só com uma linha; ao contrario do codigo abaixo>

            var qtdItens = decimais.Length;
            decimal total = 0;

            foreach (var @decimal in decimais)
            {
                total += @decimal;
            }
            return total / qtdItens;
        }

    }
}
