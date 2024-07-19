using System;
using System.Collections.Generic;

namespace EscolaTeste
{
    public class Calculadora
    {
        public double CalcularMediaPonderada(List<double> notas, List<int> pesos)
        {
            if (notas.Count != pesos.Count || notas.Count == 0)
            {
                throw new ArgumentException("A quantidade de notas deve ser igual à quantidade de pesos, e não deve ser zero.");
            }

            double somaNotasPonderadas = 0;
            double somaPesos = 0;

            for (int i = 0; i < notas.Count; i++)
            {
                somaNotasPonderadas += notas[i] * pesos[i];
                somaPesos += pesos[i];
            }

            return somaNotasPonderadas / somaPesos;
        }
    }
}
