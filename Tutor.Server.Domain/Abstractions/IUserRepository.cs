using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Server.Domain.Entities;

namespace Tutor.Server.Domain.Abstractions
{
    public interface IUserRepository : IRepository
    {
        Task AddAsync(User user);
        Task<User> GetByEmailAsync(string email);
    }
}
