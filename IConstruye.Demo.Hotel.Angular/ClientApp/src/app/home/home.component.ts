import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

    Hotels: Array<Object>;
    title = 'demo131';
    users: any[] = [];

    constructor(
        protected userService: UserService
    ) {
    }



    ngOnInit() {
    }

    searchBoxSubmitAPI(event) {

        // evento click
        this.userService.getUsers()
            .subscribe(
                (data) => {
                    console.log(data);
                    this.users = data;
                },
                (error) => {
                    console.error(error);
                }
            );
    }

}



