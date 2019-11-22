// filename: fetchtxt.js

// Hook up the fetch buttons
document.addEventListener('DOMContentLoaded', () => {
    document.getElementById('fetchText').addEventListener('click', (e) => {

        // Why do we NOT have to preventDefault here???
        fetchTextFileVerbose();
    });
    document.getElementById('fetchPark').addEventListener('click', (e) => {
        fetchParkData();
    });
});

let npsURL = 'https://developer.nps.gov/api/v1/parks?parkCode=cuva&fields=images&api_key=sarrXt7VtO7SLrLPx4h2DzH7uE5ZdtMyFlub7BXY';
/*
    Fetch data from a text file and parse the response. (Embedded then's)
*/

function fetchTextFile() {
    console.log('fetchTextFile 1');
    clearImages();
    fetch('demo.txt')           // sends an HTTP request to the relative path 'demo.txt'
        .then((response) => {   // get a Response object once this completes
            console.log('fetchTextFile 2');
            response.text()     // Call async function to get the text from the response
                .then((txt) => {   // get a string once that completes
                    console.log('fetchTextFile 3');
                    console.log(txt);   // log the string data
                    document.getElementById('results').innerText = txt
                })
        });
    console.log('fetchTextFile 4');
}

/*
    VERBOSE version of the text fetch
*/
function fetchTextFileVerbose() {
    console.log('fetchTextFile 1');
    clearImages();

    // Call fetch and get back a Promise of a Response
    let responsePromise = fetch('demo.txt');
    console.log(responsePromise);

    // Thee the Response what code you want to run when the Promise is fulfilled (.then)
    responsePromise.then(
        (resp) => {
            console.log('fetchTextFile 2');

            // Call the text() function which returns to us a Promise of a string
            let stringPromise = resp.text();
            console.log(responsePromise);
            console.log(stringPromise);

            // Tell the string Promise what to do when it gets the text (.then)
            stringPromise.then(
                (str) => {
                    // We finally got what we were asking for.  Do something with it.
                    console.log('fetchTextFile 3');
                    console.log(stringPromise);
                    console.log(str);
                    document.getElementById('results').innerText = str;
                }
            );
        }
    );
    console.log('fetchTextFile 4');
}



function fetchParkData() {
    console.log('fetchParkData 1');
    clearImages();
    fetch(npsURL)             // sends an HTTP request to the nps parks api
        .then((response) => {       // get a Response object once this completes
            console.log('fetchParkData 2');

            // A bad status code (like forbidden) is not an ERR (so will not be caught in catch). We have to check the response code.
            if (response.ok) {
                // 200 status, continue
                response.json()         // Call async function to get the json from the response
                .then((json) => {       // get a string once that completes
                    console.log('fetchParkData 3');
                    console.log(json);   // log the string data
                    const parks = json;     // The api returns a collection of parks
                    if (parks.data.length > 0) {
                        const park = parks.data[0];
                        document.getElementById('results').innerText = park.description;
                        addImages(park.images)
                    }
                })
            }
            else
            {
                document.getElementById('results').innerText = `BAD STATUS CODE: ${response.status} ${response.statusText}`;
            }
        }).catch ( (err) => {
            console.log(err);
            document.getElementById('results').innerText = `There was an ERROR: ${err}`;
        })
        ;
    console.log('fetchParkData 4');
}

function clearImages(){
    const container = document.getElementById('imageContainer');
    container.innerHTML = '';
}
function addImages(images)
{
    const container = document.getElementById('imageContainer');
    images.forEach(
        (image) => {
            const img = document.createElement('img');
            img.src = image.url;
            container.appendChild(img);
        }
    );
}


/*
    Fetch data from a text file and parse the response. (CHAINED then's)
*/
// fetch('demo.txt')               // sends an HTTP request to the relative path 'demo.txt'
//     .then((response) => {       // get a Response object once this completes
//         return response.text(); // Call async function to get the text from the response
//     }).then((txt) => {          // get a string once that completes
//         console.log(txt);       // log the string data
//         document.getElementById('results').innerText = txt
//     });

/*
    VERBOSE version of the above
*/
// let responsePromise = fetch('demo.txt');
// let stringPromise;
// console.log(responsePromise);
// responsePromise.then(
//     (resp) => {
//         stringPromise = resp.text();
//         console.log(responsePromise);
//         console.log(stringPromise);
//         return stringPromise;
//     }
// ).then( (str) => {
//     console.log(stringPromise);
//     console.log(str);
//     document.getElementById('results').innerText = str;
// });




/*
    Fetch and Catch
    Note that catch only catches network-type errors. If the call completes with a bad http response,
    it will not be caught.  You must check for a good response code.
*/
// fetch('demoxxx.txt')            // sends an HTTP request to the relative path 'demo.txt'
//     .then((response) => {       // get a Response object once this completes
//         if (response.ok) {
//         response.text()         // Call async function to get the text from the response
//         .then( (txt) => {       // get a string once that completes
//             console.log(txt);   // log the string data
//             document.getElementById('results').innerText = txt
//         })
//     }
//     else
//     {
//         console.log(`BAD STATUS CODE: ${response.status} ${response.statusText}`)
//     }
//     }).catch ( (err) => {
//         console.log(`There was an ERROR: ${err}`);
//     });



