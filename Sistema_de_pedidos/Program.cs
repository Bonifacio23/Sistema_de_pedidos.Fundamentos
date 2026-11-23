using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sistema_de_pedidos
{
    internal class Program
    {


        static int maxItems = 50;
        static string[,] pedido = new string[maxItems, maxItems];
        static int[,] cantidades = new int[maxItems, maxItems];
        static int[] cantidadPedidos = new int[maxItems];
        static bool[] delivery = new bool[maxItems];
        static string[] Nombre = new string[maxItems];
        static string[] Direccion = new string[maxItems];
        static string[] Telefono = new string[maxItems];

        static string[] boleta = new string[maxItems];
        static double[] totalCliente = new double[maxItems];
        static Dictionary<string, int> ventasDelDia = new Dictionary<string, int>();
        static double totalVendido = 0;
        static string rutaHistorial = "historial.txt";
        static string[] metodoPago = new string[maxItems];
        static int contador = 0;
        static string[] estado = new string[maxItems];
        static string[] distrito = new string[maxItems];
        static string[] tipoDoc = new string[maxItems];
        static string[] rucCliente = new string[maxItems];
        static public Dictionary<string, double> precios = new Dictionary<string, double>
        {
            { "Arroz chaufa", 15 },
            { "Tallarín saltado", 16 },
            { "Pollo con verduras", 18 },
            { "Pollo Chi Jau Kay", 20},
            { "Pollo Tipakay", 20 },
            { "Aeropuerto", 17 },
            { "Lomo saltado", 22 },
            { "Kam Lu Wantán", 20 },
            { "Wantán frito", 8 },
            { "Sopa wantán", 10 },
            { "Rollito primavera", 7 },
            { "Inca Kola", 4 },
            { "Coca-Cola", 4 },
            { "Chicha morada", 5 },
            { "Limonada", 5 }
        };
                                                         
        static public Dictionary<string, double> costosDelivery = new Dictionary<string, double>
{
{ "San Martín de Porres", 3 },
{ "Los Olivos", 4 },
{ "Independencia", 4 },
{ "Rímac", 5 },
{ "Comas", 6 },
{ "Cercado de Lima", 6 },
{ "Carmen de la Legua-Reynoso", 7 },
{ "Callao", 7 },
{ "Puente Piedra", 8 },
{ "Ventanilla", 10 }
};
        static public List<string> platos = precios.Keys.ToList();
        static public List<string> distritos = costosDelivery.Keys.ToList();

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
                string patronNombre = @"\A[A-Za-zÁÉÍÓÚáéíóúÑñ]+(\s[A-Za-zÁÉÍÓÚáéíóúÑñ]+)*\z";
                bool nombreValido = false;

                while (!nombreValido)
                {
                    Console.WriteLine("Ingrese el nombre del cliente:");
                    string entradaNombre = (Console.ReadLine() ?? "").Trim();

                    if (Regex.IsMatch(entradaNombre, patronNombre))
                    {
                        Nombre[contador] = entradaNombre;
                        nombreValido = true;
                    }
                    else
                    {
                        Console.WriteLine("El nombre no es válido. Use solo letras y espacios.");
                    }
                }



                Console.WriteLine("¿El pedido será por delivery o para salón? (d/s):");
                string tipo = Console.ReadLine().ToLower();

                if (tipo == "d")
                {

                    string patronDireccion = @"\A[A-Za-zÁÉÍÓÚáéíóúÑñ0-9][A-Za-zÁÉÍÓÚáéíóúÑñ0-9\s.,#-]*\z";

                    bool direccionValida = false;

                    while (!direccionValida)
                    {
                        Console.WriteLine("Ingrese la dirección:");
                        Direccion[contador] = (Console.ReadLine() ?? "").Trim();

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
                        Telefono[contador] = (Console.ReadLine() ?? "").Trim();

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
                        string entrada = (Console.ReadLine() ?? "").Trim();

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
                PedirDocumento(contador);
                CalcularTotal(contador);
                Metodo_pago(contador);

            }

            else
            {
                Console.WriteLine("Se alcanzó el límite máximo de pedidos.");
            }
        }
        static void PedirDocumento(int cliente)
        {
            Console.WriteLine("El cliente desea boleta o factura(b / f): ");
            string tipo = (Console.ReadLine() ?? "").Trim().ToLower();
            while (tipo != "b" && tipo != "f")
            {
                Console.WriteLine("Opción inválida.Escriba b o f:");
                tipo = (Console.ReadLine() ?? "").Trim().ToLower();
            }
            tipoDoc[cliente] = tipo;
            rucCliente[cliente] = "";
            if (tipo == "f")
            {
                Console.WriteLine("Ingrese el RUC del cliente: ");
                string ruc = (Console.ReadLine() ?? "").Trim();
                while (!Regex.IsMatch(ruc, @"\A(10|20)[0-9]{9}\z"))
                {
                    Console.WriteLine("RUC inválido.Debe tener 11 dígitos y empezar con 10 o 20:");
                    ruc = (Console.ReadLine() ?? "").Trim();
                }
                rucCliente[cliente] = ruc;
            }
        }
        static double ObtenerCostoDelivery(string d)
        {
            if (costosDelivery.TryGetValue(d, out double costo))
            {
                return costo;
            }
            Console.WriteLine("Distrito no válido");
            return 0;
        }

        static double ObtenerPrecio(string plato)
        {
            if (precios.TryGetValue(plato, out double precio))
            {
                return precio;
            }
            Console.WriteLine("Plato no válido");
            return 0;
        }

        static public void Metodo_pago(int cliente)

        {

            bool pagoValido = false;



            while (!pagoValido)
            {
                
                Console.WriteLine("Seleccione el método de pago:");
                Console.WriteLine("1. Yape");
                Console.WriteLine("2. Plin");
                Console.WriteLine("3. Tarjeta");
                Console.WriteLine("4. Efectivo");

                try
                {
                    int valido = int.TryParse(Console.ReadLine(), out int pago) ? pago : 0;

                    switch (pago)

                    {
                        case 1:

                            Console.WriteLine("Pago con Yape.");
                            metodoPago[cliente] = "Yape";
                            pagoValido = true; 
                            break;

                        case 2:

                            Console.WriteLine("Pago con Plin.");
                            metodoPago[cliente] = "Plin";
                            pagoValido = true;
                            break;

                        case 3:

                            Console.WriteLine("Pago con tarjeta.");
                            metodoPago[cliente] = "Tarjeta";
                            pagoValido = true;
                            break;

                        case 4:

                            Console.WriteLine("Pago en efectivo.");
                            metodoPago[cliente] = "Efectivo";
                            double total = totalCliente[cliente];

                            Console.WriteLine("Cuanto dinero entregará el cliente?");
                            double dineroEntregado;
                            while (!double.TryParse(Console.ReadLine(), out dineroEntregado) || dineroEntregado < 0 || dineroEntregado < total)
                            {
                                Console.WriteLine($"Ingrese una cantidad válida");
                            }
                            

                            Console.WriteLine($"Su vuelto es S/ {dineroEntregado - total}");
                            pagoValido = true;
                            break;

                        default:
                            Console.WriteLine("Opción inválida. Elija un número del 1 al 4.\n");                       
                            break;
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("Error: Debe ingresar un número válido (no letras).\n");
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}\n");
                    
                }

            }

            Console.WriteLine("Pedido registrado exitosamente.");
            estado[contador] = "Pendiente";
            contador++;
        }
        static public void Platosmasvendidos()
        {
            var total = new Dictionary<string, int>(ventasDelDia);
            for (int i = 0; i < contador; i++)
            {
                for (int j = 0; j < cantidadPedidos[i]; j++)
                {
                    string plato = pedido[i, j];
                    if (plato == null)
                    {
                        continue;
                    }
                    if (total.ContainsKey(plato))
                    {
                        total[plato] += cantidades[i, j];
                    }
                    else
                    {
                        total[plato] = cantidades[i, j];
                    }
                }
            }
            if (total.Count == 0)
            {
                Console.WriteLine("Aun no hay pedidos registrados.");
                return;
            }
            var topPlatos = total.OrderByDescending(p => p.Value).ThenBy(p => p.Key).Take(3);
            Console.WriteLine("Los 3 platos mas vendidos del dia son:");
            foreach (var plato in topPlatos)
            {
                Console.WriteLine($"{plato.Key} - Cantidad vendida: {plato.Value}");
            }
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
                    Console.WriteLine("Plato seleccionado: " + platoSeleccionado);
                    if (opcion >= 12 && opcion <= 15)
                    {
                        Console.WriteLine("Cuantas bebidas desea agregar?");
                    }
                    else
                    {
                        Console.WriteLine("Cuantos platos desea agregar?");
                    }
                    int cantidad;
                    while(!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
                    {
                        Console.WriteLine("Ingrese una cantidad válida (mayor a 0):");
                    }
                    pedido[cliente, cantidadPedidos[cliente]] = platoSeleccionado;
                    cantidades[cliente, cantidadPedidos[cliente]] = cantidad;
                    Console.WriteLine("Agregado: " + cantidad + " x " + platoSeleccionado);
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
                            Console.WriteLine($"{cantidades[i, j]} x {pedido[i, j]}");
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
        static public double CalcularTotal(int cliente, bool mostrar = true)
        {
            StringBuilder sb = new StringBuilder();
            double totalPedidos = 0;
            bool esFactura = tipoDoc[cliente] == "f";

            sb.AppendLine("------------------------------");
            sb.AppendLine(esFactura ? " FACTURA DE PAGO" : " BOLETA DE PAGO");
            sb.AppendLine("------------------------------");

            for (int i = 0; i < cantidadPedidos[cliente]; i++)
            {
                double precio = ObtenerPrecio(pedido[cliente, i]);
                sb.AppendLine(pedido[cliente, i] + " x " +cantidades[cliente, i] + " -S / " +cantidades[cliente, i] * precio);
                totalPedidos += cantidades[cliente, i] * precio;
            }

            double costoDelivery = 0;
            if (delivery[cliente])
            {
                costoDelivery = ObtenerCostoDelivery(distrito[cliente]);
                sb.AppendLine("Distrito: " +distrito[cliente]);
                sb.AppendLine("Costo de delivery: S/ " +costoDelivery);
            }

            double total = totalPedidos + costoDelivery;

            if (esFactura)
            {
                sb.AppendLine("RUC: " +rucCliente[cliente]);
            }
            sb.AppendLine("--------------------------------");
            sb.AppendLine("Subtotal: S/ " +totalPedidos);
            sb.AppendLine("Total a pagar: S/ " +total);

            string texto = sb.ToString();
            if (mostrar)
            {
                Console.Write(texto);
            }

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
                tipoDoc[i] = tipoDoc[i + 1];
                rucCliente[i] = rucCliente[i + 1];
                for (int k = 0; k < maxItems; k++)
                {
                    pedido[i, k] = pedido[i + 1, k];
                    cantidades[i, k] = cantidades[i + 1, k];
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
            tipoDoc[ultimo] = null;
            rucCliente[ultimo] = null;
            for (int k = 0; k < maxItems; k++)
            {
                pedido[ultimo, k] = null;
                cantidades[ultimo, k] = 0;
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
            string encabezado = "Cliente: " +Nombre[cliente] + " - " +DateTime.Now.ToString("dd / MM / yyyy HH: mm") + " -Pago: " +metodoPago[cliente] + " -Documento: " +(tipoDoc[cliente] == "f" ? "Factura" : "Boleta");
            File.AppendAllText(rutaHistorial, encabezado + Environment.NewLine + boleta[cliente] + Environment.NewLine);
            totalVendido += totalCliente[cliente];

            for (int j = 0; j < cantidadPedidos[cliente]; j++)
            {
                string plato = pedido[cliente, j];
                if (plato == null)
                {
                    continue;
                }
                if (ventasDelDia.ContainsKey(plato))
                {
                    ventasDelDia[plato] += cantidades[cliente, j];
                }
                else
                {
                    ventasDelDia[plato] = cantidades[cliente, j];
                }
            }
        }
        static void Main(string[] args)
        {
            int Op = 0;
            while (Op != 6)
            {
                Console.Clear();
                Title();
                Console.WriteLine("1. Registrar pedido");
                Console.WriteLine("2. Validar datos del pedido");
                Console.WriteLine("3. Actualizar estado del pedido");
                Console.WriteLine("4. Ver historial de ventas");
                Console.WriteLine("5. Platos más vendidos del día");
                Console.WriteLine("6. Salir");
                Console.WriteLine("Ingrese una opción:");
                if (!int.TryParse(Console.ReadLine(), out Op))
                {
                    Console.WriteLine("!!!!ERROR: Ingrese una opción numerica...!!!!");
                    Console.ReadKey();
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
                        Platosmasvendidos();
                        break;
                    case 6:
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
