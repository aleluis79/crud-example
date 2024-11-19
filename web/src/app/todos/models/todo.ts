export interface Todo {
  id: number;
  name: string;
  description: string;
  isComplete: boolean;
  created: Date;
}

export type TodoNew = Omit<Todo, 'id' | 'created' | 'isComplete'>;

export type TodoUpdate = Omit<Todo, 'id' | 'created'>;
