
document.addEventListener('DOMContentLoaded', () => {
    
    const aboutusTable = document.querySelector("div.aboutus");
    if(aboutusTable) {
        apiRequest("/api/aboutus/get", "GET", null,
            (response) => {
                const tbody = aboutusTable.querySelector("tbody");
                let tbodyInnerHtml = '';
                response.forEach((product) => {
                    const rowHtml = `
                    <tr>
                        <td><a href="/admin/aboutus/edit/${product.id}">${product.title}</a></td>
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

        aboutusTable.addEventListener('click', (e) => {
            if(e.target.classList.contains('delete')) {
                const tr = e.target.closest('tr');
                let id = e.target.dataset.id;

                apiRequest('/api/aboutus/delete/'+id, 'DELETE', null,
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


    
    const addAboutUsAddForm = document.querySelector('.about-us-add');
    if(addAboutUsAddForm) {
        
        let toolbaroptions = [
            ["bold", "italic", "underline", "strike"],
            [{header:[1,2,3,4,5,6, false]}],
            [{list:"ordered"}, {list:"bullet"}],
            [{script:"sub"}, {script:"super"}],
            [{indent:"+1"}, {indent: "-1"}],
            [{align:[]}],
            [{size:["small", "large", "huge", false]}],
            // ["image", "link", "video", 'formula'],
            [{color:[]}, {background:[]}],
            [{font:[]}],
        ]

        let quill = new Quill("#largeText", {
            modules:{
                toolbar: toolbaroptions,
            },
            theme:"snow"
        })





    addAboutUsAddForm.addEventListener('submit', (e) => {
            e.preventDefault();
            const requestData = {};
            const html = document.querySelector('.ql-editor');
            requestData["Title"] = html.innerHTML;
            
            const successfully = document.querySelector('.successfully');
            
            apiRequest('/api/aboutus/add', 'POST', requestData,
                (response) => {
                    successfully.textContent = 'О нас успешно добавлено';
                    setTimeout(function() {
                        successfully.textContent = '';
                    }, 4000);
                    
                    document.querySelector('.ql-editor').textContent = '';
                    
                    console.log('completed', response);
                },
                (error, response) => {
                    console.log('crashed', error, response);
                }, null,
                true)
        });
    }



    const editAboutUsAddForm = document.querySelector('.about-us-edit');
    if (editAboutUsAddForm) {


        console.log(2);
        apiRequest("/api/aboutus/get", "GET", null,
            (response) => {
                response.forEach(el => {
                    if (document.querySelector('.ql-container').dataset.id == el.id) {
                        document.querySelector('.ql-editor').innerHTML = el.title;
                    }
                })
            },
            (error, response) => {
                console.log("error", error);
            },
            null,
            false);
        
        
        
        let toolbaroptions = [
            ["bold", "italic", "underline", "strike"],
            [{header:[1,2,3,4,5,6, false]}],
            [{list:"ordered"}, {list:"bullet"}],
            [{script:"sub"}, {script:"super"}],
            [{indent:"+1"}, {indent: "-1"}],
            [{align:[]}],
            [{ size: ["small", "large", "huge", false] }],
            [ "link", "formula"],
            // ["image", "link", "video", 'formula'],
            [{color:[]}, {background:[]}],
            [{font:[]}],
        ]

        let quill = new Quill("#largeText", {
            modules:{
                toolbar: toolbaroptions,
            },
            theme:"snow"
        })


        


        editAboutUsAddForm.addEventListener('submit', (e) => {
            e.preventDefault();
            const requestData = {};
            const html = document.querySelector('.ql-editor');
            
            console.log(document.querySelector('.id-aboutas'));
            requestData["Id"] = html.parentElement.dataset.id;
            requestData["Title"] = html.innerHTML;





            const successfully = document.querySelector('.successfully');
            
        
            apiRequest('/api/aboutus/update', 'POST', requestData,
                (response) => {
                    successfully.textContent = 'О нас успешно отредактировано';
                    setTimeout(function() {
                        successfully.textContent = '';
                    }, 4000);
                    
                    console.log('completed', response);
                },
                (error, response) => {
                    console.log('crashed', error, response);
                }, null,
                true)
        });






        
        
        
        
        
    }
    
    
    
    
});