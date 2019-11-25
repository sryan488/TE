const host = "https://localhost:44354/api";
const todo = {
  task: "Go For a Walk",
  completed: false
};

document.addEventListener("DOMContentLoaded", () => {
  document.querySelector("#getTodos").addEventListener("click", e => {
    getTodos();
  });
  document.querySelector("#getTodo").addEventListener("click", e => {
    getTodo(1);
  });
  document.querySelector("#postTodo").addEventListener("click", e => {
    postTodo(todo);
  });
  document.querySelector("#putTodo").addEventListener("click", e => {
    putTodo(1, todo);
  });
  document.querySelector("#deleteTodo").addEventListener("click", e => {
    deleteTodo(1);
  });
});

/**
 * Gets all resources.
 */
function getTodos() {
  fetch(`${host}/todos`, {
    method: "GET"
  })
    .then(response => {
      return response.json();
    })
    .then(json => {
      console.log(json);
    });
}

/**
 * Gets a single resource by id.
 * @param {Number} id The id of the resource to get.
 */
function getTodo(id) {
  fetch(`${host}/todos/${id}`, {
    method: "GET"
  })
    .then(response => {
      return response.json();
    })
    .then(json => {
      console.log(json);
    });
}

/**
 * Creates a new resource.
 * @param {Object} newTodo Creates a new review
 */
function postTodo(newTodo) {
  // A POST request to http://localhost:3000/todos
  fetch(`${host}/todos`, {
    method: "POST",
    body: JSON.stringify(newTodo),
    headers: {
      "Content-Type": "application/json",
      Accept: "application/json"
    }
  })
    .then(response => {
      return response.json();
    })
    .then(json => {
      console.log(json);
    });
}

/**
 * Updates an existing resource.
 * @param {Number} id The id of the resource to update.
 * @param {Object} existingTodo The resource to update on the server.
 */
function putTodo(id, existingTodo) {
  // A PUT request to http://localhost:3000/todos/1
  fetch(`${host}/todos/${id}`, {
    method: "PUT",
    body: JSON.stringify(existingTodo),
    headers: {
      "Content-Type": "application/json",
      Accept: "application/json"
    }
  })
    .then(response => {
      console.log(`Updated, Response Status: ${response.status}`)
    });
}

/**
 * Deletes a resource by id.
 * @param {Number} id The resource to delete.
 */
function deleteTodo(id) {
  // A DELETE request to http://localhost:3000/todos/1
  fetch(`${host}/todos/${id}`, {
    method: "DELETE"
  });
}
