using claseTarea;
namespace programa
{
    public class Program
    {
        static void Main()
        {
            string[] descrips = { "Largo", "corta", "Muy corta", "Ez", "muy ez", "brito" };
            List<Tarea>[] l = CrearTareas(descrips);
            List<Tarea> listaPendientes = l[0];
            List<Tarea> listaTerminadas = l[1];
            int opcion;
            do
            {
                Console.WriteLine("Seleccione una opcion");
                Console.WriteLine("1-Marcar como terminadas");
                Console.WriteLine("2-Buscar por Descripcion");
                Console.WriteLine("3-Mostrar Tareas pendientes y Tareas realizadas");
                Console.WriteLine("4-Salir");
                string input=Console.ReadLine()??"" ;
                opcion = int.TryParse(input, out opcion) ? opcion : 0;

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Mover tareas pendientes a realizadas");
                        /*int cantidadTareas = listaPendientes.Count();
                        for (int i = 0; i < cantidadTareas; i++)
                        {
                            Tarea tarea = listaPendientes[i];
                            listaPendientes.RemoveAt(i);
                            listaTerminadas.Add(tarea);
                        }*/
                        TareasTerminadas(listaPendientes, listaTerminadas);
                        break;
                    case 2:
                        Console.WriteLine("Ingrese la descripcion de la tarea a buscar");
                        string Buscar_descripcion = Console.ReadLine() ?? "";
                        BuscarPorDescripcion(listaPendientes, Buscar_descripcion);
                        break;
                    case 3:
                        mostrarTodas(listaPendientes, listaTerminadas);

                        break;
                    case 4:
                        Console.WriteLine("Salir");
                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        break;
                }


            } while (opcion != 4);

        }
        static List<Tarea>[] CrearTareas(string[] descrips)
        {
            Random RND = new Random();
            int N = RND.Next(1, 6);
            Console.WriteLine("n: " + N);
            List<Tarea> tareasPendientes = new List<Tarea>();
            List<Tarea> tareasTerminadas = new List<Tarea>();
            for (int i = N - 1; i >= 0; i--)
            {
                tareasPendientes.Add(new Tarea(i + 1000, descrips[RND.Next(0, 5)], RND.Next(10, 100)));
            }
            List<Tarea>[] Lista = new List<Tarea>[2];
            Lista[0] = tareasPendientes;
            Lista[1] = tareasTerminadas;

            return Lista;

        }
        static void TareasTerminadas(List<Tarea> Pendientes,List<Tarea> Terminadas)
        {
            while (Pendientes.Count > 0)
            {
                Console.WriteLine("Ingrese el id de la tarea que quiere marcar como realizada");
                Console.WriteLine("Si no hay tareas para marcar aprete 0");
                string input = Console.ReadLine() ?? "";
                int id = int.TryParse(input, out id) ? id : 0;
          
                if (id == 0)
                {
                    break;
                }
                Tarea? tarea = null;

                foreach (Tarea T in Pendientes)
                {
                    if (T.TareaID == id)
                    {
                        tarea = T;
                        break;
                    }
                }
                if (tarea != null)
                {
                    Pendientes.Remove(tarea);
                    Terminadas.Add(tarea);
                    Console.WriteLine("Tarea cambiada con exito");
                }
                else
                {
                    Console.WriteLine("EL id no existe en tareas pendientes");
                }

            }
        }
        static void BuscarPorDescripcion(List<Tarea> Pendientes, string Buscar_descripcion)
        {
            foreach (Tarea tarea in Pendientes)
            {
                if (tarea.Descripcion != null &&tarea.Descripcion.StartsWith(Buscar_descripcion,StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Id: {tarea.TareaID}");
                    Console.WriteLine($"Descripción: {tarea.Descripcion}");
                    Console.WriteLine($"Duración: {tarea.Duracion}");

                }
            }
        }
        static void mostrarTodas(List<Tarea> Pendientes, List<Tarea> Terminadas)
        {
            Console.WriteLine("Tareas pendientes");
            foreach (Tarea tarea in Pendientes)
            {
                Console.WriteLine($"Id: {tarea.TareaID}");
                Console.WriteLine($"Descripción: {tarea.Descripcion}");
                Console.WriteLine($"Duración: {tarea.Duracion}");

            }
            Console.WriteLine("Tareas Terminadas");
            foreach (Tarea T in Terminadas)
            {
                Console.WriteLine($"Id: {T.TareaID}");
                Console.WriteLine($"Descripción: {T.Descripcion}");
                Console.WriteLine($"Duración: {T.Duracion}");
            }
        }

    }
}