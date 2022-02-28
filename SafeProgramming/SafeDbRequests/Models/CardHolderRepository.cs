using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeDbRequests.Models
{
    public class CardHolderRepository : ICardHolderRepository
    {

        private List<cardholderUsers> cardholderUsers = new List<cardholderUsers>();
        private int _nextId = 1;

        public cardholderUsers Add(cardholderUsers item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.id = _nextId++;
            cardholderUsers.Add(item);
            return item;
        }

        public cardholderUsers Get(int id)
        {
            return cardholderUsers.Find(p => p.id == id);
        }

        public IEnumerable<cardholderUsers> GetAll()
        {
            return cardholderUsers;
        }

        public void Remove(int id)
        {
            cardholderUsers.RemoveAll(p => p.id == id);
        }

        public bool Update(cardholderUsers item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = cardholderUsers.FindIndex(p => p.id == item.id);
            if (index == -1)
            {
                return false;
            }
            cardholderUsers.RemoveAt(index);
            cardholderUsers.Add(item);
            return true;
        }
    }
}