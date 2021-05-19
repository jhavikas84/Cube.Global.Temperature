import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

export interface TemperatureData {
  Kelvin: string;
  Celsius: string;
  Fahrenheit: string;
}

@Injectable({
  providedIn: 'root'
})
export class TempertureService {

  private REST_API_SERVER = "https://localhost:5001/Temperature";
  constructor(private httpClient: HttpClient) { }

  handleError(error: HttpErrorResponse) {
    let errorMessage = 'Unknown error!';
    if (error.error instanceof ErrorEvent) {
      // Client-side errors
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side errors
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }

  public getConvertedTemperature(temperatureType: string, temperature: number) {
    const headers = new HttpHeaders();
    headers.append('Access-Control-Allow-Origin', '*');
    headers.append('Content-Type', 'text/json');

    return this.httpClient.get(this.REST_API_SERVER + '/' + temperatureType + '/' + temperature, { responseType: 'json', headers }).pipe(catchError(this.handleError));
  }

}