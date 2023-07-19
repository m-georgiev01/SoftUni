function lockedProfile() {
  const btns = Array.from(document.querySelectorAll('button'));

  btns.forEach((btn) => {
    btn.addEventListener('click', (e) => {
      const lockedRadioBtn = e.currentTarget.parentElement.querySelector(
        'input[type="radio"]'
      );

      if (lockedRadioBtn.checked) {
        return;
      }

      const isHidden = e.currentTarget.textContent === 'Show more';
      const hiddenInfo = e.currentTarget.parentElement.querySelector('div');

      hiddenInfo.style.display = isHidden ? 'block' : 'none';
      e.currentTarget.textContent = isHidden ? 'Hide it' : 'Show more';
    });
  });
}
