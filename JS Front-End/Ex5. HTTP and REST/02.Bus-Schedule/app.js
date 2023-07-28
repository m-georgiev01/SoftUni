function solve() {
  let currentBusStop = {
    name: '',
    next: 'depot',
  };

  const busNameContainer = document.querySelector('#info .info');
  const departBtn = document.querySelector('#depart');
  const arriveBtn = document.querySelector('#arrive');

  function depart() {
    fetch(`http://localhost:3030/jsonstore/bus/schedule/${currentBusStop.next}`)
      .then((response) => response.json())
      .then((busInfo) => {
        departBtn.disabled = true;
        arriveBtn.disabled = false;
        currentBusStop = busInfo;

        busNameContainer.textContent = `Next stop ${currentBusStop.name}`;
      })
      .catch((_) => {
        busNameContainer.textContent = 'Error';
        departBtn.disabled = true;
        arriveBtn.disabled = true;
      });
  }

  async function arrive() {
    departBtn.disabled = false;
    arriveBtn.disabled = true;

    busNameContainer.textContent = `Arriving at ${currentBusStop.name}`;
  }

  return {
    depart,
    arrive,
  };
}

let result = solve();
