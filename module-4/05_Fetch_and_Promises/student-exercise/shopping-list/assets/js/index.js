let button = document.getElementsByClassName("loadingButton");

Array.from(button).forEach((element) => {
  element.addEventListener('click', ()=>{


fetch("assets/data/shopping-list.json")
  .then((response) => {
    return response.json();
  })
  .then((items) => {
    if('content' in document.createElement('template')) {
      const list = document.querySelector("ul");
      items.forEach((item) => {
        const tmpl = document.getElementById('shopping-list-item-template').content.cloneNode(true);
        tmpl.querySelector("li").insertAdjacentHTML('afterbegin',item.name);
        if( item.completed ) {
          const circleCheck = tmpl.querySelector('.fa-check-circle');
          circleCheck.className += " completed";
        }
        list.appendChild(tmpl);
      });
    } else {
      console.error('Your browser does not support templates');
    }
  })
  .catch((err) => {console.error(err)});
});
})
