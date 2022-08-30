using System;
using System.Collections.Generic;
using Checkpoint1.Models;

namespace Checkpoint1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de cadastro de Funcionários.");

            Console.WriteLine("Digite a qtd de funcionários que deseja cadastrar(CLT)");
            int qtdClt = Convert.ToInt32(Console.ReadLine());

            //Criar uma lista de funcs CLT
            List<FuncionarioClt> listaClt = new List<FuncionarioClt>();

            //Criar um laço para ler os funcs CLT
            for (int i = 0; i < qtdClt; i++)
            {
                //Ler dados
                Console.WriteLine("Digite o Id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite o nome");
                string? nome = Console.ReadLine();
                Console.WriteLine("Digite o Gênero(M/F):");
                string genero = Console.ReadLine();
                Console.WriteLine("Digite o salário");
                decimal salario = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Possui Cargo de confiança(S/N)?");
                string cargoConfiancaValidacao = Console.ReadLine().ToUpper();
                string cargoConfianca;
                if (cargoConfiancaValidacao.Equals('S'))
                {
                    cargoConfianca = "Sim";
                }
                else
                {
                    cargoConfianca = "Não";
                }
                //Instanciar funcionário CLT e adicionar na lista
                FuncionarioClt funcionarioClt = new FuncionarioClt(id, nome, genero, salario, cargoConfianca);
                listaClt.Add(funcionarioClt);
            }
            Console.WriteLine("Digite a qnt de funcionários que deseja cadastrar(PJ)");
            int qtdPj = Convert.ToInt32(Console.ReadLine());

            //Criar uma lista de funcs PJ
            List<FuncionarioPj> listaPj = new List<FuncionarioPj>();

            //Criar um laço para ler os funcs PJ
            for (int i = 0; i < qtdPj; i++)
            {
                //Ler dados
                Console.WriteLine("Digite o Id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite o nome");
                string? nome = Console.ReadLine();
                Console.WriteLine("Digite o Gênero(M/F):");
                string genero = Console.ReadLine().ToUpper();
                Console.WriteLine("Digite o valor da Hora");
                decimal valorHora = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Digite a quantidade de horas contratadas");
                int qntHorasContratadas = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite o CNPJ");
                string cnpj = Console.ReadLine();
                //Instanciar funcionário PJ e adicionar na lista
                FuncionarioPj funcionarioPj = new FuncionarioPj(id, nome, genero, valorHora, qntHorasContratadas, cnpj);
                listaPj.Add(funcionarioPj);
            }


            int opcao;
            do
            {
                Console.WriteLine("Escolha uma opção: 1-exibir todos os funcionários CLT, 2-exibir todos os funcionários PJ, 3-exibir custo total mensal de todos os funcionários(Funcionário PJ sem horas extras), 4-aumentar salário de um funcionário CLT (%), 5-aumentar salário de um funcionário PJ(valor da hora em R$), 6-pesquisar funcionário, 7-exibir custo total de um funcionário, 0-sair");
                opcao = Convert.ToInt32(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        listaClt.ForEach(funcionario => Console.WriteLine(funcionario.ToString()));
                        break;
                    case 2:
                        listaPj.ForEach(funcionario => Console.WriteLine(funcionario.ToString()));
                        break;
                    case 3:
                        decimal custoTotal = 0;
                        listaClt.ForEach(funcionario => {
                            decimal custoCltTotal = funcionario.calculaCustoTotalClt();
                            custoTotal += custoCltTotal;
                        });
                        listaPj.ForEach(funcionario =>
                        {
                            decimal custoPjTotal = funcionario.calculaCustoTotalPj(0);
                            custoTotal += custoPjTotal;
                        });
                        Console.WriteLine("Custo mensal total em reais: R$" + String.Format("{0:0.00}", custoTotal));
                        break;
                    case 4:
                        Console.WriteLine("Digite o Id do funcionário que deseja aumentar o salário(CLT)");
                        int idInformadoClt = Convert.ToInt32(Console.ReadLine());
                        FuncionarioClt? funcionarioClt = listaClt.Find(match: funcionario => funcionario.Id.Equals(idInformadoClt));
                        if (funcionarioClt != null)
                        {
                            Console.WriteLine("Digite em quanto deseja aumentar o salário(%)");
                            int valorAumento = Convert.ToInt32(Console.ReadLine());
                            if (valorAumento > 0)
                            {
                                funcionarioClt.aumentarSalarioClt(valorAumento);
                                Console.WriteLine("Valor aumentado!");
                                Console.WriteLine("Salário atualizado: " + String.Format("{0:0.00}", funcionarioClt.Salario));
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Funcionário informado não existe.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Digite o Id do funcionário que deseja aumentar o salário(PJ)");
                        int idInformadoPj = Convert.ToInt32(Console.ReadLine());
                        FuncionarioPj? funcionarioPj = listaPj.Find(match: funcionario => funcionario.Id.Equals(idInformadoPj));
                        if (funcionarioPj != null)
                        {
                            Console.WriteLine("Digite em quanto deseja aumentar o valor da hora(R$)");
                            decimal valorAumento = Convert.ToDecimal(Console.ReadLine());
                            if (valorAumento > 0)
                            {
                                funcionarioPj.aumentarSalarioPj(valorAumento);
                                Console.WriteLine("Valor aumentado!");
                                Console.WriteLine("Valor da hora atualizado: " + String.Format("{0:0.00}", funcionarioPj.ValorHora));
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Funcionário informado não existe.");
                        }
                        break;
                    case 6:
                        int idCase6 = 0;
                        Console.WriteLine("Deseja buscar um funcionário PJ ou CLT?");
                        string escolhaCase6 = Console.ReadLine().ToUpper();
                        if (escolhaCase6 == "CLT")
                        {
                            Console.WriteLine("Digite o Id do funcionário");
                            idCase6 = Convert.ToInt32(Console.ReadLine());
                            FuncionarioClt? funcionario = listaClt.Find(match: funcionario => funcionario.Id.Equals(idCase6));
                            if (funcionario != null)
                            {
                                Console.WriteLine("Dados do funcionário encontrado: " + funcionario.ToString());
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Funcionário não encontrado.");
                            }
                        }
                        else if (escolhaCase6 == "PJ")
                        {
                            Console.WriteLine("Digite o Id do funcionário");
                            idCase6 = Convert.ToInt32(Console.ReadLine());
                            FuncionarioPj? funcionario = listaPj.Find(match: funcionario => funcionario.Id.Equals(idCase6));
                            if (funcionario != null)
                            {
                                Console.WriteLine("Dados do funcionário encontrado: " + funcionario.ToString());
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Funcionário não encontrado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Tipo de contrato inválido, escolha entre CLT e PJ.");
                        }
                        break;
                    case 7:
                        int idCase7 = 0;
                        Console.WriteLine("Deseja buscar um funcionário PJ ou CLT?");
                        string escolhaCase7 = Console.ReadLine().ToUpper();
                        if (escolhaCase7 == "CLT")
                        {
                            Console.WriteLine("Digite o Id do funcionário");
                            idCase7 = Convert.ToInt32(Console.ReadLine());
                            FuncionarioClt? funcionario = listaClt.Find(funcionario => funcionario.Id.Equals(idCase7));
                            if (funcionario != null)
                            {
                                Console.WriteLine("Custo total do funcionário: " + String.Format("{0:0.00}", funcionario.calculaCustoTotalClt()));
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Funcionário não encontrado.");
                            }
                        }
                        else if (escolhaCase7 == "PJ")
                        {
                            Console.WriteLine("Digite o Id do funcionário");
                            idCase7 = Convert.ToInt32(Console.ReadLine());
                            FuncionarioPj? funcionario = listaPj.Find(funcionario => funcionario.Id.Equals(idCase7));
                            Console.WriteLine("O funcionário fez horas extras(S/N)?");
                            string escolhaCase7Pj = Console.ReadLine().ToUpper();
                            if (escolhaCase7Pj == "S")
                            {
                                int horasExtras = 0;
                                Console.WriteLine("Quantas horas extras foram feitas?");
                                horasExtras = Convert.ToInt32(Console.ReadLine());
                                if (funcionario != null)
                                {
                                    Console.WriteLine("Custo total do funcionário: " + String.Format("{0:0.00}", funcionario.calculaCustoTotalPj(horasExtras)));
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Funcionário não encontrado.");
                                }
                            }
                            else if (escolhaCase7Pj == "N")
                            {
                                if (funcionario != null)
                                {
                                    Console.WriteLine("Custo total do funcionário: " + String.Format("{0:0.00}", funcionario.calculaCustoTotalPj(0)));
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Funcionário não encontrado.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Escolha inválida.");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Tipo de contrato inválido, escolha entre CLT e PJ.");
                        }
                        break;
                    case 0:
                        Console.WriteLine("Programa finalizado, adeus.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (opcao != 0);
        }
    }
}
