const API_URL = 'http://localhost:3030/jsonstore/collections/books';

function attachEvents() {
  document.querySelector('#loadBooks').addEventListener('click', getAllBooks);

  document
    .querySelector('#form button')
    .addEventListener('click', handleFormSubmission);
}

function getAllBooks() {
  fetch(API_URL)
    .then((response) => response.json())
    .then((books) => {
      const booksContainer = document.querySelector('tbody');
      booksContainer.innerHTML = '';

      Object.entries(books).forEach((bookInfo) => {
        booksContainer.appendChild(createBookRow(bookInfo));
      });
    });
}

function createBookRow([id, book]) {
  const row = document.createElement('tr');

  row.appendChild(createBookCell(book.title));
  row.appendChild(createBookCell(book.author));
  row.appendChild(createButton('Edit', fillEditForm));
  row.appendChild(createButton('Delete', deleteSelectedBtn));

  return row;

  function createBookCell(text) {
    const col = document.createElement('td');
    col.textContent = text;

    return col;
  }

  function createButton(text, callbackFunc) {
    const btn = document.createElement('button');
    btn.textContent = text;
    btn.setAttribute('data-bookid', id);
    btn.addEventListener('click', callbackFunc);

    return btn;
  }
}

function deleteSelectedBtn(e) {
  const bookId = e.currentTarget.dataset.bookid;

  fetch(`${API_URL}/${bookId}`, {
    method: 'DELETE',
  }).then(() => {
    getAllBooks();
  });
}

function handleFormSubmission(e) {
  const isEditing = document.querySelector('h3').textContent.includes('Edit');
  isEditing ? updateBook(e) : saveBook(e);
}

function saveBook() {
  const titleInput = document.querySelector('input[name="title"]');
  const authorInput = document.querySelector('input[name="author"]');

  const errorMsgContainer = document.querySelector('#errorMsg');

  if (!titleInput.value || !authorInput.value) {
    errorMsgContainer.style.display = 'block';
    errorMsgContainer.textContent = 'All fields are required!';
    return;
  }

  fetch(API_URL, {
    method: 'POST',
    body: JSON.stringify({
      author: authorInput.value,
      title: titleInput.value,
    }),
  }).then(() => {
    errorMsgContainer.style.display = 'none';
    titleInput.value = '';
    authorInput.value = '';

    getAllBooks();
  });
}

function updateBook(e) {
  const bookId = e.currentTarget.dataset.bookid;
  const titleInput = document.querySelector('#form input[name="title"]');
  const authorInput = document.querySelector('#form input[name="author"]');

  fetch(`${API_URL}/${bookId}`, {
    method: 'PUT',
    body: JSON.stringify({
      title: titleInput.value,
      author: authorInput.value,
    }),
  }).then(() => {
    titleInput.value = '';
    authorInput.value = '';
    document.querySelector('h3').textContent = 'FORM';
    document.querySelector('#form button').textContent = 'Submit';

    getAllBooks();
  });
}

function fillEditForm(e) {
  const title =
    e.currentTarget.parentElement.querySelector('td:nth-child(1)').textContent;

  const author =
    e.currentTarget.parentElement.querySelector('td:nth-child(2)').textContent;

  document.querySelector('h3').textContent = 'Edit FORM';
  document.querySelector('#form input[name="title"]').value = title;
  document.querySelector('#form input[name="author"]').value = author;

  const submitBtn = document.querySelector('#form button');
  submitBtn.textContent = 'Save';
  submitBtn.setAttribute('data-bookid', e.currentTarget.dataset.bookid);
}

attachEvents();
