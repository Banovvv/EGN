using EGN.Interfaces;

namespace EGN.Models
{
    public class Egn : IValidator, IGenerator
    {
        public string Generate(DateTime birthDate, string city, bool isMale)
        {
            throw new NotImplementedException();
        }

        public bool Validate(string egn)
        {
            throw new NotImplementedException();
        }
    }
}
