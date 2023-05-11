// отримуємо всі checkbox-и з атрибутом name="house"
const checkboxes = document.querySelectorAll('input[name="house"]');

// обробник події при зміні стану checkbox-ів
function onCheckboxChange() {
    // перевіряємо, який checkbox був змінений
    const currentCheckbox = this;

    // якщо цей checkbox вже був вибраний, то знімаємо вибір з усіх checkbox-ів
    if (currentCheckbox.checked) {
        checkboxes.forEach((checkbox) => {
            if (checkbox !== currentCheckbox) {
                checkbox.checked = false;
                checkbox.value = "Nope"; // змінюємо значення в checkbox на "Nope"
            }
        });
        currentCheckbox.value = "Yeap"; // змінюємо значення в поточному checkbox на "Yeap"
    } else {
        currentCheckbox.value = "Nope"; // якщо checkbox не вибраний, змінюємо значення на "Nope"
    }
}

//// додаємо обробник події для кожного checkbox-а
//checkboxes.forEach((checkbox) => {
//    checkbox.addEventListener('change', onCheckboxChange);
//});
