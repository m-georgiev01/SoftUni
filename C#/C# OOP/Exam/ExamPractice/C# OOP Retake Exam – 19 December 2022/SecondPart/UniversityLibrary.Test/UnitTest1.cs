using System;
using System.Text;

namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    public class Tests
    {
        private UniversityLibrary universityLibrary;

        [SetUp]
        public void Setup()
        {
            universityLibrary = new UniversityLibrary();
        }

        [TearDown]
        public void TearDown()
        {
            universityLibrary = null;
        }

        [Test]
        public void UniversityLibraryConstructorWorksCorrectly()
        {
            universityLibrary = new UniversityLibrary();

            Assert.That(universityLibrary.Catalogue.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddTextBookToLibraryWorksCorrectly()
        {
            TextBook tb = new TextBook("t1", "t1_author", "t1_cat");
            TextBook tb2 = new TextBook("t2", "t2_author", "t2_cat");

            universityLibrary.AddTextBookToLibrary(tb);
            string actual = universityLibrary.AddTextBookToLibrary(tb2);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine($"Book: {tb2.Title} - {tb2.InventoryNumber}");
            expected.AppendLine($"Category: {tb2.Category}");
            expected.AppendLine($"Author: {tb2.Author}");

            Assert.That(tb2.InventoryNumber, Is.EqualTo(2));
            Assert.That(universityLibrary.Catalogue.Count, Is.EqualTo(2));
            Assert.That(actual, Is.EqualTo(expected.ToString().TrimEnd()));
        }

        [Test]
        public void LoanTextBookThrowsIfTextBookNotFound()
        {
            Assert.Throws<NullReferenceException>(() => universityLibrary.LoanTextBook(1, "s1"));
        }

        [Test]
        public void LoanTextBookThrowsIfStudentHasNotReturnedTheBook()
        {
            TextBook tb = new TextBook("t1", "t1_author", "t1_cat");
            tb.Holder = "s1";

            universityLibrary.AddTextBookToLibrary(tb);

            string expected = $"s1 still hasn't returned {tb.Title}!";

            string actual = universityLibrary.LoanTextBook(1, "s1");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void LoanTextBookWorksCorrectly()
        {
            TextBook tb = new TextBook("t1", "t1_author", "t1_cat");
            universityLibrary.AddTextBookToLibrary(tb);

            string expected = $"{tb.Title} loaned to s1.";

            string actual = universityLibrary.LoanTextBook(1, "s1");

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(tb.Holder, Is.EqualTo("s1"));
        }

        [Test]
        public void ReturnTextBookThrowsIfTextBookNotFound()
        {
            Assert.Throws<NullReferenceException>(() => universityLibrary.ReturnTextBook(1));
        }

        [Test]
        public void ReturnTextBookWorksCorrectly()
        {
            TextBook tb = new TextBook("t1", "t1_author", "t1_cat");
            universityLibrary.AddTextBookToLibrary(tb);

            string actual = universityLibrary.ReturnTextBook(1);

            string expected = $"{tb.Title} is returned to the library.";

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(tb.Holder, Is.EqualTo(string.Empty));
        }
    }
}