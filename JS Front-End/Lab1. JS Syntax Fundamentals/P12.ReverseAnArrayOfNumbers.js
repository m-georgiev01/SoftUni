function reverseArray(count, nums){
    console.log(nums.slice(0, count).reverse().join(" "));
}

reverseArray(4, [-1, 20, 99, 5]);