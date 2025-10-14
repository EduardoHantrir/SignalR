import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { FormControl } from '@angular/forms';

interface Message {
  text: string;
  sender: string;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.html',
  styleUrls: ['./home.scss']
})
export class Home implements OnInit {
  connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5094/messageHub")
    .withAutomaticReconnect()
    .build();

  messages: Message[] = [];

  textControl = new FormControl("");
  user: string;

  constructor(private cd: ChangeDetectorRef) {
    
    const possibleUsers = ["user", "teste"];
    this.user = possibleUsers[Math.floor(Math.random() * possibleUsers.length)];

    console.log("Usuário definido:", this.user);
    this.startConnection();
  }

  ngOnInit() {}

  async startConnection() {
    this.connection.on("ReceiveMessage", (sender: string, text: string) => {
      this.messages.push({ text, sender });

      // força atualização da view
      this.cd.detectChanges();
    });

    try {
      if (this.connection.state !== signalR.HubConnectionState.Connected) {
        await this.connection.start();
        console.log("Connected");
      }
    } catch (error) {
      console.log(error);
      setTimeout(() => this.startConnection(), 1000);
    }
  }

  async sendMessage() {
    const text = this.textControl.value?.toString().trim();
    if (!text) return;

    if (this.connection.state !== signalR.HubConnectionState.Connected) {
      console.warn('Conexão não está pronta. Tentando conectar...');
      await this.startConnection();
    }

    try {
      await this.connection.invoke('NewMessage', this.user, text);
      this.textControl.setValue('');
    } catch (err) {
      console.error('Erro ao enviar mensagem via SignalR:', err);
    }
  }
}
