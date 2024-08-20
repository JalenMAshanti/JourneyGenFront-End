namespace Logic.API.ApiResponses
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class MessagesAPIResponse
    {
        public int postId { get; set; }
        public int groupId { get; set; }
        public string? content { get; set; }
        public int userId { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public DateTime datePosted { get; set; }
    }
}
