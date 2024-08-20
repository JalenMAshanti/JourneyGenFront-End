namespace Logic.Models
{
    public class BibleBook
    {

        public BibleBook(string title, int chapters) 
        { 
            Title = title;
            Chapters = chapters; 
        }

        public string? Title { get; set; }
        public int Chapters { get; set; }
    }
}
