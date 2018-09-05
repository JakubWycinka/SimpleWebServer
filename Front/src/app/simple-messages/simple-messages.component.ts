import { ApiService } from './../api-service.service';
import { Component, OnInit } from '@angular/core';
import { SimpleMessageModel } from '../models/message-model';

@Component({
  selector: 'app-simple-messages',
  templateUrl: './simple-messages.component.html',
  styleUrls: ['./simple-messages.component.css']
})
export class SimpleMessagesComponent implements OnInit {

  messages: SimpleMessageModel[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.apiService.getMessages()
      .subscribe((messages: SimpleMessageModel[]) => {
        this.messages = messages;
      });
  }

  addMessage(simpleMessage: SimpleMessageModel) {
    this.messages.push(simpleMessage);
  }

  deletedMessage(simpleMessage: SimpleMessageModel) {
    this.messages.splice(this.messages.indexOf(simpleMessage),  1);
  }
