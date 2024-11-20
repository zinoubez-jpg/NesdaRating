using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Anade.Khadamat.Domain
{
    public partial class MatierePremiereApprovisionnement : IEntity<int>
    {
        public MatierePremiereApprovisionnement()
        {
            this.DetailsAchatsDirects = new HashSet<DetailAchatsDirects>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Designation { get; set; }

        public virtual ICollection<DetailAchatsDirects> DetailsAchatsDirects { get; set; }

        public string GetCode(string code, int index)
        {
            string newCodeMatierePremiereApprovisionnement;

            if (index < 10)
            {
                newCodeMatierePremiereApprovisionnement = code + "_00" + index.ToString();
            }
            else if (index < 100 && index >= 10)
            {
                newCodeMatierePremiereApprovisionnement = code + "_0" + index.ToString();
            }
            else if (index < 1000 && index >= 100)
            {
                newCodeMatierePremiereApprovisionnement = code + "_" + index.ToString();
            }
            else
            {
                newCodeMatierePremiereApprovisionnement = code + "_000";
            }

            return newCodeMatierePremiereApprovisionnement;
        }
    }
}