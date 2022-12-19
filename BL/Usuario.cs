using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Usuario
    {
        static public ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandText = "INSERT INTO [Usuario]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[Email],[UserName],[Password],[FechaNacimiento],[Sexo],[Telefono],[Celular],[CURP],[Imagen])"
                        + "VALUES (@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Email,@UserName,@Password,@FechaNacimiento,@Sexo,@Telefono,@Celular,@CURP,@Imagen)";

                    SqlParameter[] collection = new SqlParameter[4];
                    collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;
                    collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;
                    collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;
                    collection[3] = new SqlParameter("Email", SqlDbType.VarChar);
                    collection[3].Value = usuario.Email;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al insertar usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        static public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "SELECT [IdUsuario],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Email],[UserName],[Password],[FechaNacimiento],[Sexo],"
                        + "[Telefono],[Celular],[CURP],[Imagen] FROM [Usuario]";

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable usuarioTable = new DataTable();

                    da.Fill(usuarioTable);

                    if (usuarioTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in usuarioTable.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.Email = row[4].ToString();

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No contiene registros la tabla Usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        static public ML.Result GetById(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "SELECT [IdUsuario],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Email],[UserName],[Password],[FechaNacimiento],"
                        + "[Sexo],[Telefono],[Celular],[CURP],[Imagen] FROM [Usuario] WHERE [IdUsuario] = @IdUsuario";

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[0].Value = idUsuario;
                    cmd.Parameters.AddRange(collection);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable usuarioTable = new DataTable();

                    da.Fill(usuarioTable);

                    if (usuarioTable.Rows.Count > 0)
                    {
                        DataRow row = usuarioTable.Rows[0];

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = int.Parse(row[0].ToString());
                        usuario.Nombre = row[1].ToString();
                        usuario.ApellidoPaterno = row[2].ToString();
                        usuario.ApellidoMaterno = row[3].ToString();
                        usuario.Email = row[4].ToString();

                        result.Object = usuario;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No contiene al usuario solicitado";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        static public ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandText = "UPDATE [Usuario] SET [Nombre] = @Nombre,[ApellidoPaterno] = @ApellidoPaterno,[ApellidoMaterno] = @ApellidoMaterno,[Email] = @Email, "
                        + "[UserName] = @UserName,[Password] = @Password,[FechaNacimiento] = @FechaNacimiento,[Sexo] = @Sexo,[Telefono] = @Telefono,[Celular] = @Celular,"
                        + "[CURP] = @CURP,[Imagen] = @Imagen WHERE [IdUsuario] = @IdUsuario";

                    SqlParameter[] collection = new SqlParameter[5];
                    collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;
                    collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;
                    collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;
                    collection[3] = new SqlParameter("Correo", SqlDbType.VarChar);
                    collection[3].Value = usuario.Email;
                    collection[4] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[4].Value = usuario.IdUsuario;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al modificar el usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        static public ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandText = "DELETE FROM [Usuario] WHERE [IdUsuario] = @IdUsuario";

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[0].Value = usuario.IdUsuario;
                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar el usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        //Metodos SP

        static public ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandText = "UsuarioAdd";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[11];
                    collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;
                    collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;
                    collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;
                    collection[3] = new SqlParameter("Email", SqlDbType.VarChar);
                    collection[3].Value = usuario.Email;
                    collection[4] = new SqlParameter("UserName", SqlDbType.VarChar);
                    collection[4].Value = usuario.UserName;
                    collection[5] = new SqlParameter("Password", SqlDbType.VarChar);
                    collection[5].Value = usuario.Password;
                    collection[6] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
                    collection[6].Value = usuario.FechaNacimiento;
                    collection[7] = new SqlParameter("Sexo", SqlDbType.Char);
                    collection[7].Value = usuario.Sexo;
                    collection[8] = new SqlParameter("Telefono", SqlDbType.VarChar);
                    collection[8].Value = usuario.Telefono;
                    collection[9] = new SqlParameter("Celular", SqlDbType.VarChar);
                    collection[9].Value = usuario.Celular;
                    collection[10] = new SqlParameter("CURP", SqlDbType.VarChar);
                    collection[10].Value = usuario.CURP;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al insertar usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        static public ML.Result GetAllSP()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "UsuarioGetAll";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable usuarioTable = new DataTable();

                    da.Fill(usuarioTable);

                    if (usuarioTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in usuarioTable.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.Email = row[4].ToString();
                            usuario.UserName = row[5].ToString();
                            usuario.Password = row[6].ToString();
                            usuario.FechaNacimiento = DateTime.Parse(row[7].ToString());
                            usuario.Sexo = row[8].ToString();
                            usuario.Telefono = row[9].ToString();
                            usuario.Celular = row[10].ToString();
                            usuario.CURP = row[11].ToString();

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No contiene registros la tabla Usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        static public ML.Result GetByIdSP(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "UsuarioGetById";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[0].Value = idUsuario;
                    cmd.Parameters.AddRange(collection);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable usuarioTable = new DataTable();

                    da.Fill(usuarioTable);

                    if (usuarioTable.Rows.Count > 0)
                    {
                        DataRow row = usuarioTable.Rows[0];

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = int.Parse(row[0].ToString());
                        usuario.Nombre = row[1].ToString();
                        usuario.ApellidoPaterno = row[2].ToString();
                        usuario.ApellidoMaterno = row[3].ToString();
                        usuario.Email = row[4].ToString();
                        usuario.UserName = row[5].ToString();
                        usuario.Password = row[6].ToString();
                        usuario.FechaNacimiento = DateTime.Parse(row[7].ToString());
                        usuario.Sexo = row[8].ToString();
                        usuario.Telefono = row[9].ToString();
                        usuario.Celular = row[10].ToString();
                        usuario.CURP = row[11].ToString();

                        result.Object = usuario;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No contiene al usuario solicitado";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        static public ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandText = "UsuarioUpdate";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[12];
                    collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;
                    collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;
                    collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;
                    collection[3] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[3].Value = usuario.IdUsuario;
                    collection[4] = new SqlParameter("Password", SqlDbType.VarChar);
                    collection[4].Value = usuario.Password;
                    collection[5] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
                    collection[5].Value = usuario.FechaNacimiento;
                    collection[6] = new SqlParameter("Sexo", SqlDbType.Char);
                    collection[6].Value = usuario.Sexo;
                    collection[7] = new SqlParameter("Telefono", SqlDbType.VarChar);
                    collection[7].Value = usuario.Telefono;
                    collection[8] = new SqlParameter("Celular", SqlDbType.VarChar);
                    collection[8].Value = usuario.Celular;
                    collection[9] = new SqlParameter("CURP", SqlDbType.VarChar);
                    collection[9].Value = usuario.CURP;
                    collection[10] = new SqlParameter("Email", SqlDbType.VarChar);
                    collection[10].Value = usuario.Email;
                    collection[11] = new SqlParameter("UserName", SqlDbType.VarChar);
                    collection[11].Value = usuario.UserName;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al modificar el usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        static public ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandText = "UsuarioDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[0].Value = usuario.IdUsuario;
                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar el usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

    }
}