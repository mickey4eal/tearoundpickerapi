using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tearoundpickerapi.Data;
using tearoundpickerapi.Models;
using tearoundpickerapi.Services;

namespace tearoundpickerapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly ParticipantContext _context;
        private readonly IParticipantRepository participantRepository;

        public ParticipantsController(ParticipantContext context)
        {
            _context = context;
            participantRepository = new ParticipantRepository(_context);
        }

        // GET: api/Participants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipants()
        {
            List<Participant> result = null;
            await Task.Run(() => { result = participantRepository.GetAll(); });
            return result;
        }

        // GET: api/Participants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participant>> GetParticipant(long id)
        {
            Participant result = null;
            await Task.Run(() => { result = participantRepository.GetByID(id); });
            return result;
        }

        // PUT: api/Participants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipant(long id, Participant participant)
        {
            await Task.Run(() => { participantRepository.Update(id, participant); });

            return NoContent();
        }

        // POST: api/Participants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Participant>> PostParticipant(Participant participant)
        {
            await Task.Run(() => { participantRepository.Insert(participant); });

            return CreatedAtAction(nameof(GetParticipant), new { id = participant.Id }, participant);
        }

        // DELETE: api/Participants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(long id)
        {
            await Task.Run(() => { participantRepository.Delete(id); });

            return NoContent();
        }
    }
}
