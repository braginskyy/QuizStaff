﻿using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class TesteeDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual Setting UserSetting { get; set; }
        public virtual ICollection<HistoryDTO> Histories { get; set; }
        public virtual ICollection<TesteeTrainingDTO> Trainings { get; set; }

        public static implicit operator TesteeDTO(Testee testee)
        {
            TesteeDTO newTeste = new TesteeDTO();
            Conversion.CopyProperty(testee, newTeste);
            return newTeste;
        }
    }
}
