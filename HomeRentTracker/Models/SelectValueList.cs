namespace HomeRentTracker.Models
{
    public class SelectValueList
    {
        private string value { get; set; }
        private string _text { get; set; }
       
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public string Text
        {
            get { return _text; }
            set { this._text = value; }
        }
    }
}
