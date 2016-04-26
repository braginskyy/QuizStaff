﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Settings
    {
        public int AmountOfQuestionsPerDay { get; set; }
        public DateTime FrequencyOfAsking { get; set; }
        public Settings(int amountofq , DateTime freq)
        {
            AmountOfQuestionsPerDay = amountofq;
            FrequencyOfAsking = freq;
        }
    }
}
