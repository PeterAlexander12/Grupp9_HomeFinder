function ConfirmDelete(uniqueId, isDeleteClicked)
{
    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}

function EnableDisable(chbox, id) {
    var disablechange = document.getElementById(id);
    disablechange.disabled = chbox.checked ? false : true;
    if (!disablechange.disabled) {
        disablechange.focus();
    }
}