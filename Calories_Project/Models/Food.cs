namespace Calories_Project.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
