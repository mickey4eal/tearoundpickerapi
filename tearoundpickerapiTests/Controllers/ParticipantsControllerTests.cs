using Microsoft.VisualStudio.TestTools.UnitTesting;
using tearoundpickerapi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using tearoundpickerapi.Data;
using Microsoft.EntityFrameworkCore;
using tearoundpickerapi.Models;

namespace tearoundpickerapi.Controllers.Tests
{
    [TestClass()]
    public class ParticipantsControllerTests
    {
        public static ParticipantContext GetTestDbContext(string dbName)
        {
            var dbContextOptionBuilder = new DbContextOptionsBuilder<ParticipantContext>();
            dbContextOptionBuilder.UseInMemoryDatabase(dbName);

            return new ParticipantContext(dbContextOptionBuilder.Options);
        }

        public static void SetToDoRepository(ParticipantContext participantContext)
        {
            var initialParticipants = new List<Participant>
            {
                new Participant
                {
                    Id = 1,
                    Name = "feed cat",
                    WantsADrink = true
                },
                new Participant
                {
                    Id = 2,
                    Name = "feed cat",
                    WantsADrink = true
                },
                new Participant
                {
                    Id = 3,
                    Name = "feed cat",
                    WantsADrink = true
                },
                new Participant
                {
                    Id = 4,
                    Name = "feed cat",
                    WantsADrink = true
                },
                new Participant
                {
                    Id = 5,
                    Name = "feed cat",
                    WantsADrink = true
                }
            };

            participantContext.Participants.AddRange(initialParticipants);

            participantContext.SaveChanges();
        }

        public static ParticipantsController ParticipantsControllerTest(ParticipantContext testContext)
        {
            return new ParticipantsController(testContext);
        }

        [TestMethod()]
        public async Task GetParticipantsTest()
        {
            var testContext = GetTestDbContext("list1");
            SetToDoRepository(testContext);
            var participantController = ParticipantsControllerTest(testContext);

            await participantController.GetParticipants();

            Assert.AreEqual(5, testContext.Participants.Count());
        }

        [TestMethod()]
        public async Task GetParticipantTest()
        {
            var testContext = GetTestDbContext("list2");
            SetToDoRepository(testContext);
            var participantController = ParticipantsControllerTest(testContext);

            var result = await participantController.GetParticipant(2);

            Assert.AreEqual("feed cat", result.Value.Name);
        }

        [TestMethod()]
        public async Task PutParticipantTest()
        {
            var testContext = GetTestDbContext("list3");
            SetToDoRepository(testContext);
            var participantController = ParticipantsControllerTest(testContext);

            await participantController.PutParticipant(3, new Participant()
            {
                Id = 3,
                Name = "feed cat",
                WantsADrink = true
            });

            var result = await participantController.GetParticipant(3);

            Assert.AreEqual("feed cat", result.Value.Name);
        }

        [TestMethod()]
        public async Task PostParticipantTest()
        {
            var testContext = GetTestDbContext("list4");
            SetToDoRepository(testContext);
            var participantController = ParticipantsControllerTest(testContext);

            await participantController.PostParticipant(new Participant()
            {
                Name = "feed bird",
                WantsADrink = true
            });

            Assert.AreEqual(6, testContext.Participants.Count());
        }

        [TestMethod()]
        public async Task DeleteParticipantTest()
        {
            var testContext = GetTestDbContext("list5");
            SetToDoRepository(testContext);
            var participantController = ParticipantsControllerTest(testContext);

            await participantController.DeleteParticipant(1);

            Assert.AreEqual(4, testContext.Participants.Count());
        }
    }
}