const API_URL = 'http://localhost:3030/jsonstore/messenger';

function attachEvents() {
  document.querySelector('#submit').addEventListener('click', sendMessage);
  document.querySelector('#refresh').addEventListener('click', getMessages);
}

function sendMessage() {
  const author = document.querySelector('input[name="author"]').value;
  const content = document.querySelector('input[name="content"]').value;

  fetch(API_URL, {
    method: 'POST',
    body: JSON.stringify({ author, content }),
  });
}

function getMessages() {
  fetch(API_URL)
    .then((res) => res.json())
    .then((messages) => {
      const text = Object.values(messages).reduce((acc, curr) => {
        return acc + `${curr.author}: ${curr.content}\n`;
      }, '');

      document.querySelector('#messages').textContent = text.trimEnd();
    });
}

attachEvents();
