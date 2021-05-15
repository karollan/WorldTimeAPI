import { Component, Inject } from '@angular/core';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-world-time',
  templateUrl: './world-time.component.html',
})
export class WorldTimeComponent {
  public response: WorldTime[];
  public error: boolean = false;
  public loading: boolean = true;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.getResult(baseUrl).subscribe(result => {
      this.error = false;
      this.loading = false;
    }, error => {
      this.error = true;
      this.loading = false;
    });
  }

  getResult(baseUrl): Observable<WorldTime[]> {
    return this.http.get(baseUrl + 'worldtime').pipe(map((result: WorldTime[]) => {
      this.response = result;
      return result;
    }));
  }

}

interface WorldTime {
 worldTime: string;
}
