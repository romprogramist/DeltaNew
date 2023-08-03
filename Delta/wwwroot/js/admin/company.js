
document.addEventListener("DOMContentLoaded", () => {
    const productTable = document.querySelector("div.companies");
    if(productTable) {
        apiRequest("/api/companies/get", "GET", null,
            (response) => {
                const tbody = productTable.querySelector("tbody");
                let tbodyInnerHtml = '';
                response.forEach((product) => {
                    const rowHtml = `
                        <tr>
                            <td><a href="/admin/company/edit/${product.id}">${product.name}</a></td>
                            <td>${product.description}</td>
                            <td><img src="/images/companies/${product.logo}" alt="${product.name}"/></td>
                            <td><img class="delete-company" src="/images/icon/garbage.svg" alt=""></td>
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
    }

    const addCompanyForm = document.querySelector('form.company-add');

    if(addCompanyForm) {
        addCompanyForm.addEventListener("submit", (e) => {
            e.preventDefault();
            const formData = new FormData();
            formData.append("name", addCompanyForm.elements["name"].value);
            formData.append("description", addCompanyForm.elements["description"].value);
            const logo = document.querySelector(".form-file").files[0];
            formData.append("logo", logo);


            const successfully = document.querySelector('.successfully');
            successfully.textContent = 'Компания успешно добавлена';
            setTimeout(function() {
                successfully.textContent = '';
            }, 4000);
            addCompanyForm.reset()
            
            fetch("/api/companies/add", {
                method: "POST",
                body: formData
            }).then(data => {
                console.log("Success:", data);
            });
        });
    }

    const updateCompanyForm = document.querySelector('form.company-edit');
    if(updateCompanyForm) {
        updateCompanyForm.addEventListener("submit", (e) => {
            e.preventDefault();
            console.log(updateCompanyForm.elements["id"].value);
            const formData = new FormData();
            formData.append("id", updateCompanyForm.elements["id"].value);
            formData.append("name", updateCompanyForm.elements["name"].value);
            formData.append("description", updateCompanyForm.elements["description"].value);
            const logo = document.querySelector(".form-file").files[0];
            formData.append("logo", logo);

            fetch("/api/companies/update", {
                method: "POST",
                body: formData
            }).then(data => {
                console.log("Success:", data);
            });
        });
    }


    //
    // if(productTable) {
    //     productTable.addEventListener('click', (e) => {
    //         e.preventDefault();
    //         if(e.target.classList.contains('delete-company')) {
    //             console.log('1');
    //             const tr = e.target.closest('tr');
    //             const id = tr.dataset.index;
    //            
    //             apiRequest('/api/companies/delete/'+id, 'DELETE', null,
    //                 (response) => {
    //                     console.log('completed', response);
    //                     tr.remove();
    //                 },
    //                 (error, response) => {
    //                     console.log('crashed', error, response);
    //                 }, null,
    //                 true)
    //         }
    //     });
    // }
    
});

