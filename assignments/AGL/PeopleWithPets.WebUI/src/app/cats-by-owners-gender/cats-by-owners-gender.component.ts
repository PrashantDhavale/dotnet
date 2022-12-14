import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CatsByOwnersGender } from '../models/CatsByOwnersGender';
import { environment } from '../../environments/environment';
@Component({
  selector: 'app-cats-by-owners-gender',
  templateUrl: './cats-by-owners-gender.component.html',
  styleUrls: ['./cats-by-owners-gender.component.css']
})
export class CatsByOwnersGenderComponent implements OnInit {

  apiData: CatsByOwnersGender[];
  isLoading: boolean = false;
  hasErrored: boolean = false;

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  onGetClick() {
    this.isLoading = true;
    this.apiData = null;
    this.hasErrored = false;

    this.http.get<CatsByOwnersGender[]>(environment.peopleWithPetsAPI)
      .subscribe(data => {
        this.isLoading = false;
        this.apiData = data;
      },
      err => {
        this.isLoading = false;
        this.hasErrored = true;
        console.log("Error occured.")
      });
  }
}
