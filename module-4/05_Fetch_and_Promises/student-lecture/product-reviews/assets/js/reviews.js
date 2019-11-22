// An empty reviews array that we will load data into
let reviews = [];

/******************
 * TODO: Create a loadReviews function that will fetch reviews from a server, and load them into the reviews array
 */
/* Data can be found at:
  data.json
  https://my-json-server.typicode.com/blazebiz/json1/reviews
*/
function loadReviews() {
  console.log("Load Reviews...");
  const urlToFetch = 'data.json';
  //const urlToFetch = 'https://my-json-server.typicode.com/blazebiz/json1/reviews';

  // TODO: fetch data here...

}


/****************
 * TODO: Once we have a DOM, add an event listener for the button. It will call loadReviews, and then disable itself.
 */


/**
 * This function when invoked will look at an array of reviews
 * and add it to the page by cloning the #review-template
 */
function displayReviews() {
  console.log("Display Reviews...");

  // first check to make sure the browser supports content templates
  if ('content' in document.createElement('template')) {
    // query the document for .reviews and assign it to a variable called container
    const container = document.querySelector(".reviews");
    // loop over the reviews array
    reviews.forEach((review) => {
      // get the template; find all the elements and add the data from our review to each element
      const tmpl = document.getElementById('review-template').content.cloneNode(true);
      tmpl.querySelector('img').setAttribute("src", review.avatar);
      tmpl.querySelector('.username').innerText = review.username;
      tmpl.querySelector('h2').innerText = review.title;
      tmpl.querySelector('.published-date').innerText = review.publishedOn;
      tmpl.querySelector('.user-review').innerText = review.review;
      container.appendChild(tmpl);
    });
  } else {
    console.error('Your browser does not support templates');
  }
}