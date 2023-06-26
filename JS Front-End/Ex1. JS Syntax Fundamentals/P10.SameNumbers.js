function checkSameDigits(number){
    const numberAsString = number.toString();
    let isConsistent = true;
    let sum = Number(numberAsString[0]);

    for(let i = 1; i < numberAsString.length; i++){;
        if(numberAsString[i] !== numberAsString[i - 1]){
            isConsistent = false;
        }

        sum += Number(numberAsString[i]);
    }

    console.log(isConsistent);
    console.log(sum)
}