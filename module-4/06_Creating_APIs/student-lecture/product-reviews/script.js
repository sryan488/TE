const host = "https://localhost:44359/api";
const review = {
  title: "Review",
  review: "This was a good product",
  avatar: "https://via.placeholder.com/150",
  name: "Anonymous",
  createdAt: "2019-08-02T04:23:04.763Z"
};

document.addEventListener("DOMContentLoaded", () => {
  document.querySelector("#getReviews").addEventListener("click", e => {
    getReviews();
  });
  document.querySelector("#getReview").addEventListener("click", e => {
    getReview(1);
  });
  document.querySelector("#postReview").addEventListener("click", e => {
    postReview(review);
  });
  document.querySelector("#putReview").addEventListener("click", e => {
    putReview(1, review);
  });
  document.querySelector("#deleteReview").addEventListener("click", e => {
    deleteReview(1);
  });
});

/**
 * Gets all resources.
 */
function getReviews() {
  fetch(`${host}/reviews`, {
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
function getReview(id) {
  fetch(`${host}/reviews/${id}`, {
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
 * @param {Object} newReview Creates a new review
 */
function postReview(newReview) {
  // A POST request to http://localhost:3000/reviews
  fetch(`${host}/reviews`, {
    method: "POST",
    body: JSON.stringify(newReview),
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
 * @param {Object} existingReview The resource to update on the server.
 */
function putReview(id, existingReview) {
  // A PUT request to http://localhost:3000/reviews/1
  fetch(`${host}/reviews/${id}`, {
    method: "PUT",
    body: JSON.stringify(existingReview),
    headers: {
      "Content-Type": "application/json",
      Accept: "application/json"
    }
  })
    .then(response => {
      console.log(`Updated, Received ${response.status}`);    
    });
}

/**
 * Deletes a resource by id.
 * @param {Number} id The resource to delete.
 */
function deleteReview(id) {
  // A DELETE request to http://localhost:3000/reviews/1
  fetch(`${host}/reviews/${id}`, {
    method: "DELETE"
  });
}
