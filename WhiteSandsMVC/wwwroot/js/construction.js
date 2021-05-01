function fromConstructionOpenCheckRates() {
    const checkRatesOpenBtn = document.getElementById('check-rates-open-btn');
    const checkRatesDrawer = document.getElementById('check-rates-drawer');
    const checkRatesContent = document.getElementById('check-rates-content');
    // a node list
    const roomCheckRatesBtns = document.querySelectorAll('.room__check-rates-btn');

    checkRatesDrawer.classList.add('check-rates-drawer-open');
    checkRatesContent.classList.add('check-rates__content-open');
    checkRatesOpenBtn.classList.add('visibility-hidden');
    roomCheckRatesBtns.forEach(n => {
        n.classList.add('visibility-hidden');
    });
}