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

        //public ML.Result GetAllpruebs()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        var query = _context.UsuarioGetAll
        //            .FromSqlRaw("UsuarioGetAllDinamico '' ,'','',''")
        //            .ToList();
        //        if (query != null)
        //        {
        //            result.Objects = new List<object>();
        //            foreach (var item in query)
        //            {
        //                ML.Usuario usuario = new ML.Usuario
        //                {
        //                    IdUsuario = item.IdUsuario,
        //                    UserName = item.UserName,
        //                    Nombre = item.UsuarioNombre,
        //                    ApellidoPaterno = item.ApellidoPaterno,
        //                    ApellidoMaterno = item.ApellidoMaterno,
        //                    Email = item.Email,
        //                    Password = item.Password,
        //                    FechaNacimiento = item.FechaNacimiento,
        //                    Sexo = item.Sexo,
        //                    Telefono = item.Telefono,
        //                    Celular = item.Celular,
        //                    Estatus = item.Estatus,
        //                    CURP = item.Curp,
        //                    Imagen = item.Imagen,
        //                    Role = new ML.Role
        //                    {
        //                        Id = item.IdRol,
        //                        Name = item.RolNombre
        //                    },
        //                    Direccion = new ML.Direccion
        //                    {
        //                        Calle = item.Calle,
        //                        NumeroInterior = item.NumeroInterior,
        //                        NumeroExterior = item.NumeroExterior,
        //                        Colonia = new ML.Colonia
        //                        {
        //                            IdColonia = item.IdColonia ?? 0,
        //                            Nombre = item.ColoniaNombre,
        //                            Municipio = new ML.Municipio
        //                            {
        //                                IdMunicipio = item.IdMunicipio ?? 0,
        //                                Nombre = item.NombreMunicipio,
        //                                Estado = new ML.Estado
        //                                {
        //                                    IdEstado = item.IdEstado ?? 0,
        //                                    Nombre = item.EstadoNombre
        //                                }
        //                            }
        //                        }
        //                    }
        //                };
        //                result.Objects.Add(usuario);
        //            }
        //            result.Correct = true;
        //        }
        //        else
        //        {
        //            result.Correct = false;
        //            result.ErrorMessage = "No hay Registros";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public ML.Result GetByIdprueb(int IdUsuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        var usuarioRegistro = _context.UsuarioGetById
        //            .FromSqlInterpolated($"UsuarioGetById {IdUsuario}")
        //            .AsEnumerable()
        //            .FirstOrDefault();

        //        if (usuarioRegistro != null)
        //        {
        //            ML.Usuario usuario = new ML.Usuario
        //            {
        //                IdUsuario = usuarioRegistro.IdUsuario,
        //                UserName = usuarioRegistro.UserName,
        //                Nombre = usuarioRegistro.UsuarioNombre,
        //                ApellidoPaterno = usuarioRegistro.ApellidoPaterno,
        //                ApellidoMaterno = usuarioRegistro.ApellidoMaterno,
        //                Email = usuarioRegistro.Email,
        //                Password = usuarioRegistro.Password,
        //                FechaNacimiento = usuarioRegistro.FechaNacimiento,
        //                Sexo = usuarioRegistro.Sexo,
        //                Telefono = usuarioRegistro.Telefono,
        //                Celular = usuarioRegistro.Celular,
        //                Estatus = usuarioRegistro.Estatus,
        //                CURP = usuarioRegistro.Curp,
        //                Imagen = usuarioRegistro.Imagen,
        //                Role = new ML.Role
        //                {
        //                    Id = usuarioRegistro.IdRol,
        //                    Name = usuarioRegistro.RolNombre
        //                },
        //                Direccion = new ML.Direccion
        //                {
        //                    Calle = usuarioRegistro.Calle,
        //                    NumeroInterior = usuarioRegistro.NumeroInterior,
        //                    NumeroExterior = usuarioRegistro.NumeroExterior,
        //                    Colonia = new ML.Colonia
        //                    {
        //                        IdColonia = usuarioRegistro.IdColonia ?? 0,
        //                        Nombre = usuarioRegistro.ColoniaNombre,
        //                        CodigoPostal = usuarioRegistro.CodigoPostal,
        //                        Municipio = new ML.Municipio
        //                        {
        //                            IdMunicipio = usuarioRegistro.IdMunicipio ?? 0,
        //                            Nombre = usuarioRegistro.NombreMunicipio,
        //                            Estado = new ML.Estado
        //                            {
        //                                IdEstado = usuarioRegistro.IdEstado ?? 0,
        //                                Nombre = usuarioRegistro.EstadoNombre
        //                            }
        //                        }
        //                    }
        //                }
        //            };

        //            result.Object = usuario;
        //            result.Correct = true;
        //        }
        //        else
        //        {
        //            result.Correct = false;
        //            result.ErrorMessage = "No existe el usuario";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;


        //}


        //public ML.Result Addprueb(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        int filasAfectadas = _context.Database.ExecuteSqlRaw(
        //            "UsuarioAdd " +
        //            "@UserName, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Email, @Password, " +
        //            "@FechaNacimiento, @Sexo, @Telefono, @Celular, @Estatus, @CURP, @Imagen, @IdRol, " +
        //            "@Calle, @NumeroInterior, @NumeroExterior, @IdColonia",

        //            new SqlParameter("@UserName", usuario.UserName),
        //            new SqlParameter("@Nombre", usuario.Nombre),
        //            new SqlParameter("@ApellidoPaterno", usuario.ApellidoPaterno),
        //            new SqlParameter("@ApellidoMaterno", usuario.ApellidoMaterno ?? (object)DBNull.Value),
        //            new SqlParameter("@Email", usuario.Email),
        //            new SqlParameter("@Password", usuario.Password),

        //            new SqlParameter("@FechaNacimiento",
        //                usuario.FechaNacimiento ?? (object)DBNull.Value),

        //            new SqlParameter("@Sexo", usuario.Sexo),
        //            new SqlParameter("@Telefono", usuario.Telefono),
        //            new SqlParameter("@Celular", usuario.Celular ?? (object)DBNull.Value),
        //            new SqlParameter("@Estatus", usuario.Estatus),
        //            new SqlParameter("@CURP", usuario.CURP ?? (object)DBNull.Value),

        //            new SqlParameter("@IdRol",
        //                usuario.Role?.Id ?? (object)DBNull.Value),

        //            new SqlParameter("@Imagen", SqlDbType.VarBinary)
        //            {
        //                Value = usuario.Imagen ?? (object)DBNull.Value
        //            },

        //            new SqlParameter("@Calle", usuario.Direccion?.Calle ?? (object)DBNull.Value),
        //            new SqlParameter("@NumeroInterior", usuario.Direccion?.NumeroInterior ?? (object)DBNull.Value),
        //            new SqlParameter("@NumeroExterior", usuario.Direccion?.NumeroExterior ?? (object)DBNull.Value),
        //            new SqlParameter("@IdColonia",
        //                usuario.Direccion?.Colonia?.IdColonia ?? (object)DBNull.Value)
        //        );

        //        result.Correct = filasAfectadas > 0;
        //        if (!result.Correct)
        //            result.ErrorMessage = "No se agregó el usuario.";
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}



        //public ML.Result Updateprueb(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        int filasAfectadas = _context.Database.ExecuteSqlRaw(
        //            "EXEC UsuarioUpdate @IdUsuario, @UserName, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Email, @Password, " +
        //            "@FechaNacimiento, @Sexo, @Telefono, @Celular, @Estatus, @CURP, @Imagen, @Id, " +
        //            "@Calle, @NumeroInterior, @NumeroExterior, @IdColonia",
        //            new SqlParameter("@IdUsuario", usuario.IdUsuario),
        //            new SqlParameter("@UserName", usuario.UserName),
        //            new SqlParameter("@Nombre", usuario.Nombre ?? (object)DBNull.Value),
        //            new SqlParameter("@ApellidoPaterno", usuario.ApellidoPaterno ?? (object)DBNull.Value),
        //            new SqlParameter("@ApellidoMaterno", usuario.ApellidoMaterno ?? (object)DBNull.Value),
        //            new SqlParameter("@Email", usuario.Email),
        //            new SqlParameter("@Password", usuario.Password),
        //            new SqlParameter("@FechaNacimiento", usuario.FechaNacimiento ?? (object)DBNull.Value),
        //            new SqlParameter("@Sexo", usuario.Sexo ?? (object)DBNull.Value),
        //            new SqlParameter("@Telefono", usuario.Telefono ?? (object)DBNull.Value),
        //            new SqlParameter("@Celular", usuario.Celular ?? (object)DBNull.Value),
        //            new SqlParameter("@Estatus", usuario.Estatus),
        //            new SqlParameter("@CURP", usuario.CURP ?? (object)DBNull.Value),
        //           new SqlParameter("@Imagen", SqlDbType.VarBinary)
        //           {
        //               Value = usuario.Imagen ?? (object)DBNull.Value
        //           },
        //            new SqlParameter("@Id", usuario.Role?.Id ?? (object)DBNull.Value),
        //            new SqlParameter("@Calle", usuario.Direccion?.Calle ?? (object)DBNull.Value),
        //            new SqlParameter("@NumeroInterior", usuario.Direccion?.NumeroInterior ?? (object)DBNull.Value),
        //            new SqlParameter("@NumeroExterior", usuario.Direccion?.NumeroExterior ?? (object)DBNull.Value),
        //            new SqlParameter("@IdColonia", usuario.Direccion?.Colonia?.IdColonia ?? (object)DBNull.Value)
        //        );

        //        result.Correct = filasAfectadas > 0;
        //        if (!result.Correct)
        //            result.ErrorMessage = "No se actualizó el usuario.";
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}



        //public ML.Result Deleteprueb(int idUsuario)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        int filasAfectadas = _context.Database.ExecuteSqlRaw(
        //            "EXEC UsuarioDelete @IdUsuario",
        //            new SqlParameter("@IdUsuario", idUsuario)
        //        );

        //        result.Correct = filasAfectadas > 0;
        //        if (!result.Correct)
        //            result.ErrorMessage = "No se encontró el usuario a eliminar.";
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}



        public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                var query = _context.Usuarios
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
                var usuarioRegistro = _context.Usuarios
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
                    "@FechaNacimiento, @Estatus",

                    new SqlParameter("@UserName", usuario.UserName),
                    new SqlParameter("@Nombre", usuario.Nombre),
                    new SqlParameter("@Email", usuario.Email),
                    new SqlParameter("@Password", usuario.Password),

                    new SqlParameter("@FechaNacimiento",
                        usuario.FechaNacimiento ?? (object)DBNull.Value),

          
                    new SqlParameter("@Estatus", usuario.Estatus)
                   


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
                    "@FechaNacimiento, @Estatus ",
                    new SqlParameter("@IdUsuario", usuario.IdUsuario),
                    new SqlParameter("@UserName", usuario.UserName),
                    new SqlParameter("@Nombre", usuario.Nombre ?? (object)DBNull.Value),
               
                    new SqlParameter("@Email", usuario.Email),
                    new SqlParameter("@Password", usuario.Password),
                    new SqlParameter("@FechaNacimiento", usuario.FechaNacimiento ?? (object)DBNull.Value),
                 
                    new SqlParameter("@Estatus", usuario.Estatus)
                    
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
