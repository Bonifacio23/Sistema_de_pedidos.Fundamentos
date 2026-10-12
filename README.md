<h1 align="center">🥡 Sistema de Registro de Pedidos</h1>

<p align="center">
  Aplicación de consola en C# para gestionar pedidos de un chifa, en salón o por delivery.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C#">
  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET">
  <img src="https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white" alt="Visual Studio">
  <img src="https://img.shields.io/badge/Estado-En%20desarrollo-orange?style=for-the-badge" alt="Estado">
</p>

---

## 📋 Contenido

- [Descripción](#-descripción)
- [Características](#-características)
- [Carta y precios](#-carta-y-precios)
- [Tarifas de delivery](#-tarifas-de-delivery)
- [Vista previa](#-vista-previa)
- [Tecnologías](#-tecnologías)
- [Instalación y uso](#-instalación-y-uso)
- [Estructura del proyecto](#-estructura-del-proyecto)
- [Roadmap](#-roadmap)
- [Autor](#-autor)

## 📖 Descripción

Proyecto del curso **Fundamentos de Programación (CIIN1205P)** de la Universidad Privada del Norte. Simula el flujo de atención de un chifa: registro del cliente, selección de platos, método de pago y emisión de una boleta con subtotal, costo de delivery y total a pagar.

Los datos se almacenan en arreglos con una capacidad máxima de **5 pedidos** por sesión.

## ✨ Características

- 🛵 **Pedidos para salón o delivery**, con flujo distinto según el tipo.
- ✅ **Validación con expresiones regulares** de la dirección y del teléfono (exactamente 9 dígitos).
- 📍 **10 distritos de entrega**, cada uno con su propia tarifa.
- 🍜 **Carta de 15 productos** entre platos y bebidas.
- 💳 **Métodos de pago:** Yape, Plin, Tarjeta y Efectivo.
- 🧾 **Boleta de pago** con detalle de platos, delivery, subtotal y total.
- 🔎 **Consulta de pedidos** por nombre del cliente.

## 🍽️ Carta y precios

| N.º | Producto | Precio |
|:---:|----------|-------:|
| 1 | Arroz chaufa | S/ 15 |
| 2 | Tallarín saltado | S/ 16 |
| 3 | Pollo con verduras | S/ 18 |
| 4 | Pollo Chi Jau Kay | S/ 20 |
| 5 | Pollo Tipakay | S/ 20 |
| 6 | Aeropuerto | S/ 17 |
| 7 | Lomo saltado | S/ 22 |
| 8 | Kam Lu Wantán | S/ 20 |
| 9 | Wantán frito | S/ 8 |
| 10 | Sopa wantán | S/ 10 |
| 11 | Rollito primavera | S/ 7 |
| 12 | Inca Kola | S/ 4 |
| 13 | Coca-Cola | S/ 4 |
| 14 | Chicha morada | S/ 5 |
| 15 | Limonada | S/ 5 |

## 🚚 Tarifas de delivery

| Distrito | Costo |
|----------|------:|
| San Martín de Porres | S/ 3 |
| Los Olivos | S/ 4 |
| Independencia | S/ 4 |
| Rímac | S/ 5 |
| Comas | S/ 6 |
| Cercado de Lima | S/ 6 |
| Carmen de la Legua-Reynoso | S/ 7 |
| Callao | S/ 7 |
| Puente Piedra | S/ 8 |
| Ventanilla | S/ 10 |

## 🖥️ Vista previa

```
------------------------------------------
*************Menú de opciones*************
------------------------------------------
1. Registrar cliente
2. Registrar pedido
3. Validar datos del pedido
4. Buscar plato por nombre
5. Validar pago del pedido
6. Actualizar estado del pedido
7. Calcular total del pedido
8. Salir
```

```
------------------------------
       BOLETA DE PAGO
------------------------------
Arroz chaufa - S/ 15
Inca Kola - S/ 4
Pedido por delivery.
Distrito: Los Olivos
Costo de delivery: S/ 4
--------------------------------
Subtotal: S/ 19
Total a pagar: S/ 23
```

## 🛠️ Tecnologías

| Herramienta | Uso |
|-------------|-----|
| C# / .NET | Lenguaje y plataforma |
| Visual Studio | Entorno de desarrollo |
| System.Text.RegularExpressions | Validación de datos |
| Git y GitHub | Control de versiones |

## 🚀 Instalación y uso

**Requisitos:** Visual Studio 2022 o superior con la carga de trabajo de desarrollo de escritorio con .NET.

1. Clona el repositorio:

```
git clone https://github.com/Bonifacio23/Sistema_de_pedidos.Fundamentos.git
```

2. Abre el archivo `Sistema_de_pedidos.slnx` con Visual Studio.
3. Presiona **F5** para compilar y ejecutar.
4. Sigue las instrucciones en la consola.

## 📁 Estructura del proyecto

```
Sistema_de_pedidos.Fundamentos/
├── Sistema_de_pedidos/
│   └── Program.cs
├── Sistema_de_pedidos.slnx
├── .gitattributes
├── .gitignore
└── README.md
```

## 🗺️ Roadmap

- [x] Registro de pedidos para salón y delivery
- [x] Validación de dirección y teléfono con regex
- [x] Carta de platos y selección de distrito
- [x] Boleta de pago con costo de delivery
- [x] Consulta de pedido por nombre del cliente
- [ ] Cola **FIFO** para atender los pedidos en orden de llegada
- [ ] Búsqueda de plato por nombre
- [ ] Validación del pago del pedido
- [ ] Actualización del estado del pedido
- [ ] Cálculo del total por pedido individual

## 👥 Autores

Estudiantes de Ingeniería de Sistemas de la Universidad Privada del Norte, Lima, Perú.

Jhonny Dylan Perez Poma (N00560734)
Félix Jesús Bonifacio Cotrina (N00559691)
Joaquin Alejandro Cabrejos Cabezas (N00542549)
Jared Valentino Readi Flores (N00535298)

[![GitHub](https://img.shields.io/badge/GitHub-Bonifacio23-181717?style=flat&logo=github)](https://github.com/Bonifacio23)
