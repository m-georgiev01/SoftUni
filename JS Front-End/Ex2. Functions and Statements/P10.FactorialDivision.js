function factorialDivision(numOne, numTwo) {
  const factorialFirstNum = getFactorialOfNumber(numOne);
  const factorialSecondNum = getFactorialOfNumber(numTwo);

  console.log((factorialFirstNum / factorialSecondNum).toFixed(2));

  function getFactorialOfNumber(num) {
    if (num === 0 || num === 1) {
      return 1;
    }

    for (let i = num - 1; i >= 1; i--) {
      num *= i;
    }

    return num;
  }
}
