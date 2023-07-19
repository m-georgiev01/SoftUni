function create(words) {
  words.forEach((element) => {
    const p = document.createElement('p');
    p.textContent = element;
    p.style.display = 'none';

    const newDiv = document.createElement('div');
    newDiv.appendChild(p);
    newDiv.addEventListener('click', (e) => {
      e.currentTarget.querySelector('p').style.display = 'block';
    });

    document.querySelector('#content').appendChild(newDiv);
  });
}
