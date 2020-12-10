//////////////////////////////
// header slideshow
//////////////////////////////

// grab the slide elements
const slide1 = document.getElementById('slide1');
const slide2 = document.getElementById('slide2');
const slide3 = document.getElementById('slide3');
const slide4 = document.getElementById('slide4');

// add animation end listeners and call fadeFinished callback
slide1.addEventListener('animationend', (e) => { fadeFinished(e) });
slide2.addEventListener('animationend', (e) => { fadeFinished(e) });
slide3.addEventListener('animationend', (e) => { fadeFinished(e) });
slide4.addEventListener('animationend', (e) => { fadeFinished(e) });

// put the slides into an array
let slides = [slide1, slide2, slide3];

// set an initial z-index for each slide (put them in desired order)
slide1.style.zIndex = '3';
slide2.style.zIndex = '4';
slide3.style.zIndex = '5';
slide4.style.zIndex = '6';

// start the chain by adding zoom class to first slide
slide4.classList.add('zoom');

// function the manipulates z-index, removes zoom class, and adds it.
function fadeFinished(e) {
    let slide = e.target;
    slide.style.zIndex = slide.style.zIndex - 4;
    slide.classList.remove('zoom');
    if (e.target.previousElementSibling) {
        e.target.previousElementSibling.classList.add('zoom');
    } else {
        e.target.parentElement.lastElementChild.classList.add('zoom');
    }
}

//////////////////////////////
// section accomodations carousel
//////////////////////////////

let elem = document.querySelector('.accomodations-carousel');
let flickity = new Flickity(elem, {
    wrapAround: true
});

//////////////////////////////
// mobile activities carousel
//////////////////////////////
let elem1 = document.querySelector('.secondary-carousel');
let flkty = new Flickity(elem1, {
    // options
    prevNextButtons: false
});

//////////////////////////////
// navbar intersection observer
//////////////////////////////

const navbar = document.getElementById('nav');
const intersection = document.getElementById('intersection');
const homePageOptions = {
    rootMargin: "-70% 0px 0px 0px"
};
const homePageObserver = new IntersectionObserver(function (entries, homePageObserver) {
    entries.forEach(entry => {
        if (!entry.isIntersecting) {
            navbar.classList.add('nav--black');
        } else {
            navbar.classList.remove('nav--black');
        }
    })
}, homePageOptions);

homePageObserver.observe(intersection);
