function solve() {
  document.querySelector('#searchBtn').addEventListener('click', onClick);

  function onClick() {
    clearLastSearch();

    const cells = Array.from(document.querySelectorAll('tbody td'));
    const searchInput = document.querySelector('#searchField');

    cells.forEach((cell) => {
      if (
        cell.textContent.toLowerCase().includes(searchInput.value.toLowerCase())
      ) {
        cell.parentElement.classList.add('select');
      }
    });

    searchInput.value = '';
  }

  function clearLastSearch() {
    const rows = Array.from(document.querySelectorAll('tbody tr'));

    rows.forEach((row) => {
      row.classList.remove('select');
    });
  }
}
