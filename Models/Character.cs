namespace TechChase.Models
{
    public class Character
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public Character(string Name,string Image)
        {
            this.Name = Name;
            this.Image = Image;
        }
    }
}
