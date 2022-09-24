using Microsoft.EntityFrameworkCore;

namespace SoulZynics.Repository
{
    public class data : DbContext
    {
        public data(DbContextOptions options): base(options)
        {

        }

    }
}
