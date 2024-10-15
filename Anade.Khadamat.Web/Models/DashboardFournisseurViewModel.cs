using Anade.Khadamat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anade.Khadamat.Web.Models
{
    public class DashboardFournisseurViewModel
    {
        public Fournisseur Fournisseur { get; set; }
        public int NbProformat { get; set; }
        public int NbDefinitive { get; set; }
        
    }
}
