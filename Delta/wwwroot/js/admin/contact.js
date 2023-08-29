document.addEventListener("DOMContentLoaded", () => {


    const productTable = document.querySelector("div.contact");
    if(productTable) {
        apiRequest("/api/contact/get", "GET", null,
            (response) => {
            console.log(response);
                const tbody = productTable.querySelector("tbody");
                let tbodyInnerHtml = '';
                response.forEach((product) => {
                    console.log(product);
                    const rowHtml = `
                        <tr>
                            <td><a style="font-size: 13px" href="/admin/contact/edit/${product.id}">Редактировать</a></td>
                            <td>${product.headerTimetable}</td>
                            <td>${product.monday}</td>
                            <td>${product.friday}</td>
                            <td>${product.saturday}</td>
                            <td>${product.headerNumber}</td>
                            <td>${product.address}</td>
                            <td>${product.numberOne}</td>
                            <td>${product.numberTwo}</td>
                            <td><img src="/images/companies/${product.imgBg}" alt="cool"/></td>
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

    }
    
    
    
    const addContactForm = document.querySelector('form.contact-add');
    if(addContactForm) {
        addContactForm.addEventListener("submit", (e) => {
            e.preventDefault();
            const formData = new FormData();
            formData.append("headerNumber", addContactForm.elements["headerNumber"].value);
            formData.append("numberOne", addContactForm.elements["numberOne"].value);
            formData.append("numberTwo", addContactForm.elements["numberTwo"].value);
            formData.append("headerTimetable", addContactForm.elements["headerTimetable"].value);
            formData.append("monday", addContactForm.elements["monday"].value);
            formData.append("friday", addContactForm.elements["friday"].value);
            formData.append("saturday", addContactForm.elements["saturday"].value);

            const imgBg = document.querySelector(".form-file").files[0];
            formData.append("imgBg", imgBg);
            formData.append("address", addContactForm.elements["address"].value);
            

            fetch("/api/contact/add", {
                method: "POST",
                body: formData
            }).then(data => {
                const successfully = document.querySelector('.successfully');
                successfully.textContent = 'Контакты успешно добавлены';
                setTimeout(function() {
                    successfully.textContent = '';
                }, 4000);
                console.log("Success:", data);
                addContactForm.reset()
            });
        });
    }




    const updateContactForm = document.querySelector('form.contact-edit');

    if(updateContactForm) {
        updateContactForm.addEventListener("submit", (e) => {
            e.preventDefault();
            const formData = new FormData();
            formData.append("id", updateContactForm.elements["id"].value);
            formData.append("headerNumber", updateContactForm.elements["headerNumber"].value);
            formData.append("numberOne", updateContactForm.elements["numberOne"].value);
            formData.append("numberTwo", updateContactForm.elements["numberTwo"].value);
            formData.append("headerTimetable", updateContactForm.elements["headerTimetable"].value);
            formData.append("monday", updateContactForm.elements["monday"].value);
            formData.append("friday", updateContactForm.elements["friday"].value);
            formData.append("saturday", updateContactForm.elements["saturday"].value);

            const imgBg = document.querySelector(".form-file").files[0];
            formData.append("imgBg", imgBg);
            formData.append("address", updateContactForm.elements["address"].value);


            


            fetch("/api/contact/update", {
                method: "POST",
                body: formData
            }).then(data => {

                const successfully = document.querySelector('.successfully');
                successfully.textContent = 'Компания успешно отредактирована';
                setTimeout(function() {
                    successfully.textContent = '';
                }, 4000);
                
                
                console.log("Success:", data);
            });
        });
    }
    
    
});

