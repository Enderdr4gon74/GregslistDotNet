namespace GregslistDotNet.Services;

public class CarsService
{
  // REPOSITORY PATTERN
  // will be used to control communication with the DB

  private readonly CarsRepository _carsRepo;

  public CarsService(CarsRepository carsRepo)
  {
    _carsRepo = carsRepo;
  }

  public List<Car> GetCars()
  {
    return _carsRepo.GetCars();
  }

  public Car GetCar(String id)
  {
    return _carsRepo.GetCar(id);
  }

  public Car CreateCar(Car carData)
  {
    return _carsRepo.CreateCar(carData);
  }

  public Car EditCar(Car carData, String id)
  {
    return _carsRepo.EditCar(carData, id);
  }
}