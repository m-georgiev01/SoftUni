function displayLoadingBar(number) {
  if (number === 100) {
    console.log('100% Complete!');
    console.log('[%%%%%%%%%%]');
    return;
  }

  const repeatCount = (number / 100).toString().split('.')[1];
  const emptyCount = 10 - repeatCount;

  const progressBar = `[${'%'.repeat(repeatCount)}${'.'.repeat(emptyCount)}]`;

  console.log(`${number}% ${progressBar}`);
  console.log('Still loading...');
}
