using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public List<Usuarios> Listar()
        {
            using (InlockContext ctx = new InlockContext())
            {
                return ctx.Usuarios.ToList();
            }
        }

        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (InlockContext ctx = new InlockContext())
            {
                var usuario = ctx.Usuarios.FirstOrDefault(x=> x.Email == login.Email &&  x.Senha == login.Senha);
                if (usuario == null)
                    return null;

                return usuario;
            }
        }



    }
}
