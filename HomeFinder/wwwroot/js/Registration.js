//--------------------Register user validation------------------------//

const re =
    /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;

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

var emailValidityChecks = [
    {
        isInvalid: function (input) {
            return input.value.match(re);
        },
        invalidityMessage: "Du har inte angett en korrekt emailadress",
        element: document.getElementById('email'),
        elementError: document.getElementById('email-error')
    }];

var GivenNameValidityChecks = [
    {
        isInvalid: function (input) {
            var regex = /^([^0-9]*)$/;
            return input.value.match(regex) && input.value.length > 0;
        },
        invalidityMessage: "Fältet får inte vara tomt och enbart bestå av bokstäver",
        element: document.getElementById('givenName'),
        elementError: document.getElementById('givenName-error'),
    }];

var SurnameValidityChecks = [
    {
        isInvalid: function (input) {
            var regex = /^([^0-9]*)$/;
            return input.value.match(regex) && input.value.length > 0;
        },
        invalidityMessage: "Fältet får inte vara tomt och enbart bestå av bokstäver",
        element: document.getElementById('surname'),
        elementError: document.getElementById('surname-error'),
    }];

var PhoneValidityChecks = [
    {
        isInvalid: function (input) {
            var regex = /^07(0|2|3|6|9)\d{7}$/g;
            return input.value.match(regex);
        },
        invalidityMessage: "Ange ett korrekt telefonnummer i formatet 07XXXXXXXX",
        element: document.getElementById('phone'),
        elementError: document.getElementById('phone-error'),
    }];

var PasswordValidityChecks = [
    {
        isInvalid: function (input) {
            var regex = /\W/g;
            return input.value.length >= 8 && input.value.match(regex);
        },
        invalidityMessage: "Lösenordet måste vara minst 8 karaktärer och innehålla karaktärer som inte är en siffra eller bokstav",
        element: document.getElementById('password'),
        elementError: document.getElementById('password-error'),
    }];

var PasswordConfirmValidityChecks = [
    {
        isInvalid: function (input) {
            return input.value.match(document.getElementById('password').value);
        },
        invalidityMessage: "Lösenordet matchar inte",
        element: document.getElementById('password-confirm'),
        elementError: document.getElementById('password-confirm-error'),
    }];

var emailInput = document.getElementById('email');

emailInput.RegistrationValidation = new RegistrationValidation();
emailInput.RegistrationValidation.checkValidities = emailValidityChecks;

emailInput.addEventListener('blur', function () {
    if (emailInput.value.length > 0) {
    emailInput.RegistrationValidation.checkValidity(this);
    }
})

emailInput.addEventListener('focus', e => {
    var element = document.getElementById('email');
    element.style.borderColor = "gray";
    document.getElementById('email-error').innerHTML = "";
})

var givenNameInput = document.getElementById('givenName');
givenNameInput.RegistrationValidation = new RegistrationValidation();
givenNameInput.RegistrationValidation.checkValidities = GivenNameValidityChecks;

givenNameInput.addEventListener('blur', function () {
    if (givenNameInput.value.length > 0) {
        givenNameInput.RegistrationValidation.checkValidity(this);
    }
})

givenNameInput.addEventListener('focus', e => {
    var element = document.getElementById('givenName');
    element.style.borderColor = "gray";
    document.getElementById('givenName-error').innerHTML = "";
})



var surnameInput = document.getElementById('surname');

surnameInput.RegistrationValidation = new RegistrationValidation();
surnameInput.RegistrationValidation.checkValidities = SurnameValidityChecks;

surnameInput.addEventListener('blur', function () {
    if (surnameInput.value.length > 0) {
        surnameInput.RegistrationValidation.checkValidity(this);
    }

})

surnameInput.addEventListener('focus', e => {
    var element = document.getElementById('surname');
    element.style.borderColor = "gray";
    document.getElementById('surname-error').innerHTML = "";
})

var phoneInput = document.getElementById('phone');

phoneInput.RegistrationValidation = new RegistrationValidation();
phoneInput.RegistrationValidation.checkValidities = PhoneValidityChecks;

phoneInput.addEventListener('blur', function () {
    if (phoneInput.value.length > 0) {
    phoneInput.RegistrationValidation.checkValidity(this);
    }
})

phoneInput.addEventListener('focus', e => {
    var element = document.getElementById('phone');
    element.style.borderColor = "gray";
    document.getElementById('phone-error').innerHTML = "";
})

var passwordInput = document.getElementById('password');

passwordInput.RegistrationValidation = new RegistrationValidation();
passwordInput.RegistrationValidation.checkValidities = PasswordValidityChecks;

passwordInput.addEventListener('blur', function () {
    if (passwordInput.value.length > 0) {
    passwordInput.RegistrationValidation.checkValidity(this);
    }
})

passwordInput.addEventListener('focus', e => {
    var element = document.getElementById('password');
    element.style.borderColor = "gray";
    document.getElementById('password-error').innerHTML = "";
})

var passwordConfirmInput = document.getElementById('password-confirm');

passwordConfirmInput.RegistrationValidation = new RegistrationValidation();
passwordConfirmInput.RegistrationValidation.checkValidities = PasswordConfirmValidityChecks;

passwordConfirmInput.addEventListener('blur', function () {
    if (passwordConfirmInput.value.length > 0) {
    passwordConfirmInput.RegistrationValidation.checkValidity(this);
    }
})

passwordConfirmInput.addEventListener('focus', e => {
    var element = document.getElementById('password-confirm');
    element.style.borderColor = "gray";
    document.getElementById('password-confirm-error').innerHTML = "";
})

function toggleSubmit() {

    var button = document.getElementById('submit-button');
    var regexPhone = /^07(0|2|3|6|9)\d{7}$/g;
    var regexName = /^([^0-9]*)$/;

    if (passwordInput.value.length >= 8 && emailInput.value.length > 0 && givenNameInput.value.length > 0 && surnameInput.value.length > 0) {
        console.log(phoneInput.value.length);
        if (phoneInput.value.length > 0)  {
            if (passwordConfirmInput.value.match(passwordInput.value) && phoneInput.value.match(regexPhone) && givenNameInput.value.match(regexName) && surnameInput.value.match(regexName) && emailInput.value.match(re)) {
                button.type = "submit";
            }
            else {
                button.type = "button";
            }
        }
        else {
            if (passwordConfirmInput.value.match(passwordInput.value) && givenNameInput.value.match(regexName) && surnameInput.value.match(regexName) && emailInput.value.match(re)) {
                button.type = "submit";
            }
            else {
                button.type = "button";
            }
        }
    }
}