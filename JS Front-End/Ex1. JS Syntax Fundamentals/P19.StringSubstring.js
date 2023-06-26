function searchForWord(word, text){
    let s = 's'
    let isFound = false;

    const textArr = text.split(/[, :!?]/gm)
                        .map((el) => el.toLowerCase())
                        .forEach(element => {
                            if (element === word) {
                                isFound = true;
                                return;
                            }
                        });;

    if (isFound) {
        console.log(word);
    } else{
        console.log(`${word} not found!`);    
    }                   
}

searchForWord('pythbhon', 'JavaScript is the best programming language');