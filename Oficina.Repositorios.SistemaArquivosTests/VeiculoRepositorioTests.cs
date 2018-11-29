﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Dominio;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class VeiculoRepositorioTests
    {
        [TestMethod()]
        public void InserirTest()
        {
            var veiculo = new Veiculo();
            
            veiculo.Placa = "FTW-1836";
            veiculo.Ano = 2014;
            veiculo.Observacao = "Observação";
            veiculo.Combustivel = Combustivel.Alcool;
            veiculo.Cambio = Cambio.Automatico;

            veiculo.Modelo = new ModeloRepositorio().Selecionar(1);
            veiculo.Cor = new CorRepositorio().Selecionar(1);

            new VeiculoRepositorio().Inserir(veiculo);
        }
    }
}