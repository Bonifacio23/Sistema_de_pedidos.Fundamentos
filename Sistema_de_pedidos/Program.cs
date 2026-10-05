using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_pedidos
{
    internal class Program
    {
        
        static int max = 5;
        static bool[] delivery = new bool[max];
        static string[] Nombre = new string[max];
        static string[] Direccion = new string[max];
        static string[] Telefono = new string[max];
        static string[] pedido = new string[max];
        static string[] metodoPago = new string[max];
        static int contador = 0;

        static public List<string> platos = new List<string> { "Pizza", "Hamburguesa", "Ensalada", "Sopa", "Pasta" };
        static public List<string> distritos = new List<string> { "Miraflores", "San Isidro", "Barranco", "Surco", "La Molina" };

        static public void Title()
            {
                string titulo = "Sistema De Registro de Pedidos";
                int posicion = (Console.WindowWidth - titulo.Length) / 2;

                Console.SetCursorPosition(posicion, Console.CursorTop);
                Console.WriteLine("------------------------------");

                Console.SetCursorPosition(posicion, Console.CursorTop);
                Console.WriteLine(titulo);

                Console.SetCursorPosition(posicion, Console.CursorTop);
                Console.WriteLine("------------------------------");
            }
        

        static public void Menu()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("*************Menú de opciones*************");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("1. Registrar cliente");
            Console.WriteLine("2. Registrar pedido");
            Console.WriteLine("3. Validar datos del pedido");
            Console.WriteLine("4. Buscar plato por nombre");
            Console.WriteLine("5. Validar pago del pedido");
            Console.WriteLine("6. Actualizar estado del pedido");
            Console.WriteLine("7. Calcular total del pedido");
            Console.WriteLine("8. Salir");
        }
        static public void RegistrarPedido()
        {

            if (contador < max)
            {
                Console.WriteLine("Ingrese el nombre del cliente:");
                Nombre[contador] = Console.ReadLine();

                Console.WriteLine("¿El pedido será por delivery o para salón? (d/s):");
                string tipo = Console.ReadLine().ToLower();

                if (tipo == "d")
                {
                    Console.WriteLine("Ingrese la dirección:");
                    Direccion[contador] = Console.ReadLine();

                    Console.WriteLine("Ingrese el teléfono:");
                    Telefono[contador] = Console.ReadLine();

                    Console.WriteLine("Ingrese el distrito:");
                    string distrito = Console.ReadLine();

                    if (distritos.Contains(distrito))
                    {
                        Console.WriteLine("Distrito válido.");
                        delivery[contador] = true;
                    }
                    else
                    {
                        Console.WriteLine("Distrito inválido.");
                        return;
                    }
                    


                }
                else if (tipo == "s")
                {
                    delivery[contador] = false;
                    Console.WriteLine("Pedido para salón.");
                }
                else
                {
                    Console.WriteLine("Opción inválida.");
                    return;
                }

                Console.WriteLine("Ingrese el pedido:");
                pedido[contador] = Console.ReadLine();
                if (!platos.Contains(pedido[contador]))
                {
                    Console.WriteLine("Plato no disponible en el menú.");
                    return;
                }
                double total = CalcularTotal(contador);

                Console.WriteLine("Seleccione el método de pago:");
                Console.WriteLine("1. Yape");
                Console.WriteLine("2. Plin");
                Console.WriteLine("3. Tarjeta");
                Console.WriteLine("4. Efectivo");


                int pago = int.Parse(Console.ReadLine());

                switch (pago)
                {
                    case 1:
                        Console.WriteLine("Pago con Yape.");
                        metodoPago[contador] = "Yape";
                        break;

                    case 2:
                        Console.WriteLine("Pago con Plin.");
                        metodoPago[contador] = "Plin";
                        break;

                    case 3:
                        Console.WriteLine("Pago con tarjeta.");
                        metodoPago[contador] = "Tarjeta";
                        break;

                    case 4:
                        Console.WriteLine("Pago en efectivo.");
                        metodoPago[contador] = "Efectivo";
                        break;

                    default:
                        Console.WriteLine("Método de pago inválido.");
                        return;
                }

                Console.WriteLine("Pedido registrado exitosamente.");

                contador++;
            }
            else
            {
                Console.WriteLine("Se alcanzó el límite máximo de pedidos.");
            }
        }

        static public void ValidarDatosPedido()
        {
            Console.WriteLine("Ingrese el nombre del cliente para validar su pedido:");
            string nombreCliente = Console.ReadLine();
            for (int i = 0; i < contador; i++)
            {
                if (Nombre[i] == nombreCliente)
                {
                    if (!string.IsNullOrEmpty(pedido[i]))
                    {
                        Console.WriteLine($"Pedido de {nombreCliente}: {pedido[i]}");
                        if (delivery[i])
                        {
                            Console.WriteLine($"Dirección de entrega: {Direccion[i]}, Teléfono: {Telefono[i]}");
                        }
                        else
                        {
                            Console.WriteLine("El pedido es para salón.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El cliente no tiene pedidos registrados.");
                    }
                    return;
                }
            }
            Console.WriteLine("Cliente no encontrado.");
        }
        static public double CalcularTotal(int i)
        {
            double precio = 0;

            if (pedido[i] == "Pizza")
            {
                precio = 25;
            }
            else if (pedido[i] == "Hamburguesa")
            {
                precio = 15;
            }
            else if (pedido[i] == "Ensalada")
            {
                precio = 10;
            }
            else if (pedido[i] == "Sopa")
            {
                precio = 8;
            }
            else if (pedido[i] == "Pasta")
            {
                precio = 18;
            }

            double costoDelivery = 0;

            if (delivery[i])
            {
                costoDelivery = 5;
            }

            double total = precio + costoDelivery;

            Console.WriteLine("Precio del pedido: S/ " + precio);

            if (delivery[i])
            {
                Console.WriteLine("Costo de delivery: S/ " + costoDelivery);
            }

            Console.WriteLine("Total a pagar: S/ " + total);

            return total;
        }

        static void Main(string[] args)
        {
            Title();
            Menu();
            int Op = 0;
            while (Op != 8)
            {
                Console.WriteLine("Ingrese una opción:");
                Op = int.Parse(Console.ReadLine());
                switch (Op)
                {
                    case 1:
                        RegistrarPedido();
                        break;
                    case 2:
                        ValidarDatosPedido  ();
                        break;
                    case 8:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}