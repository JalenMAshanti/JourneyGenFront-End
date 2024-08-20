using Logic.API.ApiResponses;

namespace Logic.Mappers
{
    public class Chapter_Mapper
    {
        public static string ChapterMapper(ChapterTextAPIResponse response) 
        {
            string result = response.ChapterText;
            return result;
        }
    }
}
