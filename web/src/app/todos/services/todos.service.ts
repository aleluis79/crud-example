import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Todo, TodoNew, TodoUpdate } from '../models/todo';

@Injectable({
  providedIn: 'root'
})
export class TodosService {

  #http = inject(HttpClient);
  #urlAPI = 'http://localhost:5000/todo';

  getTodos(): Observable<Todo[]> {
    return this.#http.get<Todo[]>(this.#urlAPI);
  }

  getTodo(id: number): Observable<Todo> {
    return this.#http.get<Todo>(`${this.#urlAPI}/${id}`);
  }

  createTodo(todo: TodoNew): Observable<Todo> {
    return this.#http.post<Todo>(this.#urlAPI, todo);
  }

  updateTodo(id: number, todo: TodoUpdate): Observable<Todo> {
    return this.#http.put<Todo>(`${this.#urlAPI}/${id}`, todo);
  }

  deleteTodo(id: number): Observable<Todo> {
    return this.#http.delete<Todo>(`${this.#urlAPI}/${id}`);
  }

}
