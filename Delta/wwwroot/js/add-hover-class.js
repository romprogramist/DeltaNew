
function addHoverClass(elements, className) {
    function handleMouseEnter(event) {
        var targetElement = event.target;
        targetElement.classList.add(className);
    }
    function handleMouseLeave(event) {
        var targetElement = event.target;
        targetElement.classList.remove(className);
    }
    for (var i = 0; i < elements.length; i++) {
        elements[i].addEventListener("mouseenter", handleMouseEnter);
        elements[i].addEventListener("mouseleave", handleMouseLeave);
    }
}



const myElementsSlide = document.getElementsByClassName("swiper-slide");
addHoverClass(myElementsSlide,"swiper-slide-active-new");

const itemCategoryActive = document.querySelectorAll(".product-category .item");
addHoverClass(itemCategoryActive,"item-category-active");