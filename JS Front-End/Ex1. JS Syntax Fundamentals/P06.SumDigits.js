function sumOfDigits(number){
    let sum = 0;

    for (let i = 0; i < number.toString().length; i++) {
        sum += parseInt(number.toString()[i]);
    }

    console.log(sum);
}