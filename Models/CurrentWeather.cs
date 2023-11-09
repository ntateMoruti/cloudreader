namespace CloudReader.Models
{
    public class CurrentWeather
    {
        public int Id { get; set; }
        public Coord Coordinates { get; set; }
        public List<Weather> weather { get; set; }
        public string _base { get; set; }
        public Main main { get; set; }
        public double visibility { get; set; }
        public Wind wind { get; set; }
        public Rain rain { get; set; }
        public Cloud clouds { get; set; }
        public long dt { get; set; }
        public Syst sys { get; set; }
        public int timezone { get; set; }
        public long id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}
