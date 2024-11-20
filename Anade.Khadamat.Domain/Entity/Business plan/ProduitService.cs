using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Anade.Khadamat.Domain
{
    public partial class ProduitService : IEntity<int>
    {
        public ProduitService()
        {
            this.DetailsChiffreAffaire = new HashSet<DetailChiffreAffaire>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Designation { get; set; }

        public virtual ICollection<DetailChiffreAffaire> DetailsChiffreAffaire { get; set; }

        public string GetCode(string code, int index)
        {
            string newCodeProduitService;

            if (index < 10)
            {
                newCodeProduitService = code + "_00" + index.ToString();
            }
            else if (index < 100 && index >= 10)
            {
                newCodeProduitService = code + "_0" + index.ToString();
            }
            else if (index < 1000 && index >= 100)
            {
                newCodeProduitService = code + "_" + index.ToString();
            }
            else
            {
                newCodeProduitService = code + "_000";
            }

            return newCodeProduitService;
        }
    }
}