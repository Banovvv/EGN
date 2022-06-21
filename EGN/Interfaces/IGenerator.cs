namespace EGN.Interfaces
{
    public interface IGenerator
    {
        string Generate(DateTime birthDate, string city, bool isMale);
    }
}
