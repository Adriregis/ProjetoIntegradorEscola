using EscolaTeste;
using System;
using System.Collections.Generic;
using Xunit;

namespace EscolaTeste.Tests
{
    public class CalculadoraTests
    {
        private readonly Calculadora _calculadora;

        public CalculadoraTests()
        {
            _calculadora = new Calculadora();
        }

        [Fact]
        public void CalcularMediaPonderada_DeveRetornarMediaCorreta()
        {
            
            var notas = new List<double> { 8, 7, 9 };
            var pesos = new List<int> { 3, 2, 5 };

            
            double resultado = _calculadora.CalcularMediaPonderada(notas, pesos);

            
            Assert.Equal(8.1, resultado, 1);
        }

        [Fact]
        public void CalcularMediaPonderada_DeveLancarExcecao_QuandoListasComTamanhosDiferentes()
        {
            
            var notas = new List<double> { 8, 7 };
            var pesos = new List<int> { 3, 2, 5 };

            
            Assert.Throws<ArgumentException>(() => _calculadora.CalcularMediaPonderada(notas, pesos));
        }

        [Fact]
        public void CalcularMediaPonderada_DeveLancarExcecao_QuandoListasVazias()
        {
            
            var notas = new List<double>();
            var pesos = new List<int>();

           
            Assert.Throws<ArgumentException>(() => _calculadora.CalcularMediaPonderada(notas, pesos));
        }
    }
}
