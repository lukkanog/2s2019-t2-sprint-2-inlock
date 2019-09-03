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
        /// <summary>
        /// Função para realizar a listagem de cada estudio.
        /// </summary>
        /// <returns></returns>
        public List<Estudios> Listar()
        {
            using (InlockContext ctx = new InlockContext())
            {
                return ctx.Estudios.ToList();
            }
        }
        /// <summary>
        /// Função para realizar o cadastro de cada estudio, pegando como parâmetro o estudio em si.
        /// </summary>
        /// <param name="estudio"></param>
        public void Cadastrar(Estudios estudio)
        {
            using (InlockContext ctx = new InlockContext())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Função para realizar a atualização do estudio requisitado a partir do ID do mesmo. Todos os parâmetros devem ser passados para realização da função.
        /// </summary>
        /// <param name="estudio"></param>
        public void Atualizar(Estudios estudio)
        {
            using (InlockContext ctx = new InlockContext())
            {
                var estudioBuscado = ctx.Estudios.FirstOrDefault(x => x.EstudioId == estudio.EstudioId);
                estudioBuscado.NomeEstudio = estudio.NomeEstudio;
                estudioBuscado.Origem = estudio.Origem;
                estudioBuscado.UsuarioId = estudio.UsuarioId;
                estudioBuscado.DataCriacao = estudio.DataCriacao;


                ctx.Estudios.Update(estudioBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Função para a exclusão de um estudio a partir da captura do ID do mesmo.
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(int id)
        {
            using (InlockContext ctx = new InlockContext())
            {
                var estudio = ctx.Estudios.Find(id);
                ctx.Estudios.Remove(estudio);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Função para listagem de todos os estudios e seus respectivos jogos.
        /// </summary>
        /// <returns></returns>
        public List<Estudios> ListarEstudiosEJogos()
        {
            using (InlockContext ctx = new InlockContext())
            {
                //return ctx.Estudios.FromSql("SELECT E.EstudioId,E.NomeEstudio,E.Origem,E.DataCriacao,E.UsuarioId,J.JogoId,J.NomeJogo,J.Descricao,J.DataLancamento,J.Valor FROM Estudios E LEFT JOIN Jogos J ON E.EstudioId = J.EstudioId").ToList();
                return ctx.Estudios.Include(x => x.Jogos).ToList();
            }
        }
        /// <summary>
        /// Função para listagem do estudio e seus respectivos jogos, recebendo para parâmetro o nome do mesmo.
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns></returns>
        public List<Estudios> ListarEstudiosPorNome(string Nome)
        {
            using (InlockContext ctx = new InlockContext())
            {
                return ctx.Estudios.Where(x => x.NomeEstudio == Nome).Include(x => x.Jogos).ToList();
            }
        }

        /// <summary>
        /// Função para listagem dos estudios a partir do país requisitado como parâmetro.
        /// </summary>
        /// <param name="idPais"></param>
        /// <returns></returns>
        public List<Estudios> ListarPorPais(int idPais)
        {
            using (InlockContext ctx = new InlockContext())
            {
                return ctx.Estudios.Where(x => x.Origem == idPais).ToList();
            }
        }

        /// <summary>
        /// Função para listagem de estudios e seus respectivos jogos a partir do país requisitado como parâmetro
        /// </summary>
        /// <param name="idPais"></param>
        /// <returns></returns>
        public List<Estudios> ListarTudoPorPais(int idPais)
        {
            using (InlockContext ctx = new InlockContext())
            {
                return ctx.Estudios.Where(x => x.Origem == idPais).Include(x => x.Jogos).ToList();
            }
        }

        /// <summary>
        /// Função para listagem de todos os registros realizados pelo administrador do qual está acessando.
        /// </summary>
        /// <param name="idAdm"></param>
        /// <returns></returns>
        public List<Estudios> ListarPorAdministrador(int idAdm)
        {
            using (InlockContext ctx = new InlockContext())
            {
                return ctx.Estudios.Where(x => x.UsuarioId == idAdm).ToList();
            }
        }


        public List<Estudios> ListarEstudiosEAdms()
        {
            using (InlockContext ctx = new InlockContext())
            {
                return ctx.Estudios.Include(x => x.Usuario).ToList();
            }
        }

        public List<Estudios> ListarEstudiosNovos()
        {
            List<Estudios> listaNova = new List<Estudios>();
            
            foreach (var item in Listar())
            {
                TimeSpan diasRestantes = item.DataCriacao - DateTime.Now;
                int intDiasRestantes = Convert.ToInt32(diasRestantes.TotalDays);

                if (intDiasRestantes > -10 && intDiasRestantes <=0)
                {
                    listaNova.Add(item);
                }
            }
            return listaNova;
        }
    }
}
