function validatePassword(password) {
  const errorMessages = [];

  if (password.length < 6 || password.length > 10) {
    errorMessages.push('Password must be between 6 and 10 characters');
  }

  if (!/^[A-Za-z0-9]*$/.test(password)) {
    errorMessages.push('Password must consist only of letters and digits');
  }

  if (!/\d{2,}/.test(password)) {
    errorMessages.push('Password must have at least 2 digits');
  }

  if (errorMessages.length === 0) {
    console.log('Password is valid');
  } else {
    console.log(errorMessages.join('\n'));
  }
}
