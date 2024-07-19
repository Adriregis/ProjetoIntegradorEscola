using EscolaTeste;
using System;

namespace EscolaTeste
{
    internal class Avaliacao
    {
        public int Peso { get; set; }
        public double Nota { get; set; }
        public Materia Materia { get; set; }

        public Avaliacao()
        {
        }

        public Avaliacao(int peso, double nota, Materia materia)
        {
            Peso = peso;
            Nota = nota;
            Materia = materia;
        }
    }
}
