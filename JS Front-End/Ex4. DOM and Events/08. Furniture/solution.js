function solve() {
  const generateBtn = document.querySelector('#exercise > button');
  generateBtn.addEventListener('click', (e) => {
    const textArea = document.querySelector('#exercise > textarea').value;
    const furnitureArr = JSON.parse(textArea);

    furnitureArr.forEach((furniture) => {
      const newTr = document.createElement('tr');

      newTr.appendChild(cellCreator.createImageCell(furniture.img));
      newTr.appendChild(cellCreator.createTextCell(furniture.name));
      newTr.appendChild(cellCreator.createTextCell(furniture.price));
      newTr.appendChild(cellCreator.createTextCell(furniture.decFactor));
      newTr.appendChild(cellCreator.createCheckboxCell());

      const container = document.querySelector('tbody');
      container.appendChild(newTr);
    });
  });

  const cellCreator = {
    createImageCell(src) {
      const imgCell = document.createElement('td');
      const img = document.createElement('img');
      img.src = src;
      imgCell.appendChild(img);

      return imgCell;
    },

    createTextCell(text) {
      const textCell = document.createElement('td');
      const textParagraph = document.createElement('p');
      textParagraph.textContent = text;
      textCell.appendChild(textParagraph);

      return textCell;
    },

    createCheckboxCell() {
      const checkCell = document.createElement('td');
      const checkbox = document.createElement('input');
      checkbox.type = 'checkbox';
      checkCell.appendChild(checkbox);

      return checkCell;
    },
  };

  const buyBtn = document.querySelectorAll('#exercise > button')[1];
  buyBtn.addEventListener('click', (e) => {
    const checkedBoxes = Array.from(document.querySelectorAll('input:checked'));

    const result = [];
    result.push(
      checkedBoxes
        .reduce((acc, curr) => {
          const currFurnitureName =
            curr.parentElement.parentElement.querySelector(
              'td:nth-child(2) p'
            ).textContent;

          return (acc += currFurnitureName + ', ');
        }, 'Bought furniture: ')
        .slice(0, -2)
    );

    const totalPrice = checkedBoxes.reduce((acc, curr) => {
      const currFurniturePrice = Number(
        curr.parentElement.parentElement.querySelector('td:nth-child(3) p')
          .textContent
      );

      return (acc += currFurniturePrice);
    }, 0);

    result.push(`Total price: ${totalPrice.toFixed(2)}`);

    const avg =
      checkedBoxes.reduce((acc, curr) => {
        const currDecFactor = Number(
          curr.parentElement.parentElement.querySelector('td:nth-child(4) p')
            .textContent
        );

        return (acc += currDecFactor);
      }, 0) / checkedBoxes.length;

    result.push(`Average decoration factor: ${avg}`);

    const resultContainer = document.querySelectorAll('textarea')[1];
    resultContainer.value = result.join('\n');
  });
}
