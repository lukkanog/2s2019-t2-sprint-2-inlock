using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Repositories
{
    public class JogoRepository
    {
        public List<Jogos> Listar()
        {
            using (InlockContext ctx = new InlockContext())
            {
                return ctx.Jogos.ToList();
            }
        }

        public void Cadastrar(Jogos jogo)
        {
            using (InlockContext ctx = new InlockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }
        public void Atualizar (Jogos jogo)
        {
            using (InlockContext ctx = new InlockContext())
            {
                var jogoBuscado = ctx.Jogos.FirstOrDefault(x => x.JogoId == jogo.JogoId);
                jogoBuscado.NomeJogo = jogo.NomeJogo;
                jogoBuscado.Valor = jogo.Valor;
                jogoBuscado.DataLancamento = jogo.DataLancamento;
                jogoBuscado.Descricao = jogo.Descricao;

                ctx.Jogos.Update(jogoBuscado);
                ctx.SaveChanges();
            }
        }
        public void Deletar (int id)
        {
            using (InlockContext ctx = new InlockContext())
            {
                var jogo = ctx.Jogos.Find(id);
                ctx.Jogos.Remove(jogo);
                ctx.SaveChanges();
            }
        }


    }
}
