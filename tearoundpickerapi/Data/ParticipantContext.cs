using Microsoft.EntityFrameworkCore;
using tearoundpickerapi.Models;

namespace tearoundpickerapi.Data
{
    public class ParticipantContext : DbContext
    {
        public ParticipantContext(DbContextOptions<ParticipantContext> options)
            : base(options)
        {
        }

        public DbSet<Participant> Participants { get; set; }
    }
}
