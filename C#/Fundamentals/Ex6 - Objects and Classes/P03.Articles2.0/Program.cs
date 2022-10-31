using System;
using System.Collections.Generic;

namespace P03.Articles2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] articleState = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (articleState.Length == 1)
                {
                    break;
                }
                var article = new Article(articleState[0], articleState[1], articleState[2]);
                articles.Add(article);
            }

            foreach (var article in articles)
            {
                Console.WriteLine(article);
            }
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

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
