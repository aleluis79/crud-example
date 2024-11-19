import { Component, inject, input, OnInit } from '@angular/core';
import { TodosService } from '../services/todos.service';
import { TodoNew, TodoUpdate } from '../models/todo';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-todo-create',
  standalone: true,
  imports: [ ReactiveFormsModule ],
  templateUrl: './todo-create.component.html',
  styleUrl: './todo-create.component.scss'
})
export default class TodoCreateComponent implements OnInit {

  // If the id is not defined, it is a create operation, otherwise it is an update
  id = input<number | undefined>(undefined, { alias: 'id' })

  todoSvc = inject(TodosService)

  router = inject(Router)

  fb = inject(FormBuilder)

  myForm = this.fb.group({
    name: '',
    description: '',
    isComplete: false
  })

  ngOnInit(): void {
    if (this.id()) {
      this.todoSvc.getTodo(this.id()!).subscribe(todo => {
        this.myForm.patchValue({
          name: todo.name,
          description: todo.description,
          isComplete: todo.isComplete
        })
      })
    }
  }

  onSubmit() {
    if (!this.myForm.valid) {
      return
    }

    if (this.id()) {
      let todoUpdate : TodoUpdate = {
        name: this.myForm.value.name ?? '',
        description: this.myForm.value.description ?? '',
        isComplete: this.myForm.value.isComplete ?? false
      }
      this.todoSvc.updateTodo(this.id()!, todoUpdate).subscribe(
        () => {
          this.router.navigate(['/todos'])
        }
      )
    } else {
      let todoNew : TodoNew = {
        name: this.myForm.value.name ?? '',
        description: this.myForm.value.description ?? ''
      }
      this.todoSvc.createTodo(todoNew).subscribe(
        () => {
          this.router.navigate(['/todos'])
        }
      )
    }
  }

}
