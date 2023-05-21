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
    
    
    const hamburger = document.querySelector('.hamburger');
    hamburger.addEventListener('click', () => {
        hamburger.parentElement.classList.toggle('active-nav');
        body.classList.toggle('no-scroll');
    })
    
    const lis = document.querySelectorAll('header ul li');
    lis.forEach(li => {
        li.addEventListener('click', (e) => {
            hamburger.parentElement.classList.remove('active-nav');
        })
        if(li.classList.contains('submenu-open')){
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


    function calculatesTheRoute(item) {
        let urlParts = item.split('/');
        let currentPage = urlParts[urlParts.length - 1];
        currentPage = currentPage.split('?')[0];
        return currentPage;
    }
    function addClassActiveHeader(href) {
        lis.forEach(li => {
            if(calculatesTheRoute(li.lastElementChild.href) === href) {
                li.classList.add('active-btn-h');
            }
            if(href === 'home' && calculatesTheRoute(li.lastElementChild.href) === href) {
                li.classList.add('active-btn-h');
            }
        })
    }
    let currentUrl = window.location.href;
    function getCurrentPage(url) {
        addClassActiveHeader(calculatesTheRoute(url))
    }
    getCurrentPage(currentUrl);
    
    
    
    
    
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
