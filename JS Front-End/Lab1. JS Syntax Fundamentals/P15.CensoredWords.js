function censoreText(text, wordToReplace){
    const replacingWord = '*'.repeat(wordToReplace.length);

    while (text.includes(wordToReplace)) {
        text = text.replace(wordToReplace, replacingWord);
    }

    console.log(text);
}

censoreText('Find the hidden word', 'hidden');