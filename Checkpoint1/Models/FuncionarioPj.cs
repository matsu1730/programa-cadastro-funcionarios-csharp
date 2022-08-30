using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint1.Models
{
    internal class FuncionarioPj : Funcionario
    {
        public decimal ValorHora { get; set; }
        public int QntHorasContratadas { get; set; }
        public string Cnpj { get; set; }

        public FuncionarioPj(int id, string nome, string genero, decimal valorHora, int qntHorasContratadas, string cnpj) : base(id, nome, genero)
        {
            ValorHora = valorHora;
            QntHorasContratadas = qntHorasContratadas;
            Cnpj = cnpj;
        }

        public decimal calculaCustoTotalPj(int horasExtras)
        {
            decimal custoTotal;
            if (horasExtras == 0)
            {
                custoTotal = ValorHora * QntHorasContratadas;
            }
            else
            {
                custoTotal = (ValorHora * QntHorasContratadas) + (ValorHora * horasExtras);
            }
            return custoTotal;
        }

        public void aumentarSalarioPj(decimal valorAumento)
        {
            ValorHora += valorAumento;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}, Gênero: {Genero}, Valor da Hora: {ValorHora}, Quantidade de horas contratadas: {QntHorasContratadas}, CNPJ: {Cnpj}";
        }
    }
}
