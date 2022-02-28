using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeDbRequests.Models
{
    public interface ICardHolderRepository
    {
        IEnumerable<cardholderUsers> GetAll();
        cardholderUsers Get(int id);
        cardholderUsers Add(cardholderUsers item);
        void Remove(int id);
        bool Update(cardholderUsers item);
    }
}
