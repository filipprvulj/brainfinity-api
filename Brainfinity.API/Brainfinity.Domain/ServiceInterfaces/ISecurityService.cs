using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.ServiceInterfaces
{
    public interface ISecurityService
    {
        public string GenerateJwtToken(Guid userId, string role);
    }
}