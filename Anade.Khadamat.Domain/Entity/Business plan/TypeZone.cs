using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class TypeZone : Referentiel
    {
        public TypeZone()
        {
            this.CommunesBP = new HashSet<CommuneBP>();
        }

        public virtual ICollection<CommuneBP> CommunesBP { get; set; }
    }
}
