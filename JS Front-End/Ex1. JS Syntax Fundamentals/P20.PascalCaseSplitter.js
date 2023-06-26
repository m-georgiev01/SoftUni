function splitPascalCaseText(text){
    const words = text.split(/(?=[A-Z])/gm)
    console.log(words.join(', '));
}