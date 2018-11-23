using FlightFinder.BL.Models;

namespace FlightFinder.Web.Controls.OrderDialog
{
    public class OrderDialogModel
    {
        public Order Order { get; set; } = new Order();
        public bool DialogIsOpen { get; set; }

        public bool ResultDialogIsOpen { get; set; }
        public string ResultMessage { get; set; }

        public void Next()
        {
            ResultDialogIsOpen = true;
            ResultMessage = "Thank you!";
        }
    }
}