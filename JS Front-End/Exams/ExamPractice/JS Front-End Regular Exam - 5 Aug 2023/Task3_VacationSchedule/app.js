const API_URL = 'http://localhost:3030/jsonstore/tasks';

const inputSelectors = {
  name: document.querySelector('#name'),
  numDays: document.querySelector('#num-days'),
  fromDate: document.querySelector('#from-date'),
};

const otherSelectors = {
  loadVacationsBtn: document.querySelector('#load-vacations'),
  editVacationBtn: document.querySelector('#edit-vacation'),
  addVacationBtn: document.querySelector('#add-vacation'),
  confirmedVacationsContainer: document.querySelector('#list'),
};

function attachEvents() {
  otherSelectors.loadVacationsBtn.addEventListener(
    'click',
    loadConfirmedVacations
  );

  otherSelectors.addVacationBtn.addEventListener('click', addVacation);

  otherSelectors.editVacationBtn.addEventListener('click', editVacation);
}

async function loadConfirmedVacations() {
  const response = await fetch(API_URL);
  const condirmedVacations = await response.json();

  otherSelectors.confirmedVacationsContainer.innerHTML = '';

  Object.values(condirmedVacations).forEach((cv) => {
    otherSelectors.confirmedVacationsContainer.appendChild(
      renderConfirmedVacation(cv)
    );
  });

  otherSelectors.editVacationBtn.disabled = true;
}

async function addVacation(e) {
  e.preventDefault();

  await fetch(API_URL, {
    method: 'POST',
    body: JSON.stringify({
      name: inputSelectors.name.value,
      days: inputSelectors.numDays.value,
      date: inputSelectors.fromDate.value,
    }),
  });

  Object.values(inputSelectors).forEach((i) => {
    i.value = '';
  });

  await loadConfirmedVacations();
}

async function editVacation(e) {
  e.preventDefault();

  const vacation = {
    name: inputSelectors.name.value,
    days: inputSelectors.numDays.value,
    date: inputSelectors.fromDate.value,
  };

  const vacationId = e.currentTarget.dataset.vacationid;

  await fetch(`${API_URL}/${vacationId}`, {
    method: 'PUT',
    body: JSON.stringify(vacation),
  });

  await loadConfirmedVacations();

  otherSelectors.editVacationBtn.disabled = true;
  otherSelectors.addVacationBtn.disabled = false;
}

function renderConfirmedVacation(confirmedVacation) {
  const container = createElement('div', null, ['container']);

  createElement('h2', confirmedVacation.name, null, container);
  createElement('h3', confirmedVacation.date, null, container);
  createElement('h3', confirmedVacation.daus, null, container);

  const changeBtn = createElement('button', 'Change', ['change-btn']);
  changeBtn.addEventListener('click', (e) => {
    e.currentTarget.parentNode.remove();

    inputSelectors.name.value = confirmedVacation.name;
    inputSelectors.numDays.value = confirmedVacation.days;
    inputSelectors.fromDate.value = confirmedVacation.date;
    otherSelectors.editVacationBtn.setAttribute(
      'data-vacationid',
      confirmedVacation._id
    );

    otherSelectors.editVacationBtn.disabled = false;
    otherSelectors.addVacationBtn.disabled = true;
  });

  container.appendChild(changeBtn);

  const deleteBtn = createElement('button', 'Done', ['done-btn']);
  deleteBtn.addEventListener('click', () => {
    fetch(`${API_URL}/${confirmedVacation._id}`, {
      method: 'DELETE',
    }).then(() => {
      loadConfirmedVacations();
    });
  });

  container.appendChild(deleteBtn);

  return container;
}

function createElement(type, textContent, classes, parent) {
  const element = document.createElement(type);

  if (textContent) {
    element.textContent = textContent;
  }

  if (classes && classes.length > 0) {
    element.classList.add(...classes);
  }

  if (parent) {
    parent.appendChild(element);
  }

  return element;
}

attachEvents();
