using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.ViewModels;
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

        public List<Jogos> ListarCincoMaisCaros()
        {
            using (InlockContext ctx = new InlockContext())
            {
                return ctx.Jogos.OrderByDescending(x=> x.Valor).Take(5).ToList();
            }
        }

        public List<Jogos> ListarMaisRecentes()
        {
            using (InlockContext ctx = new InlockContext())
            {
                return ctx.Jogos.OrderByDescending(x => x.DataLancamento).ToList();
            }
        }

        public List<DataViewModel> DataLancamento()
        {
            List<Jogos> lista = Listar();
            List<DataViewModel> listaViewModel = new List<DataViewModel>();
            foreach (var item in lista)
            {
                var jogoVm = new DataViewModel();
                jogoVm.NomeJogo = item.NomeJogo;
                jogoVm.DataLancamento = item.DataLancamento;
                TimeSpan diasRestantes = item.DataLancamento - DateTime.Now;
                var intDiasRestantes = Convert.ToInt32(diasRestantes.TotalDays);
                if (intDiasRestantes < 0)
                {
                    jogoVm.DiasFaltantes = 0;
                }
                else
                {
                    jogoVm.DiasFaltantes = intDiasRestantes;
                }

                listaViewModel.Add(jogoVm);
            }
            return listaViewModel;
        }

        public Jogos BuscarJogoPorNome(string nomeJogo)
        {
            using (InlockContext ctx = new InlockContext())
            {
                return ctx.Jogos.FirstOrDefault(x => x.NomeJogo == nomeJogo);
            }
        }

        


    }
}
