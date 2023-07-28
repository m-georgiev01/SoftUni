const API_URL = 'http://localhost:3030/jsonstore/phonebook';

function attachEvents() {
  document
    .querySelector('#btnLoad')
    .addEventListener('click', getAllPhonebookEntries);

  document
    .querySelector('#btnCreate')
    .addEventListener('click', createNewPhonebookEntry);
}

function getAllPhonebookEntries() {
  fetch(API_URL)
    .then((response) => response.json())
    .then((result) => {
      const unorderedList = document.querySelector('#phonebook');
      unorderedList.innerHTML = '';

      Object.values(result).forEach((element) => {
        unorderedList.appendChild(createListItem(element));
      });
    });
}

function createNewPhonebookEntry() {
  const personInput = document.querySelector('#person');
  const phoneInput = document.querySelector('#phone');

  const person = personInput.value;
  const phone = phoneInput.value;

  fetch(API_URL, {
    method: 'POST',
    body: JSON.stringify({
      person,
      phone,
    }),
  }).then(() => {
    personInput.value = '';
    phoneInput.value = '';

    getAllPhonebookEntries();
  });
}

function createListItem({ _id, person, phone }) {
  const deleteBtn = document.createElement('button');
  deleteBtn.textContent = 'Delete';
  deleteBtn.setAttribute('data-contactid', _id);
  deleteBtn.addEventListener('click', deleteListItem);

  const listItem = document.createElement('li');
  listItem.textContent = `${person}: ${phone}`;
  listItem.appendChild(deleteBtn);

  return listItem;

  function deleteListItem(e) {
    const contactId = e.target.dataset.contactid;

    fetch(`${API_URL}/${contactId}`, {
      method: 'DELETE',
    }).then(() => getAllPhonebookEntries());
  }
}

attachEvents();
