import { ApiService } from './../api-service.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { SimpleMessageModel } from '../models/message-model';

@Component({
  selector: 'app-message-form',
  templateUrl: './message-form.component.html',
  styleUrls: ['./message-form.component.css']
})
export class MessageFormComponent implements OnInit {

  simpleMessage: SimpleMessageModel = {
    authorName: '',
    message: '',
  };

  @Output() afterPostedMessage = new EventEmitter<SimpleMessageModel>();

  constructor(private apiService: ApiService) { }

  ngOnInit() {
  }

  postMessageApiCall() {
     this.apiService.postMessage(this.simpleMessage).subscribe(message => {
      this.afterPostedMessage.emit(message);
    });
  }

}
