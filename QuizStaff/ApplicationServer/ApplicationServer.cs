﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DomainModel;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ApplicationServer : IApplicationServer
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public List<Testee> GetAllTestees()
        {
            var testees = new List<Testee>();
            var t = new Testee("Bogdan", "Nashilnik", "mail@gmail.com") { Login = "qwer" };
            var training = new Training("Философия улицы");
            training.Questions.Add(new Question("Хм?", training));
            t.Trainings.Add(training);
            t.Trainings.Add(new Training("Брат за брата"));
            testees.Add(t);
            testees.Add(new Testee("Oleg", "Lobanov", "mail@gmail.com") { Login = "qwer"});
            testees.Add(new Testee("Fedor", "Voloshin", "mail@gmail.com") { Login = "qwer" });
            testees.Add(new Testee("Nikita", "Tsyhankov", "mail@gmail.com") { Login = "qwer" });
            testees.Add(new Testee("Valeriy", "Baditsa", "mail@gmail.com") { Login = "qwer" });
            return testees;
        
        }
        public void SaveAllTestees(List<Testee> testee)
        {
            // TODO save to database
        }

        public List<Question> GetTrainingQuestions(Training training)
        {
            var questions = new List<Question>();
            var first = new Question("первый вопрос", training);
            var second = new Question("второй вопрос", training);

            first.Answers.Add(new Answer("правильный", true));
            first.Answers.Add(new Answer("неправильный", false));
            first.Answers.Add(new Answer("тоже правильный", true));

            second.Answers.Add(new Answer("правильный", true));
            second.Answers.Add(new Answer("неправильный", false));
            second.Answers.Add(new Answer("совсем неправильный", false));

            questions.Add(first);
            questions.Add(second);

            return questions;
        }

        public void SaveAllQuestions(Training training, List<Question> questions)
        {
            // Todo: save to database


        }
    }
}
