import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    constructor(protected http: HttpClient) { }

    getUsers() {
        return this.http.get(environment.apiUrl + '/api/GetHotel');

    }
}
