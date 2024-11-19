import { Component, inject, OnInit, signal } from '@angular/core';
import { TodosService } from '../services/todos.service';
import { Router, RouterLink } from '@angular/router';
import { Todo } from '../models/todo';

@Component({
  selector: 'app-todo-list',
  standalone: true,
  imports: [ RouterLink ],
  templateUrl: './todo-list.component.html',
  styleUrl: './todo-list.component.scss'
})
export default class TodoListComponent implements OnInit {

  todoSvc = inject(TodosService)

  router = inject(Router)

  todos = signal<Todo[]>([])

  ngOnInit(): void {
    this.loadTodos();
  }

  loadTodos() {
    this.todoSvc.getTodos().subscribe(todos => this.todos.set(todos))
  }

  deleteTodo(id: number) {
    if (!confirm('Are you sure?')) {
      return
    }

    this.todoSvc.deleteTodo(id).subscribe(() => {
      this.loadTodos()
    })

  }

}
