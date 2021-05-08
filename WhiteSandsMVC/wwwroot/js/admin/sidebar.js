const bookingsBtn = document.getElementById('bookings-btn');
const bookingsNav = document.getElementById('bookings-nav');
const chevronUp = document.getElementById('chevron-up');
const chevronDown = document.getElementById('chevron-down');

let showingMenuItems = false;

if (window.location.pathname === "/admin/bookings/" || window.location.pathname === "/admin/arrivals/" || window.location.pathname === "/admin/departures/" || window.location.pathname === "/admin/inhouse/") {
    showingMenuItems = true;
    bookingsNav.classList.remove("hide-element");
    chevronDown.classList.add("hide-element")
    chevronUp.classList.remove("hide-element")
}

bookingsBtn.addEventListener('click', () => {
    if (showingMenuItems === false) {
        showingMenuItems = true;
        bookingsNav.classList.remove("hide-element");
        chevronDown.classList.add("hide-element")
        chevronUp.classList.remove("hide-element")
    } else {
        showingMenuItems = false;
        bookingsNav.classList.add("hide-element")
        chevronDown.classList.remove("hide-element")
        chevronUp.classList.add("hide-element")
    }
})
