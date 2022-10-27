using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Song> songs = new List<Song>();

            int numOfSongs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfSongs; i++)
            {
                string[] tokens = Console.ReadLine().Split('_');
                string typeLisy = tokens[0];
                string name = tokens[1];
                string time = tokens[2];

                var song = new Song(typeLisy, name, time);
                songs.Add(song);
            }

            string command = Console.ReadLine();

            if (command != "all")
            {
                songs = songs.Where(x => x.TypeList == command).ToList();               
            }

            foreach (var song in songs)
            {
                Console.WriteLine(song.Name);
            }
        }
    }

    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

        public Song(string typeList, string name, string time)
        {
            TypeList = typeList;
            Name = name;
            Time = time;
        }
    }
}
