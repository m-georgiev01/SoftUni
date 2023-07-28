function getInfo() {
  const wantedStopId = document.querySelector('#stopId').value;
  const stopName = document.querySelector('#stopName');
  const busesContainer = document.querySelector('#buses');

  busesContainer.innerHTML = '';

  const busInfo = fetch(
    `http://localhost:3030/jsonstore/bus/businfo/${wantedStopId}`
  )
    .then((response) => response.json())
    .then((data) => {
      stopName.textContent = data.name;

      console.log(Object.keys(data.buses));
      console.log(data.buses[4]);

      Object.keys(data.buses).forEach((busId) => {
        const currElement = createListItem(busId, data.buses[busId]);
        busesContainer.appendChild(currElement);
      });
    })
    .catch((err) => {
      stopName.textContent = 'Error';
    });

  function createListItem(busId, time) {
    const newListItem = document.createElement('li');
    newListItem.textContent = `Bus ${busId} arrives in ${time} minutes`;

    return newListItem;
  }
}
