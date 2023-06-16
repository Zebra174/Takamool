import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
  title = 'Takamool';
  baseUrl = 'https://localhost:5001/api/';
}
