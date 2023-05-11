// �������� �� checkbox-� � ��������� name="house"
const checkboxes = document.querySelectorAll('input[name="house"]');

// �������� ��䳿 ��� ��� ����� checkbox-��
function onCheckboxChange() {
    // ����������, ���� checkbox ��� �������
    const currentCheckbox = this;

    // ���� ��� checkbox ��� ��� ��������, �� ������ ���� � ��� checkbox-��
    if (currentCheckbox.checked) {
        checkboxes.forEach((checkbox) => {
            if (checkbox !== currentCheckbox) {
                checkbox.checked = false;
                checkbox.value = "Nope"; // ������� �������� � checkbox �� "Nope"
            }
        });
        currentCheckbox.value = "Yeap"; // ������� �������� � ��������� checkbox �� "Yeap"
    } else {
        currentCheckbox.value = "Nope"; // ���� checkbox �� ��������, ������� �������� �� "Nope"
    }
}

//// ������ �������� ��䳿 ��� ������� checkbox-�
//checkboxes.forEach((checkbox) => {
//    checkbox.addEventListener('change', onCheckboxChange);
//});
