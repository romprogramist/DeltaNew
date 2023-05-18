document.addEventListener('DOMContentLoaded', () => {
    if(!document.getElementById('development-mode')){
        // if production mode

    }
    
    // get reviews
    const reviewsContent = document.querySelector('.reviews-content');
    
    // apiRequest('/api/review/approved', 'GET', null, (response) => {
    //     if(response) {
    //         reviewsContent.textContent = JSON.stringify(response);
    //     }
    // }, (error, response) => {
    //     console.log('Something goes wrong with getting reviews', error, response);
    // })
    
    // code here
    const openSearchBtn = document.querySelector('.open-search-btn');
    openSearchBtn.addEventListener('click', () => {
        openSearchBtn.parentElement.classList.add('desktop-form-active');
    })



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

    // const swiper = new Swiper('.swiper', {
    //     // Optional parameters
    //     // direction: 'harizontal',
    //     loop: true,
    //
    //     // If we need pagination
    //     pagination: {
    //         el: '.swiper-pagination',
    //     },
    //
    //     // Navigation arrows
    //     navigation: {
    //         nextEl: '.swiper-button-next',
    //         prevEl: '.swiper-button-prev',
    //     },
    //
    //     // And if we need scrollbar
    //     scrollbar: {
    //         el: '.swiper-scrollbar',
    //     },
    // });

    // var swiper = new Swiper('.swiper', {
    //     slidesPerView: 'auto',
    //     spaceBetween: 20,
    //     centeredSlides: true,
    //     loop: true, // Добавляем параметр loop: true
    //     pagination: {
    //         el: '.swiper-pagination',
    //         clickable: true,
    //     },
    //     navigation: {
    //         nextEl: '.swiper-button-next',
    //         prevEl: '.swiper-button-prev',
    //     },
    // });


});