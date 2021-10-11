using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tearoundpickerapi.Data;
using tearoundpickerapi.Models;

namespace tearoundpickerapi.Services
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly ParticipantContext _participantContext;

        public ParticipantRepository(ParticipantContext participantContext)
        {
            _participantContext = participantContext;
        }

        public void Delete(long id)
        {
            var participant = _participantContext.Participants.Find(id);

            if (participant != null)
            {
                _participantContext.Participants.Remove(participant);
                Save();
            }
        }

        public List<Participant> GetAll()
        {
            return _participantContext.Participants
                .Select(x => x)
                .ToList();
        }

        public Participant GetByID(long id)
        {
            return _participantContext.Participants.Find(id);
        }

        public void Insert(Participant obj)
        {
            if (!string.IsNullOrEmpty(obj.Name))
            {
                Participant participant = new()
                {
                    WantsADrink = obj.WantsADrink,
                    Name = obj.Name,
                    DrinkPreference = obj.DrinkPreference
                };

                _participantContext.Participants.Add(participant);
                Save();
            }
        }

        public void Save()
        {
            _participantContext.SaveChangesAsync();
        }

        public void Update(long id, Participant obj)
        {
            Participant participant = null;

            if (id == obj.Id)
            {
                participant = _participantContext.Participants.Find(id);
            }

            if (participant != null)
            {
                participant.Name = obj.Name;
                participant.DrinkPreference = obj.DrinkPreference;
                participant.WantsADrink = obj.WantsADrink;

                try
                {
                    Save();
                }
                catch (DbUpdateConcurrencyException) when (!new ParticipantVerifier().ParticipantExists(id, _participantContext))
                {
                    throw;
                }
            }
        }
    }    
}
