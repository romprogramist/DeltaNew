console.log('company.js');

document.querySelector('.add-btn').addEventListener('click', (e) => {
    e.preventDefault();
    const name = document.getElementById("name");
    const description = document.getElementById("description");
    const data = {
        Name: name.value,
        Description: description.value
    };
    apiRequest('/api/companies/add', 'POST', data,
        (response) => {
        console.log('completed', response);
    },
    (error, response) => {
        console.log('crashed', error, response);
    }, null,
        true);
});