using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;


namespace BL
{
    public class Usuario
    {
        private readonly DL_New.UsuarioPruebaContext _context ;

        public Usuario(DL_New.UsuarioPruebaContext context)
        {
            _context = context;
        }


        public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                var query = _context.GetAll
                    .FromSqlRaw("GetAll")
                    .ToList();
                if (query != null)
                {
                    result.Objects = new List<object>();
                    foreach (var item in query)
                    {
                        ML.Usuario usuario = new ML.Usuario
                        {
                            IdUsuario = item.IdUsuario,
                            UserName = item.UserName,
                            Nombre = item.Nombre,
                            Email = item.Email,
                            Password = item.Password,
                            FechaNacimiento = item.FechaNacimiento,
                            Estatus = item.Estatus,
                            Role = new ML.Role
                            {
                                IdRol = item.IdRol,
                                Nombre = item.NombreRol
                            }
                            
                        };
                        result.Objects.Add(usuario);
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No hay Registros";
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

        public ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                var usuarioRegistro = _context.GetById
                    .FromSqlInterpolated($"GetById {IdUsuario}")
                    .AsEnumerable()
                    .FirstOrDefault();

                if (usuarioRegistro != null)
                {
                    ML.Usuario usuario = new ML.Usuario
                    {
                        IdUsuario = usuarioRegistro.IdUsuario,
                        UserName = usuarioRegistro.UserName,
                        Nombre = usuarioRegistro.Nombre,
                    
                        Email = usuarioRegistro.Email,
                        Password = usuarioRegistro.Password,
                        FechaNacimiento = usuarioRegistro.FechaNacimiento,
                      
                        Estatus = usuarioRegistro.Estatus,
                        Role = new ML.Role { 
                        IdRol= usuarioRegistro.IdRol,
                        Nombre = usuarioRegistro.NombreRol,
                        }
                      
                              
                        
                    };

                    result.Object = usuario;
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No existe el usuario";
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


        public ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                int filasAfectadas = _context.Database.ExecuteSqlRaw(
                    "UsuarioAdd " +
                    "@UserName, @Nombre,  @Email, @Password, " +
                    "@FechaNacimiento, @Estatus , @IdRol",

                    new SqlParameter("@UserName", usuario.UserName),
                    new SqlParameter("@Nombre", usuario.Nombre),
                    new SqlParameter("@Email", usuario.Email),
                    new SqlParameter("@Password", usuario.Password),

                    new SqlParameter("@FechaNacimiento",
                        usuario.FechaNacimiento ?? (object)DBNull.Value),

          
                    new SqlParameter("@Estatus", usuario.Estatus),

                   new SqlParameter("@IdRol", usuario.Role?.IdRol ?? (object)DBNull.Value)



                  );

                result.Correct = filasAfectadas > 0;
                if (!result.Correct)
                    result.ErrorMessage = "No se agregó el usuario.";
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }



        public ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                int filasAfectadas = _context.Database.ExecuteSqlRaw(
                    "EXEC UsuarioUpdate @IdUsuario, @UserName, @Nombre, @Email, @Password, " +
                    "@FechaNacimiento, @Estatus , @IdRol",
                    new SqlParameter("@IdUsuario", usuario.IdUsuario),
                    new SqlParameter("@UserName", usuario.UserName),
                    new SqlParameter("@Nombre", usuario.Nombre ?? (object)DBNull.Value),
               
                    new SqlParameter("@Email", usuario.Email),
                    new SqlParameter("@Password", usuario.Password),
                    new SqlParameter("@FechaNacimiento", usuario.FechaNacimiento ?? (object)DBNull.Value),
                 
                    new SqlParameter("@Estatus", usuario.Estatus),

                      new SqlParameter("@IdRol", usuario.Role?.IdRol ?? (object)DBNull.Value)

                );

                result.Correct = filasAfectadas > 0;
                if (!result.Correct)
                    result.ErrorMessage = "No se actualizó el usuario.";
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }



        public ML.Result Delete(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                int filasAfectadas = _context.Database.ExecuteSqlRaw(
                    "EXEC UsuarioDelete @IdUsuario",
                    new SqlParameter("@IdUsuario", idUsuario)
                );

                result.Correct = filasAfectadas > 0;
                if (!result.Correct)
                    result.ErrorMessage = "No se encontró el usuario a eliminar.";
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
