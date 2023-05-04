// cookie operations

function getCookie(name) {
    let matches = document.cookie.match(new RegExp(
        "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
}

function setCookie(name, value, options = {}) {

    if(!options.path) {
        options.path = '/';
    }

    // options = {
    //     path: '/',
    //     ...options
    // };

    if (options.expires instanceof Date) {
        options.expires = options.expires.toUTCString();
    }

    let updatedCookie = encodeURIComponent(name) + "=" + encodeURIComponent(value);

    for (let optionKey in options) {
        updatedCookie += "; " + optionKey;
        let optionValue = options[optionKey];
        if (optionValue !== true) {
            updatedCookie += "=" + optionValue;
        }
    }

    document.cookie = updatedCookie;
}

function deleteCookie(name) {
    setCookie(name, "", {
        'max-age': -1
    })
}

// query string fns

function getParameterByName(name, url = window.location.href) {
    name = name.replace(/[\[\]]/g, '\\$&');
    const regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)');
    const results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

function redirectToReturnUrl() {
    const returnUrl = getParameterByName('ReturnUrl', window.location.href);
    if (returnUrl) {
        window.location.href = returnUrl;
        return true;
    }
    return false;
}

// jsonDateString to js DateFormat

function convertJsonDateToDateTimeString(date) {
    const d = new Date(date);
    return ("0" + d.getDate()).slice(-2) + "." + ("0"+(d.getMonth()+1)).slice(-2) + "." +
        d.getFullYear().toString().slice(-2) + "&nbspг." + "&nbsp" + ("0" + d.getHours()).slice(-2) + ":" + ("0" + d.getMinutes()).slice(-2);
}

function convertJsonDateToDateString(date) {
    const d = new Date(date);
    return ("0" + d.getDate()).slice(-2) + "." + ("0"+(d.getMonth()+1)).slice(-2) + "." +
        d.getFullYear().toString().slice(-2) + "&nbspг.";
}

function convertJsonDateToDateStringFullYear(date) {
    const d = new Date(date);
    return ("0" + d.getDate()).slice(-2) + "." + ("0"+(d.getMonth()+1)).slice(-2) + "." +
        d.getFullYear().toString() + "&nbspг.";
}