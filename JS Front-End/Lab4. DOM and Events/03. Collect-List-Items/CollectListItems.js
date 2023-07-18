function extractText() {
  const listItemsAsText = Array.from(document.querySelectorAll('#items > li'))
    .map((li) => li.textContent)
    .join('\n');

  document.querySelector('#result').textContent = listItemsAsText;
}
