function printRange(start, end){
    let sum = 0;
    let nums = [];

    for (let i = start; i <= end; i++) {
        nums.push(i);    
        sum += i;
    }

    console.log(nums.join(' '));
    console.log(`Sum: ${sum}`);
}