namespace claseTarea
{
    public class Tarea
    {
        // private  int  TareaId;
        // private string? descripcion;
        // private int duracion;
        public int TareaID { get; set; }
        public string? Descripcion { get; set; }
        public int Duracion
        {
            get;
            set;
        }

        public Tarea(int id, string descri, int duracion)
        {
            TareaID = id;
            Descripcion = descri;
            Duracion = duracion;
        }
    }

}