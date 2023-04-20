public static class Tiquetera {
   private static Dictionary<int, Cliente> dicClientes{get; set;} = new Dictionary<int, Cliente>();
   private static int ultimoIdEntrada = 0;

   public static int DevolverUltimoId()
   {
      return ultimoIdEntrada;
   }

   public static int AgregarCliente(Cliente nuevoCliente)
   {
      ultimoIdEntrada++;
      dicClientes.Add(ultimoIdEntrada, nuevoCliente);
      return ultimoIdEntrada;
   }

   public static bool VerificarDniExiste(int dni)
   {
      foreach (Cliente obj in dicClientes.Values)
      {
      if (obj.dni == dni)
         {
            return true;
         }
      }
      return false;
   }

   public static Cliente BuscarCliente(int idEntrada)
   {
      bool existeCliente = dicClientes.ContainsKey(idEntrada);
      if (existeCliente) return dicClientes[idEntrada];
      else return null;
   }

   public static bool CambiarEntrada(int id, int tipo, int total)
   {
      if (tipo != dicClientes[id].tipoEntrada && total > dicClientes[id].totalAbonado)
      {
         dicClientes[id].tipoEntrada = tipo;
         dicClientes[id].totalAbonado = total;
         dicClientes[id].fechaInscripcion = DateTime.Now;
         return true;
      }
      else return false;
   }

   public static List<string> EstadisticasTiquetera(int[] arrayPrecios)
   {
      int cantidadClientes = dicClientes.Count();
      if (cantidadClientes == 0) return null;
      else
      {
         string msjCantClientes = $"Hay {cantidadClientes} clientes inscriptos.";

         int[] cantidadEntradas = {0, 0, 0, 0};
         foreach (Cliente cliente in dicClientes.Values)
         {
            cantidadEntradas[cliente.tipoEntrada - 1]++;
         }
         double[] porcentajeEntradas = {0, 0, 0, 0};
         int[] recaudacionEntradas = {0, 0, 0, 0};
         for (int i = 0; i < 4; i++)
         {
            double porcentaje = ((double)cantidadEntradas[i] / (double)cantidadClientes) * 100;
            porcentajeEntradas[i] = Math.Round(porcentaje, 2);
            recaudacionEntradas[i] = arrayPrecios[i] * cantidadEntradas[i];
         }
         string msjPorcentajeEntradas = $"Porcentaje de entradas vendidas diferenciadas por tipo respecto al total\nOpcion 1: {porcentajeEntradas[0]}%\nOpcion 2: {porcentajeEntradas[1]}%\nOpcion 3: {porcentajeEntradas[2]}%\nOpcion 4: {porcentajeEntradas[3]}%";
         string msjRecaudacionEntradas = $"Recaudación de cada tipo de entrada\nOpcion 1: ${recaudacionEntradas[0]}\nOpcion 2: ${recaudacionEntradas[1]}\nOpcion 3: ${recaudacionEntradas[2]}\nOpcion 4: ${recaudacionEntradas[3]}\n";
         
         int totalRecaudado = 0;
         foreach (int recaudacion in recaudacionEntradas)
         {
            totalRecaudado += recaudacion;
         }
         string msjRecaudacionTotal = $"La recaudacion total es de ${totalRecaudado}";

         return new List<string>() {msjCantClientes, msjPorcentajeEntradas, msjRecaudacionEntradas, msjRecaudacionTotal};
      }
      
   }
}