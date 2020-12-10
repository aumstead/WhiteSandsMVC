//////////////////////////////
// toggle check-rates
//////////////////////////////
const checkRatesOpenBtn = document.getElementById('check-rates-open-btn');
const checkRatesDrawer = document.getElementById('check-rates-drawer');
const checkRatesHideBtn = document.getElementById('check-rates-hide-btn');
const checkRatesContent = document.getElementById('check-rates-content');
// a node list
const roomCheckRatesBtns = document.querySelectorAll('.room__check-rates-btn');

checkRatesOpenBtn.addEventListener('click', () => {
    checkRatesDrawer.classList.add('check-rates-drawer-open');
    checkRatesContent.classList.add('check-rates__content-open');
    checkRatesOpenBtn.classList.add('visibility-hidden');
    roomCheckRatesBtns.forEach(n => {
        n.classList.add('visibility-hidden');
    });
})

roomCheckRatesBtns.forEach(node => {
    node.addEventListener('click', () => {
        checkRatesDrawer.classList.add('check-rates-drawer-open');
        checkRatesContent.classList.add('check-rates__content-open');
        checkRatesOpenBtn.classList.add('visibility-hidden');
        roomCheckRatesBtns.forEach(n => {
            n.classList.add('visibility-hidden');
        });
    })
})

checkRatesHideBtn.addEventListener('click', () => {
    checkRatesDrawer.classList.remove('check-rates-drawer-open');
    checkRatesContent.classList.remove('check-rates__content-open');
    checkRatesOpenBtn.classList.remove('visibility-hidden');
    roomCheckRatesBtns.forEach(n => {
        n.classList.remove('visibility-hidden');
    })
})