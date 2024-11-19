import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', loadComponent: () => import('./todos/todo-list/todo-list.component') },
  { path: 'todos/create', loadComponent: () => import('./todos/todo-create/todo-create.component') },
  { path: 'todos/:id/edit', loadComponent: () => import('./todos/todo-create/todo-create.component') },
  { path: 'todos/:id', loadComponent: () => import('./todos/todo-detail/todo-detail.component') },
  { path: '**', loadComponent: () => import('./todos/todo-list/todo-list.component') }
];
