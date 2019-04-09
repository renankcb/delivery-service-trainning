namespace DeliveryService.API.Model
{
    public class Point
    {
        public Point (int id, string name, int time, int cost)
        {
            Id = id;
            Name = name;
            Time = time;
            Cost = cost;
        }

        public Point()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Time { get; set; }

        public int Cost { get; set; }
    }
}
