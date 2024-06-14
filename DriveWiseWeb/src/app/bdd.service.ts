import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Car {
  id: number;
  registration: string;
  totalSeats: number;
  co2EmissionKm: number;
  categoryId: number;
  motorId: number;
  modelId: number;
}

@Injectable({
  providedIn: 'root'
})
export class BddService {

  constructor(private http: HttpClient) { }

  getCars(): Observable<Car[]> {

    const url = 'https://localhost:7236/swagger/index.html/api/Vehicle/GetAllAdmin';
    return this.http.get<Car[]>(url);
  }
}
