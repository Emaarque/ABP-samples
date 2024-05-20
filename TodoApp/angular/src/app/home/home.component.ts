import { AuthService } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
//Todo imports
import { ToasterService } from "@abp/ng.theme.shared";
import { TodoItemDto } from "@proxy/services/dtos";
import { TodoService } from "@proxy/services";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})

// export class HomeComponent {
//   get hasLoggedIn(): boolean {
//     return this.authService.isAuthenticated;
//   }

//   constructor() {}

//   login() {
//     this.authService.navigateToLogin();
//   }
// }

export class HomeComponent implements OnInit {

  todoItems: TodoItemDto[];
  newTodoText: string;

  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated;
  }

  constructor(
      private todoService: TodoService,
      private toasterService: ToasterService,
      private authService: AuthService)
  { }

   login() {
    this.authService.navigateToLogin();
  }

  ngOnInit(): void {
    this.todoService.getList().subscribe(response => {
      this.todoItems = response;
    });
  }
  
  create(): void{
    this.todoService.create(this.newTodoText).subscribe((result) => {
      this.todoItems = this.todoItems.concat(result);
      this.newTodoText = null;
    });
  }

  delete(id: string): void {
    this.todoService.delete(id).subscribe(() => {
      this.todoItems = this.todoItems.filter(item => item.id !== id);
      this.toasterService.info('Deleted the todo item.');
    });
  }  
}