const API_URL = 'http://localhost:3030/jsonstore/tasks';

const inputDOMSelectors = {
  title: document.querySelector('#course-name'),
  type: document.querySelector('#course-type'),
  description: document.querySelector('#description'),
  teacher: document.querySelector('#teacher-name'),
};

const otherSelectors = {
  coursesInProgressContainer: document.querySelector('#list'),
  addBtn: document.querySelector('#add-course'),
  editBtn: document.querySelector('#edit-course'),
};

const courseTypes = ['Long', 'Medium', 'Short'];

function attachEvents() {
  document
    .querySelector('#load-course')
    .addEventListener('click', loadAllCourses);

  otherSelectors.addBtn.addEventListener('click', addCourse);

  otherSelectors.editBtn.addEventListener('click', editCourse);
}

function loadAllCourses() {
  fetch(API_URL)
    .then((response) => response.json())
    .then((courses) => {
      otherSelectors.coursesInProgressContainer.innerHTML = '';

      Object.values(courses).forEach((course) => {
        otherSelectors.coursesInProgressContainer.appendChild(
          renderCourse(course)
        );
      });
    });
}

async function addCourse(e) {
  e.preventDefault();

  const type = inputDOMSelectors.type.value;

  if (!courseTypes.includes(type)) {
    return;
  }

  const course = {
    title: inputDOMSelectors.title.value,
    type,
    description: inputDOMSelectors.description.value,
    teacher: inputDOMSelectors.teacher.value,
  };

  await fetch(API_URL, {
    method: 'POST',
    body: JSON.stringify(course),
  });

  otherSelectors.coursesInProgressContainer.children.length === 0
    ? loadAllCourses()
    : otherSelectors.coursesInProgressContainer.appendChild(
        renderCourse(course)
      );

  Object.values(inputDOMSelectors).forEach((input) => {
    input.value = '';
  });
}

function editCourse(e) {
  e.preventDefault();

  const courseId = e.currentTarget.dataset.courseid;

  fetch(`${API_URL}/${courseId}`, {
    method: 'PATCH',
    body: JSON.stringify({
      title: inputDOMSelectors.title.value,
      type: inputDOMSelectors.type.value,
      description: inputDOMSelectors.description.value,
      teacher: inputDOMSelectors.teacher.value,
    }),
  }).then(() => {
    loadAllCourses();

    otherSelectors.editBtn.disabled = true;
    otherSelectors.addBtn.disabled = false;

    Object.values(inputDOMSelectors).forEach((input) => {
      input.value = '';
    });
  });
}

function renderCourse(course) {
  const container = createElement('div', null, ['container']);

  createElement('h2', course.title, null, container);
  createElement('h3', course.teacher, null, container);
  createElement('h4', course.type, null, container);
  createElement('h4', course.description, null, container);

  const editBtn = createElement('button', 'Edit Course', ['edit-btn']);
  editBtn.addEventListener('click', fillFormForEdit);
  container.appendChild(editBtn);

  const deleteBtn = createElement('button', 'Finish Course', ['finish-btn']);
  deleteBtn.setAttribute('data-courseid', course._id);
  deleteBtn.addEventListener('click', deleteCourse);
  container.appendChild(deleteBtn);

  return container;

  function fillFormForEdit() {
    inputDOMSelectors.title.value = course.title;
    inputDOMSelectors.type.value = course.type;
    inputDOMSelectors.description.value = course.description;
    inputDOMSelectors.teacher.value = course.teacher;

    otherSelectors.editBtn.setAttribute('data-courseid', course._id);
    otherSelectors.editBtn.disabled = false;

    otherSelectors.addBtn.disabled = true;
  }
}

function deleteCourse(e) {
  const courseId = e.currentTarget.dataset.courseid;

  fetch(`${API_URL}/${courseId}`, {
    method: 'DELETE',
  }).then(() => {
    loadAllCourses();
  });
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
