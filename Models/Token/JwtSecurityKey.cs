using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Admin_Backend.Models.DbModels;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Admin_Backend.Models.Token
{
    public class JwtSecurityKey
    {
       public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}