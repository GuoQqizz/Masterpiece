using Masterpiece.Repository.DBContext;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace AbhsCrmToC.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected MasterpieceDBContext db = MasterpieceDBContext.CreateDbContext();
    }
}