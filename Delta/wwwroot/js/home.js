document.addEventListener('DOMContentLoaded', () => {
    
    if(!document.getElementById('development-mode')){
        // if production mode

    }
    
    // get company


    const companyContent = document.querySelector('.list-companies .list');

    apiRequest('/api/companies/approved', 'GET', null, (response) => {
        if(response) {
            let imgPath;
            for (let i = 0; i < response.length; i++) {
                imgPath = '/imagesAdditionAdmin/company/' + response[i].logo;
                let companyOne = `
                    <tr>
                        <th>${response[i].name}</th>
                        <th>${response[i].description}</th>
                        <th>
                            <img style="width: 100px; height: 30px; object-fit: cover;" src="${imgPath}" alt="" title="">
                        </th>                        
                    </tr>                                                 
                `
                companyContent.innerHTML += companyOne; 
            }
        }
    }, (error, response) => {
        console.log('Something goes wrong with getting company', error, response);
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