namespace EGN.Exceptions
{
    public class InvalidDayException : Exception
    {
        private static readonly string _message = $"Денят на раждане трябва да е между 1 и 31";

        public InvalidDayException() : base(_message)
        {

        }
    }
}
