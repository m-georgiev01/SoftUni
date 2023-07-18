function deleteByEmail() {
  const wantedEmail = document.querySelector('input[name="email"]').value;

  const email = Array.from(document.querySelectorAll('td:nth-child(even)'))
    .filter((td) => td.innerText === wantedEmail)
    .shift();

  const resultDiv = document.querySelector('#result');
  if (email) {
    resultDiv.textContent = 'Deleted.';
    email.parentElement.remove();
  } else {
    resultDiv.textContent = 'Not found.';
  }
}
