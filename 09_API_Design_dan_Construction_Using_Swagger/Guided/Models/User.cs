namespace Guided.Models
{
    public class User
    {
        public int Id { get; set; }
        public int id { get; internal set; }
        public string Name { get; set; }
        public string name { get; internal set; }
        public string Email { get; set; }
        public string email { get; internal set; }
    }
}
