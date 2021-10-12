using System.Linq;
using tearoundpickerapi.Data;

namespace tearoundpickerapi.Services
{
    public class ParticipantVerifier
    {
        public bool ParticipantExists(long id, ParticipantContext participantContext) =>
            participantContext.Participants.Any(e => e.Id == id);
    }
}
