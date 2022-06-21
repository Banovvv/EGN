namespace EGN.Interfaces
{
    public interface IGenerator
    {
        string Generate(int year, int month, int day, string city, bool isMale);
        string Generate(DateTime birthDate, string city, bool isMale);
    }
}
