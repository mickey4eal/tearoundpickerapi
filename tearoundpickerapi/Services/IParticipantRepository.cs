﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tearoundpickerapi.Models;

namespace tearoundpickerapi.Services
{
    public interface IParticipantRepository
    {
        List<Participant> GetAll();
        Participant GetByID(long id);
        void Insert(Participant obj);
        void Update(long id, Participant obj);
        void Delete(long id);
        void Save();
    }
}
