var checkboxes = document.getElementsByClassName("exclusive");
for (var i = 0; i < checkboxes.length; i++) {
    checkboxes[i].addEventListener('click', function () {
        for (var j = 0; j < checkboxes.length; j++) {
            if (checkboxes[j] != this) {
                checkboxes[j].checked = false;
            }
        }
    });
}

document.getElementById('email').addEventListener('input', function () {
    var emailInput = document.getElementById('email');
    var errorSpan = document.getElementById('email-error');
    var email = emailInput.value.trim();

    if (!validateEmail(email)) {
        errorSpan.textContent = 'Введіть дійсну адресу електронної пошти.';
        emailInput.classList.add('invalid');
    } else {
        errorSpan.textContent = '';
        emailInput.classList.remove('invalid');
    }
});

function validateEmail(email) {
    // Використовуйте регулярний вираз для перевірки формату адреси електронної пошти
    var emailRegex = /^\S+@\S+\.\S+$/;
    return emailRegex.test(email);
}