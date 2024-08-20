using Logic.API;
using Logic.Models;

namespace JourneyGen_UI.Models
{
    public class BibleIndexViewModel
    {
        public List<BibleBook>? BibleBooks { get; set; }

        public string ChapterViewName { get; set; } = "No Chapter Selected";
        public string SelectedChapterText { get; set; } = "No chapter selected";
        public string SelectedChapterTitle { get; set; } = "";
        public int SelectedChapterNum {  get; set; }

    }
}
