function solve(input) {
  const dictionary = input
    // ['', '', '']
    .map((jsonString) => JSON.parse(jsonString))
    // map -> [{} {} {}]
    .reduce((acc, curr) => {
      return {
        ...acc,
        ...curr,
      };
    }, {});
  //reduce -> {coffee: '...', ...}

  const sortedDictionaryKeys = Object.keys(dictionary).sort();

  sortedDictionaryKeys.forEach((key) => {
    console.log(`Term: ${key} => Definition: ${dictionary[key]}`);
  });
}
