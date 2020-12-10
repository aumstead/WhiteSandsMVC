// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//////////////////////////////
// toggle side-drawer
//////////////////////////////
const openBtn = document.getElementById('open-btn');
const closeBtn = document.getElementById('close-btn');
const sideDrawer = document.getElementById('nav-drawer');
const backdrop = document.getElementById('backdrop');

openBtn.addEventListener('click', () => {
    sideDrawer.classList.add('drawer-open');
    backdrop.classList.add('backdrop-open');
});

closeBtn.addEventListener('click', () => {
    sideDrawer.classList.remove('drawer-open');
    backdrop.classList.remove('backdrop-open');
})

backdrop.addEventListener('click', () => {
    sideDrawer.classList.remove('drawer-open');
    backdrop.classList.remove('backdrop-open');
});