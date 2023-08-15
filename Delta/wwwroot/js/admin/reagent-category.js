
document.addEventListener("DOMContentLoaded", () => {
    const reagentCategoryTable = document.querySelector("div.reagent-category");
    if(reagentCategoryTable) {
        apiRequest("/api/reagentcategories/get", "GET", null,
            (response) => {
                const tbody = reagentCategoryTable.querySelector("tbody");
                let tbodyInnerHtml = '';
                response.forEach((product) => {
                    const rowHtml = `
                        <tr>
                            <td><a href="/admin/reagentcategories/edit/${product.id}">${product.name}</a></td>
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
        
        reagentCategoryTable.addEventListener('click', (e) => {
            if(e.target.classList.contains('delete')) {
                const tr = e.target.closest('tr');
                let id = e.target.dataset.id;

                apiRequest('/api/reagentcategories/delete/'+id, 'DELETE', null,
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

    
    const addReagentCategoryForm = document.querySelectorAll('.reagent-category-add');
    if(addReagentCategoryForm) {
        addReagentCategoryForm.forEach(f => {
            f.addEventListener('submit', (e) => {
                e.preventDefault();
                const requestData = {};
                document.querySelectorAll('input').forEach(i => {
                    console.log(i);    
                    requestData[i.name] = i.value;
                });


                const successfully = document.querySelector('.successfully');
                successfully.textContent = 'Категория реагентов успешно добавлена';
                setTimeout(function() {
                    successfully.textContent = '';
                }, 4000);
                
                
                apiRequest('/api/reagentcategories/add', 'POST', requestData,
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
    
    



    const updateReagentCategoryForm = document.querySelector('form.reagentcategory-edit');
    console.log(updateReagentCategoryForm);
    if(updateReagentCategoryForm) {
            updateReagentCategoryForm.addEventListener('submit', (e) => {
                e.preventDefault();
                const requestData = {};
                document.querySelectorAll('input').forEach(i => {
                    console.log(i);
                    requestData[i.name] = i.value;
                });

                const successfully = document.querySelector('.successfully');
                successfully.textContent = 'Категория реагентов успешно отредактирована';
                setTimeout(function() {
                    successfully.textContent = '';
                }, 4000);
                
                apiRequest('/api/reagentcategories/update', 'POST', requestData,
                    (response) => {
                        console.log('completed', response);
                    },
                    (error, response) => {
                        console.log('crashed', error, response);
                    }, null,
                    true)
            });
    }
    
    

    
});

