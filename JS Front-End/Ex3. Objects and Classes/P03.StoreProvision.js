function solve(currItems, orderedForDeliveryItems) {
  const products = [...currItems, ...orderedForDeliveryItems];

  const stock = products.reduce((acc, curr, index) => {
    if (index % 2 === 0) {
      if (!acc.hasOwnProperty(curr)) {
        acc[curr] = Number(products[index + 1]);
      } else {
        acc[curr] += Number(products[index + 1]);
      }
    }

    return acc;
  }, {});

  Object.keys(stock).forEach((key) => {
    console.log(`${key} -> ${stock[key]}`);
  });
}
