function convertJsonToObject(jsonAsString) {
  const object = JSON.parse(jsonAsString);

  Object.entries(object).forEach(([key, value]) => {
    console.log(`${key}: ${value}`);
  });
}
