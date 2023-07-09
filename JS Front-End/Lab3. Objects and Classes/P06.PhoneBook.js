function phoneBook(arr) {
  const phoneBook = {};

  for (let el of arr) {
    let [name, tel] = el.split(' ');
    phoneBook[name] = tel;
  }

  for (let phone in phoneBook) {
    console.log(`${phone} -> ${phoneBook[phone]}`);
  }
}
