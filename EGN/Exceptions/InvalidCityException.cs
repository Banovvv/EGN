namespace EGN.Exceptions
{
    public class InvalidCityException : Exception
    {
        private static string? _message;

        public InvalidCityException(string city) : base(_message)
        {
            _message = $"Въведеният град на раждане ({city}) е невалиден!";
        }
    }
}
