function countStringOccurrences(text, searchedWord){
    const words = text.split(' ');
    let count = 0;

    words.forEach(element => {
        if(element === searchedWord){
            count++;
        }
    });

    console.log(count);
}

countStringOccurrences('This is a word and it also is a sentence', 'is');