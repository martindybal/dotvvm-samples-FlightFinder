using FlightFinder.BL.Models;

namespace FlightFinder.Web.Controls.OrderDialog
{
    public class OrderDialogModel
    {
        public Order Order { get; set; } = new Order();
        public bool DialogIsOpen { get; set; }
    }
}