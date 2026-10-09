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
        static int contadorPedidos = 0;
        static string[] distrito = new string[max];

        static public List<string> platos = new List<string>
{
    "Arroz chaufa",
    "Tallarín saltado",
    "Pollo con verduras",
    "Pollo Chi Jau Kay",
    "Pollo Tipakay",
    "Aeropuerto",
    "Lomo saltado",
    "Kam Lu Wantán",
    "Wantán frito",
    "Sopa wantán",
    "Rollito primavera",
    "Inca Kola",
    "Coca-Cola",
    "Chicha morada",
    "Limonada"
};
        static public List<string> distritos = new List<string>
{
    "San Martín de Porres",
    "Los Olivos",
    "Independencia",
    "Rímac",
    "Comas",
    "Puente Piedra",
    "Cercado de Lima",
    "Callao",
    "Carmen de la Legua-Reynoso",
    "Ventanilla"
};

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

                    Console.WriteLine("Seleccione el distrito:");

                    for (int i = 0; i < distritos.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {distritos[i]}");
                    }

                    int opcionDistrito = int.Parse(Console.ReadLine());

                    switch (opcionDistrito)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                            distrito[contador] = distritos[opcionDistrito - 1];
                            break;

                        default:
                            Console.WriteLine("Distrito no válido.");
                            break;
                    }

                    if (distritos.Contains(distrito[contador]))
                    {
                        Console.WriteLine("Distrito válido.");
                        delivery[contador] = true;
                    }
                    else
                    {
                        Console.WriteLine("No se realiza delivery a este distrito.");
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

                int opcion = 0;
                while (opcion != 16)
                {
                    int con = 0;
                    Console.WriteLine("\nSeleccione el pedido:");
                    Console.WriteLine("1. Arroz chaufa              S/ 15");
                    Console.WriteLine("2. Tallarín saltado          S/ 16");
                    Console.WriteLine("3. Pollo con verduras        S/ 18");
                    Console.WriteLine("4. Pollo Chi Jau Kay         S/ 20");
                    Console.WriteLine("5. Pollo Tipakay             S/ 20");
                    Console.WriteLine("6. Aeropuerto                S/ 17");
                    Console.WriteLine("7. Lomo saltado              S/ 22");
                    Console.WriteLine("8. Kam Lu Wantán             S/ 20");
                    Console.WriteLine("9. Wantán frito              S/ 8");
                    Console.WriteLine("10. Sopa wantán              S/ 10");
                    Console.WriteLine("11. Rollito primavera        S/ 7");
                    Console.WriteLine("12. Inca Kola                S/ 4");
                    Console.WriteLine("13. Coca-Cola                S/ 4");
                    Console.WriteLine("14. Chicha morada            S/ 5");
                    Console.WriteLine("15. Limonada                 S/ 5");
                    Console.WriteLine("16. Salir del menú de pedidos");
                    Console.WriteLine("Ingrese el número del plato que desea pedir:");

                    opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                            pedido[contadorPedidos] = platos[opcion - 1];
                            Console.WriteLine("Plato seleccionado: " + pedido[contadorPedidos]);
                            contadorPedidos++;
                            break;
                        case 16:
                            if (contadorPedidos == 0){
                                Console.WriteLine("No ha seleccionado ningun pedido");
                                continue;
                            }
                            else {
                                Console.WriteLine("Saliendo del menú de pedidos.");
                                break;
                            }

                        default:
                            Console.WriteLine("Opción de plato inválida.");
                            continue;
                    }
                }

                    if (!platos.Contains(pedido[contador]))
                    {
                        Console.WriteLine("Plato no disponible en el menú.");
                        return;
                    }
                    double total = CalcularTotal();

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
        static public double CalcularTotal()
        {
            double totalPedidos = 0;

            Console.WriteLine("------------------------------");
            Console.WriteLine("       BOLETA DE PAGO");
            Console.WriteLine("------------------------------");

            for (int i = 0; i < contadorPedidos; i++)
            {
                double precio = 0;

                if (pedido[i] == "Arroz chaufa")
                    precio = 15;
                else if (pedido[i] == "Tallarín saltado")
                    precio = 16;
                else if (pedido[i] == "Pollo con verduras")
                    precio = 18;
                else if (pedido[i] == "Pollo Chi Jau Kay")
                    precio = 20;
                else if (pedido[i] == "Pollo Tipakay")
                    precio = 20;
                else if (pedido[i] == "Aeropuerto")
                    precio = 17;
                else if (pedido[i] == "Lomo saltado")
                    precio = 22;
                else if (pedido[i] == "Kam Lu Wantán")
                    precio = 20;
                else if (pedido[i] == "Wantán frito")
                    precio = 8;
                else if (pedido[i] == "Sopa wantán")
                    precio = 10;
                else if (pedido[i] == "Rollito primavera")
                    precio = 7;
                else if (pedido[i] == "Inca Kola")
                    precio = 4;
                else if (pedido[i] == "Coca-Cola")
                    precio = 4;
                else if (pedido[i] == "Chicha morada")
                    precio = 5;
                else if (pedido[i] == "Limonada")
                    precio = 5;

                Console.WriteLine(pedido[i] + " - S/ " + precio);

                totalPedidos += precio;
            }

            double costoDelivery = 0;

            if (delivery[0])
            {
                if (distrito[0] == "San Martín de Porres")
                    costoDelivery = 3;
                else if (distrito[0] == "Los Olivos")
                    costoDelivery = 4;
                else if (distrito[0] == "Independencia")
                    costoDelivery = 4;
                else if (distrito[0] == "Rímac")
                    costoDelivery = 5;
                else if (distrito[0] == "Comas")
                    costoDelivery = 6;
                else if (distrito[0] == "Cercado de Lima")
                    costoDelivery = 6;
                else if (distrito[0] == "Carmen de la Legua-Reynoso")
                    costoDelivery = 7;
                else if (distrito[0] == "Callao")
                    costoDelivery = 7;
                else if (distrito[0] == "Puente Piedra")
                    costoDelivery = 8;
                else if (distrito[0] == "Ventanilla")
                    costoDelivery = 10;

                Console.WriteLine("Distrito: " + distrito[0]);
                Console.WriteLine("Costo de delivery: S/ " + costoDelivery);
            }
            else
            {
                Console.WriteLine("Pedido para salón.");
            }

            double total = totalPedidos + costoDelivery;

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Subtotal: S/ " + totalPedidos);
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
                        ValidarDatosPedido();
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
