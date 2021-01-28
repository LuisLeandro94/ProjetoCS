using System;
namespace Supermercado
{
    public class Categoria
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }

        public Categoria()
        {
            active = true;
        }
    }
}
