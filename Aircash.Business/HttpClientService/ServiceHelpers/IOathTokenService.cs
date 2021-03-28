using Aircash.DataContract.Token;
using System.Threading.Tasks;

namespace Aircash.Business.HttpClientService.ServiceHelpers
{
    public interface IOathTokenService
    {
        Task<Token> GetTokenAsync();
    }
}