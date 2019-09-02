using Microsoft.EntityFrameworkCore;
using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Repositories
{
    public class EstudioRepositorio
    {
        public List<Estudios> Listar()
        {
            using(InlockContext ctx = new InlockContext())
            {
                return ctx.Estudios.ToList();
            }
        }
        public void Cadastrar(Estudios estudio)
        {
            using(InlockContext ctx = new InlockContext())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Estudios estudio)
        {
            using (InlockContext ctx = new InlockContext())
            {
                var estudioBuscado = ctx.Estudios.FirstOrDefault(x=> x.EstudioId == estudio.EstudioId);
                estudioBuscado.NomeEstudio = estudio.NomeEstudio;
                estudioBuscado.Origem = estudio.Origem;
                estudioBuscado.UsuarioId = estudio.UsuarioId;
                estudioBuscado.DataCriacao = estudio.DataCriacao;


                ctx.Estudios.Update(estudioBuscado);
                ctx.SaveChanges();
            }
        }


        public void Excluir(int id)
        {
            using (InlockContext ctx = new InlockContext())
            {
                var estudio = ctx.Estudios.Find(id);
                ctx.Estudios.Remove(estudio);
                ctx.SaveChanges();
            }
        }

        //public List<Estudios> ListarEstudiosEJogos()
        //{
        //    using (InlockContext ctx = new InlockContext())
        //    {
        //        return ctx.Estudios.FromSql("SELECT E.*,J.* FROM Estudios E INNER JOIN Jogos J ON E.EstudioId = J.EstudioId").ToList();
        //        //return ctx.Jogos.Include(x => x.Estudio).ToList();
        //    }
        //}
    }
}
