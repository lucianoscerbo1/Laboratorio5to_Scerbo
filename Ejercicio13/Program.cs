using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio13
{
    internal class Ejercicio13
    {

         class Producto
        {
            string nombre;
            public string NOMBRE { get { return nombre; } set { this.nombre = value; } }
            double precio;
            public double PRECIO { get { return precio; } set { this.precio = value; } }


            public Producto(string nombre, double precio)
            {
                this.nombre = nombre;
                this.precio = precio;
            }



            public virtual double calcular(int cantidad)
            {
                return precio * cantidad;
            }
        }

         class Perecedero : Producto
        {
             int diasCaducar;

            public int DIASCADUCAR { get { return diasCaducar; } set { this.diasCaducar = value; } }
            public Perecedero(int diasCaducar, string nombre, double precio) : base(nombre, precio)
            {
                this.diasCaducar = diasCaducar;
            }
        

            public override double calcular(int cantidad)
            {

                double precioFinal = base.calcular(cantidad);

                if (diasCaducar == 3)
                {
                    precioFinal = precioFinal / 2;
                }
                else if (diasCaducar == 2)
                {
                    precioFinal = precioFinal / 3;
                }
                else if (diasCaducar == 1)
                {
                    precioFinal = precioFinal / 4;
                }
                return precioFinal;
            }
        }

         class NoPerecedero : Producto
        {

            private string tipo;

            public NoPerecedero(string tipo, string nombre, double precio) : base(nombre, precio)
            {
                this.tipo = tipo;
            }

            public string getTipo()
            {
                return tipo;
            }

            public void setTipo(string tipo)
            {
                this.tipo = tipo;
            }
        }

        static void Main(string[] args)
        {
            Producto[] productos = new Producto[3];

            productos[0] = new Producto("Producto 1", 5);
            productos[1] = new Perecedero(1, "Coca Cola ", 300);
            productos[2] = new NoPerecedero("Tipo 1", "Producto 3", 10);

            Console.WriteLine("PRECIOS SIN CALCULAR");
            Console.WriteLine("Productos: $" + productos[0].PRECIO);
            Console.WriteLine("Productos perecederos: $" + productos[1].PRECIO);
            Console.WriteLine("Productos no perecederos: $" + productos[2].PRECIO);

        //  Console.WriteLine(productos[1].NOMBRE);
            double total = 0;
            int numprod = 1;

            for (int i = 0; i < productos.Length; i++)
            {
                total = total + productos[i].calcular(5);
                numprod++;
            }

            Console.WriteLine("PRECIO FINAL : $" + total);
            Console.ReadLine();
        }
    }
}
