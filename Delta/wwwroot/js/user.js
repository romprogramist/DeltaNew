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
        const data = {
            userName: 'arm',
            password: 'test'
        };
        
        apiRequest('/api/user/login', 'POST', data,
            (response) => {
                console.log(response);
                if(response && response.token) {
                    localStorage.setItem('token', response.token);
                }

                console.log(localStorage);
            }, (error) => {
                console.log("Error registering user: " + error);
            });
    });
});

