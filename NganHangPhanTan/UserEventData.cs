namespace NganHangPhanTan
{
    public class UserEventData
    {
        public enum EventType
        {
            CANCEL_EDIT,
            INSERT,
            DELETE,
            UPDATE,
        }

        private EventType type;
        private object content;
        private int gridPos;

        public EventType Type { get => type; set => type = value; }
        public object Content { get => content; set => content = value; }
        public int GridPos { get => gridPos; set => gridPos = value; }

        public UserEventData(EventType type, object content, int gridPos)
        {
            this.Type = type;
            this.Content = content;
            this.GridPos = gridPos;
        }

    }
}
