using Logic.API.ApiResponses;
using Logic.Models;

namespace Logic.Mappers
{
    public class PrexelImage_Mapper
    {
        public static PrexelImage PrexelMapper(PrexelAPIResponse response)
        {
            PrexelImage image = new PrexelImage();
            image.Alt = response.photos.First().alt;
            image.Photo = response.photos.First().src.landscape;
            return image;
        }
    }
}
