using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class ExonerationFiscale : Referentiel
    {
        public ExonerationFiscale()
        {
            this.StructuresFinancement = new HashSet<StructureFinancement>();
        }

        public virtual ICollection<StructureFinancement> StructuresFinancement { get; set; }
    }
}
