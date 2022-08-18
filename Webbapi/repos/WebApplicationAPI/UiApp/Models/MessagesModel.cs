namespace UiApp.Models
{
    public class MessagesModel
    {
        public int MessageID { get; set; }
        public int UserID { get; set; }
        public string MessageHeadline { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageDate { get; set; }

    }
}
