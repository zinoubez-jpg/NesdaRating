using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Anade.Khadamat.Domain
{
    public partial class Poste : IEntity<int>
    {
        public Poste()
        {
            this.DetailsPoste = new HashSet<DetailPoste>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Designation { get; set; }
        public decimal SalaireBase { get; set; }
        public decimal IndemnitesPrimesCotisables { get; set; }
        public decimal IndemnitesPrimesImposables { get; set; }
        public decimal SLR_Indemnites_PrimesNonImplCotl { get; set; }
        public decimal NetPayer { get; set; }
        public decimal RetenueIRG { get; set; }
        public virtual ICollection<DetailPoste> DetailsPoste { get; set; }

        public string GetCode(string code, int index)
        {
            string newCodePoste;

            if (index < 10)
            {
                newCodePoste = code + "_00" + index.ToString();
            }
            else if (index < 100 && index >= 10)
            {
                newCodePoste = code + "_0" + index.ToString();
            }
            else if (index < 1000 && index >= 100)
            {
                newCodePoste = code + "_" + index.ToString();
            }
            else
            {
                newCodePoste = code + "_000";
            }

            return newCodePoste;
        }
    }
}