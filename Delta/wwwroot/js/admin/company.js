﻿


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


                





apiRequest('/api/companies/get', 'GET', null,
    (response) => {

        const tableCompany = document.querySelector('table');
        if(tableCompany) {
            response.forEach(el => {
                const company = `
                <tr class="tr" data-index="${el.id}">
                    <td>${el.name}</td>
                    <td>${el.description}</td>        
                    <td>
                        <button class="delete-company">
                            <img src="/images/icon/garbage.svg" alt="delete">
                        </button>
                    </td>
                </tr>                                                                                     
            `;
                tableCompany.innerHTML += company;

            });
        }
        
        // fragment
        tableCompany.addEventListener('click', (e) => {
            e.preventDefault();
            if(e.target.classList.contains('delete-company')) {
                const tr = e.target.closest('tr');
                const id = tr.dataset.index;
                apiRequest('/api/companies/delete/'+id, 'DELETE', null,
                    (response) => {
                        console.log('completed', response);
                        tr.remove();
                    },
                    (error, response) => {
                        console.log('crashed', error, response);
                    }, null,
                    true)
            }
        });
        
    },
    (error) => {
        console.log("Error  getting reviews: " + error);
    }, null, false);

    

    
    
    
    
    

