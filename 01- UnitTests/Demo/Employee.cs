using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class Person
    {
        public string Name { get; protected set; }
        public string Nickname { get; set; }
    }

    public class Employee : Person
    {
        public double Payment { get; private set; }
        public Seniority Seniority { get; private set; }
        public IList<string> Skills { get; private set; }

        public Employee(string name, double payment)
        {
            Name = string.IsNullOrEmpty(name) ? "Fulano" : name;
            SetSeniority(payment);
            SetSkills();
        }

        public void SetSeniority(double payment)
        {
            if (payment <= 500)
            {
                throw new Exception("Less than allowed payment");
            }

            Payment = payment;

            if (payment < 2000)
            {
                Seniority = Seniority.Junior;
            }
            else if (payment < 8000)
            {
                Seniority = Seniority.Specialist;
            }
            else
            {
                Seniority = Seniority.Senior;
            }
        }
        private void SetSkills()
        {
            var basics = new List<string>()
            {
                "Programming logic",
                "OOP"
            };

            Skills = basics;

            switch (Seniority)
            {
                case Seniority.Specialist:
                    Skills.Add("Tests");
                    break;
                case Seniority.Senior:
                    Skills.Add("Tests");
                    Skills.Add("Micro services");
                    break;
            }
        }
    }

    public enum Seniority
    {
        Junior,
        Specialist,
        Senior
    }

    public class EmployeeFactory
    {
        public static Employee Create(string name, double payment)
        {
            return new Employee(name, payment);
        }
    }
}
