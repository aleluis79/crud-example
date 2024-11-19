import { Component, inject, input, OnInit, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TodosService } from '../services/todos.service';
import { Todo } from '../models/todo';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-todo-detail',
  standalone: true,
  imports: [ RouterLink, DatePipe ],
  templateUrl: './todo-detail.component.html',
  styleUrl: './todo-detail.component.scss'
})
export default class TodoDetailComponent implements OnInit {

  id = input.required<number>({ alias: 'id' });

  todoSvc = inject(TodosService)

  todo = signal<Todo | null>(null)

  ngOnInit(): void {
    this.todoSvc.getTodo(this.id()).subscribe(todo => this.todo.set(todo))
  }


}
