function checkForPalindromeIntegers(numbers) {
  for (let i = 0; i < numbers.length; i++) {
    const currNumAsString = numbers[i].toString();
    const reversedCurrNum = currNumAsString.split('').reverse().join('');

    if (currNumAsString === reversedCurrNum) {
      console.log('true');
    } else {
      console.log('false');
    }
  }
}
