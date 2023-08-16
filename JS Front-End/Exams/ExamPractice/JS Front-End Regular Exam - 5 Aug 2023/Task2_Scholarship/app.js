window.addEventListener('load', solve);

function solve() {
  const inputSelectors = {
    studentName: document.querySelector('#student'),
    university: document.querySelector('#university'),
    score: document.querySelector('#score'),
  };

  const otherSelectors = {
    nextBtn: document.querySelector('#next-btn'),
    previewContainer: document.querySelector('#preview-list'),
    candidatesContainer: document.querySelector('#candidates-list'),
  };

  otherSelectors.nextBtn.addEventListener('click', handleFormSubmission);

  function handleFormSubmission() {
    const isEmpty = Object.values(inputSelectors).some((i) => i.value === '');
    if (isEmpty) {
      return;
    }

    const application = {
      studentName: inputSelectors.studentName.value,
      university: inputSelectors.university.value,
      score: inputSelectors.score.value,
    };

    otherSelectors.previewContainer.appendChild(renderApplication(application));

    otherSelectors.nextBtn.disabled = true;

    Object.values(inputSelectors).forEach((i) => {
      i.value = '';
    });
  }

  function renderApplication(application) {
    const container = createElement('li', null, ['application']);

    const contentContainer = createElement('article');
    createElement('h4', application.studentName, null, contentContainer);
    createElement(
      'p',
      `University: ${application.university}`,
      null,
      contentContainer
    );
    createElement('p', `Score: ${application.score}`, null, contentContainer);
    container.appendChild(contentContainer);

    const editBtn = createElement('button', 'edit', ['action-btn', 'edit']);
    editBtn.addEventListener('click', (e) => {
      inputSelectors.studentName.value = application.studentName;
      inputSelectors.university.value = application.university;
      inputSelectors.score.value = application.score;

      e.currentTarget.parentNode.remove();

      otherSelectors.nextBtn.disabled = false;
    });
    container.appendChild(editBtn);

    const applyBtn = createElement('button', 'apply', ['action-btn', 'apply']);
    applyBtn.addEventListener('click', (e) => {
      const application = e.currentTarget.parentNode;
      Array.from(application.querySelectorAll('button')).forEach((btn) => {
        btn.remove();
      });

      otherSelectors.candidatesContainer.appendChild(application);
      otherSelectors.nextBtn.disabled = false;
    });
    container.appendChild(applyBtn);

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
}
