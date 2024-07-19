using EscolaTeste;
using System;
using System.Collections.Generic;

namespace EscolaTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Materia> materias = new List<Materia>
            {
                new Materia("Português", new List<Aluno>(), new List<Avaliacao>()),
                new Materia("Matemática", new List<Aluno>(), new List<Avaliacao>()),
                new Materia("História", new List<Aluno>(), new List<Avaliacao>())
            };

            Console.WriteLine("Sistema de Avaliação");
            Console.WriteLine("Digite 1 para cadastrar matéria");
            Console.WriteLine("Digite 2 para cadastrar aluno em matéria e avaliar");
            Console.Write("Opção: ");

            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                switch (opcao)
                {
                    case 1:
                        CadastrarMateria(materias);
                        break;
                    case 2:
                        CadastrarAlunoEmMateria(materias);
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, insira um número.");
            }
        }

        static void CadastrarMateria(List<Materia> materias)
        {
            Console.Clear();
            Console.Write("Nome da Matéria: ");
            string nomeMateria = Console.ReadLine();

            List<Aluno> alunos = new List<Aluno>();
            List<Avaliacao> avaliacoes = new List<Avaliacao>();

            Console.Write("Deseja anexar as avaliações (s/n): ");
            string resposta = Console.ReadLine().ToLower();

            if (resposta == "s")
            {
                try
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        Console.Write($"Informe a {i}ª nota: ");
                        double nota = double.Parse(Console.ReadLine());

                        Console.Write($"Informe o peso da {i}ª nota: ");
                        int peso = int.Parse(Console.ReadLine());

                        avaliacoes.Add(new Avaliacao(peso, nota, null));
                    }

                    Materia materia = new Materia(nomeMateria, alunos, avaliacoes);
                    materias.Add(materia);

                    Console.WriteLine("Matéria cadastrada com sucesso.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Formato de nota ou peso inválido. Por favor, insira valores válidos.");
                }
            }
            else
            {
                Materia materia = new Materia(nomeMateria, alunos, avaliacoes);
                materias.Add(materia);

                Console.WriteLine("Matéria cadastrada sem avaliações.");
            }

            CadastrarAlunoEmMateria(materias);
        }

        static void CadastrarAlunoEmMateria(List<Materia> materias)
        {
            Materia materiaAtual = null;
            bool continuarCadastrando = true;

            while (continuarCadastrando)
            {
                if (materiaAtual == null)
                {
                    Console.WriteLine("Escolha um número correspondente à matéria para cadastrar alunos:");
                    for (int i = 0; i < materias.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {materias[i].NomeDaMateria}");
                    }

                    if (int.TryParse(Console.ReadLine(), out int resposta) && resposta > 0 && resposta <= materias.Count)
                    {
                        materiaAtual = materias[resposta - 1];
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida.");
                        continue;
                    }
                }

                Console.Write("Nome do Aluno: ");
                string nomeAluno = Console.ReadLine();

                Aluno aluno = new Aluno
                {
                    NomeDoAluno = nomeAluno,
                    Materia = materiaAtual
                };

                for (int j = 0; j < 3; j++)
                {
                    try
                    {
                        Console.Write($"Nota da {j + 1}ª avaliação: ");
                        double nota = double.Parse(Console.ReadLine());

                        Console.Write($"Peso da {j + 1}ª avaliação: ");
                        int peso = int.Parse(Console.ReadLine());

                        aluno.Materia.AdicionarAvaliacao(nota, peso);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Formato de nota ou peso inválido. Por favor, insira valores válidos.");
                        j--; 
                    }
                }

                materiaAtual.Alunos.Add(aluno);

                Console.WriteLine("Aluno(a) cadastrado(a)!");
                Console.ReadKey();

                Console.WriteLine();
                Console.Write("Deseja cadastrar outro aluno na mesma matéria? (s/n): ");
                string respostaCadastro = Console.ReadLine().ToLower();

                if (respostaCadastro == "n")
                {
                    continuarCadastrando = false;
                }
                else
                {
                    materiaAtual = null;
                }
            }

            
            Console.WriteLine("\nLista de alunos cadastrados:");

            foreach (var materia in materias)
            {
                foreach (var alunoCadastrado in materia.Alunos)
                {
                    Console.WriteLine($"Aluno: {alunoCadastrado.NomeDoAluno}");
                    double media = alunoCadastrado.Materia.CalcularMedia();
                    Console.WriteLine($"Média: {media}");

                    if (media >= 6)
                    {
                        Console.WriteLine("APROVADO");
                    }
                    else
                    {
                        Console.WriteLine("REPROVADO");
                    }
                }
            }
        }
    }
}
