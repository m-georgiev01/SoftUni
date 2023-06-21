function calculate(numbers){
    let evenSum = 0;
    let oddSum = 0;

    numbers.forEach(element => {
        if (element % 2 == 0) {
            evenSum += element;
        }else {
            oddSum += element;
        }
    });

    console.log(evenSum - oddSum);
}

calculate([2,4,6,8,10]);