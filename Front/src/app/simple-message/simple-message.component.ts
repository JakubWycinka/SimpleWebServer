import { ApiService } from './../api-service.service';
import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { SimpleMessageModel } from '../models/message-model';

@Component({
  selector: 'app-simple-message',
  templateUrl: './simple-message.component.html',
  styleUrls: ['./simple-message.component.css']
})
export class SimpleMessageComponent implements OnInit {

  @Input() message: SimpleMessageModel;

  @Output() deletedMessage = new EventEmitter<SimpleMessageModel>();

  constructor(private apiService: ApiService) { }

  ngOnInit() {
  }

  delete() {
    this.apiService.deleteMessage(this.message.id).subscribe(() => {
      this.deletedMessage.emit(this.message);
    });
  }
}
