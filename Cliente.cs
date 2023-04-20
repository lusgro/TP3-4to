public class Cliente
{
   public int dni{get; private set;}
   public string apellido{get; private set;}
   public string nombre{get; private set;}
   public DateTime fechaInscripcion{get; set;}
   public int tipoEntrada{get; set;}
   public int totalAbonado{get; set;}

   public Cliente(int dni, string apellido, string nombre, DateTime fechaInscripcion, int tipoEntrada, int totalAbonado)
   {
      this.dni = dni;
      this.apellido = apellido;
      this.nombre = nombre;
      this.fechaInscripcion = fechaInscripcion;
      this.tipoEntrada = tipoEntrada;
      this.totalAbonado = totalAbonado;
   }
}