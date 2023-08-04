console.log(1);
document.addEventListener("DOMContentLoaded", () => {
    const productTable = document.querySelector("div.companies");
    if(productTable) {
        apiRequest("/api/reagentcategories/get", "GET", null,
            (response) => {
            // console.log(response);
                const tbody = productTable.querySelector("tbody");
                let tbodyInnerHtml = '';
                response.forEach((product) => {
                    const rowHtml = `
                        <tr>
                            <td><a href="/admin/company/edit/${product.id}">${product.name}</a></td>
                            <td><img data-id="${product.id}" class="delete-company" src="/images/icon/garbage.svg" alt=""></td>
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




    //
        productTable.addEventListener('click', (e) => {
            if(e.target.classList.contains('delete-company')) {

                const tr = e.target.closest('tr');
                let id = e.target.dataset.id;
                console.log(id)
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
    //
    //
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

            fetch("/api/reagentcategories/update", {
                method: "POST",
                body: formData
            }).then(data => {
                console.log("Success:", data);
            });
        });
    }


    // document.querySelectorAll('.delete-company').forEach(del => {
    //     del.addEventListener('click', (e) => {
    //         e.preventDefault();
    //         const tr = e.target.closest('tr');
    //         const id = document.querySelector('tr[data-id]').dataset.id;
    //
    //         apiRequest('/api/companies/delete/'+id, 'DELETE', null,
    //             (response) => {
    //                 console.log('completed', response);
    //                 tr.remove();
    //             },
    //             (error, response) => {
    //                 console.log('crashed', error, response);
    //             }, null,
    //             true)
    //
    //     });
    // })

});

