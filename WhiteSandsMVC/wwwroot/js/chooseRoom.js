const detailsBtn = document.getElementById('details-btn');
const servicesBtn = document.getElementById('services-btn');


const hiddenInputViewDetailsNodeList = document.querySelectorAll('.hidden-view-details');
//const hiddenInputDetailsNodeList = document.querySelectorAll('.hidden-details__btn--details');
//const hiddenInputServicesNodeList = document.querySelectorAll('.hidden-details__btn--services');

hiddenInputViewDetailsNodeList.forEach(node => {
    let id = node.value;
    let viewDetailsBtn = document.getElementById(`view-details-${id}`)
    let isOpen = false;
    //let id = node.value[node.value.length - 1]
    viewDetailsBtn.addEventListener('click', () => {
        let roomDetails = document.getElementById(`room-details-${id}`)

        if (isOpen) {
            roomDetails.classList.remove('room-details--show')
            isOpen = false;
        } else {
            roomDetails.classList.add('room-details--show')
            isOpen = true;
        }
    })

    // details and services btns
    let detailsBtn = document.getElementById(`details-btn-${id}`)
    let servicesBtn = document.getElementById(`services-btn-${id}`)
    let detailsSection = document.getElementById(`details-${id}`)
    let servicesSection = document.getElementById(`services-${id}`)
    let isServicesBtnActive = false;

    servicesBtn.addEventListener('click', () => {
        if (!isServicesBtnActive) {
            servicesBtn.classList.add('room-details__btn--active')
            detailsBtn.classList.remove('room-details__btn--active')
            servicesSection.classList.remove('hide-element')
            detailsSection.classList.add('hide-element')
            isServicesBtnActive = true;
        }
    })

    detailsBtn.addEventListener('click', () => {
        if (isServicesBtnActive) {
            detailsBtn.classList.add('room-details__btn--active')
            servicesBtn.classList.remove('room-details__btn--active')
            detailsSection.classList.remove('hide-element')
            servicesSection.classList.add('hide-element')
            isServicesBtnActive = false;
        }
    })
})

//hiddenInputServicesNodeList.forEach(node => {
//    let id = node.value[node.value.length - 1]
//    let servicesBtn = document.getElementById(node.value);
//    let detailsBtn = document.getElementById(`details-btn-${id}`)
//    let isActive = false;
//    servicesBtn.addEventListener('click', () => {
//        if (!isActive) {
//            servicesBtn.classList.add('room-details__btn--active')
//            isActive = true;
//        }
//    })
//})