using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
namespace NossoQueijo.Repositorio.RepositoriosEF
{
    public class  PedidoRepositorio : RepositorioBase<Pedido> , IPedidoRepositorio
    {
    }
}
