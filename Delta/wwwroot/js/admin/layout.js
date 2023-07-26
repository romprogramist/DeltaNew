document.addEventListener('DOMContentLoaded', () => {


    const telInputs = document.querySelectorAll('input[type=tel]');
    phoneMask(telInputs);

    modalsInit();

    const logoutButton = document.querySelector('.logout');
    logoutButton.addEventListener('click', () => {
        localStorage.removeItem('token');
        window.location.href = '/user/login';
    });


    const currentURL = window.location.pathname;
    const lis = document.querySelectorAll('li');

    document.querySelector('ul').addEventListener('click', (e) => {
        if (e.target.tagName === 'A') {
            lis.forEach(li => {
                li.classList.remove('active-link');
            });
            const clickedLi = e.target.closest('li');
            clickedLi.classList.add('active-link');
        }
    });

    lis.forEach(li => {
        const link = li.querySelector('a');
        if (link.pathname === currentURL) {
            li.classList.add('active-link');
        }
    });


    


    //
    // const name = document.getElementById("name");
    // const password = document.getElementById("description");
    // const data = {
    //     Name: name.value,
    //     Description: password.value
    // };
    //
    //
    // function sendRequest()


});