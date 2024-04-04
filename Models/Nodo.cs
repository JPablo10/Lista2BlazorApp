using Lista2BlazorApp.Models;

namespace Lista2BlazorApp.Models
{
    public class Nodo
    {
        public object Valor { get; set; }

        public Nodo Liga { get; set; }

        public Nodo()
        {
            Valor = null;
            Liga = null;
        }

        public Nodo(object valor)
        {
            Valor = valor;
            Liga = null;
        }

        public Nodo(object valor, Nodo liga)
        {
            Valor = valor;
            Liga = liga;
        }

        public override string ToString()
        {
            return $"{Valor}";
        }
    }
}
