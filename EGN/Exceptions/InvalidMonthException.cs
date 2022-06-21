namespace EGN.Exceptions
{
    public class InvalidMonthException : Exception
    {
        private static readonly string _message = $"Месецът на раждане трябва да е между 1 и 12";

        public InvalidMonthException() : base(_message)
        {

        }
    }
}
