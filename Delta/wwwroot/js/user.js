document.addEventListener('DOMContentLoaded', () => {

    // const regButton = document.querySelector('.register');
    // regButton.addEventListener('click', () => {
    //     const data = {
    //         userName: 'arm',
    //         password: 'test'
    //     };
    //
    //     apiRequest('/api/user/register', 'POST', data,
    //         (response) => {
    //             console.log(response);
    //         }, (error) => {
    //             console.log("Error registering user: " + error);
    //         });
    // });

    const loginButton = document.querySelector('.login');
    loginButton.addEventListener('click', (e) => {
        e.preventDefault()
        const name = document.getElementById("name");
        const password = document.getElementById("password");
        const data = {
            userName: name.value,
            password: password.value
        };
        apiRequest('/api/user/login', 'POST', data,
            (response) => {
                console.log(response);
                if(response && response.token) {
                    localStorage.setItem('token', response.token);
                }

                console.log(localStorage);
                window.location.href = '/admin';
            }, (error) => {
                console.log("Error registering user: " + error);
            },
            null, 
            true);
    });
});

