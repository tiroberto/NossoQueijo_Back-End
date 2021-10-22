using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Entidades
{
    public class EstoquePorData
    {
        public int idFichaProducao { get; set; }
        public FichaProducao FichaProducao { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
