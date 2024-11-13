using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class TypeMateriel : Referentiel
    {
        public string CodeDesignationFr { get => GetCodeDesignationFr(); }
        public TypeMateriel()
        {
            this.DetailsInvestissement = new HashSet<DetailInvestissement>();
        }

        public virtual ICollection<DetailInvestissement> DetailsInvestissement { get; set; }

        public string GetCodeDesignationFr()
        {
            return "("+Code +") "+ DesignationFr;
        }
    }
}
