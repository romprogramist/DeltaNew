

const dropdowns = document.getElementsByClassName('dropdown');

Array.from(dropdowns).forEach(function(element) {
    element.firstElementChild.addEventListener('click', function() {
        element.lastElementChild.classList.toggle('show');
    });
});