function revealWords (searchedWords, text){
    const searchedWordsArr = searchedWords.split(', ');
    const textArr = text.split(' ');
    
    for (let i = 0; i < textArr.length; i++) {
        if (textArr[i].includes('*')) {
            for (let j = 0; j < searchedWordsArr.length; j++) {
                if (textArr[i].length === searchedWordsArr[j].length) {
                    textArr[i] = searchedWordsArr[j];
                }            
            }
        }   
    }

    console.log(textArr.join(' '));
}