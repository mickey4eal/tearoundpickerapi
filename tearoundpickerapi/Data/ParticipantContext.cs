using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
