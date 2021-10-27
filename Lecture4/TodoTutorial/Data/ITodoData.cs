using System.Collections.Generic;
using TodoTutorial.Models;

namespace TodoTutorial.Data {
    public interface ITodoData {
        IList<Todo> GetTodos();
        void AddTodo(Todo todo);
        void RemoveTodo(int todoId);
        void Update(Todo todo);
        Todo Get(int id);
    }
}