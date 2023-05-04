function apiRequest(apiURL, methodType = 'GET', data, completedFn, crashedFn) {
    try {
        const xhr = new XMLHttpRequest();
        xhr.open(methodType, apiURL);
        xhr.setRequestHeader('Content-Type', 'application/json; charset=utf-8');
        xhr.addEventListener('load', () => {
            if (Math.floor(xhr.status / 100) !== 2) {
                let response = null;
                if(xhr.responseText) {
                    try {
                        response = JSON.parse(xhr.responseText);
                        crashedFn(xhr.statusText, response);
                    } catch (e) {
                        crashedFn(xhr.statusText, e);
                    }
                } else {
                    crashedFn(xhr.statusText, null);
                }
                return;
            }
            completedFn(xhr.responseText ? JSON.parse(xhr.responseText) : null)
        });
        xhr.addEventListener('error', () => {
            crashedFn(null, xhr.responseText ? JSON.parse(xhr.responseText) : null);
        });
        xhr.send(data ? JSON.stringify(data) : null);
    } catch(error) {
        crashedFn(error);
    }
}