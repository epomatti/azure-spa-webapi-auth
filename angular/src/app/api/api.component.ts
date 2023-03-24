import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const API_ENDPOINT = "http://localhost:5053/api/protected"

type ProtectedAPI = {
  protectedValue?: string
};

@Component({
  selector: 'app-api',
  templateUrl: './api.component.html',
  styleUrls: ['./api.component.css']
})
export class ApiComponent {
  protectedAPI!: ProtectedAPI;

  constructor(
    private http: HttpClient
  ) { }

  ngOnInit() {
    this.getProtectedAPI();
  }

  getProtectedAPI() {
    this.http.get(API_ENDPOINT)
      .subscribe(protectedAPI => {
        this.protectedAPI = protectedAPI;
      });
  }

}
