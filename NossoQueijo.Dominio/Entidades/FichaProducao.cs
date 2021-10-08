using System;

namespace NossoQueijo.Dominio.Entidades
{
    public class FichaProducao
    {
        public int idFichaProducao { get; set; }
        public DateTime Data { get; set; }
        public Usuario Usuario { get; set; }
        public decimal VolumePingo { get; set; }
        public decimal VolumeLeite { get; set; }
        public decimal VolumeCoalho { get; set; }
        public decimal QntdSal { get; set; }
        public int QntdProduzida { get; set; }
        public EstoquePorData EstoquePorData { get; set; }
    }
}