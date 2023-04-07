using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private IRepository<ISubject> subjects;
        private IRepository<IStudent> students;
        private IRepository<IUniversity> universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != nameof(TechnicalSubject) &&
                subjectType != nameof(EconomicalSubject) &&
                subjectType != nameof(HumanitySubject))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (subjects.Models.Any(s => s.Name == subjectName))
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            ISubject subject = null;
            if (subjectType == nameof(TechnicalSubject))
            {
                subject = new TechnicalSubject(subjects.Models.Count + 1, subjectName);
            }
            if (subjectType == nameof(EconomicalSubject))
            {
                subject = new EconomicalSubject(subjects.Models.Count + 1, subjectName);
            }
            if (subjectType == nameof(HumanitySubject))
            {
                subject = new HumanitySubject(subjects.Models.Count + 1, subjectName);
            }

            subjects.AddModel(subject);

            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.Models.Any(u => u.Name == universityName))
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            ICollection<int> subjectsIds = new List<int>();

            foreach (var requiredSubject in requiredSubjects)
            {
                subjectsIds.Add(subjects.FindByName(requiredSubject).Id);
            }

            IUniversity university = new University(universities.Models.Count + 1, universityName, category, capacity, subjectsIds);
            universities.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (students.Models.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            IStudent student = new Student(students.Models.Count + 1, firstName, lastName);
            students.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (!students.Models.Any(s => s.Id == studentId))
            {
                return OutputMessages.InvalidStudentId;
            }

            if (!subjects.Models.Any(s => s.Id == subjectId))
            {
                return OutputMessages.InvalidSubjectId;
            }

            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);

            if (student.CoveredExams.Any(s => s == subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] studentNameTokens = studentName.Split(" ");
            string firstName = studentNameTokens[0];
            string lastName = studentNameTokens[1];

            if (!students.Models.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }

            if (!universities.Models.Any(u => u.Name == universityName))
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            IStudent student = students.FindByName(studentName);
            IUniversity university = universities.FindByName(universityName);

            bool canApply = student.CoveredExams.Count == university.RequiredSubjects.Count &&
                     student.CoveredExams.All(s => university.RequiredSubjects.Contains(s));

            if (!canApply)
            {
                return string.Format(OutputMessages.StudentHasToCoverExams,studentName, universityName);
            }

            if (student.University is not null &&
                student.University.Name == universityName)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, student.FirstName, student.LastName, universityName);
            }

            student.JoinUniversity(university);

            return string.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName, student.LastName, universityName);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");

            int studentsAdmitted = students.Models.Where(s => s.University is not null).Count(s => s.University.Name == university.Name);

            sb.AppendLine($"Students admitted: {studentsAdmitted}");
            sb.AppendLine($"University vacancy: {university.Capacity - studentsAdmitted}");

            return sb.ToString().TrimEnd();
        }
    }
}
