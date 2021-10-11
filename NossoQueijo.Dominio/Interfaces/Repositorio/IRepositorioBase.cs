using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioBase<T> where T : class
    {
        void Adicionar(T entidade, bool saveChanges = true);
        void Atualizar(T entidade, bool saveChanges = true);
        public bool Remover(T entidade, bool saveChanges = true);
        public void SaveChanges();
    }
}
