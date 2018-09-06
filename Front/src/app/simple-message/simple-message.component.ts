import { ApiService } from './../api-service.service';
import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { SimpleMessageModel } from '../models/message-model';

@Component({
  selector: 'app-simple-message',
  templateUrl: './simple-message.component.html',
  styleUrls: ['./simple-message.component.css']
})
export class SimpleMessageComponent implements OnInit {

  @Input() simpleMessage: SimpleMessageModel;

  @Output() afterDeletedResponse = new EventEmitter<SimpleMessageModel>();

  constructor(private apiService: ApiService) { }

  ngOnInit() {
  }

  deleteApiCall() {
    this.apiService.deleteMessage(this.simpleMessage.id).subscribe(() => {
      this.afterDeletedResponse.emit(this.simpleMessage);
    });
  }
}
