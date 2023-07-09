function createAndPrintAddressBook(arr) {
  const addressBook = {};

  arr.forEach((element) => {
    const [name, address] = element.split(':');
    addressBook[`${name}`] = address;
  });

  Object.entries(addressBook)
    .sort((a, b) => a[0].localeCompare(b[0]))
    .forEach(([key, value]) => {
      console.log(`${key} -> ${value}`);
    });
}
