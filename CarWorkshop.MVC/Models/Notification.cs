namespace CarWorkshop.MVC.Models
{
    public class Notification
    {
        public Notification(string type, string message)
        {
            Type = type;
            Message = message;
        }

        public string Type { get; set; }
        public string Message { get; set; }
    }
}
