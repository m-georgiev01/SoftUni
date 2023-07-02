function printOddAndEvenSum(number) {
  const numberAsString = number.toString();
  let oddSum = 0;
  let evenSum = 0;

  for (let i = 0; i < numberAsString.length; i++) {
    const currDigit = Number.parseInt(numberAsString[i]);

    if (currDigit % 2 !== 0) {
      oddSum += currDigit;
    } else {
      evenSum += currDigit;
    }
  }

  console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}
