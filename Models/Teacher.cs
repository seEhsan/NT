namespace WebApplication1.Models
{
    public class Teacher : People
    {
        public string Subject { get; set; }
        public bool Availability { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
