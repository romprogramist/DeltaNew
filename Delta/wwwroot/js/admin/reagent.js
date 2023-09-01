
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
        
        const containerForOption = document.querySelector(".options-container");
        apiRequest("/api/reagentcategories/get", "GET", null,
            (response) => {
                let tbodyInnerHtml = '';
                response.forEach((product) => {
                    const reagentCattegory = `
                        <div class="option"><input type="checkbox" value="${product.id}">${product.name}</div>
                    `;
                    tbodyInnerHtml += reagentCattegory;
                });
                containerForOption.insertAdjacentHTML("beforeend", tbodyInnerHtml);

                //Функция, обеспечивающая возможность фильтрации избыточных элементов.
                const optionsContainer = document.getElementById("optionsContainer");
                const categorySearchInput = optionsContainer.querySelector("#categorySearchInput");
                const selectedReagentsInput = document.getElementById("selectedReagents");
                
                const optionItems = optionsContainer.querySelectorAll(".option");

                const selectedOptions = new Set();
                

                document.getElementById("selectHeader").addEventListener("click", function(event) {
                    optionsContainer.style.display = optionsContainer.style.display === "block" ? "none" : "block";

                    document.querySelectorAll('.category-spacer').forEach(el => {
                        const categoryValue = el.id;

                        optionItems.forEach(o => {
                            const optionValue = o.firstElementChild.value;

                            if (categoryValue === optionValue) {
                                o.firstElementChild.checked = true;
                                o.firstElementChild.addEventListener('click', () => {
                                    if(!o.firstElementChild.checked) {
                                        o.firstElementChild.value = "";
                                        el.textContent = '';
                                    } else {
                                        console.log(o.textContent);
                                        o.firstElementChild.value = o.textContent;
                                    }
                                })
                            }
                        });
                    });
                    
                    
                    
                    
                    
                    
                    
                    event.stopPropagation();
                });

                optionsContainer.addEventListener("click", function(event) {
                    event.stopPropagation(); // Предотвратить всплытие события, чтобы клик на optionsContainer не приводил к закрытию
                });

                document.addEventListener("click", function() {
                    optionsContainer.style.display = "none";
                });
                
                categorySearchInput.addEventListener("input", function() {
                    const searchTerm = categorySearchInput.value.toLowerCase();

                    optionItems.forEach(optionItem => {
                        const optionText = optionItem.textContent.toLowerCase();
                        const checkbox = optionItem.querySelector("input[type='checkbox']");
                        optionItem.style.display = optionText.includes(searchTerm) ? "block" : "none";
                        checkbox.style.display = optionText.includes(searchTerm) ? "inline-block" : "none";
                    });
                });

                optionsContainer.addEventListener("change", function(event) {
                    if (event.target.type === "checkbox") {
                        const checkbox = event.target;
                        const optionText = checkbox.parentNode.textContent.trim();
                        checkbox.checked ? selectedOptions.add(optionText) : selectedOptions.delete(optionText);
                        updateSelectedReagentsInput();
                    }
                });

                function updateSelectedReagentsInput() {
                    selectedReagentsInput.value = [...selectedOptions].join(", ");
                }
                

                updateSelectedReagentsInput();
               

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
            formData.append("kitComposition", addReagentForm.elements["kitComposition"].value);
            if(addReagentForm.elements["companyId"].value) {
                const selectedOption = document.querySelector(`#fruitsList option[value="${addReagentForm.elements["companyId"].value}"]`);
                // console.log(selectedOption.dataset.id);
                formData.append("companyId", selectedOption.dataset.id);
            }

            const selectedOptions = Array.from(optionsContainer.querySelectorAll("input[type='checkbox']:checked"))
                    .map(checkbox => parseInt(checkbox.value));

            for (const option of selectedOptions) {
                console.log(option);
                formData.append('ReagentCategoryIds', option);
            }
            
            const instructionPdf = document.querySelector(".form-file").files[0];
            formData.append("instructionPdf", instructionPdf);

            var fieldData = [];
            formData.forEach(function(value, key) {
                fieldData.push({ key: key, value: value });
            });

            fetch("/api/reagents/add", {
                method: "POST",
                body: formData
            }).then(data => {
                const successfully = document.querySelector('.successfully');
                successfully.textContent = 'Реагент успешно добавлен';

                setTimeout(function() {
                    successfully.textContent = '';
                }, 4000);
                
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
                    console.log(product.reagentCategories);
                    const categories = product.reagentCategories.map(category => category.name).join(", ");
                    const rowHtml = `
                        <tr style="margin-top: 25px" class="tr-top">                        
                            <td style="background: #D1D1D1">БРЕНД:</span>&nbsp; ( ${ product.companyName} ) </td>                                                        
                            <td>${categories}</td>                            
                        </tr>
                        <tr>
                            <td>${product.name}</td>
                            <td>${product.kitComposition}</td>
                            <td><a href="/images/reagents/${product.instructionPdf}" target="_blank">PDF</a></td>
                            <td> <a href="/admin/reagent/edit/${product.id}">Редактировать</a></td>
                            <td data-id="${product.id}" class="delete">Удалить</td>
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
            formData.append("id", updateReagentForm.elements["id"].value);
            formData.append("name", updateReagentForm.elements["name"].value);
            formData.append("kitComposition", updateReagentForm.elements["kitComposition"].value);
            if(updateReagentForm.elements["companyId"].value) {
                const selectedOption = document.querySelector(`#fruitsList option[value="${updateReagentForm.elements["companyId"].value}"]`);
                formData.append("companyId", selectedOption.dataset.id);
            }

            const selectedOptions = Array.from(optionsContainer.querySelectorAll("input[type='checkbox']:checked"))
                .map(checkbox => parseInt(checkbox.value));

            for (const option of selectedOptions) {
                formData.append('reagentCategoryIds', option);
            }
            

            const instructionPdf = document.querySelector(".form-file").files[0];
            formData.append("instructionPdf", instructionPdf);
        
            fetch("/api/reagents/update", {
                method: "POST",
                body: formData
            }).then(data => {
                console.log("Success:", data);
            });
        });

        


        
    }
    
});
