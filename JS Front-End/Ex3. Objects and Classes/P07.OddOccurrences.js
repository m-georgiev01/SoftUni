function solve(input) {
  const words = [];

  input
    .split(' ')
    .map((w) => w.toLowerCase())
    .forEach((word) => {
      const wordAtArr = words.find((w) => w.word === word);

      if (wordAtArr) {
        wordAtArr.count++;
        return;
      }
      words.push({
        word,
        count: 1,
      });
    });

  console.log(
    words
      .filter((w) => w.count % 2 !== 0)
      .map((w) => w.word)
      .join(' ')
  );
}
