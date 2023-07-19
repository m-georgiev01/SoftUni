function subtract() {
  const firstNum = Number(document.querySelector('#firstNumber').value);
  const secondNum = Number(document.querySelector('#secondNumber').value);

  const resultDiv = document.querySelector('#result');
  resultDiv.textContent = firstNum - secondNum;
}
