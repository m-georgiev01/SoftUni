window.addEventListener('load', solve);

function solve() {
  const inputSelectors = {
    title: document.querySelector('#task-title'),
    category: document.querySelector('#task-category'),
    content: document.querySelector('#task-content'),
  };

  const otherSelectors = {
    publishBtn: document.querySelector('#publish-btn'),
    containerTasksForReview: document.querySelector('#review-list'),
    containerUploadedTasks: document.querySelector('#published-list'),
  };

  otherSelectors.publishBtn.addEventListener('click', publishTask);

  function publishTask() {
    const hasInvalidInputValue = Object.values(inputSelectors).some(
      (input) => input.value === ''
    );

    if (hasInvalidInputValue) {
      return;
    }

    otherSelectors.containerTasksForReview.appendChild(createTask());

    Object.values(inputSelectors).forEach((input) => {
      input.value = '';
    });
  }

  function createTask() {
    const container = createElement('li', null, ['rpost']);
    const taskContentContainer = createElement('article');

    createElement(
      'h4',
      inputSelectors.title.value,
      null,
      null,
      taskContentContainer
    );

    createElement(
      'p',
      `Category: ${inputSelectors.category.value}`,
      null,
      null,
      taskContentContainer
    );

    createElement(
      'p',
      `Content: ${inputSelectors.content.value}`,
      null,
      null,
      taskContentContainer
    );

    container.appendChild(taskContentContainer);

    const editBtn = createElement('button', 'Edit', ['action-btn', 'edit']);
    editBtn.addEventListener('click', handleEditEvent);
    container.appendChild(editBtn);

    const postBtn = createElement('button', 'Post', ['action-btn', 'post']);
    postBtn.addEventListener('click', handlePostEvent);
    container.appendChild(postBtn);

    return container;
  }

  function handleEditEvent(e) {
    const title = e.currentTarget.parentNode.querySelector('h4').textContent;
    const category = e.currentTarget.parentNode
      .querySelector('article p')
      .textContent.split(': ')[1];

    const content = e.currentTarget.parentNode
      .querySelectorAll('article p')[1]
      .textContent.split(': ')[1];

    inputSelectors.title.value = title;
    inputSelectors.category.value = category;
    inputSelectors.content.value = content;

    e.currentTarget.parentNode.remove();
  }

  function handlePostEvent(e) {
    const task = e.currentTarget.parentNode;
    Array.from(task.querySelectorAll('button')).forEach((btn) => {
      btn.remove();
    });

    otherSelectors.containerUploadedTasks.appendChild(task);
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
}
