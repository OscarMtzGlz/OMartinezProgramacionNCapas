using System;

namespace PL // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            string seguir;
            do
            {
                Console.WriteLine("Seleccione una opcion \t 1- Registrar \t 2- Modificar \t 3- Eliminar \n\t 4- Mostrar Todos los datos \t 5- Mostrar un solo dato");
                string respuesta = Console.ReadLine();

                if (respuesta == "1")
                {
                    //PL.Usuario.Add();
                    PL.Usuario.AddSP();
                }
                else if (respuesta == "2")
                {
                    //PL.Usuario.Update();
                    PL.Usuario.UpdateSP();
                }
                else if (respuesta == "3")
                {
                    //PL.Usuario.Delete();
                    PL.Usuario.DeleteSP();
                }
                else if (respuesta == "4")
                {
                    //PL.Usuario.GetAll();
                    PL.Usuario.GetAllSP();
                }
                else if (respuesta == "5")
                {
                    //PL.Usuario.GetById();
                    PL.Usuario.GetByIdSP();
                }

                Console.WriteLine("Hacer otra consulta, 1-si 2-no");
                seguir = Console.ReadLine();
                Console.Clear();
            } while (seguir == "1");

            Console.Clear();
        }
    }
}