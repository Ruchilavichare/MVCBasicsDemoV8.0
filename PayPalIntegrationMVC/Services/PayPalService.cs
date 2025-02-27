using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalCheckoutSdk.Payments;
using System.Threading.Tasks;

namespace PayPalIntegrationMVC.Services
{
    public class PayPalService
    {
        private readonly PayPalHttpClient _client;

        public PayPalService(IConfiguration configuration)
        {
            var environment = new SandboxEnvironment(
                configuration["PayPal:ClientId"],
                configuration["PayPal:ClientSecret"]
            );
            _client = new PayPalHttpClient(environment);
        }

        public async Task<string> CreateOrderAsync(decimal amount, string currency)
        {
            var order = new OrderRequest
            {
                CheckoutPaymentIntent = "CAPTURE",
                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                    new PurchaseUnitRequest
                    {
                        AmountWithBreakdown = new AmountWithBreakdown
                        {
                            CurrencyCode = currency,
                            Value = amount.ToString("F2")
                        }
                    }
                },
                ApplicationContext = new ApplicationContext
                {
                    ReturnUrl = "https://localhost:7125/Payment/Success",
                    CancelUrl = "https://localhost:7125/Payment/Cancel"
                }
            };

            var request = new OrdersCreateRequest();
            request.Prefer("return=representation");
            request.RequestBody(order);

            var response = await _client.Execute(request);
            return response.Result<Order>().Id;
        }

        public async Task<bool> CapturePaymentAsync(string orderId)
        {
            var request = new OrdersCaptureRequest(orderId);
            request.RequestBody(new OrderActionRequest());

            var response = await _client.Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}