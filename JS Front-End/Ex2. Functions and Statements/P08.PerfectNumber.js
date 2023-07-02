function checkIfItsPerfectNumber(number) {
  let aliquotSum = 0;

  for (let i = number - 1; i > 0; i--) {
    if (number % i === 0) {
      aliquotSum += i;
    }
  }

  if (number === aliquotSum) {
    console.log('We have a perfect number!');
  } else {
    console.log("It's not so perfect.");
  }
}
