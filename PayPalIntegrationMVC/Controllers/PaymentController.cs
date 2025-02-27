using Microsoft.AspNetCore.Mvc;
using PayPalIntegrationMVC.Services;
using System.Threading.Tasks;

namespace PayPalIntegrationMVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly PayPalService _payPalService;

        public PaymentController(PayPalService payPalService)
        {
            _payPalService = payPalService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(decimal amount, string currency)
        {
            var orderId = await _payPalService.CreateOrderAsync(amount, currency);
            return Json(new { orderId });
        }

        [HttpPost]
        public async Task<IActionResult> CapturePayment(string orderId)
        {
            var success = await _payPalService.CapturePaymentAsync(orderId);
            return Json(new { success });
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Cancel()
        {
            return View();
        }
    }
}