﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthDate;


        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthDate;
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }

        public int Age
        {
            get => age;
            private set => age = value;
        }

        public string Id
        {
            get => id;
            private set => id = value;
        }

        public string Birthdate
        {
            get => birthDate;
            private set => birthDate = value;
        }
    }
}
