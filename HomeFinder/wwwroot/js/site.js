//////changing word start page JS------------------------------


//const { forEach } = require("../lib/fontawesome-free-6.1.1-web/js/v4-shims");

////var words = document.getElementsByClassName('word');
////var wordArray = [];
////var currentWord = 0;

////words[currentWord].style.opacity = 1;
////for (var i = 0; i < words.length; i++) {
////    splitLetters(words[i]);
////}

////function changeWord() {
////    var cw = wordArray[currentWord];
////    var nw = currentWord == words.length - 1 ? wordArray[0] : wordArray[currentWord + 1];
////    for (var i = 0; i < cw.length; i++) {
////        animateLetterOut(cw, i);
////    }

////    for (var i = 0; i < nw.length; i++) {
////        nw[i].className = 'letter behind';
////        nw[0].parentElement.style.opacity = 1;
////        animateLetterIn(nw, i);
////    }

////    currentWord = (currentWord == wordArray.length - 1) ? 0 : currentWord + 1;
////}

////function animateLetterOut(cw, i) {
////    setTimeout(function () {
////        cw[i].className = 'letter out';
////    }, i * 80);
////}

////function animateLetterIn(nw, i) {
////    setTimeout(function () {
////        nw[i].className = 'letter in';
////    }, 340 + (i * 80));
////}

////function splitLetters(word) {
////    var content = word.innerHTML;
////    word.innerHTML = '';
////    var letters = [];
////    for (var i = 0; i < content.length; i++) {
////        var letter = document.createElement('span');
////        letter.className = 'letter';
////        letter.innerHTML = content.charAt(i);
////        word.appendChild(letter);
////        letters.push(letter);
////    }

////    wordArray.push(letters);
////}

////changeWord();
////setInterval(changeWord, 4000);

//////----------------------------------------

//////Slideshow JS--------------------------

////let slideIndex = 1;
////showSlides(slideIndex);

////// Next/previous controls
////function plusSlides(n) {
////    showSlides(slideIndex += n);
////}

////// Thumbnail image controls
////function currentSlide(n) {
////    showSlides(slideIndex = n);
////}

////function showSlides(n) {
////    let i;
////    let slides = document.getElementsByClassName("mySlides");

////        if (n > slides.length) { slideIndex = 1 }
////        if (n < 1) { slideIndex = slides.length }

////    for (i = 0; i < slides.length; i++) {
////        slides[i].style.display = "none";
////    }
////    //slideIndex++;
////    if (slideIndex > slides.length) { slideIndex = 1 }
////    slides[slideIndex - 1].style.display = "block";
////    //setTimeout(showSlides, 4000);
////}

//////--------------------------------------------------

//----------------------- search enginge ------------------//

function toggleClick(click) {

    var button;
    var checkbox;

    if (click == 0) {
        button = document.getElementById('house-button');
        checkbox = document.getElementById("house");
    }

    if (click == 1) {
        button = document.getElementById('apartment-button');
        checkbox = document.getElementById("apartment");
    }

    if (click == 2) {
        button = document.getElementById('farm-button');
        checkbox = document.getElementById("farm");
    }

    if (checkbox.checked) {
        button.style.backgroundColor = 'gray';
    } else {
        button.style.backgroundColor = 'white';
    }
}

//----------------------------------------------------------------

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


        if (this.checkValidities.length > 1) {
            var invalidities = [];
            for (var i = 0; i < this.checkValidities.length; i++) {
                invalidities.push(this.checkValidities[i].isInvalid);
            }

                var allAreValid = [];

            for (var i = 0; i < this.checkValidities.length; i++) {

                var isValid = this.checkValidities[i].isInvalid(input);

                if (isValid && !allAreValid.includes(false)) {
                    this.checkValidities[i].element.style.borderColor = "green";
                    this.checkValidities[i].elementError.innerHTML = "<li class=list-unstyled></li>"
                } else {
                    this.checkValidities[i].element.style.borderColor = "red";
                    this.checkValidities[i].elementError.innerHTML += "<li class=list-unstyled>" + this.checkValidities[i].invalidityMessage + "</li>";
                    allAreValid.push(false);
                }
            }
        }
        else
        {

            for (var i = 0; i < this.checkValidities.length; i++)
            {
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
            return input.length > 0;
        },
        invalidityMessage: "Fältet får inte vara tomt",
        element: document.getElementById('givenName'),
        elementError: document.getElementById('givenName-error')
    },
    {
        isInvalid: function (input) {
            var regex = /^([^0-9]*)$/;
            return input.value.match(regex);
        },
        invalidityMessage: "Ange enbart bokstäver",
        element: document.getElementById('givenName'),
        elementError: document.getElementById('givenName-error'),
    }];

var SurnameValidityChecks = [
    {
        isInvalid: function (input) {
            return input.value.length > 0;
        },
        invalidityMessage: "Fältet får inte vara tomt",
        element: document.getElementById('surname'),
        elementError: document.getElementById('surname-error'),
        isInvalid: function (input) {
            var regex = /^([^0-9]*)$/;
            return input.value.match(regex);
        },
        invalidityMessage: "Ange enbart bokstäver",
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
            return input.value.length >= 8;
        },
        invalidityMessage: "Lösenordet måste vara minst 8 karaktärer",
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

    emailInput.RegistrationValidation.checkValidity(this);
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

    givenNameInput.RegistrationValidation.checkValidity(this);
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

    surnameInput.RegistrationValidation.checkValidity(this);
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

    phoneInput.RegistrationValidation.checkValidity(this);
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

    passwordInput.RegistrationValidation.checkValidity(this);
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

    passwordConfirmInput.RegistrationValidation.checkValidity(this);
})

passwordConfirmInput.addEventListener('focus', e => {
    var element = document.getElementById('password-confirm');
    element.style.borderColor = "gray";
    document.getElementById('password-confirm-error').innerHTML = "";
})

