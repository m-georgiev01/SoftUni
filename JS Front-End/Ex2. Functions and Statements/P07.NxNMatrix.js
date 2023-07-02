function create2DMatrixFromNumber(number) {
  const matrix = new Array(number);

  for (let i = 0; i < matrix.length; i++) {
    matrix[i] = [];
  }

  for (let i = 0; i < number; i++) {
    for (let j = 0; j < number; j++) {
      matrix[i][j] = number;
    }
  }

  for (let i = 0; i < matrix.length; i++) {
    console.log(matrix[i].join(' '));
  }
}
