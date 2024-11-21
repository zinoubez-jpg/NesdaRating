using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class RubriqueChargesExternes : Referentiel
    {
        public string CodeDesignationFr { get => GetCodeDesignationFr(); }
        public RubriqueChargesExternes()
        {
            this.DetailsChargesExternes = new HashSet<DetailChargesExternes>();
        }

        public virtual ICollection<DetailChargesExternes> DetailsChargesExternes { get; set; }

        public string GetCodeDesignationFr()
        {
            return "(" + Code + ") " + DesignationFr;
        }
    }
}
