function toggle() {
  const toggleBtn = document.querySelector('.button');
  const extraInfo = document.querySelector('#extra');

  if (toggleBtn.textContent === 'More') {
    toggleBtn.textContent = 'Less';
    extraInfo.style.display = 'block';
  } else {
    toggleBtn.textContent = 'More';
    extraInfo.style.display = 'none';
  }
}
