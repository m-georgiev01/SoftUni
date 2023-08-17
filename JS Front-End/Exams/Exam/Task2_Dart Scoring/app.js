window.addEventListener('load', solve);

function solve() {
  const inputSelectors = {
    player: document.querySelector('#player'),
    score: document.querySelector('#score'),
    round: document.querySelector('#round'),
  };

  const otherSelectors = {
    addBtn: document.querySelector('#add-btn'),
    sureList: document.querySelector('#sure-list'),
    scoreboardList: document.querySelector('#scoreboard-list'),
    clearBtn: document.querySelector('.clear'),
  };

  otherSelectors.addBtn.addEventListener('click', addInfo);
  otherSelectors.clearBtn.addEventListener('click', reloadApplication);

  function addInfo() {
    const isEmpty = Object.values(inputSelectors).some((i) => i.value === '');
    if (isEmpty) {
      return;
    }

    const dartItem = {
      player: inputSelectors.player.value,
      score: inputSelectors.score.value,
      round: inputSelectors.round.value,
    };

    otherSelectors.sureList.appendChild(renderDartItem(dartItem));

    otherSelectors.addBtn.disabled = true;

    Object.values(inputSelectors).forEach((i) => {
      i.value = '';
    });
  }

  function reloadApplication() {
    location.reload();
  }

  function renderDartItem(dartItem) {
    const container = createElement('li', null, ['dart-item']);

    const contentContainer = createElement('article');
    createElement('p', dartItem.player, null, contentContainer);
    createElement('p', `Score: ${dartItem.score}`, null, contentContainer);
    createElement('p', `Round: ${dartItem.round}`, null, contentContainer);
    container.appendChild(contentContainer);

    const editBtn = createElement('button', 'edit', ['btn', 'edit']);
    editBtn.addEventListener('click', (e) => {
      inputSelectors.player.value = dartItem.player;
      inputSelectors.score.value = dartItem.score;
      inputSelectors.round.value = dartItem.round;

      e.currentTarget.parentNode.remove();

      otherSelectors.addBtn.disabled = false;
    });

    container.appendChild(editBtn);

    const okBtn = createElement('button', 'ok', ['btn', 'ok']);
    okBtn.addEventListener('click', (e) => {
      const dartItem = e.currentTarget.parentNode;

      Array.from(dartItem.querySelectorAll('button')).forEach((btn) => {
        btn.remove();
      });

      otherSelectors.scoreboardList.appendChild(dartItem);
      otherSelectors.addBtn.disabled = false;
    });

    container.appendChild(okBtn);

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
