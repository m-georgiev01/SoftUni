function printMultiplicationTable(number){
    let multiplicationTable = [];

    for (let i = 1; i <= 10; i++) {
        multiplicationTable.push(`${number} X ${i} = ${number * i}`);          
    }

    console.log(multiplicationTable.join('\n'));
}