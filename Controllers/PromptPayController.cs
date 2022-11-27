using Microsoft.AspNetCore.Mvc;
using Saladpuk.PromptPay.Contracts.Models;
using Saladpuk.PromptPay.Facades;
using Saladpuk.PromptPay.Models;
using System.Text.Json;

namespace Saladpuk.PromptPay.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PromptPayController : ControllerBase
    {
        [HttpGet("{qrcode}")]
        public string Get(string qrcode)
        {
            var model = PPay.Reader.ReadQrPromptPay(qrcode);
            return JsonSerializer.Serialize(model as PromptPayQrInfo);
        }

        [HttpPost("bill")]
        public CreateQrResponse CreateBillPayment([FromBody] CreateBillPaymentRequest req)
        {
            var areArgumentValid = null != req?.BillPayment;
            if (!areArgumentValid)
            {
                return new CreateQrResponse { ErrorMessage = "Invalid request" };
            }

            var builder = req.IsQrReusable ? PPay.StaticQR : PPay.DynamicQR;
            return new CreateQrResponse
            {
                QrCode = builder.CreateBillPaymentQrCode(req.BillPayment),
            };
        }

        [HttpPost("transfer")]
        public CreateQrResponse CreateCreditTransfer([FromBody] CreateCreditTransferRequest req)
        {
            var areArgumentValid = null != req?.CreditTransfer;
            if (!areArgumentValid)
            {
                return new CreateQrResponse { ErrorMessage = "Invalid request" };
            }

            var builder = req.IsQrReusable ? PPay.StaticQR : PPay.DynamicQR;
            return new CreateQrResponse
            {
                QrCode = builder.CreateCreditTransferQrCode(req.CreditTransfer),
            };
        }

        public class CreateBillPaymentRequest
        {
            public bool IsQrReusable { get; set; }
            public BillPayment BillPayment { get; set; }
        }

        public class CreateCreditTransferRequest
        {
            public bool IsQrReusable { get; set; }
            public CreditTransfer CreditTransfer { get; set; }
        }

        public class CreateQrResponse
        {
            public string QrCode { get; set; }
            public string ErrorMessage { get; set; }
        }
    }
}
