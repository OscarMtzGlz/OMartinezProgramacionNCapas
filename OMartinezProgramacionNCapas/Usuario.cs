using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        static public void Add()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Inserte los datos del Usuario");
            Console.WriteLine("UserName: ");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("ApellidoPaterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("ApellidoMaterno: ");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Email: ");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Password: ");
            usuario.Password = Console.ReadLine();
            //Console.WriteLine("FechaNacimiento: ");
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            usuario.FechaNacimiento = dt;
            Console.WriteLine("Sexo: ");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Telefono: ");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Celular: ");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("CURP: ");
            usuario.CURP = Console.ReadLine();


            //ML.Result result = BL.Usuario.Add(usuario);
            ML.Result result = BL.Usuario.AddSP(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Usuario insertado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al insertar " + result.ErrorMessage);
            }
            Console.ReadLine();
        }

        static public void GetAll()
        {
            ML.Result result = BL.Usuario.GetAll();

            Console.WriteLine("GetAll");
            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("El IdUsuario del usuario es: " + usuario.IdUsuario);
                    Console.WriteLine("El Nombre del usuario es: " + usuario.Nombre);
                    Console.WriteLine("El ApellidoPaterno del usuario es: " + usuario.ApellidoPaterno);
                    Console.WriteLine("El ApellidoMaterno del usuario es: " + usuario.ApellidoMaterno);
                    Console.WriteLine("El Email del usuario es: " + usuario.Email);
                    Console.WriteLine("----------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Ocurrio un error");
            }
        }

        static public void GetById()
        {
            Console.WriteLine("Ingresa el id");
            int idUsuario = int.Parse(Console.ReadLine());
            ML.Result result = BL.Usuario.GetById(idUsuario);

            Console.WriteLine("GetById");
            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;
                Console.WriteLine("El IdUsuario del usuario es: " + usuario.IdUsuario);
                Console.WriteLine("El Nombre del usuario es: " + usuario.Nombre);
                Console.WriteLine("El ApellidoPaterno del usuario es: " + usuario.ApellidoPaterno);
                Console.WriteLine("El ApellidoMaterno del usuario es: " + usuario.ApellidoMaterno);
                Console.WriteLine("El Email del usuario es: " + usuario.Email);
                Console.WriteLine("----------------------------------------------");

            }
            else
            {
                Console.WriteLine("Ocurrio un error");
            }
        }

        static public void Update()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Que Usuario deseas modificar, ingresa el Id");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo Nombre del Usuario");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo ApellidoPaterno del Usuario");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo ApellidoMaterno del Usuario");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo Email del Usuario");
            usuario.Email = Console.ReadLine();

            ML.Result result = BL.Usuario.Update(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Usuario modificado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al modificar " + result.ErrorMessage);
            }
            Console.ReadLine();
        }

        static public void Delete()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Que Usuario deseas eliminar, ingresa el Id");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            Console.WriteLine("Seguro que lo deseas eliminar? 1-Si 2-No");
            int respuesta = int.Parse(Console.ReadLine());

            if (respuesta == 1)
            {
                ML.Result result = BL.Usuario.Delete(usuario);

                if (result.Correct)
                {
                    Console.WriteLine("Usuario eliminado correctamente");
                }
                else
                {
                    Console.WriteLine("Ocurrio un error al eliminar " + result.ErrorMessage);
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Usuario no eliminado");
            }
        }

        //SP

        static public void AddSP()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Inserte los datos del Usuario");
            Console.WriteLine("UserName: ");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("ApellidoPaterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("ApellidoMaterno: ");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Email: ");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Password: ");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("FechaNacimiento: ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());
            //DateTime dt = new DateTime();
            //dt = DateTime.Now;
            //usuario.FechaNacimiento = dt;
            Console.WriteLine("Sexo: ");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Telefono: ");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Celular: ");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("CURP: ");
            usuario.CURP = Console.ReadLine();


            //ML.Result result = BL.Usuario.Add(usuario);
            ML.Result result = BL.Usuario.AddSP(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Usuario insertado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al insertar " + result.ErrorMessage);
            }
            Console.ReadLine();
        }

        static public void GetAllSP()
        {
            ML.Result result = BL.Usuario.GetAllSP();

            Console.WriteLine("GetAllSP");
            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("El IdUsuario del usuario es: " + usuario.IdUsuario);
                    Console.WriteLine("El Nombre del usuario es: " + usuario.Nombre);
                    Console.WriteLine("El ApellidoPaterno del usuario es: " + usuario.ApellidoPaterno);
                    Console.WriteLine("El ApellidoMaterno del usuario es: " + usuario.ApellidoMaterno);
                    Console.WriteLine("El Email del usuario es: " + usuario.Email);
                    Console.WriteLine("El UserName del usuario es: " + usuario.UserName);
                    Console.WriteLine("El Password del usuario es: " + usuario.Password);
                    Console.WriteLine("El Sexo del usuario es: " + usuario.Sexo);
                    Console.WriteLine("El FechaNacimiento del usuario es: " + usuario.FechaNacimiento);
                    Console.WriteLine("El Telefono del usuario es: " + usuario.Telefono);
                    Console.WriteLine("El Celular del usuario es: " + usuario.Celular);
                    Console.WriteLine("El CURP del usuario es: " + usuario.CURP);
                    Console.WriteLine("----------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Ocurrio un error");
            }
        }

        static public void GetByIdSP()
        {
            Console.WriteLine("Ingresa el id");
            int idUsuario = int.Parse(Console.ReadLine());
            ML.Result result = BL.Usuario.GetByIdSP(idUsuario);

            Console.WriteLine("GetByIdSP");
            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;
                Console.WriteLine("El IdUsuario del usuario es: " + usuario.IdUsuario);
                Console.WriteLine("El Nombre del usuario es: " + usuario.Nombre);
                Console.WriteLine("El ApellidoPaterno del usuario es: " + usuario.ApellidoPaterno);
                Console.WriteLine("El ApellidoMaterno del usuario es: " + usuario.ApellidoMaterno);
                Console.WriteLine("El Email del usuario es: " + usuario.Email);
                Console.WriteLine("El UserName del usuario es: " + usuario.UserName);
                Console.WriteLine("El Password del usuario es: " + usuario.Password);
                Console.WriteLine("El Sexo del usuario es: " + usuario.Sexo);
                Console.WriteLine("El FechaNacimiento del usuario es: " + usuario.FechaNacimiento);
                Console.WriteLine("El Telefono del usuario es: " + usuario.Telefono);
                Console.WriteLine("El Celular del usuario es: " + usuario.Celular);
                Console.WriteLine("El CURP del usuario es: " + usuario.CURP);
                Console.WriteLine("----------------------------------------------");

            }
            else
            {
                Console.WriteLine("Ocurrio un error");
            }
        }

        static public void UpdateSP()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Que Usuario deseas modificar, ingresa el Id");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo Nombre del Usuario");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo ApellidoPaterno del Usuario");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo ApellidoMaterno del Usuario");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo Email del Usuario");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo UserName del Usuario");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo Password del Usuario");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("FechaNacimiento: ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());
            //Console.WriteLine("FechaNacimiento: ");
            //DateTime dt = new DateTime();
            //dt = DateTime.Now;
            //usuario.FechaNacimiento = dt;
            Console.WriteLine("Ingrese el nuevo Sexo del Usuario");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo Telefono del Usuario");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo Celular del Usuario");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo CURP del Usuario");
            usuario.CURP = Console.ReadLine();

            ML.Result result = BL.Usuario.UpdateSP(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Usuario modificado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al modificar " + result.ErrorMessage);
            }
            Console.ReadLine();
        }

        static public void DeleteSP()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Que Usuario deseas eliminar, ingresa el Id");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            Console.WriteLine("Seguro que lo deseas eliminar? 1-Si 2-No");
            int respuesta = int.Parse(Console.ReadLine());

            if (respuesta == 1)
            {
                ML.Result result = BL.Usuario.DeleteSP(usuario);

                if (result.Correct)
                {
                    Console.WriteLine("Usuario eliminado correctamente");
                }
                else
                {
                    Console.WriteLine("Ocurrio un error al eliminar " + result.ErrorMessage);
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Usuario no eliminado");
            }
        }
    }
}
