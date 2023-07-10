import { JsonPipe } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }
  url = 'http://localhost:5101';

  registrate(body: any){
    return this.http.post(`${this.url}/UserContoller/Register`, body);
  } 

  logIn(body: any) {
    const headers = new HttpHeaders({
      'Accept': 'application/json'
    });
    return this.http.post(`${this.url}/UserContoller/Login`, body, {headers: headers, responseType: "json"});
  }

  getAll(){
    let token = localStorage.getItem("token");
    if (token) {
      token = JSON.parse(token);      
    }
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
    return this.http.get(`${this.url}/UserContoller/GetAll`,{headers});
  }

  delete(body: any){
    const headers = new HttpHeaders({
      'Accept': 'application/json'
    });
    return this.http.delete(`${this.url}/UserContoller/Delete`, {body,headers});
  }
}
