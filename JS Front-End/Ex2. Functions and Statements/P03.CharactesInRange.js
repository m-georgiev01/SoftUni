function printCharsInRange(firstChar, secondChar) {
  const firstCharASCIICode = firstChar.charCodeAt(0);
  const secondCharASCIICode = secondChar.charCodeAt(0);

  let start = firstCharASCIICode;
  let end = secondCharASCIICode;

  if (firstCharASCIICode > secondCharASCIICode) {
    start = secondCharASCIICode;
    end = firstCharASCIICode;
  }

  const charsInRange = [];
  for (let i = start + 1; i < end; i++) {
    charsInRange.push(String.fromCharCode(i));
  }

  console.log(charsInRange.join(' '));
}
