using Library.Services.AuthenticateModels;
using Library.Services.DbConfig.DbClient.Users;
using Library.Services.Models;
using Library.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Library.Services.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;

        private readonly IMongoCollection<User> _users;
        public UserService(IDbUserClient dbClient, 
            IConfiguration configuration)
        {
            _users = dbClient.GetUsersCollection();
            _configuration = configuration;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.Find(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefault();
            if (user == null) return null;
            var token = GenerateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        public User CreateUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public User GetById(string id) =>
            _users.Find(x => x.Id == id).FirstOrDefault();

        public IEnumerable<User> GetAll() =>
            _users.Find(x => true).ToList();


        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
