document.addEventListener("DOMContentLoaded", () => {
    
    const addProductForm = document.querySelector('.product-add');
    if(addProductForm) {
        const shippingContainer = document.querySelector(".datalist-company");
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

        const shippingContainer2 = document.querySelector(".datalist-product-category");
        apiRequest("/api/productcategory/get", "GET", null,
            (response) => {
                let tbodyInnerHtml = '';
                response.forEach((product) => {
                    const productCategort = `
                        <option data-id="${product.id}" value="${product.name}">
                    `;
                    tbodyInnerHtml += productCategort;
                });
                shippingContainer2.innerHTML = tbodyInnerHtml;
            },
            (error, response) => {
                console.log("error", error);
            },
            null,
            false);
        
        addProductForm.addEventListener("submit", (e) => {
            e.preventDefault();
            
            const formData = new FormData();


            if(addProductForm.elements["productCategoriesId"].value) {
                const selectedOption = document.querySelector(`#fruitsList1 option[value="${addProductForm.elements["productCategoriesId"].value}"]`);
                formData.append("productCategoriesId", selectedOption.dataset.id);
            }

            if(addProductForm.elements["companyId"].value) {
                const selectedOption = document.querySelector(`#fruitsList option[value="${addProductForm.elements["companyId"].value}"]`);
                formData.append("companyId", selectedOption.dataset.id);
            }
            formData.append("longNamePrefix", addProductForm.elements["longNamePrefix"].value);
            formData.append("description", addProductForm.elements["description"].value);
            formData.append("url", addProductForm.elements["url"].value);
            formData.append("techInfo", addProductForm.elements["techInfo"].value);
            formData.append("type", addProductForm.elements["type"].value);
            formData.append("cardTitle", addProductForm.elements["cardTitle"].value);
            formData.append("modelSeries", addProductForm.elements["modelSeries"].value);
            formData.append("model", addProductForm.elements["model"].value);


            const imgProduct = document.querySelectorAll(".form-file");
            imgProduct.forEach((img, i) => {
                formData.append(`img${i}`, img.files[0]);
            })

            // const res = imgProduct.map(img => img);


            // for (const r of res) {
            //     console.log(r.files[0]);
            //     formData.append('url', r);
            // }
            

            fetch("/api/products/add", {
                method: "POST",
                body: formData
            }).then(data => {
                const successfully = document.querySelector('.successfully');
                successfully.textContent = 'Реагент успешно добавлен';

                setTimeout(function() {
                    successfully.textContent = '';
                }, 4000);

                console.log("Success:", data);
                addProductForm.reset()
            });
        });
        
        
        
    }
    
});