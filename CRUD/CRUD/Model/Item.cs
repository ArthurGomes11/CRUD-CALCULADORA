using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model
{
    internal class Item
    {
        public int iditens { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }
        public int quantidade { get; set; }
        public string pagamento { get; set; }
        public double imposto { get; set; } 
        public double precofinal { get; set; }  
    }
}
