const API_URL = 'http://localhost:3030/jsonstore/collections/students';

class Student {
  constructor(firstName, lastName, facultyNumber, grade) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.facultyNumber = facultyNumber;
    this.grade = grade;
  }
}

function attachEvents() {
  window.onload = getStudents;

  document.querySelector('#submit').addEventListener('click', createNewStudent);
}

function getStudents() {
  fetch(API_URL)
    .then((response) => response.json())
    .then((students) => {
      const studentsContainer = document.querySelector('#results tbody');
      studentsContainer.innerHTML = '';

      Object.values(students).forEach((student) => {
        studentsContainer.appendChild(createStudentRow(student));
      });
    });
}

function createStudentRow(student) {
  const row = document.createElement('tr');

  row.appendChild(createStudentColumn(student.firstName));
  row.appendChild(createStudentColumn(student.lastName));
  row.appendChild(createStudentColumn(student.facultyNumber));
  row.appendChild(createStudentColumn(Number(student.grade).toFixed(2)));

  return row;

  function createStudentColumn(data) {
    const col = document.createElement('td');
    col.textContent = data;

    return col;
  }
}

function createNewStudent() {
  const fNameInput = document.querySelector('input[name="firstName"]');
  const lNameInput = document.querySelector('input[name="lastName"]');
  const facNumInput = document.querySelector('input[name="facultyNumber"]');
  const gradeInput = document.querySelector('input[name="grade"]');

  const errorMsgContainer = document.querySelector('#form .notification');
  errorMsgContainer.textContent = '';

  if (checkInputsAreEmpty(fNameInput, lNameInput, facNumInput, gradeInput)) {
    errorMsgContainer.textContent = 'All fields are required!';
    return;
  }

  if (isNaN(gradeInput.value) || gradeInput.value < 2 || gradeInput.value > 6) {
    errorMsgContainer.textContent = 'Grade should be between 2 and 6!';
    return;
  }

  const student = new Student(
    fNameInput.value,
    lNameInput.value,
    facNumInput.value,
    gradeInput.value
  );

  fetch(API_URL, {
    method: 'POST',
    body: JSON.stringify(student),
  }).then(() => {
    fNameInput.value = '';
    lNameInput.value = '';
    facNumInput.value = '';
    gradeInput.value = '';

    getStudents();
  });
}

function checkInputsAreEmpty(...inputs) {
  let isEmpty = false;

  inputs.forEach((i) => {
    if (i.value === '') {
      isEmpty = true;
    }
  });

  return isEmpty;
}

attachEvents();
