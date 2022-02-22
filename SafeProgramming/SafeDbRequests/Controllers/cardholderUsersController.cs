using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using SafeDbRequests.Models;
using System.Security.Policy;

namespace SafeDbRequests.Controllers
{
    public class cardholderUsersController : Controller
    {
        static readonly ICardHolderRepository repository = new CardHolderRepository();

        public IEnumerable<cardholderUsers> GetAllCardholderUsers()
        {
            return repository.GetAll();
        }

        public cardholderUsers GetCardholderusersById(int id)
        {
            cardholderUsers item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<cardholderUsers> GetCardholderUsersByName(string name)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.cardholderName, name, StringComparison.OrdinalIgnoreCase));
        }
        public cardholderUsers PostCardholderUsers(cardholderUsers item)
        {
            item = repository.Add(item);
            return item;
        }

        public void PutCardholderUsers(int id, cardholderUsers cardholderUsers)
        {
            cardholderUsers.id = id;
            if (!repository.Update(cardholderUsers))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteCardholderUsers(int id)
        {
            cardholderUsers item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }


        // GET: cardholderUsers
        public ActionResult Index()
        {
            return View();
        }
    }
}