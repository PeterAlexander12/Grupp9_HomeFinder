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
        button.classList.add('accomodation-type-checkbox-checked');
        button.classList.remove('accomodation-type-checkbox');
    } else {
        button.classList.add('accomodation-type-checkbox');
        button.classList.remove('accomodation-type-checkbox-checked');
    }
}