using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class CommuneBP : Referentiel
    {
        public bool ZonePromouvoir { get; set; }

        public int WilayaBPId { get; set; }
        public int TypeZoneId { get; set; }

        public virtual WilayaBP WilayaBP { get; set; }
        public virtual TypeZone TypeZone { get; set; }
    }
}
