
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
    
    const addReagentForm = document.querySelector('.reagent-add');
    if(addReagentForm) {
        addReagentForm.addEventListener("submit", (e) => {
            e.preventDefault();
            
            const formData = new FormData();
            formData.append("name", addReagentForm.elements["name"].value);
            if(addReagentForm.elements["companyId"].value) {
                const selectedOption = document.querySelector(`#fruitsList option[value="${addReagentForm.elements["companyId"].value}"]`);
                console.log(selectedOption.dataset.id);
                formData.append("companyId", selectedOption.dataset.id);
            }
            
            const instructionPdf = document.querySelector(".form-file").files[0];
            formData.append("instructionPdf", instructionPdf);

            const successfully = document.querySelector('.successfully');
            console.log(successfully);
            successfully.textContent = 'Компания успешно добавлена';
            setTimeout(function() {
                successfully.textContent = '';
            }, 4000);


            fetch("/api/reagents/add", {
                method: "POST",
                body: formData
            }).then(data => {
                console.log("Success:", data);
                addReagentForm.reset()
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
                            <td><a href="/admin/reagent/edit/${product.id}">${product.name}</a></td>
                            <td style="font-weight: 700; font-size: 20px">${product.companyName}</td>
                            <td><a href="/images/reagents/${product.instructionPdf}">PDF</a></td>
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






    const updateReagentForm = document.querySelector('form.reagent-edit');

    
    if(updateReagentForm) {
        
        updateReagentForm.addEventListener("submit", (e) => {
            e.preventDefault();

            const formData = new FormData();
            formData.append("name", updateReagentForm.elements["name"].value);
            if(updateReagentForm.elements["companyId"].value) {
                const selectedOption = document.querySelector(`#fruitsList option[value="${updateReagentForm.elements["companyId"].value}"]`);
                formData.append("companyId", selectedOption.dataset.id);
            }

            const instructionPdf = document.querySelector(".form-file").files[0];
            console.log(instructionPdf);
            formData.append("instructionPdf", instructionPdf);

            const successfully = document.querySelector('.successfully');
            console.log(successfully);
            successfully.textContent = 'Компания успешно добавлена';
            setTimeout(function() {
                successfully.textContent = '';
            }, 4000);


            fetch("/api/reagents/update", {
                method: "POST",
                body: formData
            }).then(data => {
                console.log("Success:", data);
            });
        });
    }
    
    
    
});
