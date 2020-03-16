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

  onSubmit() {   
      
    }

    ngOnInit() {
       
    }

    searchBoxSubmitAPI(event) {
        //just added console.log which will display the event details in browser on click of the button.
        //alert("Boton es click");
        //console.log(event);

        this.userService.getUsers()
            .subscribe(
                (data) => { // Success
                    this.users = data['results'];
                },
                (error) => {
                    console.error(error);
                }
            );

        /*this.Hotels = [
            { HotelName: 'hotel fantansia', Description: 'hotel fantasia puerto varas' },
            { HotelName: 'hotel leones', Description: 'hotel leones puerto montt' },
        ];     */
       
    }

}



