function solve(input) {
  const parking = [];

  input.forEach((element) => {
    const [command, carNumber] = element.split(', ');

    if (command === 'IN') {
      if (!parking.includes(carNumber)) {
        parking.push(carNumber);
      }
    } else if (command === 'OUT') {
      if (parking.includes(carNumber)) {
        parking.splice(parking.indexOf(carNumber), 1);
      }
    }
  });

  const result = parking.sort().join('\n');

  console.log(result.length > 0 ? result : 'Parking Lot is Empty');
}
