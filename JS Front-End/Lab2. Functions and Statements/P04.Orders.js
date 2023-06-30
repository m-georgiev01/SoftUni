function printOrderTotalPrice(product, quantity) {
  const products = {
    coffee: 1.5,
    water: 1,
    coke: 1.4,
    snacks: 2,
  };

  const currProductPrice = products[product] ? products[product] : 0;
  const totalPrice = (currProductPrice * quantity).toFixed(2);

  console.log(totalPrice);
}
