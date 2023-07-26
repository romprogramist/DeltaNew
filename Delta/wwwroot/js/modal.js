function modalsInit() {

    const modalTriggers = document.querySelectorAll(`.m-trigger`);

    modalTriggers.forEach(trigger => {
        trigger.addEventListener('click', (e) => {
            e.preventDefault();
            showModal(document.getElementById(`${trigger.dataset.modalId}`),trigger);
        });
    });

    const overlays = document.querySelectorAll('.overlay');
    overlays.forEach(overlay => {
        overlay.addEventListener('mousedown', (e) => {
            if (e.target.classList.contains('close-m') || e.target.classList.contains('overlay')) { //  || burger
                hideModals(overlay);
            }
        });
    });
}

function showModal(modal) {
    const overlay = modal.parentElement;
    hideModals(overlay);
    document.body.classList.add('no-scroll');
    overlay.classList.add('show');
    overlay.scrollTo(0, 0);
    modal.classList.add('show');
}

function hideModals(overlay) {
    const modals = overlay.querySelectorAll(`.modal`);
    modals.forEach(function (m) {
        m.classList.remove('show');
    });
    overlay.classList.remove('show');
    document.body.classList.remove('no-scroll');
}