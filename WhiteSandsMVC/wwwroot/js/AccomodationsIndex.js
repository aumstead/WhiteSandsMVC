﻿// section accomodations carousel

let elem = document.querySelector('.accomodations-carousel');
let flickity = new Flickity(elem, {
    wrapAround: true
});

// filter room types
const overwaterBtn = document.getElementById('overwater-btn');
const beachfrontBtn = document.getElementById('beachfront-btn');
const villasBtn = document.getElementById('villas-btn');

const overwaterRooms = document.querySelector('.room-types__overwater');
const beachfrontRooms = document.querySelector('.room-types__beachfront');
const villas = document.querySelector('.room-types__villas');

// the default type shown
overwaterRooms.classList.add('show-room-type');

overwaterBtn.addEventListener('click', () => {
    overwaterRooms.classList.add('show-room-type');
    beachfrontRooms.classList.remove('show-room-type');
    villas.classList.remove('show-room-type');
})

beachfrontBtn.addEventListener('click', () => {
    overwaterRooms.classList.remove('show-room-type');
    beachfrontRooms.classList.add('show-room-type');
    villas.classList.remove('show-room-type');
})

villasBtn.addEventListener('click', () => {
    overwaterRooms.classList.remove('show-room-type');
    beachfrontRooms.classList.remove('show-room-type');
    villas.classList.add('show-room-type');
})

// policies
const checkInBtn = document.getElementById('check-in-btn');
const closeCheckInBtn = document.getElementById('close-check-in-btn');
const earlyArrivalsBtn = document.getElementById('early-arrivals-btn');
const closeEarlyArrivalsBtn = document.getElementById('close-early-arrivals-btn');
const creditCardsBtn = document.getElementById('credit-cards-btn');
const closeCreditCardsBtn = document.getElementById('close-credit-cards-btn');
const familyPlanBtn = document.getElementById('family-plan-btn');
const closeFamilyPlanBtn = document.getElementById('close-family-plan-btn');

const checkInPolicy = document.getElementById('check-in-policy');
const earlyArrivalsPolicy = document.getElementById('early-arrivals-policy');
const creditCardsPolicy = document.getElementById('credit-cards-policy');
const familyPlanPolicy = document.getElementById('family-plan-policy');

const checkInSpan = document.getElementById('check-in-span');
const earlyArrivalsSpan = document.getElementById('early-arrivals-span');
const creditCardsSpan = document.getElementById('credit-cards-span');
const familyPlanSpan = document.getElementById('family-plan-span');

const chevronDownCreditCards = document.getElementById('chevron-down-credit-cards');

let showingCheckIn = false;
let showingEarlyArrivals = false;
let showingCreditCards = false;
let showingFamilyPlan = false;

checkInBtn.addEventListener('click', () => {
    if (showingCheckIn == false) {
        showingCheckIn = true;
        checkInPolicy.classList.add('policy--check-in');
        checkInSpan.classList.add('policy__text--show');
        checkInBtn.classList.add('hide-element');
        closeCheckInBtn.classList.remove('hide-element')
    }
})

closeCheckInBtn.addEventListener('click', () => {
    if (showingCheckIn) {
        showingCheckIn = false;
        checkInPolicy.classList.remove('policy--check-in');
        checkInSpan.classList.remove('policy__text--show');
        checkInBtn.classList.remove('hide-element');
        closeCheckInBtn.classList.add('hide-element');
    }
})

earlyArrivalsBtn.addEventListener('click', () => {
    if (showingEarlyArrivals == false) {
        showingEarlyArrivals = true;
        earlyArrivalsPolicy.classList.add('policy--early-arrivals');
        earlyArrivalsSpan.classList.add('policy__text--show');
        earlyArrivalsBtn.classList.add('hide-element');
        closeEarlyArrivalsBtn.classList.remove('hide-element');
    }
})

closeEarlyArrivalsBtn.addEventListener('click', () => {
    if (showingEarlyArrivals) {
        showingEarlyArrivals = false;
        earlyArrivalsPolicy.classList.remove('policy--early-arrivals');
        earlyArrivalsSpan.classList.remove('policy__text--show');
        earlyArrivalsBtn.classList.remove('hide-element');
        closeEarlyArrivalsBtn.classList.add('hide-element');
    }
})

creditCardsBtn.addEventListener('click', () => {
    if (showingCreditCards == false) {
        showingCreditCards = true;
        creditCardsPolicy.classList.add('policy--credit-cards');
        creditCardsSpan.classList.add('policy__text--show');
        creditCardsBtn.classList.add('hide-element');
        closeCreditCardsBtn.classList.remove('hide-element');
    }
})

closeCreditCardsBtn.addEventListener('click', () => {
    if (showingCreditCards) {
        showingCreditCards = false;
        creditCardsPolicy.classList.remove('policy--credit-cards');
        creditCardsSpan.classList.remove('policy__text--show');
        creditCardsBtn.classList.remove('hide-element');
        closeCreditCardsBtn.classList.add('hide-element');
    }
})

familyPlanBtn.addEventListener('click', () => {
    if (showingFamilyPlan == false) {
        showingFamilyPlan = true;
        familyPlanPolicy.classList.add('policy--family-plan');
        familyPlanSpan.classList.add('policy__text--show');
        familyPlanBtn.classList.add('hide-element');
        closeFamilyPlanBtn.classList.remove('hide-element');
    }
})

closeFamilyPlanBtn.addEventListener('click', () => {
    if (showingFamilyPlan) {
        showingFamilyPlan = false;
        familyPlanPolicy.classList.remove('policy--family-plan');
        familyPlanSpan.classList.remove('policy__text--show');
        familyPlanBtn.classList.remove('hide-element');
        closeFamilyPlanBtn.classList.add('hide-element');
    }
})