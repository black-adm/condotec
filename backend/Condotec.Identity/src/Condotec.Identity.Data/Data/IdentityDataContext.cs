using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Condotec.Identity.Data.Data
{
    public class IdentityDataContext(DbContextOptions<IdentityDataContext> options) : IdentityDbContext(options)
    {
    }
}
