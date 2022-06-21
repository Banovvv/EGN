namespace EGN.Models
{
    public class Region
    {
        public Region(string name, int startValue, int endValue)
        {
            Name = name;
            StartValue = startValue;
            EndValue = endValue;
        }

        public string Name { get; set; }
        public int StartValue { get; set; }
        public int EndValue { get; set; }
    }
}
