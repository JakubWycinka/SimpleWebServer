import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppMaterialModule } from './app-material.module';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { MessageFormComponent } from './message-form/message-form.component';
import { HttpClientModule } from '@angular/common/http';
import { SimpleMessageComponent } from './simple-message/simple-message.component';
import { SimpleMessagesComponent } from './simple-messages/simple-messages.component';

@NgModule({
  declarations: [
    AppComponent,
    MessageFormComponent,
    SimpleMessageComponent,
    SimpleMessagesComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppMaterialModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
