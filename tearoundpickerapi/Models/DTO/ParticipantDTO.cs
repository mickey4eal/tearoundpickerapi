using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tearoundpickerapi.Models.DTO
{
    public class ParticipantDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string DrinkPreference { get; set; }
        public bool WantsADrink { get; set; }
        public bool IsTeaMaker { get; set; }
    }
}
