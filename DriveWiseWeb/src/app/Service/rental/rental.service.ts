import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

// Assuming you have models for data transfer
import { CarpoolDto, CityDto, DriverDto, PassengerDto } from 'src/app/models/rental/rental-interfaces'; // Update with your model paths

@Injectable({
  providedIn: 'root'
})
export class RentalService {

  private readonly baseUrl: string = 'http://localhost:5245/api';

  constructor(private http: HttpClient) { }

  // GET /Carpool
  getCarpools(cities: CityDto[]): Observable<CarpoolDto[]> {
    const url = `${this.baseUrl}/Carpool`; // Replace with actual URL
    const params = { cities: cities.map(city => city.id) }; // Example query parameters
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http
      .get<CarpoolDto[]>(url, { params, headers })
      .pipe(
        tap((response) => console.log(response)),
        catchError((error) => {
          console.error(error);
          return of(error);
        })
      );
  }

  // GET /Carpool/{id}
  getCarpoolById(id: number): Observable<CarpoolDto> {
    const url = `<span class="math-inline">\{this\.baseUrl\}/Carpool/</span>{id}`; // Replace with actual URL

    return this.http
      .get<CarpoolDto>(url)
      .pipe(
        tap((response) => console.log(response)),
        catchError((error) => {
          console.error(error);
          return of(error);
        })
      );
  }

  // POST /Carpool
  createCarpool(carpool: CarpoolDto): Observable<CarpoolDto> {
    const url = `${this.baseUrl}/Carpool`; // Replace with actual URL
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http
      .post<CarpoolDto>(url, carpool, { headers })
      .pipe(
        tap((response) => console.log(response)),
        catchError((error) => {
          console.error(error);
          return of(error);
        })
      );
  }

  // PUT /Carpool/{id}
  updateCarpool(id: number, carpool: CarpoolDto): Observable<CarpoolDto> {
    const url = `<span class="math-inline">\{this\.baseUrl\}/Carpool/</span>{id}`; // Replace with actual URL
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http
      .put<CarpoolDto>(url, carpool, { headers })
      .pipe(
        tap((response) => console.log(response)),
        catchError((error) => {
          console.error(error);
          return of(error);
        })
      );
  }

  // DELETE /Carpool/{id}
  deleteCarpool(id: number): Observable<any> {
    const url = `<span class="math-inline">\{this\.baseUrl\}/Carpool/</span>{id}`; // Replace with actual URL

    return this.http
      .delete(url)
      .pipe(
        tap((response) => console.log(response)),
        catchError((error) => {
          console.error(error);
          return of(error);
        })
      );
  }

  // Example methods for Drivers and Passengers (if applicable)
  //getDrivers(): Observable<DriverDto[]> {
  //  const url = `${this.baseUrl}/Driver`; // Replace with actual URL

  //  return this.http
  //    .get<DriverDto[]>(url)
  //    .pipe(
  //      tap((response) => console.log(response)),
  //      catchError((error) => {
  //        console.error(error);
  //        return of(error);
  //      })
  //    );
  //}
}
