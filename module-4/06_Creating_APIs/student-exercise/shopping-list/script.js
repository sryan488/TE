const host = "https://localhost:44322/api";
const grocery = {
  completed: false,
  name: "Apples"
};

document.addEventListener("DOMContentLoaded", () => {
  document.querySelector("#getGroceries").addEventListener("click", e => {
    getGroceries();
  });
  document.querySelector("#getGrocery").addEventListener("click", e => {
    getGrocery(1);
  });
  document.querySelector("#postGrocery").addEventListener("click", e => {
    postGrocery(grocery);
  });
  document.querySelector("#putGrocery").addEventListener("click", e => {
    putGrocery(1, grocery);
  });
  document.querySelector("#deleteGrocery").addEventListener("click", e => {
    deleteGrocery(1);
  });
});

/**
 * Gets all resources.
 */
function getGroceries() {
  fetch(`${host}/groceries`, {
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
function getGrocery(id) {
  fetch(`${host}/groceries/${id}`, {
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
 * @param {Object} newGrocery Creates a new grocery
 */
function postGrocery(newGrocery) {
  // A POST request to http://localhost:3000/groceries
  fetch(`${host}/groceries`, {
    method: "POST",
    body: JSON.stringify(newGrocery),
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
 * @param {Object} existingGrocery The resource to update on the server.
 */
function putGrocery(id, existingGrocery) {
  // A PUT request to http://localhost:3000/groceries/1
  fetch(`${host}/groceries/${id}`, {
    method: "PUT",
    body: JSON.stringify(existingGrocery),
    headers: {
      "Content-Type": "application/json",
      Accept: "application/json"
    }
  })
    .then(response => {
      console.log(`Updated, Response Status: ${response.status}`);
    });
}

/**
 * Deletes a resource by id.
 * @param {Number} id The resource to delete.
 */
function deleteGrocery(id) {
  // A DELETE request to http://localhost:3000/groceries/1
  fetch(`${host}/groceries/${id}`, {
    method: "DELETE"
  });
}
