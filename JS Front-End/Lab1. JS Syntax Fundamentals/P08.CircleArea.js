function calculateCircleArea (radius){
    const typeOfInput = typeof radius;

    if (typeOfInput !== 'number') {
        console.log(`We can not calculate the circle area, because we receive a ${typeOfInput}.`);
    }else {
        const result = Math.PI * Math.pow(radius, 2);
        console.log(result.toFixed(2));
    }
}

calculateCircleArea(5);