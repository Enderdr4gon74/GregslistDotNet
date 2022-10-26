namespace GregslistDotNet.Repositories;

public class CarsRepository
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }


  public List<Car> GetCars()
  {
    var sql = "SELECT * FROM cars";
    return _db.Query<Car>(sql).ToList();
  }

  public Car CreateCar(Car carData)
  {
    var sql = @"
    INSERT INTO cars(
      make, model, year, price, description, imgUrl
    )
    VALUES(
      @Make, @Model, @Year, @Price, @Description, @ImgUrl
    );
    SELECT LAST_INSERT_ID();
    ";

    carData.Id = _db.ExecuteScalar<int>(sql, carData);
    return carData;

  }

  public Car GetCar(String id) 
  {
    var sql = @"SELECT * FROM cars where id = @id;";
    return _db.QuerySingle<Car>(sql, new {id});
  }

  public Car EditCar(Car carData, String id) 
  {
    string sql = "";
    if (carData.Year >= 1886) {
      sql += "UPDATE cars SET year = @Year WHERE id = @id;";
    } if (carData.Make != null) {
      sql += "UPDATE cars SET make = @Make WHERE id = @id;";
    } if (carData.Model != null) {
      sql += "UPDATE cars SET model = @Model WHERE id = @id;";
    } if (carData.Description != null) {
      sql += "UPDATE cars SET description = @Description WHERE id = @id;";
    } if (carData.ImgUrl != null) {
      sql += "UPDATE cars SET imgUrl = @ImgUrl WHERE id = @id;";
    } if (carData.Price >= 0) {
      sql += "UPDATE cars SET price = @Price WHERE id = @id;";
    }
    _db.QuerySingleOrDefault<Car>(sql, new { id, ImgUrl = carData.ImgUrl, Description = carData.Description, Model = carData.Model, Make = carData.Make, Year = carData.Year, Price = carData.Price });
    return this.GetCar(id);
  }
}
