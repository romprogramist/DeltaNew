let img = document.querySelectorAll('.emptyTable .img');
const body = document.querySelector('body');
img.forEach(img => {
    img.addEventListener('click', () => {
        if(img.classList.contains('active-img')){
            img.classList.remove('active-img');
            body.classList.remove('no-scroll');
        }
        else {
            img.classList.add('active-img');
            body.classList.add('no-scroll');
        }
    })
})




