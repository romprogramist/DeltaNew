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



    
    function addHoverClass(elements, className) {
        function containsMyElement(element) {
            return element.classList.contains("swiper-slide-active-new") || element.closest(".swiper-slide");
        }
        function handleMouseEnter(event) {
            var targetElement = event.target;
            if (containsMyElement(targetElement)) {
                targetElement.closest(".swiper-slide").classList.add(className);
            }
        }
        function handleMouseLeave(event) {
            var targetElement = event.target;
            if (containsMyElement(targetElement)) {
                targetElement.closest(".swiper-slide").classList.remove(className);
            }
        }
        for (var i = 0; i < elements.length; i++) {
            elements[i].addEventListener("mouseenter", handleMouseEnter);
            elements[i].addEventListener("mouseleave", handleMouseLeave);
        }
    }

    const myElementsSlide = document.getElementsByClassName("swiper-slide");
    addHoverClass(myElementsSlide, "swiper-slide-active-new");

});