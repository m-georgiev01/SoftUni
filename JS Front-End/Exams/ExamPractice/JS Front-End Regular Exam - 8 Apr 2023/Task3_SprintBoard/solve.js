const API_URL = 'http://localhost:3030/jsonstore/tasks';

const tasksContainers = {
  ToDo: document.querySelector('#todo-section .task-list'),
  'In Progress': document.querySelector('#in-progress-section .task-list'),
  'Code Review': document.querySelector('#code-review-section .task-list'),
  Done: document.querySelector('#done-section .task-list'),
};

const taskButtonText = {
  ToDo: 'Move to In Progress',
  'In Progress': 'Move to Code Review',
  'Code Review': 'Move to Done',
  Done: 'Close',
};

const textContentToStatusMap = {
  'Move to In Progress': 'In Progress',
  'Move to Code Review': 'Code Review',
  'Move to Done': 'Done',
};

function attachEvents() {
  document
    .querySelector('#load-board-btn')
    .addEventListener('click', loadTasks);

  document
    .querySelector('#create-task-btn')
    .addEventListener('click', createNewSprintTask);
}

function loadTasks() {
  fetch(API_URL)
    .then((response) => response.json())
    .then((tasks) => {
      Object.values(tasksContainers).forEach((ul) => {
        ul.innerHTML = '';
      });

      Object.values(tasks).forEach((task) => {
        tasksContainers[task.status].appendChild(createTaskAsDOMElement(task));
      });
    });
}

function createNewSprintTask() {
  const titleInput = document.querySelector('#title');
  const descriptionInput = document.querySelector('#description');

  if (titleInput.value === '' || descriptionInput.value === '') {
    return;
  }

  fetch(API_URL, {
    method: 'POST',
    body: JSON.stringify({
      description: descriptionInput.value,
      status: 'ToDo',
      title: titleInput.value,
    }),
  }).then(() => {
    titleInput.value = '';
    descriptionInput.value = '';

    loadTasks();
  });
}

function createTaskAsDOMElement(task) {
  const listItem = createElement('li', null, ['task']);
  createElement('h3', task.title, null, null, listItem);
  createElement('p', task.description, null, null, listItem);
  const btn = createElement(
    'button',
    taskButtonText[task.status],
    null,
    task._id
  );
  btn.addEventListener('click', changeTaskStatus);
  listItem.appendChild(btn);

  return listItem;
}

function changeTaskStatus(e) {
  const btn = e.target;
  const taskid = btn.id;

  if (btn.textContent === 'Close') {
    deleteTask(btn.parentElement, taskid);
    return;
  }

  fetch(`${API_URL}/${taskid}`, {
    method: 'PATCH',
    body: JSON.stringify({
      status: textContentToStatusMap[btn.textContent],
    }),
  }).then(loadTasks);
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
    element.setAttribute('id', id);
  }

  if (parent) {
    parent.appendChild(element);
  }

  return element;
}

function deleteTask(taskDOMElement, taskid) {
  fetch(`${API_URL}/${taskid}`, {
    method: 'DELETE',
  }).then(loadTasks);
}

attachEvents();
