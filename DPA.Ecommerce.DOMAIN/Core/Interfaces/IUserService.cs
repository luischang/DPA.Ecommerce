using DPA.Ecommerce.DOMAIN.Core.DTOs;
using System.Threading.Tasks;

namespace DPA.Ecommerce.DOMAIN.Core.Interfaces
{
    public interface IUserService
    {
        Task<int> SignupAsync(UserSignupDTO dto);
        Task<UserAuthResponseDTO> SigninAsync(UserSigninDTO dto);
    }
}
