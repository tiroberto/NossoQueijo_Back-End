using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace AnBertoCars.Aplicacao
{
    public class TipoUsuarioAplicacao : ITipoUsuarioAplicacao
    {
        private readonly ITipoUsuarioRepositorio _tipoUsuarioRepositorio;

        public TipoUsuarioAplicacao(ITipoUsuarioRepositorio tipoUsuarioRepositorio)
        {
            _tipoUsuarioRepositorio = tipoUsuarioRepositorio;
        }

        public NotificationResult Salvar(TipoUsuario entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if (entidade.idTipoUsuario == 0)
                    {
                        _tipoUsuarioRepositorio.Adicionar(entidade);
                        notificationResult.Add("Tipo de usuário cadastrado com sucesso.");
                    }
                    else
                    {
                        _tipoUsuarioRepositorio.Atualizar(entidade);
                        notificationResult.Add("Tipo de usuário atualizado com sucesso.");
                    }

                }

                notificationResult.Result = entidade;

                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public IEnumerable<TipoUsuario> ListarTodos()
        {
            return _tipoUsuarioRepositorio.ListarTodos();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            if (id > 0)
                return _tipoUsuarioRepositorio.BuscarPorId(id);
            return null;
        }

        public NotificationResult RemoverPersonalizado(int id)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    _tipoUsuarioRepositorio.RemoverPersonalizado(id);
                    notificationResult.Add("Removido com sucesso");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }
    }
}
