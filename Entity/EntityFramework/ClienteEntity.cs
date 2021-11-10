namespace EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class ClienteEntity
    {
        [Key()]
        public int codigo_cliente { get; set; }

        [Required]
        [StringLength(50)]
        public string nome_cliente { get; set; }
        
        [Required]
        [StringLength(50)]
        public string endereco { get; set; }

        [Required]
        [StringLength(30)]
        public string bairro { get; set; }

        [Required]
        [StringLength(30)]
        public string cidade { get; set; }

        [Required]
        [StringLength(2)]
        public string estado { get; set; }

    }
}
