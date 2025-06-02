namespace MVCProject.Models
{
    public class Categeories
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Books> Books { get; set; }
    }
}
