function addItem() {
  const text = document.querySelector('#newItemText').value;
  const listItem = document.createElement('li');
  listItem.textContent = text;

  const btnDelete = document.createElement('a');
  btnDelete.href = '#';
  btnDelete.textContent = '[Delete]';
  btnDelete.addEventListener('click', (e) => {
    e.currentTarget.parentElement.remove();
  });

  listItem.appendChild(btnDelete);

  document.querySelector('#items').appendChild(listItem);
}
