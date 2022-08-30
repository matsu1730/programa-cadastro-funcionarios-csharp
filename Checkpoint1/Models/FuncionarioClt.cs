using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint1.Models
{
    internal class FuncionarioClt : Funcionario
    {
        public decimal Salario { get; set; }
        public string CargoConfianca { get; set; }

        public FuncionarioClt(int id, string nome, string genero, decimal salario, string cargoConfianca) : base(id, nome, genero)
        {
            Salario = salario;
            CargoConfianca = cargoConfianca;
        }

        public decimal calculaCustoTotalClt()
        {
            decimal custoTotal = Salario + (Salario * 0.1111m) + (Salario * 0.0833m) + (Salario * 0.08m) + (Salario * 0.04m) + (Salario * 0.0793m);
            return custoTotal;
        }

        public void aumentarSalarioClt(int valorAumento)
        {
            Salario += Salario * (valorAumento / 100m);
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}, Gênero: {Genero}, Salário: {Salario}, Cargo de Confiança: {CargoConfianca}";
        }
    }
}
