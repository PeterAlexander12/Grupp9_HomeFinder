//changing word start page JS------------------------------

var words = document.getElementsByClassName('word');
var wordArray = [];
var currentWord = 0;

words[currentWord].style.opacity = 1;
for (var i = 0; i < words.length; i++) {
    splitLetters(words[i]);
}

function changeWord() {
    var cw = wordArray[currentWord];
    var nw = currentWord == words.length - 1 ? wordArray[0] : wordArray[currentWord + 1];
    for (var i = 0; i < cw.length; i++) {
        animateLetterOut(cw, i);
    }

    for (var i = 0; i < nw.length; i++) {
        nw[i].className = 'letter behind';
        nw[0].parentElement.style.opacity = 1;
        animateLetterIn(nw, i);
    }

    currentWord = (currentWord == wordArray.length - 1) ? 0 : currentWord + 1;
}

function animateLetterOut(cw, i) {
    setTimeout(function () {
        cw[i].className = 'letter out';
    }, i * 80);
}

function animateLetterIn(nw, i) {
    setTimeout(function () {
        nw[i].className = 'letter in';
    }, 340 + (i * 80));
}

function splitLetters(word) {
    var content = word.innerHTML;
    word.innerHTML = '';
    var letters = [];
    for (var i = 0; i < content.length; i++) {
        var letter = document.createElement('span');
        letter.className = 'letter';
        letter.innerHTML = content.charAt(i);
        word.appendChild(letter);
        letters.push(letter);
    }

    wordArray.push(letters);
}

changeWord();
setInterval(changeWord, 4000);

//----------------------------------------

//Slideshow JS--------------------------

let slideIndex = 1;
let slideIndexTwo = 1;
showSlides(slideIndex);
showSlidesTwo(slideIndexTwo);

// Next/previous controls
function plusSlides(n) {
    showSlides(slideIndex += n);
    showSlidesTwo(slideIndexTwo += n);
}

// Thumbnail image controls
function currentSlide(n) {
    showSlides(slideIndex = n);
    showSlidesTwo(slideIndexTwo = n);
}

function showSlides(n) {
    let i;
    let slides = document.getElementsByClassName("mySlides");

    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }

    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    //slideIndex++;
    slides[slideIndex - 1].style.display = "block";
    //setTimeout(showSlides, 4000);
}

function showSlidesTwo(n) {
    let i;
    let slides = document.getElementsByClassName("mySlidesTwo");

    if (n > slides.length) { slideIndexTwo = 1 }
    if (n < 1) { slideIndexTwo = slides.length }

    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    //slideIndex++;
    slides[slideIndexTwo - 1].style.display = "block";
    //setTimeout(showSlides, 4000);
}

//--------------------------------------------------