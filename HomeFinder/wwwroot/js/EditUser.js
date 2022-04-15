function RegistrationValidation() {

    this.invalidites = [];

    this.checkValidities = [];
}

RegistrationValidation.prototype = {
    addInvalidity: function (message) {
        this.invalidites.push(message);
    },
    getInvalidities: function () {
        return this.invalidites.join('. \n');
    },
    checkValidity: function (input) {

        for (var i = 0; i < this.checkValidities.length; i++) {

            var isValid = this.checkValidities[i].isInvalid(input);

            if (isValid) {
                this.checkValidities[i].element.style.borderColor = "green";
                this.checkValidities[i].elementError.innerHTML = "<li class=list-unstyled></li>"
            } else {
                this.checkValidities[i].element.style.borderColor = "red";
                this.checkValidities[i].elementError.innerHTML = "<li class=list-unstyled>" + this.checkValidities[i].invalidityMessage + "</li>";
            }
        }
    }
};


var PasswordValidityChecks = [
    {
        isInvalid: function (input) {
            var regex = /\W/g;
            return input.value.length >= 8 && input.value.match(regex);
        },
        invalidityMessage: "Lösenordet måste vara minst 8 karaktärer och innehålla karaktärer som inte är en siffra eller bokstav",
        element: document.getElementById('newPassword'),
        elementError: document.getElementById('password-error'),
    }];

var PasswordConfirmValidityChecks = [
    {
        isInvalid: function (input) {
            return input.value.match(passwordInput.value);
        },
        invalidityMessage: "Lösenordet matchar inte",
        element: document.getElementById('confirmNewPassword'),
        elementError: document.getElementById('password-confirm-error'),
    }];


var passwordInput = document.getElementById('newPassword');

passwordInput.RegistrationValidation = new RegistrationValidation();
passwordInput.RegistrationValidation.checkValidities = PasswordValidityChecks;

passwordInput.addEventListener('blur', function () {
    if (passwordInput.value.length > 0) {
        passwordInput.RegistrationValidation.checkValidity(this);
    }
})

passwordInput.addEventListener('focus', e => {
    var element = document.getElementById('newPassword');
    element.style.borderColor = "gray";
    document.getElementById('password-error').innerHTML = "";
})

var passwordConfirmInput = document.getElementById('confirmNewPassword');

passwordConfirmInput.RegistrationValidation = new RegistrationValidation();
passwordConfirmInput.RegistrationValidation.checkValidities = PasswordConfirmValidityChecks;

passwordConfirmInput.addEventListener('blur', function () {
    if (passwordConfirmInput.value.length > 0) {
        passwordConfirmInput.RegistrationValidation.checkValidity(this);
    }
})

passwordConfirmInput.addEventListener('focus', e => {
    var element = document.getElementById('confirmNewPassword');
    element.style.borderColor = "gray";
    document.getElementById('password-confirm-error').innerHTML = "";
})

function toggleSubmit() {

    var button = document.getElementById('submit-button');

    if (passwordInput.value.length >= 8 && passwordInput.value.match(passwordConfirmInput.value) && document.getElementById('password').value > 0) {
            button.type = "submit";
    } else {
        button.type = "button";
    }
}


const re =
    /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;

    var email = document.getElementById('emailInput');
var phoneNumber = document.getElementById('phoneNumber');

var emailValidityChecks = [
    {
        isInvalid: function (input) {
            return input.value.match(re);
        },
        invalidityMessage: "Du har inte angett en korrekt emailadress",
        element: document.getElementById('emailInput'),
        elementError: document.getElementById('email-error')
    }];


email.RegistrationValidation = new RegistrationValidation();
email.RegistrationValidation.checkValidities = emailValidityChecks;

email.addEventListener('blur', function () {
    if (email.value.length > 0) {
        email.RegistrationValidation.checkValidity(this);
    }
});

emailInput.addEventListener('focus', e => {
    email.style.borderColor = "gray";
    document.getElementById('email-error').innerHTML = "";
});

function makeDisabled()
{

    var button = document.getElementById('changeButton');
    var changeButton = document.getElementById('changePasswordButton');
    var backButton = document.getElementById('backButton');


    if (button.innerHTML.match('Ändra')) {
        button.innerHTML = 'Spara';
        button.type = 'button';
        email.readOnly = false;
        phoneNumber.readOnly = false;
        changeButton.hidden = true;
        backButton.hidden = false;
    } else {
        button.innerHTML = 'Ändra';
        button.type = 'submit';
        email.readOnly = true;
        phoneNumber.readOnly = true;
        changeButton.hidden = false;
        backButton.hidden = true;
    }
}