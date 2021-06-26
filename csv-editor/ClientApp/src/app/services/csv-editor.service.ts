import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable, of, Subject } from 'rxjs';
import { catchError, retry } from 'rxjs/internal/operators';
import { IPerson } from '../class/person';
import { IPersonList } from '../class/person-list';
import { CSV_API } from '../consts/consts';

@Injectable()
export class CsvEditorService {

  constructor(private _http: HttpClient,
    private _snackBar: MatSnackBar) { }

  private _usersList$ = new Subject<IPersonList>();

  public get usersList$() {
    return this._usersList$;
  }

  /*
    Get users methods - makes a HTTP requests to get the
    list of the users, and returns them.
  */
  getPersons() {
    return this._http.get<IPerson[]>(`${CSV_API}/get-persons`).pipe(
      retry(3), catchError(this.handleError<IPerson[]>('getPersons')));
  }

  /* Update users method - makes a HTTP request to update the CSV file. */
  updatePersons(persons: IPerson[]) {
    return this._http.put(`https://localhost:5001/api/v1/csv/update-persons`, persons).pipe(
      retry(3), catchError(this.handleError<IPerson[]>('getPersons')))
      .subscribe(result => {
        if (result) {
          this._snackBar.open('CSV update successully! :)');
        }
      });
  }

  /**
    * Handle Http operation that failed.
    * Let the app continue.
    * @param operation - name of the operation that failed
    * @param result - optional value to return as the observable result
  */
   private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      this._snackBar.open(error);
      console.error(error);

      return of(result as T);
    };
  }

}
