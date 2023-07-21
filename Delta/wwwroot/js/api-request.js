function apiRequest(apiURL, methodType = 'GET', data, completedFn, crashedFn, headers) {
    
    try {

        let iFormFile = new FormData();
        if(document.querySelector('input[type="file"]')) {
            let fileInput = document.querySelector('input[type="file"]');
            if (methodType === 'POST') {
                iFormFile.append('iFormFile', fileInput.files[0]);
                data.iFormFile = iFormFile.get('iFormFile').name;
                delete data.utmInfo;
                delete data.sitePage;
                delete data.FormFile;
            }
        }
        
        
        
        const xhr = new XMLHttpRequest();
        xhr.open(methodType, apiURL);
        if(headers) {
            Object.entries(headers).forEach(([key, value]) => {
                if(value) {
                    xhr.setRequestHeader('Content-Type', 'application/json; charset=utf-8');
                    // xhr.setRequestHeader(key, value.toString());
                    xhr.send(JSON.stringify(data));
                }
            });
        }
        
        
        
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
        if(iFormFile) {
            xhr.send(iFormFile);
        }
    } catch(error) {
        crashedFn(error);
    }
}
