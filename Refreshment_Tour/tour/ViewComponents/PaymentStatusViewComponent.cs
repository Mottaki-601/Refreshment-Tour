using Microsoft.AspNetCore.Mvc;
using System.Linq;
using tour.Models; 

namespace tour.ViewComponents
{
    public class PaymentStatusViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<Member> members)
        {
            var paidCount = members.Count(x => x.PaymentDone);
            var totalCount = members.Count();

            return View(new { Paid = paidCount, Total = totalCount });
        }
    }
}