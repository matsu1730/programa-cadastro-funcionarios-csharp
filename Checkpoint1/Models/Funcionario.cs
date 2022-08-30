using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint1.Models
{
    class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }

        public Funcionario(int id, string nome, string genero)
        {
            Id = id;
            Nome = nome;
            Genero = genero;
        }
    }
}
