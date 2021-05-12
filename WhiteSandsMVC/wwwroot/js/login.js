function demoMemberLogin() {
    const email = document.getElementById("emailInput")
    const password = document.getElementById("passwordInput")
    const loginForm = document.getElementById("loginForm")
    email.value = "betty@gmail.com"
    password.value = "Gandalf1"
    loginForm.submit();
}

function demoAdminLogin() {
    const email = document.getElementById("emailInput")
    const password = document.getElementById("passwordInput")
    const loginForm = document.getElementById("loginForm")
    email.value = "admin@whitesands.com"
    password.value = "Gandalf1"
    loginForm.submit();
}