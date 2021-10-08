namespace NossoQueijo.Comum.NotificationPattern
{
    public enum NotificationErrorType
    {
        UNKNOWN = 0,
        BUSINESS_RULES = 1,
        DATABASE = 2,
        CONNECTION = 3,
        USER = 4
    }

    public class NotificationError
    {
        public string Message { get; }
        public NotificationErrorType Type { get; }

        public NotificationError(string message, NotificationErrorType type = NotificationErrorType.UNKNOWN)
        {
            Message = message;
            Type = type;
        }
    }
}
