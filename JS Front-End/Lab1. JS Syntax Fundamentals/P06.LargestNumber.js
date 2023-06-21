function printMaxNumber (...params) {
    console.log(`The largest number is ${Math.max(...params)}.`);
}

printMaxNumber(1, 5, 8, 6);