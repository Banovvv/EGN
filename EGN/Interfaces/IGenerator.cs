namespace EGN.Interfaces
{
    public interface IGenerator
    {
        string Generate(int year, int month, int day, string city, bool isMale, int birthPosition);
        string Generate(DateOnly birthDate, string city, bool isMale, int birthPosition);
        string[] GenerateAll(int year, int month, int day, string city, bool isMale);
        string[] GenerateAll(DateOnly birthDate, string city, bool isMale);
    }
}
