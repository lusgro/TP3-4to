int[] ARRAY_PRECIOS = {15000, 30000, 10000, 40000};

int opcion;

do
{
   Console.ResetColor();
   Console.WriteLine("\nPulsa cualquier tecla para continuar");
   Console.ReadKey();
   Console.Clear();
   Console.WriteLine("1. Nueva Inscripcion");
   Console.WriteLine("2. Obtener estadisticas del Evento");
   Console.WriteLine("3. Buscar Cliente");
   Console.WriteLine("4. Cambiar entrada de un Cliente");
   Console.WriteLine("5. Salir");
   opcion = Funciones.IngresarEnteroEnRango("Elija opción: ", 1, 5);

   switch (opcion)
   {
      case 1:
         int dni = Funciones.IngresarEntero("Ingresar DNI: ");
         bool dniYaExiste = Tiquetera.VerificarDniExiste(dni);
         if (dniYaExiste)
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("El DNI ingresado ya existe");
         }
         else
         {
            Cliente cliente = CrearCliente(dni);
            Tiquetera.AgregarCliente(cliente);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cliente agregado con éxito");
         }
         break;
      case 2:
         List<string> estadisticas = Tiquetera.EstadisticasTiquetera(ARRAY_PRECIOS);
         if (estadisticas != null)
         {
            foreach (string estadistica in estadisticas)
            {
               Console.WriteLine(estadistica);
            }
         }
         else
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No hay clientes inscriptos");
         }
         break;
      case 3:
         int id = Funciones.IngresarEntero("Ingresar ID de entrada: ");
         Cliente clienteEncontrado = Tiquetera.BuscarCliente(id);
         if (clienteEncontrado != null)
         {
            ResumirCliente(clienteEncontrado);
         }
         else
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No se encontró el cliente");
         }
         break;
      case 4:
         id = Funciones.IngresarEntero("Ingresar ID de entrada: ");
         clienteEncontrado = Tiquetera.BuscarCliente(id);
         if (clienteEncontrado != null)
         {
            int tipoEntrada = Funciones.IngresarEnteroEnRango("Ingresar tipo de entrada (1-2-3-4): ", 1, 4);
            int totalAbonado = ARRAY_PRECIOS[tipoEntrada - 1];
            bool pudoCambiar = Tiquetera.CambiarEntrada(id, tipoEntrada, totalAbonado);
            if (pudoCambiar)
            {
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine("Entrada cambiada con éxito");
            }
            else
            {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine("No se pudo cambiar la entrada");
            }
         }
         else
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No se encontró el cliente");
         }
         break;
   }
} while (opcion != 5);

Cliente CrearCliente(int dni)
   {
         string apellido = Funciones.IngresarTexto("Ingresar apellido: ");
         string nombre = Funciones.IngresarTexto("Ingresar nombre: ");
         DateTime fechaInscripcion = DateTime.Now;
         int tipoEntrada = Funciones.IngresarEnteroEnRango("Ingresar tipo de entrada (1-2-3-4): ", 1, 4);
         int totalAbonado = ARRAY_PRECIOS[tipoEntrada - 1];
         return new Cliente(dni, apellido, nombre, fechaInscripcion, tipoEntrada, totalAbonado);
   }

void ResumirCliente(Cliente obj)
   {
      Console.WriteLine($"DNI: {obj.dni}");
      Console.WriteLine($"Apellido: {obj.apellido}");
      Console.WriteLine($"Nombre: {obj.nombre}");
      Console.WriteLine($"Fecha de inscripcion: {obj.fechaInscripcion}");
      Console.WriteLine($"Tipo de entrada: {obj.tipoEntrada}");
      Console.WriteLine($"Total abonado: ${obj.totalAbonado}");
   }

