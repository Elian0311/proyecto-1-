class program
{
    // Se definen arreglos estáticos para almacenar los datos de los pagos.

    static int[] numerodepago = new int[10];
    static DateTime[] fecha = new DateTime[10];
    static DateTime[] hora = new DateTime[10];
    static string[] cedula = new string[10];
    static string[] nombre = new string[10];
    static string[] apellido1 = new string[10];
    static string[] apellido2 = new string[10];                             // ==> usamos int 10 para definir la capacida, en este caso 10 
    static int[] numerocaja = new int[10];
    static int[] tipo_servicio = new int[10];
    static int[] numero_factura = new int[10];
    static int[] vuelto = new int[10];
    static double[] monto_pagar = new double[10];
    static double[] montoComision = new double[10];
    static double[] monto_deducido = new double[10];
    static double[] montoPagaCliente = new double[10];
    static double[] vueltoPaciente = new double[10];
    static int numeroPagoEliminar = 0;
    static int indiceEliminar = 0;
    static int numeroPagoModificar = 0;
    static int indiceModificar = 0;
    static int numeroPagoConsultar = 0;
    static int indiceConsultar = 0;

    static int posicion = 0;  // Variable para controlar la posición en los arreglos

    static void Main() // Punto de entrada principal del programa.
    {
        int opcion;
        // Menú principal del programa-----------------------------------------------------------------
        do //  Inicia un bucle
        {
            Console.WriteLine("menu principal");
            Console.WriteLine("1. inicializar vectores");
            Console.WriteLine("2. Realizar Pagos");
            Console.WriteLine("3. Consultar Pagos");
            Console.WriteLine("4. Modificar Pagos");
            Console.WriteLine("5. Eliminar Pagos");
            Console.WriteLine("6. Submenú Reportes");
            Console.WriteLine("7. Salir");

            Console.WriteLine("seleccione una opcion: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            // Switch para manejar las opciones del menú--------------------------------------------------

            switch (opcion)
            {
                case 1:
                    Vectores();
                    break;

                case 2:
                    Pagos();
                    break;

                case 3:
                    Consulta();
                    break;

                case 4:
                    Modificar();
                    break;

                case 5:
                    Eliminar();
                    break;

                case 6:
                    Submenu();
                    break;

                case 7:
                    Console.WriteLine("Saliendo del programa");
                    break;

                default:
                    Console.WriteLine("Intente de nuevo");
                    break;
            }

        } while (opcion != 7); // salir del menu 

        //Función para inicializar los vectores -----------------------------------------------------------------

        static void Vectores()
        {
            for (int i = 0; i < 10; i++)
            {
                // Inicializar todos los arreglos con valores predeterminados(primer opcion del menu)

                numerodepago[i] = 0;
                fecha[i] = DateTime.MinValue;
                hora[i] = DateTime.MinValue;
                cedula[i] = "";
                nombre[i] = "";
                apellido1[i] = "";
                apellido2[i] = "";
                numerocaja[i] = 0;
                tipo_servicio[i] = 0;
                numero_factura[i] = 0;
                monto_pagar[i] = 0.0;
                montoComision[i] = 0.0;
                monto_deducido[i] = 0.0;
                montoPagaCliente[i] = 0.0;
                posicion = 0;

                // restablecemos los valores en 0
            }

            Console.WriteLine("Vectores listos");

        }

        // Función para realizar pagos----------------------------------------------------------------------

        static void Pagos()
        {
            // Verificar si se ha alcanzado el límite de pagos

            if (posicion >= 10)
            {
                Console.WriteLine("Vectores Llenos. No se pueden ingresar más pagos.");
                return;
            }

            Console.WriteLine("Ingrese los datos para el pago:");

            // El ingreso de los datos para el pago 

            numerodepago[posicion] = posicion + 1;
            Console.Write("Fecha (MM/dd/yyyy): ");
            fecha[posicion] = DateTime.Parse(Console.ReadLine());  // : Lee una cadena de la consola y la convierte en un objeto DateTime.
            Console.Write("Hora (HH:mm:ss): ");
            hora[posicion] = DateTime.Parse(Console.ReadLine());
            Console.Write("Cédula: ");
            cedula[posicion] = Console.ReadLine();
            Console.Write("Nombre: ");
            nombre[posicion] = Console.ReadLine();
            Console.Write("Apellido1: ");
            apellido1[posicion] = Console.ReadLine();
            Console.Write("Apellido2: ");
            apellido2[posicion] = Console.ReadLine();
            do
            {
                Console.Write("Número de Caja (1, 2, 3)");
                numerocaja[posicion] = Convert.ToInt32(Console.ReadLine());

                if (numerocaja[posicion] < 1 || numerocaja[posicion] > 3)
                {
                    Console.WriteLine("Número de caja no válido. Por favor, ingrese un número entre 1 y 3.");
                }
            } while (numerocaja[posicion] < 1 || numerocaja[posicion] > 3);

            // verificar que el tipo de servicio sea correcto 
            do
            {
                Console.Write("Número de Caja (1:Recibo de Luz    2:Recibo Teléfono 3: Recibo de Agua): ");
                tipo_servicio[posicion] = Convert.ToInt32(Console.ReadLine());

                if (tipo_servicio[posicion] != 1 && tipo_servicio[posicion] != 2 && tipo_servicio[posicion] != 3)
                {
                    Console.WriteLine("Tipo de servicio no válido. Por favor, ingrese 1, 2 o 3.");
                }

            } while (tipo_servicio[posicion] != 1 && tipo_servicio[posicion] != 2 && tipo_servicio[posicion] != 3);

            Console.Write("Monto a Pagar: ");
            monto_pagar[posicion] = Convert.ToDouble(Console.ReadLine());

            // Calcular comisión basada en el tipo de servicio

            if (tipo_servicio[posicion] == 1)
            {
                montoComision[posicion] = monto_pagar[posicion] * 0.04;
            }
            else if (tipo_servicio[posicion] == 2)
            {
                montoComision[posicion] = monto_pagar[posicion] * 0.055;
            }
            else if (tipo_servicio[posicion] == 3)
            {
                montoComision[posicion] = monto_pagar[posicion] * 0.065;
            }

            // restar la comision al pago final del cliente 

            monto_deducido[posicion] = monto_pagar[posicion] - montoComision[posicion];
            Console.WriteLine($" El monto deducido es: {monto_deducido[posicion]}");

            // Evitar que el monto final del cliente sea menor al monto deducido

            double montoCliente;


            do
            {
                Console.Write("Monto que cancela el cliente: ");
                montoCliente = Convert.ToDouble(Console.ReadLine());

                if (montoCliente < monto_pagar[posicion])
                {
                    Console.WriteLine("El monto que cancela el cliente no puede ser menor al monto a pagar. Intente de nuevo.");
                }

            } while (montoCliente < monto_pagar[posicion]);

            montoPagaCliente[posicion] = montoCliente;

            // calculamos vuelto

            if (montoPagaCliente[posicion] > monto_deducido[posicion])
            {
                double vuelto = montoPagaCliente[posicion] - monto_deducido[posicion];
                vueltoPaciente[posicion] = vuelto;
                Console.WriteLine($"El vuelto es: {vuelto}");
                Console.WriteLine("Su pago fue realizado con exito");
            }

            // Incrementar la posición para el próximo pago
            posicion++;




        }

        // consulta-----------------------------------------------------------------------------

        static void Consulta()

        {
            // Se le solicita al usuario que ingrese el número de pago que desea consultar.
            Console.WriteLine("Ingrese el número de pago que desea consultar:");
            int numeroPagoConsultar = Convert.ToInt32(Console.ReadLine());

            // Se busca el índice del pago en el vector numerodepago.
            int indiceConsultar = Array.IndexOf(numerodepago, numeroPagoConsultar);

            // Se verifica si el número de pago existe en el vector.
            if (indiceConsultar != -1 && indiceConsultar < posicion)
            {
                // Si el pago se encuentra registrado, se muestran los datos asociados.
                Console.WriteLine($"Datos del Pago {numeroPagoConsultar}:");
                Console.WriteLine($"Fecha: {fecha[indiceConsultar].Date.ToString("MM/dd/yyyy")}");
                Console.WriteLine($"Hora: {hora[indiceConsultar].TimeOfDay.ToString("hh\\:mm\\:ss")}");
                Console.WriteLine($"Cédula: {cedula[indiceConsultar]}");
                Console.WriteLine($"Nombre: {nombre[indiceConsultar]}");
                Console.WriteLine($"Apellido1: {apellido1[indiceConsultar]}");
                Console.WriteLine($"Apellido2: {apellido2[indiceConsultar]}");
                Console.WriteLine($"Número de Caja: {numerocaja[indiceConsultar]}");
                Console.WriteLine($"Tipo de Servicio: {tipo_servicio[indiceConsultar]}");
                Console.WriteLine($"Número de Factura: {numero_factura[indiceConsultar]}");
                Console.WriteLine($"Monto a Pagar: {monto_pagar[indiceConsultar]}");
                Console.WriteLine($"Monto de Comisión: {montoComision[indiceConsultar]}");
                Console.WriteLine($"Monto Deducido: {monto_deducido[indiceConsultar]}");
                Console.WriteLine($"Monto Pagado por el Cliente: {montoPagaCliente[indiceConsultar]}");
                Console.WriteLine($"Vuelto para el Cliente: {vueltoPaciente[indiceConsultar]}");
            }
            else
            {
                // Si el pago no se encuentra registrado, mostrar un mensaje.
                Console.WriteLine("Pago no se encuentra registrado.");
            }
        }
        // Modificar-----------------------------------------------------------------------------
        static void Modificar()


        {    // Se le solicita al usuario que ingrese el número de pago que desea modificar.


            Console.WriteLine("Ingrese el número de pago que desea modificar:");
            numeroPagoModificar = Convert.ToInt32(Console.ReadLine());

            // Buscar el índice del pago en el vector numerodepago.


            int indiceModificar = Array.IndexOf(numerodepago, numeroPagoModificar);

            // Verificar si el número de pago existe en el vector.


            if (indiceModificar != -1)
            {
                Console.WriteLine($"Modificando el Pago {numeroPagoModificar}:");
                Console.WriteLine("Ingrese los nuevos datos:");

                Console.Write("Fecha (MM/dd/yyyy): ");
                fecha[indiceModificar] = DateTime.Parse(Console.ReadLine());
                Console.Write("Nueva Hora (HH:mm:ss): ");
                hora[indiceModificar] = DateTime.Parse(Console.ReadLine());
                Console.Write("Cédula: ");
                cedula[indiceModificar] = Console.ReadLine();
                Console.Write("Nombre: ");
                nombre[indiceModificar] = Console.ReadLine();
                Console.Write("Apellido1: ");
                apellido1[indiceModificar] = Console.ReadLine();
                Console.Write("Apellido2: ");
                apellido2[indiceModificar] = Console.ReadLine();

                do
                {
                    Console.Write("Número de Caja (1: Recibo de Luz, 2: Recibo Teléfono, 3: Recibo de Agua): ");
                    numerocaja[indiceModificar] = Convert.ToInt32(Console.ReadLine());

                    if (numerocaja[indiceModificar] < 1 || numerocaja[indiceModificar] > 3)
                    {
                        Console.WriteLine("Número de caja no válido. Por favor, ingrese un número entre 1 y 3.");
                    }
                } while (numerocaja[indiceModificar] < 1 || numerocaja[indiceModificar] > 3);

                do
                {
                    Console.WriteLine("Número de Caja (1:Recibo de Luz    2:Recibo Teléfono 3: Recibo de Agua): ");
                    tipo_servicio[indiceModificar] = Convert.ToInt32(Console.ReadLine());

                    if (tipo_servicio[indiceModificar] != 1 && tipo_servicio[indiceModificar] != 2 && tipo_servicio[indiceModificar] != 3)
                    {
                        Console.WriteLine("Tipo de servicio no válido. Por favor, ingrese 1, 2 o 3.");
                    }
                } while (tipo_servicio[indiceModificar] != 1 && tipo_servicio[indiceModificar] != 2 && tipo_servicio[indiceModificar] != 3);

                Console.Write("Monto a Pagar: ");
                monto_pagar[indiceModificar] = Convert.ToDouble(Console.ReadLine());

                // Se calcula nuevamente la comisión y el monto deducido dependiendo del servicio.
                if (tipo_servicio[indiceModificar] == 1)
                {
                    montoComision[indiceModificar] = monto_pagar[indiceModificar] * 0.04;
                }
                else if (tipo_servicio[indiceModificar] == 2)
                {
                    montoComision[indiceModificar] = monto_pagar[indiceModificar] * 0.055;
                }
                else if (tipo_servicio[indiceModificar] == 3)
                {
                    montoComision[indiceModificar] = monto_pagar[indiceModificar] * 0.065;
                }

                // Se calcula el monto deducido
                monto_deducido[indiceModificar] = monto_pagar[indiceModificar] - montoComision[indiceModificar];

                // Si el número de pago a modificar existe, se mostrará este mensaje de exito que se modificó el número.
                Console.WriteLine($" El monto deducido es: {monto_deducido[indiceModificar]}");

                double montoCliente;


                do
                {
                    Console.Write("Monto que cancela el cliente: ");
                    montoCliente = Convert.ToDouble(Console.ReadLine());

                    if (montoCliente < monto_pagar[posicion])
                    {
                        Console.WriteLine("El monto que cancela el cliente no puede ser menor al monto a pagar. Intente de nuevo.");
                    }

                } while (montoCliente < monto_pagar[posicion]);

                montoPagaCliente[posicion] = montoCliente;

                // calculamos vuelto

                if (montoPagaCliente[posicion] > monto_deducido[posicion])
                {
                    double vuelto = montoPagaCliente[posicion] - monto_deducido[posicion];
                    vueltoPaciente[posicion] = vuelto;
                    Console.WriteLine($"El vuelto es: {vuelto}");
                    Console.WriteLine("Su pago fue realizado con exito");
                }
            }
            else
            {   // Si el número de pago a modificar no existe, se mostrará este mensaje de error que el número de pago no existe.
                Console.WriteLine($"El número de pago {numeroPagoModificar} no existe.");

            }


        }

        static void Eliminar()
        {
            // Aquí se le solicita al usuario el número de pago que desea eliminar.
            Console.WriteLine("Ingrese el número de pago que desea eliminar:");
            int numeroPagoEliminar = Convert.ToInt32(Console.ReadLine());

            // Aquí se busca el índice del pago en el vector numerodepago.
            int indiceEliminar = Array.IndexOf(numerodepago, numeroPagoEliminar);

            // Aquí verificamos si verdaderamente el número de pago existe en el vector.
            if (indiceEliminar != -1)
            {
                // Preguntar al usuario si está seguro de eliminar el dato
                Console.WriteLine("¿Está seguro de eliminar el dato? (S/N)");
                string respuesta = Console.ReadLine();

                // Convertir la respuesta a minúsculas para comparar
                respuesta = respuesta.ToLower();

                if (respuesta == "s")
                {
                    for (int i = indiceEliminar; i < posicion - 1; i++)
                    {
                        numerodepago[i] = numerodepago[i + 1];
                        fecha[i] = fecha[i + 1];
                        cedula[i] = cedula[i + 1];
                        nombre[i] = nombre[i + 1];
                        apellido1[i] = apellido1[i + 1];
                        apellido2[i] = apellido2[i + 1];
                        numerocaja[i] = numerocaja[i + 1];
                        tipo_servicio[i] = tipo_servicio[i + 1];
                        numero_factura[i] = numero_factura[i + 1];
                        monto_pagar[i] = monto_pagar[i + 1];
                        montoComision[i] = montoComision[i + 1];
                        monto_deducido[i] = monto_deducido[i + 1];
                        montoPagaCliente[i] = montoPagaCliente[i + 1];
                        vueltoPaciente[i] = vueltoPaciente[i + 1];
                    }

                    posicion--;

                    // Si el numero de pago a eliminar es correcto mostrará este mensaje de exito.
                    Console.WriteLine($"La información ya fue eliminada.");
                }
                else
                {
                    // Si la respuesta no es afirmativa, indicar que la información no fue eliminada.
                    Console.WriteLine($"La información no fue eliminada.");
                }
            }
            else
            {    // Aquí se pide que muestre un mensaje de error si el número de pago no existe.
                Console.WriteLine($"Pago no se encuentra Registrado");
            }
        }

        static void Submenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("Submenú Reportes:");
                Console.WriteLine("1. Reporte Todos los Pagos");
                Console.WriteLine("2. Reporte Ver Pagos por Tipo de Servicios");
                Console.WriteLine("3. Reporte Ver Pagos por Código de Caja");
                Console.WriteLine("4. Ver Dinero Comisionado por servicios");
                Console.WriteLine("5. Regresar al Menú Principal");

                Console.WriteLine("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ReporteTodosLosPagos();
                        break;
                    case 2:
                        ReportePagosPorTipoDeServicio();
                        break;
                    case 3:
                        ReportePagosPorCodigoDeCaja();
                        break;
                    case 4:
                        VerDineroComisionadoPorServicios();
                        break;
                    case 5:
                        Console.WriteLine("Volviendo al Menú Principal...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }

            } while (opcion != 5);
        }

        static void ReporteTodosLosPagos()
        {
            Console.WriteLine("Reporte de Todos los Pagos Realizados:");

            // Verificar si hay pagos realizados
            if (posicion == 0)
            {
                Console.WriteLine("No hay pagos registrados.");
                Console.WriteLine("Regresando al Menú Principal...");
                return;
            }

            // Iterar sobre todos los pagos registrados
            for (int i = 0; i < posicion; i++)
            {
                Console.WriteLine($"Número de Pago: {numerodepago[i]}");
                Console.WriteLine($"Fecha: {fecha[i]}");
                Console.WriteLine($"Cédula: {cedula[i]}");
                Console.WriteLine($"Nombre: {nombre[i]}");
                Console.WriteLine($"Apellido1: {apellido1[i]}");
                Console.WriteLine($"Apellido2: {apellido2[i]}");
                Console.WriteLine($"Número de Caja: {numerocaja[i]}");
                Console.WriteLine($"Tipo de Servicio: {tipo_servicio[i]}");
                Console.WriteLine($"Número de Factura: {numero_factura[i]}");
                Console.WriteLine($"Monto a Pagar: {monto_pagar[i]}");
                Console.WriteLine($"Monto de Comisión: {montoComision[i]}");
                Console.WriteLine($"Monto Deducido: {monto_deducido[i]}");
                Console.WriteLine($"Monto Pagado por el Cliente: {montoPagaCliente[i]}");
                Console.WriteLine($"Vuelto para el Cliente: {vueltoPaciente[i]}");
                Console.WriteLine("-------------------------------------------");
            }
        }

        static void ReportePagosPorTipoDeServicio()
        {
            Console.WriteLine("Reporte de Pagos por Tipo de Servicio:");

            // Solicitar al usuario que ingrese el tipo de servicio
            Console.WriteLine("Ingrese el tipo de servicio (1: Recibo de Luz, 2: Recibo Teléfono, 3: Recibo de Agua):");
            int tipoServicioSeleccionado = Convert.ToInt32(Console.ReadLine());

            // Verificar si hay pagos registrados
            bool pagosEncontrados = false;

            // Iterar sobre todos los pagos registrados
            for (int i = 0; i < posicion; i++)
            {
                // Verificar si el tipo de servicio coincide con el seleccionado
                if (tipo_servicio[i] == tipoServicioSeleccionado)
                {
                    pagosEncontrados = true;
                    Console.WriteLine($"Número de Pago: {numerodepago[i]}");
                    Console.WriteLine($"Fecha: {fecha[i]}");
                    Console.WriteLine($"Cédula: {cedula[i]}");
                    Console.WriteLine($"Nombre: {nombre[i]}");
                    Console.WriteLine($"Apellido1: {apellido1[i]}");
                    Console.WriteLine($"Apellido2: {apellido2[i]}");
                    Console.WriteLine($"Número de Caja: {numerocaja[i]}");
                    Console.WriteLine($"Número de Factura: {numero_factura[i]}");
                    Console.WriteLine($"Monto a Pagar: {monto_pagar[i]}");
                    Console.WriteLine($"Monto de Comisión: {montoComision[i]}");
                    Console.WriteLine($"Monto Deducido: {monto_deducido[i]}");
                    Console.WriteLine($"Monto Pagado por el Cliente: {montoPagaCliente[i]}");
                    Console.WriteLine($"Vuelto para el Cliente: {vueltoPaciente[i]}");
                    Console.WriteLine("-------------------------------------------");
                }
            }

            // Si no se encontraron pagos para el tipo de servicio seleccionado, mostrar un mensaje
            if (!pagosEncontrados)
            {
                Console.WriteLine($"No se encontraron pagos para el tipo de servicio {tipoServicioSeleccionado}.");
            }
        }

        static void ReportePagosPorCodigoDeCaja()
        {
            Console.WriteLine("Reporte de Pagos por Código de Caja:");

            // Solicitar al usuario que ingrese el código de caja
            Console.WriteLine("Ingrese el código de caja (1, 2, 3):");
            int codigoCajaSeleccionado = Convert.ToInt32(Console.ReadLine());

            // Verificar si hay pagos registrados
            bool pagosEncontrados = false;

            // Iterar sobre todos los pagos registrados
            for (int i = 0; i < posicion; i++)
            {
                // Verificar si el código de caja coincide con el seleccionado
                if (numerocaja[i] == codigoCajaSeleccionado)
                {
                    pagosEncontrados = true;
                    Console.WriteLine($"Número de Pago: {numerodepago[i]}");
                    Console.WriteLine($"Fecha: {fecha[i]}");
                    Console.WriteLine($"Cédula: {cedula[i]}");
                    Console.WriteLine($"Nombre: {nombre[i]}");
                    Console.WriteLine($"Apellido1: {apellido1[i]}");
                    Console.WriteLine($"Apellido2: {apellido2[i]}");
                    Console.WriteLine($"Tipo de Servicio: {tipo_servicio[i]}");
                    Console.WriteLine($"Número de Factura: {numero_factura[i]}");
                    Console.WriteLine($"Monto a Pagar: {monto_pagar[i]}");
                    Console.WriteLine($"Monto de Comisión: {montoComision[i]}");
                    Console.WriteLine($"Monto Deducido: {monto_deducido[i]}");
                    Console.WriteLine($"Monto Pagado por el Cliente: {montoPagaCliente[i]}");
                    Console.WriteLine($"Vuelto para el Cliente: {vueltoPaciente[i]}");
                    Console.WriteLine("-------------------------------------------");
                }
            }

            // Si no se encontraron pagos para el código de caja seleccionado, mostrar un mensaje
            if (!pagosEncontrados)
            {
                Console.WriteLine($"No se encontraron pagos para el código de caja {codigoCajaSeleccionado}.");
            }
        }

        static void VerDineroComisionadoPorServicios()
        {
            Console.WriteLine("Dinero Comisionado por Servicios:");

            // Arreglos para almacenar la suma de comisiones y la cantidad de transacciones por tipo de servicio
            double[] sumaComisionesPorServicio = new double[3];
            int[] cantidadTransaccionesPorServicio = new int[3];

            // Inicializar arreglos a cero
            for (int i = 0; i < 3; i++)
            {
                sumaComisionesPorServicio[i] = 0.0;
                cantidadTransaccionesPorServicio[i] = 0;
            }

            // Calcular la suma de comisiones y la cantidad de transacciones por tipo de servicio
            for (int i = 0; i < posicion; i++)
            {
                // Asumiendo que los tipos de servicio están numerados como 1, 2, 3
                int tipoServicioIndex = tipo_servicio[i] - 1; // Restar 1 para ajustar el índice del arreglo

                sumaComisionesPorServicio[tipoServicioIndex] += montoComision[i];
                cantidadTransaccionesPorServicio[tipoServicioIndex]++;
            }

            // Mostrar el resumen de dinero comisionado por cada tipo de servicio
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Tipo de Servicio: {i + 1}");
                Console.WriteLine($"Cantidad de Transacciones: {cantidadTransaccionesPorServicio[i]}");
                Console.WriteLine($"Dinero Comisionado: {sumaComisionesPorServicio[i]}");
                Console.WriteLine("-------------------------------------------");
            }

            // Calcular y mostrar el total del dinero comisionado por todos los servicios
            double totalComisionado = 0.0;
            for (int i = 0; i < 3; i++)
            {
                totalComisionado += sumaComisionesPorServicio[i];
            }
            Console.WriteLine($"Total del Dinero Comisionado: {totalComisionado}");
        }
    }
}