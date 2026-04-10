using System;
using System.Linq;
using BCrypt.Net;

namespace BL
{
    public class Login
    {
        private readonly DL_New.UsuarioPruebaContext _context;

        public Login(DL_New.UsuarioPruebaContext context)
        {
            _context = context;
        }

        public ML.Result Session(string Email, string Password)
        {
            ML.Result result = new ML.Result();

            try
            {
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                {
                    result.Correct = false;
                    result.ErrorMessage = "Email y contraseña son requeridos";
                    return result;
                }

                var usuarioDB = _context.Usuarios
                    .FirstOrDefault(u => u.Email == Email);

                if (usuarioDB != null && usuarioDB.Password == Password)
                {
                    result.Correct = true;
                    result.Object = new ML.Usuario
                    {
                        IdUsuario = usuarioDB.IdUsuario,
                        Email = usuarioDB.Email
                    };
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Credenciales incorrectas";
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}