using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Anade.Khadamat.Domain
{
    public partial class TauxStructureFinancement : IEntity<int>
    {
        public TauxStructureFinancement()
        {
            this.StructuresFinancement = new HashSet<StructureFinancement>();
        }

        public int Id { get; set; }

        public string Code { get; set; }
        public int ApportPersonnel { get; set; }
        public int CMT { get; set; }
        public int PNRClassique { get; set; }

        [NotMapped]
        public string DesignationFr { get => DesignationFrTest(); }

        public virtual ICollection<StructureFinancement> StructuresFinancement { get; set; }

        public string DesignationFrTest()
        {
            if (Code == "01")
            {
                return "A100C000P000";
            }
            else
            {
                if (Code == "02")
                {
                    return "A050C000P050";
                }
                else
                {
                    if (Code == "03")
                    {
                        return "A005C070P025";
                    }
                    else
                    {
                        if (Code == "04")
                        {
                            return "A010C070P020";
                        }
                        else
                        {
                            if (Code == "05")
                            {
                                return "A012C070P018";
                            }
                            else
                            {
                                if (Code == "06")
                                {
                                    return "A015C070P015";
                                }
                                else
                                {
                                    return "A000C000P000";
                                }
                            }
                        }
                    }
                }

            }

        }

    }
}