function printCity(city) {
  const t = Object.entries(city).forEach(([key, value]) => {
    console.log(`${key} -> ${value}`);
  });
}
