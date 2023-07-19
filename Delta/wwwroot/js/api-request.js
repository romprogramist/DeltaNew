function apiRequest(apiURL, methodType = 'GET', data, completedFn, crashedFn) {
    try {
        const xhr = new XMLHttpRequest();
        xhr.open(methodType, apiURL);
        let textData = data;
        if (methodType === 'POST' || methodType === 'PUT') {
            let fileInput = document.querySelector('input[type="file"]');
            const iFormFile = new FormData();
            for (const key in data) {
                iFormFile.append('iFormFile', fileInput.files[0]);
            }
            data = iFormFile;
            textData.iFormFile = data.get('iFormFile').name;
        }
        
        xhr.addEventListener('load', () => {
            if (Math.floor(xhr.status / 100) !== 2) {
                let response = null;
                if (xhr.responseText) {
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
            completedFn(xhr.responseText ? JSON.parse(xhr.responseText) : null);
        });

        xhr.addEventListener('error', () => {
            crashedFn(null, xhr.responseText ? JSON.parse(xhr.responseText) : null);
        });
        console.log(textData);
        
        xhr.send(data);
        xhr.send(textData);
    } catch (error) {
        crashedFn(error);
    }
}






// function apiRequest(apiURL, methodType = 'GET', data, completedFn, crashedFn) {
//     try {
//         const xhr = new XMLHttpRequest();
//         xhr.open(methodType, apiURL);
//         xhr.setRequestHeader('Content-Type', 'multipart/form-data; charset=utf-8');
//         xhr.addEventListener('load', () => {
//             if (Math.floor(xhr.status / 100) !== 2) {
//                 let response = null;
//                 if(xhr.responseText) {
//                     try {
//                         response = JSON.parse(xhr.responseText);
//                         crashedFn(xhr.statusText, response);
//                     } catch (e) {
//                         crashedFn(xhr.statusText, e);
//                     }
//                 } else {
//                     crashedFn(xhr.statusText, null);
//                 }
//                 return;
//             }
//             completedFn(xhr.responseText ? JSON.parse(xhr.responseText) : null)
//         });
//         xhr.addEventListener('error', () => {
//             crashedFn(null, xhr.responseText ? JSON.parse(xhr.responseText) : null);
//         });
//         console.log(data);
//         xhr.send(data);
//     } catch(error) {
//         crashedFn(error);
//     }
// }