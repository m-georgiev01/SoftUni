const API_URL = 'http://localhost:3030/jsonstore/tasks';

const inputSelectors = {
  location: document.querySelector('#location'),
  temperature: document.querySelector('#temperature'),
  date: document.querySelector('#date'),
};

const otherSelectors = {
  loadHistoryBtn: document.querySelector('#load-history'),
  editWeatherBtn: document.querySelector('#edit-weather'),
  addWeatherBtn: document.querySelector('#add-weather'),
  historyContainer: document.querySelector('#list'),
};

function attachEvents() {
  otherSelectors.loadHistoryBtn.addEventListener('click', loadHistory);
  otherSelectors.addWeatherBtn.addEventListener('click', addWeather);
  otherSelectors.editWeatherBtn.addEventListener('click', editWeather);
}

function loadHistory() {
  fetch(API_URL)
    .then((response) => response.json())
    .then((weatherHistory) => {
      otherSelectors.historyContainer.innerHTML = '';

      Object.values(weatherHistory).forEach((wh) => {
        otherSelectors.historyContainer.appendChild(renderHistoryRecord(wh));
      });

      otherSelectors.editWeatherBtn.disabled = true;
    });
}

function addWeather() {
  fetch(API_URL, {
    method: 'POST',
    body: JSON.stringify({
      location: inputSelectors.location.value,
      temperature: inputSelectors.temperature.value,
      date: inputSelectors.date.value,
    }),
  }).then(() => {
    loadHistory();

    Object.values(inputSelectors).forEach((i) => {
      i.value = '';
    });
  });
}

function editWeather(e) {
  const weather = {
    location: inputSelectors.location.value,
    temperature: inputSelectors.temperature.value,
    date: inputSelectors.date.value,
  };

  const weatherId = e.currentTarget.dataset.weatherid;

  fetch(`${API_URL}/${weatherId}`, {
    method: 'PUT',
    body: JSON.stringify(weather),
  }).then(() => {
    loadHistory();

    otherSelectors.editWeatherBtn.disabled = true;
    otherSelectors.addWeatherBtn.disabled = false;
  });
}

function renderHistoryRecord(weatherHistory) {
  const container = createElement('div', null, ['container']);
  createElement('h2', weatherHistory.location, null, null, container);
  createElement('h3', weatherHistory.date, null, null, container);
  createElement('h3', weatherHistory.temperature, null, 'celsius', container);

  const btnContainer = createElement('div', null, ['buttons-container']);

  const changeBtn = createElement('button', 'Change', ['change-btn']);
  changeBtn.addEventListener('click', (e) => {
    e.currentTarget.parentNode.remove();

    inputSelectors.location.value = weatherHistory.location;
    inputSelectors.temperature.value = weatherHistory.temperature;
    inputSelectors.date.value = weatherHistory.date;

    otherSelectors.editWeatherBtn.setAttribute(
      'data-weatherid',
      weatherHistory._id
    );

    otherSelectors.editWeatherBtn.disabled = false;
    otherSelectors.addWeatherBtn.disabled = true;
  });
  btnContainer.appendChild(changeBtn);

  const deleteBtn = createElement('button', 'Delete', ['delete-btn']);
  deleteBtn.addEventListener('click', () => {
    fetch(`${API_URL}/${weatherHistory._id}`, {
      method: 'DELETE',
    }).then(() => {
      loadHistory();
    });
  });
  btnContainer.appendChild(deleteBtn);

  container.appendChild(btnContainer);

  return container;
}

function createElement(type, textContent, classes, id, parent) {
  const element = document.createElement(type);

  if (textContent) {
    element.textContent = textContent;
  }

  if (classes && classes.length > 0) {
    element.classList.add(...classes);
  }

  if (id) {
    element.id = id;
  }

  if (parent) {
    parent.appendChild(element);
  }

  return element;
}

attachEvents();
