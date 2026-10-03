using Shop.Api.Infrastructure.GatEways.Zibal.DTOs;

namespace Shop.Api.Infrastructure.GatEways.Zibal
{
    public interface IZibalService
    {
        Task<string> StartPay(ZibalPaymentRequest request);
        Task<ZibalVeriyfyResponse> Verify(ZibalVeriyfyRequest request);
    }
}
