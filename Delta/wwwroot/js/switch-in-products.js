const btnSwitch = document.querySelectorAll(".at-the-right-edge .buttons button");
btnSwitch.forEach(btn => {
    btn.addEventListener("click", () => {
        btnSwitch.forEach(b => {
            b.classList.remove('active-btn');
        })
        btn.classList.add("active-btn");
        if(btn.classList.contains('reg')) {
            btn.parentElement.nextElementSibling.nextElementSibling.classList.remove('wrapper-none');
            btn.parentElement.nextElementSibling.classList.add('wrapper-none');
        } else {
            btn.parentElement.nextElementSibling.nextElementSibling.classList.add('wrapper-none');
            btn.parentElement.nextElementSibling.classList.remove('wrapper-none');
        }
    })
})