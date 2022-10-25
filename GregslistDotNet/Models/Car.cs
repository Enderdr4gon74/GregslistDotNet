
namespace GregslistDotNet.Models;

public class Car
{
  public int Id { get; set; }
  public string Make { get; set; }
  public string Model { get; set; }
  public int Year { get; set; }
  public decimal Price { get; set; }
  public string Description { get; set; }
  public string ImgUrl { get; set; }

  public Car(int id, string make, string model, int year, decimal price, string description, string imgUrl)
  {
    Id = id;
    Make = make;
    Model = model;
    Year = year;
    Price = price;
    Description = description;
    ImgUrl = imgUrl;
    // Id = Guid.NewGuid().ToString();
    // Name = name;
    // IsComplete = isComplete;
  }
}
