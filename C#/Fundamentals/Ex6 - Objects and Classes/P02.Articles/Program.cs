using System;

namespace P02.Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] articleStartState = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var article = new Article(articleStartState[0], articleStartState[1], articleStartState[2]);
            
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] == "Edit")
                {
                    article.Edit(cmdArgs[1]);
                }
                else if (cmdArgs[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(cmdArgs[1]);
                }
                else if (cmdArgs[0] == "Rename")
                {
                    article.Rename(cmdArgs[1]);
                }
            }

            Console.WriteLine(article);
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
