using Logic.API.ApiResponses;
using Logic.Models;

namespace Logic.Mappers
{
    public class Verse_Mapper
    {
        public static VerseOfTheDay VerseMapper(VerseAPIResponse response) { 
            
            VerseOfTheDay verse = new VerseOfTheDay();

            verse.Verse = response.verse;
            verse.VerseLocation = response.verseLocation;

            return verse;
        }
    }
}
