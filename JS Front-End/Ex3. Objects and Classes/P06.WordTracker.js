function solve(input) {
  const searchedWords = [];

  input
    .shift()
    .split(' ')
    .forEach((word) => {
      searchedWords.push({
        word,
        count: 0,
      });
    });

  input.forEach((word) => {
    const searchedWord = searchedWords.find((w) => w.word === word);
    if (searchedWord) {
      searchedWord.count++;
    }
  });

  searchedWords
    .sort((a, b) => b.count - a.count)
    .forEach((w) => {
      console.log(`${w.word} - ${w.count}`);
    });
}
