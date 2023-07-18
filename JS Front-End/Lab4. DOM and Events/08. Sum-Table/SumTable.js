function sumTable() {
  const costs = Array.from(
    document.querySelectorAll('td:nth-child(even):not(#sum)')
  );

  const total = costs.reduce((acc, curr) => {
    return (acc += Number(curr.textContent));
  }, 0);

  document.querySelector('#sum').textContent = total;
}
