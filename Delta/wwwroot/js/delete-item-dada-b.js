function deleteItemDada(route, id) {
    fetch(`${route}?id=${id}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        // body: JSON.stringify(id),
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(item => {
            // Обработка данных нового элемента, который вернулся с сервера
            console.log('Created item:', item);
        })
        .catch(error => {
            // Обработка ошибок
            console.error('Error creating item:', error);
        });
}



const companyContent = document.querySelector('.list-companies .list');
apiRequest('/api/companies/approved', 'GET', null,  (response) => {
    if(response) {
        let imgPath;
        for (let i = 0; i < response.length; i++) {
            imgPath = '/imagesAdditionAdmin/' + response[i].iFormFile;
            let companyOne = `
                <tr>
                    <th>${response[i].name}</th>
                    <th>${response[i].description}</th>
                    <th>
                        <img style="width: 100px; height: 30px; object-fit: cover;" src="${imgPath}" alt="" title="">
                    </th> 
                    <th data-index="${response[i].id}">
                        <form class="company-deletion">
                            <button>
                                <img src="/images/icon/garbage.svg" alt="">
                            </button>
                        </form>
                    </th>     
                </tr>                                                 
            `
            companyContent.innerHTML += companyOne;
        }
    }
    if(document.querySelectorAll('.company-deletion')){
        let companyDeletion = document.querySelectorAll('.company-deletion');
        companyDeletion.forEach(el => {
            el.parentElement.addEventListener('click', (e) => {
                deleteItemDada('/api/companies/id', el.parentElement.getAttribute('data-index'))
            })
        })
    }
    
}, (error, response) => {
    console.log('Something goes wrong with getting company', error, response);
}, {
    'Content-Type': 'application/json; charset=utf-8'
})
















deleteItemDada('/api/companiesImg/id', companyDeletion);
