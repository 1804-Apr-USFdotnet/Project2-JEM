import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
_Username: String = '';
Platform: String = '';
LifeTimeStats: String[];
RecentMatches: String[];

  constructor(private httpClient: HttpClient) {}
  getProfile(Username: String) {
    this.httpClient.get(`http://ec2-52-15-80-15.us-east-2.compute.amazonaws.com/FTV/api/Players/${Username}`).subscribe((data: any) => {
    this._Username = data['Username'];
    this.Platform = data['Platform'];
    this.LifeTimeStats = data['LifeTimeStats'];
    this.RecentMatches = data['RecentMatches'];
    });
  }
}
