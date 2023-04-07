using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> students;

        public StudentRepository()
        {
            students = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models
            => students.AsReadOnly();

        public void AddModel(IStudent model)
            => students.Add(model);

        public IStudent FindById(int id)
            => students.FirstOrDefault(s => s.Id == id);

        public IStudent FindByName(string name)
        {
            string[] studentNameTokens = name.Split(" ");
            string fName = studentNameTokens[0];
            string lName = studentNameTokens[1];

            return students.FirstOrDefault(s => s.FirstName == fName && s.LastName == lName);
        }
    }
}
