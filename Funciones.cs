public static class Funciones
{
   public static int IngresarEntero(string msj)
   {
      int entero=-1;
      while (entero == -1)
      {   
         Console.Write(msj);
         int.TryParse(Console.ReadLine(), out entero);
      }
      return entero;
   }

   public static int IngresarEnteroEnRango(string msj, int minimo, int maximo)
   {
      int entero;
      entero = IngresarEntero(msj);
      while (entero < minimo || entero > maximo)
      {
         Console.ForegroundColor = ConsoleColor.Red;
         entero = IngresarEntero("ERROR! " + msj);
      }
      return entero;
   }

   public static string IngresarTexto(string msj)
   {
      string texto = "";
      while (texto == "")
      {
         Console.Write(msj);
         texto = Console.ReadLine();
      }
      return texto;
   }

   public static DateTime IngresarFecha(string msj)
   {
      DateTime fechaDate;
      string fechaCadena = IngresarTexto(msj);
      while (!DateTime.TryParse(fechaCadena, out fechaDate))
      {
         Console.ForegroundColor = ConsoleColor.Red;
         fechaCadena = IngresarTexto("ERROR! " + msj);
      }
      return fechaDate;
   }
}