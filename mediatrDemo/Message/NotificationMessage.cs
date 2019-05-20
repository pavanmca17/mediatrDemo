using MediatR;


namespace mediatrDemo
{
    public class NotificationMessage : INotification
    {
        public string NotifyText { get; set; }
    }
}
