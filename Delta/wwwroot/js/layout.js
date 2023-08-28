
document.addEventListener('DOMContentLoaded', () => {
    const telInputs = document.querySelectorAll('input[type=tel]');
    const body = document.querySelector('body');
    phoneMask(telInputs);

    modalsInit();

    const applicationForms = document.querySelectorAll('form.application-form');
    const applicationCompletedModal = document.getElementById('application-success');
    const applicationCrashedModal = document.getElementById('application-error');
    formRequest(applicationForms, '/api/application/send', applicationCompletedModal, applicationCrashedModal, ['name', 'phone']);

    const reviewForms = document.querySelectorAll('form.review-form');
    const reviewCompletedModal = document.getElementById('review-success');
    const reviewCrashedModal = document.getElementById('review-error');
    formRequest(reviewForms, '/api/review/send', reviewCompletedModal, reviewCrashedModal, ['name', 'phone', 'email', 'text', 'rate']);

    const companyForms = document.querySelectorAll('form.company-form');
    const companyCompletedModal = document.getElementById('company-success');
    const companyCrashedModal = document.getElementById('company-error');
    
    formRequest(companyForms, '/api/companies/send', companyCompletedModal, companyCrashedModal, ['name', 'description', 'iFormFile'], {'Content-Type': 'application/json; charset=utf-8'}, document.querySelector('input[type="file"]'));
    formRequest(companyForms, '/api/companiesImg/send', companyCompletedModal, companyCrashedModal, ['iFormFile']);

    
    const hamburger = document.querySelector('.hamburger');
    hamburger.addEventListener('click', () => {
        hamburger.parentElement.classList.toggle('active-nav');
        body.classList.toggle('no-scroll');
    })
    
    const lis = document.querySelectorAll('ul li');
    lis.forEach(li => {
        li.addEventListener('click', (e) => {
            hamburger.parentElement.classList.remove('active-nav');
        })
        if(li.classList.contains('submenu-open')){
            window.scrollTo(0, 0);
            const submenu = document.querySelector('.submenu')
            li.addEventListener('click', () => {
                submenu.classList.add('submenu-active');
                body.classList.add('no-scroll');
                li.classList.add('product-active');
            })
            submenu.addEventListener('mouseleave', (e) => {
                submenu.classList.remove('submenu-active');
                body.classList.remove('no-scroll')
                li.classList.remove('product-active');
            }, )
        }
    })




    lis.forEach(function(li) {
        li.addEventListener('mouseover', function() {
            this.classList.add('active-btn-h');
        });
    
        li.addEventListener('mouseout', function() {
            this.classList.remove('active-btn-h');
        });
    });
    
    const sections = document.getElementsByTagName('section');
    for (let i = 0; i < sections.length; i++) {
        const section = sections[i];
        const position = section.getBoundingClientRect();

        // Проверяем, если секция видима при загрузке страницы
        if (position.top >= 0 && position.top < window.innerHeight) {
            section.style.opacity = 1; // Устанавливаем полную прозрачность
        }
    }
    

    window.addEventListener('scroll', function() {
        var sections = document.getElementsByTagName('section');
        for (var i = 0; i < sections.length; i++) {
            var section = sections[i];
            var position = section.getBoundingClientRect();

            // Проверяем, если секция видима в окне просмотра
            if (position.top < window.innerHeight) {
                section.style.opacity = 1; // Устанавливаем полную прозрачность
            }
        }
    });
    
    const plusMinus = document.querySelector('.submenu .arrow');
    plusMinus.addEventListener('click', () => {
        plusMinus.parentElement.parentElement.classList.toggle('subsection-static');
        
    })

    let btn = document.querySelector('.top');
    window.addEventListener('scroll', function() {
        let res = self.pageYOffset || (document.documentElement && document.documentElement.scrollTop) || (document.body && document.body.scrollTop);
        if(res > 500) {
            btn.classList.add('top-active');
        } else {
            btn.classList.remove('top-active');
        }
    });
    btn.addEventListener('click', (e) => {
        scrollTo(0, 0)
    })
    
});
