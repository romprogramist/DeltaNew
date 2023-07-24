document.addEventListener('DOMContentLoaded', () => {

    const reviewsButton = document.querySelector('.reviews');
    reviewsButton.addEventListener('click', () => {
        apiRequest('/api/review/all', 'GET', null,
            (response) => {
                console.log(response);
            },
            (error) => {
                console.log("Error  getting reviews: " + error);
            }, null, true);
    });


    // apiRequest('/api/review/approve/1', 'PUT', null,
    //     (response) => {
    //         console.log("Review approved");
    //     },
    //     (error) => {
    //         console.log("Error approving review: " + error);
    //     }, {
    //         // 'Authorization': 'Bearer ' + localStorage.getItem('token')
    //     });
});
