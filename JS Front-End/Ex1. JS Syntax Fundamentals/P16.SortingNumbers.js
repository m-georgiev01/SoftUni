function sortArr(numbers){
    const sortedAsc = [...numbers].sort((a, b) => a - b);
    const sortedDesc = numbers.sort((a, b) => b - a);
    const count = Math.floor(sortedAsc.length / 2);

    const result = [];

    for (let i = 0; i < count; i++) {
        result.push(sortedAsc[i]);            
        result.push(sortedDesc[i]);            
    }

    if (numbers.length % 2 !== 0) {
        result.push(sortedAsc[count]);
    }

    return result;
}

sortArr([1, 65, 3, 52, 48, 63, 31, -3, 18, 56])