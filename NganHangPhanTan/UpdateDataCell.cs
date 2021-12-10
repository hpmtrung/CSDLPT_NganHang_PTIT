namespace NganHangPhanTan
{
    public class UpdateDataCell
    {
        private object rowId;
        private string fieldName;
        private object content;

        public UpdateDataCell() { }

        public UpdateDataCell(object rowId, string fieldName, object content)
        {
            this.rowId = rowId;
            this.fieldName = fieldName;
            this.content = content;
        }

        public object RowId { get => rowId; set => rowId = value; }
        public string FieldName { get => fieldName; set => fieldName = value; }
        public object Content { get => content; set => content = value; }
    }
}
