function printSumOfFirstAndLastElement (numbers){
    const firstElement = numbers[0];
    const lastElement = numbers[numbers.length - 1];

    console.log(firstElement + lastElement);
}

printSumOfFirstAndLastElement([10, 17, 22, 33]);