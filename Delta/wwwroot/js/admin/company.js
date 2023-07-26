


if(document.querySelector('.add-btn')) {
    document.querySelector('.add-btn').addEventListener('click', (e) => {
        e.preventDefault();
        const name = document.getElementById("name");
        const description = document.getElementById("description");
        const data = {
            Name: name.value,
            Description: description.value
        };
        apiRequest('/api/companies/add', 'POST', data,
            (response) => {
                console.log('completed', response);
            },
            (error, response) => {
                console.log('crashed', error, response);
            }, null,
            true);
    });    
}


                


const tabelCompany = document.querySelector('table');

if(tabelCompany){
    apiRequest('/api/companies/get', 'GET', null,
        (response) => {
            response.forEach(el => {
                let companyOne = `
                    <tr class="tr" data-index="${el.id}">
                        <td>${el.name}</td>
                        <td>${el.description}</td>        
                        <td>
                            <form class="company-deletion">
                                <button>
                                    <img src="/images/icon/garbage.svg" alt="">
                                </button>
                            </form>
                        </td>
                    </tr>                                                                                     
                `
                tabelCompany.innerHTML += companyOne;
                
            })
        },
        (error) => {
            console.log("Error  getting reviews: " + error);
        }, null, true);

    

    
    // apiRequest('/api/companies/delete/11', 'DELETE', null,
    //     (response) => {
    //         console.log('completed', response);
    //     },
    //     (error, response) => {
    //         console.log('crashed', error, response);
    //     }, null,
    //     true);
    
    
    
}
