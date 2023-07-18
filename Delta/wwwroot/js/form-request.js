function formRequest(forms, apiURL, requestCompletedModal, requestCrashedModal, inputNames) {
    forms.forEach(f => {
        f.addEventListener('submit', (e) => {
            e.preventDefault();

            const inputs = [];
            inputNames.forEach(i => {
                if(f.elements[i]) {
                    inputs.push(f.elements[i]);
                }
            });

            const validation = f.querySelector('.validation');

            if (validation) {
                validation.classList.remove('show');
                validation.textContent = '';
            }
        

            const requestData = {};
            inputs.forEach(i => {
                requestData[i.name] = i.value;
            });

            const utmInfo = getCookie('utm_info');
            requestData.utmInfo = utmInfo ? utmInfo : '';

            const sitePage = document.title;
            requestData.sitePage = sitePage ? sitePage : '';

            apiRequest(apiURL, 'POST', requestData, () => {
                setTimeout(() => {
                    hideLoader();
                    showModal(requestCompletedModal);
                    f.reset();
                    if(!document.getElementById('development-mode')){
                        // reach goals in analytics
                    }
                }, 400);
            }, (error, response) => {
                setTimeout(() => {
                    hideLoader();
                    if (response && response.errors) {

                        const messages = Object.values(response.errors).reduce((prev, curr) => {
                            return prev + ' ' + curr.reduce((prev,curr) => prev + " " + curr, '')
                        }, '');
                        
                        validation.textContent = messages.toString();
                        validation.classList.add('show');
                    } else {
                        showModal(requestCrashedModal);
                    }
                }, 400);
            });
            showLoader();
        });
    });
}


