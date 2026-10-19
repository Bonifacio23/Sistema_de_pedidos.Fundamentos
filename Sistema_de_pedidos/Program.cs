using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sistema_de_pedidos
{
    internal class Program
    {

        static int maxItems = 50;
        static string[,] pedido = new string[maxItems, maxItems];
        static int[] cantidadPedidos = new int[maxItems];
        static bool[] delivery = new bool[maxItems];
        static string[] Nombre = new string[maxItems];
        static string[] Direccion = new string[maxItems];
        static string[] Telefono = new string[maxItems];

        static string[] boleta = new string[maxItems];
        static double[] totalCliente = new double[maxItems];
        static double totalVendido = 0;
        static string rutaHistorial = "historial.txt";
        static string[] metodoPago = new string[maxItems];
        static int contador = 0;
        static string[] estado = new string[maxItems];
        static string[] distrito = new string[maxItems];

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


        static public void RegistrarPedido()
        {

            if (contador < maxItems)
            {

                cantidadPedidos[contador] = 0;
                Console.WriteLine("Ingrese el nombre del cliente:");
                Nombre[contador] = Console.ReadLine()?.Trim();


                Console.WriteLine("¿El pedido será por delivery o para salón? (d/s):");
                string tipo = Console.ReadLine().ToLower();

                if (tipo == "d")
                {

                    string patronDireccion = @"\A[A-Za-zÁÉÍÓÚáéíóúÑñ0-9][A-Za-zÁÉÍÓÚáéíóúÑñ0-9\s.,#-]*\z";

                    bool direccionValida = false;

                    while (!direccionValida)
                    {
                        Console.WriteLine("Ingrese la dirección:");
                        Direccion[contador] = Console.ReadLine() ?? "".Trim();

                        if (Regex.IsMatch(Direccion[contador], patronDireccion))
                        {
                            direccionValida = true;
                        }
                        else
                        {
                            Console.WriteLine("La dirección no es válida. Intente nuevamente.");
                        }
                    }

                    Console.WriteLine("Dirección registrada correctamente.");


                    string patronTelefono = @"\A[0-9]{9}\z";
                    bool telefonoValido = false;

                    while (!telefonoValido)
                    {
                        Console.WriteLine("Ingrese el teléfono:");
                        Telefono[contador] = Console.ReadLine() ?? "".Trim();

                        if (Regex.IsMatch(Telefono[contador], patronTelefono))
                        {
                            telefonoValido = true;
                        }
                        else
                        {
                            Console.WriteLine("El teléfono no es válido. Debe contener exactamente 9 dígitos.");
                        }
                    }
                    Console.WriteLine("Teléfono registrado correctamente.");


                    bool distritoValido = false;

                    while (!distritoValido)
                    {
                        Console.WriteLine("\nSeleccione el distrito:");

                        for (int i = 0; i < distritos.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {distritos[i]}");
                        }


                        Console.Write("Ingrese el número del distrito: ");
                        string entrada = Console.ReadLine() ?? "".Trim();

                        if (int.TryParse(entrada, out int opcionDistrito) &&
                            opcionDistrito >= 1 &&
                            opcionDistrito <= distritos.Count)
                        {
                            distrito[contador] = distritos[opcionDistrito - 1];
                            distritoValido = true;
                            delivery[contador] = true;

                            Console.WriteLine("Distrito válido: " + distrito[contador]);
                        }
                        else
                        {
                            Console.WriteLine("Opción inválida. Seleccione un distrito de la lista.");
                        }
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

                Menu(contador);
                double total = CalcularTotal(contador);
                Metodo_pago();

            }

            else
            {
                Console.WriteLine("Se alcanzó el límite máximo de pedidos.");
            }
        }

        static double ObtenerCostoDelivery(string d)
        {
            switch (d)
            {
                case "San Martín de Porres":
                    return 3;
                case "Los Olivos":
                case "Independencia":
                    return 4;
                case "Rímac":
                    return 5;
                case "Comas":
                case "Cercado de Lima":
                    return 6;
                case "Carmen de la Legua-Reynoso":
                case "Callao":
                    return 7;
                case "Puente Piedra":
                    return 8;
                case "Ventanilla":
                    return 10;
                default:
                    Console.WriteLine("Distrito no válido.");
                    return 0;
            }
        }
        static double ObtenerPrecio(string plato)
        {
            switch (plato)
            {
                case "Arroz chaufa": return 15;
                case "Tallarín saltado": return 16;
                case "Pollo con verduras": return 18;
                case "Pollo Chi Jau Kay": return 20;
                case "Pollo Tipakay": return 20;
                case "Aeropuerto": return 17;
                case "Lomo saltado": return 22;
                case "Kam Lu Wantán": return 20;
                case "Wantán frito": return 8;
                case "Sopa wantán": return 10;
                case "Rollito primavera": return 7;
                case "Inca Kola": return 4;
                case "Coca-Cola": return 4;
                case "Chicha morada": return 5;
                case "Limonada": return 5;
                default: return 0;
            }
        }
        static public void Metodo_pago()
        {
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


            estado[contador] = "Pendiente";
            contador++;

        }
        static public void Menu(int cliente)
        {
            int opcion = 0;

        
            List<string> platosMenu = new List<string>(platos);

            while (opcion != 16)
            {
                Console.Clear();
                Console.WriteLine("\nSeleccione el pedido:");

                for (int i = 0; i < platosMenu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {platosMenu[i],-25} S/ {ObtenerPrecio(platosMenu[i])}");
                }

                Console.WriteLine("16. Salir del menú de pedidos");
                Console.WriteLine("17. Ordenar alfabéticamente (A-Z)");
                Console.WriteLine("18. Ordenar por precio (menor a mayor)");
                Console.Write("Ingrese una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida. Ingrese un número.");
                    Console.ReadKey();
                    opcion = 0;
                    continue;
                }

                if (opcion >= 1 && opcion <= platosMenu.Count)
                {
                    if (cantidadPedidos[cliente] >= maxItems)
                    {
                        Console.WriteLine("Se alcanzó el límite de platos por cliente.");
                        Console.ReadKey();
                        continue;
                    }

                    string platoSeleccionado = platosMenu[opcion - 1];
                    pedido[cliente, cantidadPedidos[cliente]] = platoSeleccionado;
                    Console.WriteLine("Plato seleccionado: " + platoSeleccionado);
                    cantidadPedidos[cliente]++;
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }
                else if (opcion == 16)
                {
                    if (cantidadPedidos[cliente] == 0)
                    {
                        Console.WriteLine("No ha seleccionado ningún pedido.");
                        Console.ReadKey();
                        opcion = 0;
                        continue;
                    }

                    Console.WriteLine("Saliendo del menú de pedidos.");
                }
                else if (opcion == 17)
                {
                    platosMenu = platos.OrderBy(p => p, StringComparer.CurrentCultureIgnoreCase).ToList();
                    Console.WriteLine("Menú ordenado alfabéticamente de la A a la Z. Presione un cualquier tecla para actualizar");
                    Console.ReadKey();
                    opcion = 0;
                }
                else if (opcion == 18)
                {
                    platosMenu = platos.OrderBy(p => ObtenerPrecio(p))
                                       .ThenBy(p => p, StringComparer.CurrentCultureIgnoreCase)
                                       .ToList();
                    Console.WriteLine("Menú ordenado por precio, de menor a mayor. Presione un cualquier tecla para actualizar");
                    Console.ReadKey();
                    opcion = 0;
                }
                else
                {
                    Console.WriteLine("Opción inválida.");
                    Console.ReadKey();
                    opcion = 0;
                }
            }
        }

        static public void ValidarDatosPedido()
        {
            Console.WriteLine("Ingrese el nombre del cliente para validar su pedido:");
            string nombreCliente = (Console.ReadLine() ?? "").Trim();

            for (int i = 0; i < contador; i++)
            {
                if (string.Equals(Nombre[i], nombreCliente, StringComparison.OrdinalIgnoreCase))
                {
                    if (cantidadPedidos[i] > 0)
                    {
                        Console.WriteLine($"Pedido de {Nombre[i]}:");
                        for (int j = 0; j < cantidadPedidos[i]; j++)
                        {
                            Console.WriteLine($"- {pedido[i, j]}");
                        }

                        if (delivery[i])
                        {
                            Console.WriteLine($"Distrito: {distrito[i]}");
                            Console.WriteLine($"Costo de delivery: S/ {ObtenerCostoDelivery(distrito[i])}");
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
        static public double CalcularTotal(int cliente)
        {
            StringBuilder sb = new StringBuilder();
            double totalPedidos = 0;

            sb.AppendLine("------------------------------");
            sb.AppendLine("       BOLETA DE PAGO");
            sb.AppendLine("------------------------------");

            for (int i = 0; i < cantidadPedidos[cliente]; i++)
            {
                double precio = ObtenerPrecio(pedido[cliente, i]);
                sb.AppendLine(pedido[cliente, i] + " - S/ " + precio);
                totalPedidos += precio;
            }

            double costoDelivery = 0;

            if (delivery[cliente])
            {
                costoDelivery = ObtenerCostoDelivery(distrito[cliente]);
                sb.AppendLine("Distrito: " + distrito[cliente]);
                sb.AppendLine("Costo de delivery: S/ " + costoDelivery);
            }

            double total = totalPedidos + costoDelivery;

            sb.AppendLine("--------------------------------");
            sb.AppendLine("Subtotal: S/ " + totalPedidos);
            sb.AppendLine("Total a pagar: S/ " + total);

            string texto = sb.ToString();
            Console.Write(texto);

            boleta[cliente] = texto;
            totalCliente[cliente] = total;

            return total;
        }
        static void EliminarCliente(int indice)
        {
            for (int i = indice; i < contador - 1; i++)
            {
                Nombre[i] = Nombre[i + 1];
                Direccion[i] = Direccion[i + 1];
                Telefono[i] = Telefono[i + 1];
                distrito[i] = distrito[i + 1];
                metodoPago[i] = metodoPago[i + 1];
                delivery[i] = delivery[i + 1];
                estado[i] = estado[i + 1];
                boleta[i] = boleta[i + 1];
                totalCliente[i] = totalCliente[i + 1];
                cantidadPedidos[i] = cantidadPedidos[i + 1];
                for (int k = 0; k < maxItems; k++)
                {
                    pedido[i, k] = pedido[i + 1, k];
                }
            }

            int ultimo = contador - 1;
            Nombre[ultimo] = null;
            Direccion[ultimo] = null;
            Telefono[ultimo] = null;
            distrito[ultimo] = null;
            metodoPago[ultimo] = null;
            delivery[ultimo] = false;
            estado[ultimo] = null;
            boleta[ultimo] = null;
            totalCliente[ultimo] = 0;
            cantidadPedidos[ultimo] = 0;
            for (int k = 0; k < maxItems; k++)
            {
                pedido[ultimo, k] = null;
            }

            contador--;
        }
        static public void MostrarHistorial()
        {
            Console.WriteLine("*****HISTORIAL DE VENTAS DEL DÍA*****");

            if (!File.Exists(rutaHistorial))
            {
                Console.WriteLine("Aún no hay pedidos entregados.");
                return;
            }

            Console.WriteLine(File.ReadAllText(rutaHistorial));
            Console.WriteLine("Total vendido en esta sesión: S/ " + totalVendido);
        }
        static public void ActualizarEstadoPedido()
        {
            Console.WriteLine("*****ACTUALIZAR ESTADO DEL PEDIDO*****");

            if (contador == 0)
            {
                Console.WriteLine("No hay pedidos registrados.");
                return;
            }

            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine((i + 1) + ". " + Nombre[i] + " - " + estado[i]);
            }

            Console.Write("Ingrese el número del pedido: ");
            string entrada = Console.ReadLine() ?? "";

            if (!int.TryParse(entrada, out int opcion) || opcion < 1 || opcion > contador)
            {
                Console.WriteLine("Opción inválida.");
                return;
            }

            int cliente = opcion - 1;

            if (estado[cliente] == "Pendiente")
            {
                Console.WriteLine("El pedido de " + Nombre[cliente] + " está listo para entrega.");
                GuardarEnHistorial(cliente);
                EliminarCliente(cliente);
                Console.WriteLine("Pedido eliminado de la lista y guardado en el historial.");
            }
        }
        static void GuardarEnHistorial(int cliente)
        {
            string encabezado = "Cliente: " + Nombre[cliente] + " - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " - Pago: " + metodoPago[cliente];
            File.AppendAllText(rutaHistorial, encabezado + Environment.NewLine + boleta[cliente] + Environment.NewLine);
            totalVendido += totalCliente[cliente];
        }
        static void Main(string[] args)
        {
            int Op = 0;
            while (Op != 5)
            {
                Console.Clear();
                Title();
                Console.WriteLine("1. Registrar pedido");
                Console.WriteLine("2. Validar datos del pedido");
                Console.WriteLine("3. Actualizar estado del pedido");
                Console.WriteLine("4. Ver historial de ventas");
                Console.WriteLine("5. Salir");
                Console.WriteLine("Ingrese una opción:");
                if (!int.TryParse(Console.ReadLine(), out Op))
                {
                    Console.WriteLine("!!!!ERROR: Ingrese una opción numerica...!!!!");
                    continue;
                }
                switch (Op)
                {
                    case 1:
                        RegistrarPedido();
                        break;
                    case 2:
                        ValidarDatosPedido();
                        break;
                    case 3:
                        ActualizarEstadoPedido();
                        break;
                    case 4:
                        MostrarHistorial();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
                Console.ReadKey();

            }
        }
    }
}
