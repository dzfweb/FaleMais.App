using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FaleMais.App;
using FaleMais.Negocio;
using FaleMais.Negocio.Models;

namespace FaleMais.App.Tests
{
    [TestClass]
    public class FaleMaisTest
    {
        [TestMethod]
        public void CalculoDeTarifas_SituacaoUm()
        {
            //pedido de calculo
            var pedidoCalculo = new PedidoCalculo();
            pedidoCalculo.Tempo = 20;
            pedidoCalculo.Origem = 11;
            pedidoCalculo.Destino = 16;
            pedidoCalculo.PlanoID = 1; //plano FaleMais30

            //resultado experado
            var detalhe = new DetalheResultado();
            detalhe.Sucesso = true;
            detalhe.Tempo = 20;
            detalhe.ValorComPlano = 0;
            detalhe.ValorSemPlano = 38;
                        
            var _calculos = new Calculos();
            ResultadoCalculo tarifa = _calculos.CalcularTarifa(pedidoCalculo);

            Assert.AreEqual(detalhe.Tempo, tarifa.Detalhe.Tempo, "Tempo Retornado diferente do experado.");
            Assert.AreEqual(detalhe.ValorComPlano, tarifa.Detalhe.ValorComPlano, "Valor com Plano retornado diferente do experado.");
            Assert.AreEqual(detalhe.ValorSemPlano, tarifa.Detalhe.ValorSemPlano, "Valor sem Plano retornado diferente do experado");

        }

        [TestMethod]
        public void CalculoDeTarifas_SituacaoDois()
        {
            //pedido de calculo
            var pedidoCalculo = new PedidoCalculo();
            pedidoCalculo.Tempo = 80;
            pedidoCalculo.Origem = 11;
            pedidoCalculo.Destino = 17;
            pedidoCalculo.PlanoID = 2; //plano FaleMais60

            //resultado experado
            var detalhe = new DetalheResultado();
            detalhe.Sucesso = true;
            detalhe.Tempo = 80;
            detalhe.ValorComPlano = decimal.Parse("37,40");
            detalhe.ValorSemPlano = decimal.Parse("136,00");
                        
            var _calculos = new Calculos();
            ResultadoCalculo tarifa = _calculos.CalcularTarifa(pedidoCalculo);

            Assert.AreEqual(detalhe.Tempo, tarifa.Detalhe.Tempo, "Tempo Retornado diferente do experado.");
            Assert.AreEqual(detalhe.ValorComPlano, tarifa.Detalhe.ValorComPlano, "Valor com Plano retornado diferente do experado.");
            Assert.AreEqual(detalhe.ValorSemPlano, tarifa.Detalhe.ValorSemPlano, "Valor sem Plano retornado diferente do experado");

        }

         [TestMethod]
        public void CalculoDeTarifas_SituacaoTres()
        {
            //pedido de calculo
            var pedidoCalculo = new PedidoCalculo();
            pedidoCalculo.Tempo = 200;
            pedidoCalculo.Origem = 18;
            pedidoCalculo.Destino = 11;
            pedidoCalculo.PlanoID = 3; //plano FaleMais120

            //resultado experado
            var detalhe = new DetalheResultado();
            detalhe.Sucesso = true;
            detalhe.Tempo = 200;
            detalhe.ValorComPlano = decimal.Parse("167,20");
            detalhe.ValorSemPlano = decimal.Parse("380,00");
                        
            var _calculos = new Calculos();
            ResultadoCalculo tarifa = _calculos.CalcularTarifa(pedidoCalculo);

            Assert.AreEqual(detalhe.Tempo, tarifa.Detalhe.Tempo, "Tempo Retornado diferente do experado.");
            Assert.AreEqual(detalhe.ValorComPlano, tarifa.Detalhe.ValorComPlano, "Valor com Plano retornado diferente do experado.");
            Assert.AreEqual(detalhe.ValorSemPlano, tarifa.Detalhe.ValorSemPlano, "Valor sem Plano retornado diferente do experado");

        }

        [TestMethod]
        public void CalculoDeTarifas_SituacaoQuatro()
        {
            //pedido de calculo
            var pedidoCalculo = new PedidoCalculo();
            pedidoCalculo.Tempo = 100;
            pedidoCalculo.Origem = 18;
            pedidoCalculo.Destino = 17;
            pedidoCalculo.PlanoID = 1; //plano FaleMais30

            //resultado experado
            var detalhe = new DetalheResultado();
            detalhe.Sucesso = false;
            detalhe.Tempo = 0;
            detalhe.ValorComPlano = 0;
            detalhe.ValorSemPlano = 0;
                        
            var _calculos = new Calculos();
            ResultadoCalculo tarifa = _calculos.CalcularTarifa(pedidoCalculo);

            Assert.AreEqual(detalhe.Tempo, tarifa.Detalhe.Tempo, "Tempo Retornado diferente do experado.");
            Assert.AreEqual(detalhe.ValorComPlano, tarifa.Detalhe.ValorComPlano, "Valor com Plano retornado diferente do experado.");
            Assert.AreEqual(detalhe.ValorSemPlano, tarifa.Detalhe.ValorSemPlano, "Valor sem Plano retornado diferente do experado");

        }
    }
}
