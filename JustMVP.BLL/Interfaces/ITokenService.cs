using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JustMVP.BLL.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwt(int userId, string userName);
    }
}
