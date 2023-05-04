let btnHed = document.querySelectorAll('.at-the-right-edge .hed');
btnHed.forEach(el => {
    console.log(el);
    el.addEventListener('click', () => {
        el.nextElementSibling.classList.toggle("show");
    })
})