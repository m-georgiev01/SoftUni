function addItem() {
  const inputText = document.querySelector('#newItemText');
  const inputValue = document.querySelector('#newItemValue');

  const newOption = document.createElement('option');
  newOption.value = inputValue.value;
  newOption.textContent = inputText.value;

  const dropdown = document.querySelector('#menu');
  dropdown.appendChild(newOption);
  inputText.value = '';
  inputValue.value = '';
}
