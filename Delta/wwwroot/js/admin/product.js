document.addEventListener("DOMContentLoaded", () => {
    
    const addProductForm = document.querySelector('.product-add');
    if(addProductForm) {
        const shippingContainer = document.querySelector("div datalist");
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
        
        
        
        
        
        
        addProductForm.addEventListener("submit", (e) => {
            e.preventDefault();
            
            const formData = new FormData();
            // formData.append("productCategoriesId", addProductForm.elements["productCategoriesId"].value);
            formData.append("longNamePrefix", addProductForm.elements["longNamePrefix"].value);
            formData.append("description", addProductForm.elements["description"].value);
            formData.append("url", addProductForm.elements["url"].value);
            formData.append("techInfo", addProductForm.elements["techInfo"].value);
            formData.append("type", addProductForm.elements["type"].value);
            formData.append("cardTitle", addProductForm.elements["cardTitle"].value);
            formData.append("modelSeries", addProductForm.elements["modelSeries"].value);
            formData.append("model", addProductForm.elements["model"].value);
            
            if(addProductForm.elements["companyId"].value) {
                const selectedOption = document.querySelector(`#fruitsList option[value="${addProductForm.elements["companyId"].value}"]`);
                formData.append("companyId", selectedOption.dataset.id);
            }


            for (const [key, value] of formData.entries()) {
                console.log(`Поле: ${key}, Значение: ${value}`);
            }
            

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