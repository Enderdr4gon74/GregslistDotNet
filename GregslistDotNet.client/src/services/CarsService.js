import { AppState } from "../AppState.js"
import { Car } from "../models/Car.js"
import { api } from "./AxiosService.js"

class CarsService {
  async getCars() {
    const cars = await api.get('/api/cars')
    AppState.cars = cars.data.map(c => new Car(c))
  }
}

export const carsService = new CarsService()