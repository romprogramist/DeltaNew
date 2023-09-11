document.addEventListener("DOMContentLoaded", () => {
    const addProductcategoryForm = document.querySelector('.productcategory-add');
    const checkbox = document.getElementById("showInput");
    const input = document.getElementById("parentCategoryId");
    const shippingContainer = document.querySelector("div datalist");
    if(addProductcategoryForm) {
        checkbox.addEventListener("change", function() {
            if (this.checked) {
                input.style.display = "inline-block";
            } else {
                input.style.display = "none";
            }
        });
        
        
        addProductcategoryForm.addEventListener("submit", (e) => {
            e.preventDefault();

            e.preventDefault();
            // Получаем выбранный элемент <option> из <datalist>
            const selectedOption = document.querySelector('#fruitsList option[value="' + addProductcategoryForm.elements["parentCategoryId"].value + '"]');
            // Получаем значение атрибута data-id выбранного элемента
            // const dataIdValue = selectedOption.getAttribute('data-id');
            
            
            

            const formData = new FormData();
            formData.append("name", addProductcategoryForm.elements["name"].value);
            formData.append("url", addProductcategoryForm.elements["url"].value);

            if (selectedOption) {
                const dataIdValue = parseInt(selectedOption.getAttribute('data-id'), 10);
                formData.append("parentCategoryId", dataIdValue); // Передаем значение data-id
            }
            
            
            const image = document.querySelector(".form-file").files[0];
            formData.append("image", image);

            fetch("/api/productcategory/add", {
                method: "POST",
                body: formData
            }).then(data => {
                if (data.ok) {
                    const successfully = document.querySelector('.successfully');
                    successfully.textContent = 'Категория продукта успешно добавлена';

                    setTimeout(function () {
                        successfully.textContent = '';
                    }, 4000);
                }
                console.log("Success:", data);
                addProductcategoryForm.reset()
            });
        });

        
        
        apiRequest("/api/productcategory/get", "GET", null,
            (response) => {
            console.log(response);
                let tbodyInnerHtml = '';
                response.forEach((product) => {
                    const productСategory = `
                        <option data-id="${product.id}" value="${product.name}"></option>
                    `;
                    tbodyInnerHtml += productСategory;
                });
                shippingContainer.innerHTML = tbodyInnerHtml;
            },
            (error, response) => {
                console.log("error", error);
            },
            null,
            false);
    }


    const productCategoryTable = document.querySelector("div.product-category");
    if(productCategoryTable){
        apiRequest("/api/productcategory/get", "GET", null,
            (response) => {
                const tbody = productCategoryTable.querySelector("tbody");
                let tbodyInnerHtml = '';
                response.forEach((product) => {
                    const rowHtml = `
                        <tr>
                            <td><a href="/admin/productcategory/edit/${product.id}">${product.name}</a></td>
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




        productCategoryTable.addEventListener('click', (e) => {
            if(e.target.classList.contains('delete')) {
                const tr = e.target.closest('tr');
                let id = e.target.dataset.id;
                console.log(id);

                apiRequest('/api/productcategory/delete/'+id, 'DELETE', null,
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




    const updateProductCategoryForm = document.querySelector('form.productcategory-edit');
    if(updateProductCategoryForm) {

        checkbox.addEventListener("change", function() {
            if (this.checked) {
                input.style.display = "inline-block";
            } else {
                input.style.display = "none";
            }
        });



        const inputElement = document.querySelector('input[name="parentCategoryId"]').value;
        
        if(inputElement) {
            checkbox.checked = true;
            input.style.display = "inline-block";
        }
        
        updateProductCategoryForm.addEventListener("submit", (e) => {
            e.preventDefault();
            const selectedOption = document.querySelector('#fruitsList option[value="' + updateProductCategoryForm.elements["parentCategoryId"].value + '"]');
            
            // Получаем значение атрибута data-id выбранного элемента
            

            const formData = new FormData();
            formData.append("id", updateProductCategoryForm.elements["id"].value);
            formData.append("name", updateProductCategoryForm.elements["name"].value);
            formData.append("url", updateProductCategoryForm.elements["url"].value);

            if (selectedOption) {
                const dataIdValue = parseInt(selectedOption.getAttribute('data-id'), 10);
                formData.append("parentCategoryId", dataIdValue); // Передаем значение data-id
            }
            
            

            const image = document.querySelector(".form-file").files[0];
            formData.append("image", image);


            // const formDataEntries = formData.entries();
            //
            // // Пройдитесь по итератору и выведите поля
            // for (const pair of formDataEntries) {
            //     console.log(`Key: ${pair[0]}, Value: ${pair[1]}`);
            // }
            

            fetch("/api/productcategory/update", {
                method: "POST",
                body: formData
            }).then(data => {
                if (data.ok) {
                    const successfully = document.querySelector('.successfully');
                    successfully.textContent = 'Категория продукта успешно изменена';

                    setTimeout(function () {
                        successfully.textContent = '';
                    }, 4000);
                }
                console.log("Success:", data);
                updateProductCategoryForm.reset()
            });
        });


        apiRequest("/api/productcategory/get", "GET", null,
            (response) => {
                console.log(response);
                let tbodyInnerHtml = '';
                response.forEach((product) => {
                    const productСategory = `
                        <option data-id="${product.id}" value="${product.name}"></option>
                    `;
                    tbodyInnerHtml += productСategory;
                });
                shippingContainer.innerHTML = tbodyInnerHtml;
            },
            (error, response) => {
                console.log("error", error);
            },
            null,
            false);
        
    }
    
});