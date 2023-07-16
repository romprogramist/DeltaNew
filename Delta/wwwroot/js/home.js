document.addEventListener('DOMContentLoaded', () => {
    
    if(!document.getElementById('development-mode')){
        // if production mode

    }
    
    // get reviews
    const reviewsContent = document.querySelector('.test');
    
    apiRequest('/api/company/approved', 'GET', null, (response) => {
        console.log(1)
        if(response) {
            // reviewsContent.textContent = JSON.stringify(response);
            reviewsContent.textContent = response[0].name;
            console.log(response[0].name);
        }
    }, (error, response) => {
        console.log('Something goes wrong with getting reviews', error, response);
    })
    
    // code here
    // const openSearchBtn = document.querySelector('.open-search-btn');
    // openSearchBtn.addEventListener('click', () => {
    //     openSearchBtn.parentElement.classList.add('desktop-form-active');
    // })



    var swiper = new Swiper(".mySwiper", {
        slidesPerView: 1.2,
        spaceBetween: 30,
        pagination: {
            el: ".swiper-pagination",
            clickable: true,
        },
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },
        
        breakpoints: {
            370: {
                slidesPerView: 1.4,
            },
            460: {
                slidesPerView: 2,
            },
            690: {
                slidesPerView: 3,
            },
            1140: {
                slidesPerView: 5,
            },
        },
    });

    

});