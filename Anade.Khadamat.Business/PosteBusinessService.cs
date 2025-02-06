using Anade.Business.Core;
using Anade.Data.Abstractions;
using Anade.Khadamat.Domain;
using System;
using System.Linq.Expressions;

namespace Anade.Khadamat.Business
{
    public class PosteBusinessService : GenericBusinessService<Poste, int>
    {
        public PosteBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public override Expression<Func<Poste, object>>[] GetDefaultLoadProperties()
        {
            Expression<Func<Poste, object>> loadDetailPoste = x => x.DetailsPoste;

            return new Expression<Func<Poste, object>>[] { loadDetailPoste };
        }

        public string GenererNumero(string codeStructure, int numSequ)
        {
            var numeroSequentiel = numSequ + 1;

            // Generate the sequential number string with leading zeros
            return $"{codeStructure}{numeroSequentiel:D5}";
        }

    }
}
