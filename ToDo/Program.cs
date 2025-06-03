using claseTarea;
namespace programa
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] descrips = { "Largo", "corta", "Muy corta", "Ez", "muy ez", "brito" };
            List<Tarea>[] l = crearTareas(descrips);
            List<Tarea> listaPendientes = l[0];
            List<Tarea> listaTerminadas = l[1];

        }
        static List<Tarea>[] crearTareas(string[] descrips)
        {
            Random RND = new Random();
            int N = RND.Next(1, 6);
            Console.WriteLine("n: " + N);
            List<Tarea> listaPendientes = new List<Tarea>();
            List<Tarea> listaTerminadas = new List<Tarea>();
            for (int i = N - 1; i >= 0; i--)
            {
                listaPendientes.Add(new Tarea(i + 1000, descrips[RND.Next(0, 5)], RND.Next(10, 100)));
            }
            Console.WriteLine("Elementos listaPendientes: " + listaPendientes.Count());
            foreach (Tarea elemento in listaPendientes)
            {
                Console.WriteLine(elemento.Descripcion);
                Console.WriteLine(elemento.TareaID);
                Console.WriteLine(elemento.Duracion);
            }
            List<Tarea>[] pepe = new List<Tarea>[2];
            pepe.Append(listaPendientes);
            pepe.Append(listaTerminadas);
            return pepe;

        }


    }
}