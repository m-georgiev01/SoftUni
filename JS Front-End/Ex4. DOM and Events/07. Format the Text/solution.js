function solve() {
  const sentences = document.querySelector('#input').value.split('.');
  //clear last empty element
  sentences.pop();

  const container = document.querySelector('#output');

  while (sentences.length > 0) {
    const p = document.createElement('p');
    p.textContent = `${sentences
      .splice(0, 3)
      .map((text) => text.trim())
      .join('.')}.`;

    container.appendChild(p);
  }
}
