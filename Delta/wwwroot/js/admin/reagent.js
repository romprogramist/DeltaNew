

if(document.querySelector('.add-btn')) {
    document.querySelector('.add-btn').addEventListener('click', (e) => {
        e.preventDefault();
        const name = document.getElementById("name");
        const CompanyId = document.getElementById("CompanyId");
        
        const data = {
            Name: name.value,
            CompanyId: CompanyId.value
        };
        const formElement = document.querySelector('form');
        formElement.reset();
        apiRequest('/api/reagents/add', 'POST', data,
            (response) => {
                const successfully = document.querySelector('.successfully');
                successfully.textContent = 'Реагент успешно добавлена';
                setTimeout(function() {
                    successfully.textContent = '';
                }, 4000);
            },
            (error, response) => {
                console.log('crashed', error, response);
            }, null,
            true);
    });
}


// apiRequest('/api/reagents/get', 'GET', null,
//     (response) => {
//         const fragment = document.createDocumentFragment();
//         const tableCompany = document.querySelector('table');
//         if(tableCompany) {
//            
//             response.forEach((reagent, i) => {
//
//                 const tr = document.createElement('tr');
//                 // const headingElement = document.createElement('h1');
//                 // const paragraphElement = document.createElement('p');
//                 // const buttonElement = document.createElement('button');
//                
//                 apiRequest('/api/companies/get', 'GET', null,
//                     (response) => {
//                         if(response[i].id === reagent.companyId) {
//                             console.log(response[i]);
//                         }
//                     },
//                     (error, response) => {
//                         console.log('crashed', error, response);
//                     }, null,
//                     true)        
//             });
//         }
//     },
//     (error) => {
//         console.log("Error  getting reviews: " + error);
//     }, null, false);