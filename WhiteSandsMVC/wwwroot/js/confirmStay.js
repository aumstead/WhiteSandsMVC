const termsElement = document.getElementById("terms-and-conditions")
termsElement.value = termsElement.checked

termsElement.addEventListener("change", () => {
    if (termsElement.checked) {
        termsElement.value = true
    }
    else {
        termsElement.value = false
    }
})

function validateTermsAndConditions() {
    const termsValue = document.getElementById("terms-and-conditions").value;

    console.log('terms val type', typeof(termsValue))
    const errorText = document.getElementById("terms-client-validation-error")
    if (termsValue === 'true') {
        console.log('in if')
        errorText.classList.remove('terms__client-validation-error--show')
        return true;
    } else {
        console.log('in else')
        errorText.classList.add('terms__client-validation-error--show')
        return false
    }
}