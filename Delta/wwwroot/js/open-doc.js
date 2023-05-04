let imgDoc = document.querySelectorAll('.emptyTable .doc');

imgDoc.forEach(d => {
    console.log(d);
        d.addEventListener('click', () => {
        d.previousElementSibling.classList.add('active-img');
        body.classList.add('no-scroll');     
    })
})
imgDoc.forEach(d => {
    d.previousElementSibling.addEventListener("click", () => {
        if(imgDoc.previousElementSibling.classList.contains('active-img')){
            d.previousElementSibling.classList.remove('active-img');
            body.classList.remove('no-scroll');
        }
    })
})
