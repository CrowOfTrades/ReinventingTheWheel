using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinventingTheWheel
{
    public class Aluno : BaseItem
    {
        public string? Nome { get; set; }

        public Aluno(string nome)
        {
            Nome = nome;
        }
    }
}
