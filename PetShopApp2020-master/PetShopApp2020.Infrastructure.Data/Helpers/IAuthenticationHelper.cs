using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp2020.Infrastructure.Data.Helpers
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(User user);
    }
}
