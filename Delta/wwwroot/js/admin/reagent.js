
document.addEventListener("DOMContentLoaded", () => {

    const shippingContainer = document.querySelector("div datalist");
    if(shippingContainer) {
        apiRequest("/api/companies/get", "GET", null,
            (response) => {
                let tbodyInnerHtml = '';
                response.forEach((product) => {
                    const company = `
                        <option data-id="${product.id}" value="${product.name}">
                    `;
                    tbodyInnerHtml += company;
                });
                shippingContainer.innerHTML = tbodyInnerHtml;
            },
            (error, response) => {
                console.log("error", error);
            },
            null,
            false);
    }
    
    const addReagentForm = document.querySelectorAll('.reagent-add');
    if(addReagentForm) {
        addReagentForm.forEach(f => {
            f.addEventListener('submit', (e) => {
                e.preventDefault();
                const requestData = {};
                document.querySelectorAll('input').forEach(i => {
                    requestData[i.name] = i.value;
                    if(i.name === 'CompanyId') {
                        const selectedOption = document.querySelector(`#fruitsList option[value="${i.value}"]`);
                        requestData[i.name] = selectedOption.dataset.id
                    }
                });
                console.log(requestData);
                
                const successfully = document.querySelector('.successfully');
                successfully.textContent = 'Реагент успешно добавлена';
                setTimeout(function() {
                    successfully.textContent = '';
                }, 4000);


                apiRequest('/api/reagents/add', 'POST', requestData,
                    (response) => {
                        document.querySelector('form').reset()
                        console.log('completed', response);
                    },
                    (error, response) => {
                        console.log('crashed', error, response);
                    }, null,
                    true)
            });
        });
    }



    const reagentTable = document.querySelector("div.reagent");
    if(reagentTable) {
        apiRequest("/api/reagents/get", "GET", null,
            (response) => {
                const tbody = reagentTable.querySelector("tbody");
                let tbodyInnerHtml = '';
                response.forEach((product) => {
                    const rowHtml = `
                        <tr>
                            <td><a href="/admin/reagents/edit/${product.id}">${product.name}</a></td>
                            <td>${product.companyName}</td>
                            <td><img data-id="${product.id}" class="delete" src="/images/icon/garbage.svg" alt=""></td>
                        </tr>
                    `;
                    tbodyInnerHtml += rowHtml;
                });
                tbody.innerHTML = tbodyInnerHtml;
            },
            (error, response) => {
                console.log("error", error);
            },
            null,
            false);

        reagentTable.addEventListener('click', (e) => {
            if(e.target.classList.contains('delete')) {
                const tr = e.target.closest('tr');
                let id = e.target.dataset.id;

                apiRequest('/api/reagents/delete/'+id, 'DELETE', null,
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
    }
    

});

