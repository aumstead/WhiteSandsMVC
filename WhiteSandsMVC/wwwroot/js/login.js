function demoLogin() {
    const email = document.getElementById("emailInput")
    const password = document.getElementById("passwordInput")
    const loginForm = document.getElementById("loginForm")
    email.value = "harry@scdp.com"
    password.value = "Gandalf1"
    loginForm.submit();

}