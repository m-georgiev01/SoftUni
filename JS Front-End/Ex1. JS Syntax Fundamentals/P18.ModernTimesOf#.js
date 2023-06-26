function printSpecialWords(text){
    const result = [];
    const textArr = text.split(' ');

    textArr.forEach(element => {
        if (element.match(/#[A-Za-z]+/gm)) {
            result.push(element.substring(1, element.length));
        }
    });

    console.log(result.join('\n'));
}

printSpecialWords('The symbol # is known #variously in English-speaking #regions as the #number sign')