import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { NguiMapModule} from '@ngui/map';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    NguiMapModule.forRoot({apiUrl: 'https://maps.google.com/maps/api/js?key=AIzaSyD5W8EzEuPsvvitGICxg0NvQ8TUHdNp4To'})

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
