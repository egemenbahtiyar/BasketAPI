using System.Threading;
using System.Threading.Tasks;
using Basket.Application.Requests;
using Basket.Definition.Request;

namespace Basket.Application.Services
{
    public interface IProductService
    {
        Task CreateProduct(CreateProductApplicationRequest request, CancellationToken cancellationToken);
    }
}