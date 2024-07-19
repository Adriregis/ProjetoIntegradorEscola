using EscolaTeste;
using System;
using System.Collections.Generic;

namespace EscolaTeste
{
    internal class Materia
    {
        public string NomeDaMateria { get; set; }
        public List<Aluno> Alunos { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; }

        public Materia(string nomeDaMateria, List<Aluno> alunos, List<Avaliacao> avaliacoes)
        {
            NomeDaMateria = nomeDaMateria;
            Alunos = alunos;
            Avaliacoes = avaliacoes;
        }

        public double CalcularMedia()
        {
            if (Avaliacoes.Count == 0)
            {
                throw new InvalidOperationException("Não há avaliações para calcular a média.");
            }

            double somaNotasPonderadas = 0;
            double somaPesos = 0;

            foreach (var avaliacao in Avaliacoes)
            {
                somaNotasPonderadas += avaliacao.Nota * avaliacao.Peso;
                somaPesos += avaliacao.Peso;
            }

            return somaNotasPonderadas / somaPesos;
        }

        public void AdicionarAvaliacao(double nota, int peso)
        {
            try
            {
                Avaliacao avaliacao = new Avaliacao(peso, nota, this);
                Avaliacoes.Add(avaliacao);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
