import { ApiService } from './../api-service.service';
import { Component, OnInit } from '@angular/core';
import { SimpleMessageModel } from '../models/message-model';

@Component({
  selector: 'app-simple-messages',
  templateUrl: './simple-messages.component.html',
  styleUrls: ['./simple-messages.component.css']
})
export class SimpleMessagesComponent implements OnInit {

  simpleMessages: SimpleMessageModel[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.apiService.getMessages().subscribe((simpleMessages: SimpleMessageModel[]) => {
        this.simpleMessages = simpleMessages;
      });
  }

  addMessageToView(simpleMessage: SimpleMessageModel) {
    this.simpleMessages.push(simpleMessage);
  }

  removeMessageFromView(simpleMessage: SimpleMessageModel) {
    this.simpleMessages.splice(this.simpleMessages.indexOf(simpleMessage),  1);
  }
}
