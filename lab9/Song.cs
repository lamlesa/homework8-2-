using System;

namespace lab9
{

    internal class Song
    {
        private string name;
        private string author;
        private Song prev;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public Song Prev
        {
            get { return prev; }
            set { prev = value; }
        }
        public Song(string name, string author)
        {
            Song prev = null;
            this.name = name;
            this.author = author;
        }
        public Song(string name, string author, Song prev)
        {
            this.name = name;
            this.author = author;
            this.prev = prev;
        }
        public Song()
        {
            name = "Фейерверк";
        }
        public string PrintTitleAndAuthor()
        {
            string s = name + ' ' + author;
            Console.WriteLine(s);
            return (s);
        }
        public override bool Equals(object d)
        {
            Song song = (Song)d;
            if ((song.Name == Name) && (song.Author == Author))
            {
                Console.WriteLine("Песни одинаковые.");
                return true;
            }
            else
            {
                Console.WriteLine("Песни разные.");
                return false;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}