function addItem() {
  const text = document.querySelector('#newItemText').value;
  const newElement = document.createElement('li');
  newElement.textContent = text;

  document.querySelector('#items').appendChild(newElement);
}
