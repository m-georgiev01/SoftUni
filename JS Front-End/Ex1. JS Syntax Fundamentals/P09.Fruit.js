function calculateTotal(typeOfFruit, weightGrams, pricePerKg){
    const weightKg = weightGrams / 1000;

    console.log(`I need $${(weightKg * pricePerKg).toFixed(2)} to buy ${weightKg.toFixed(2)} kilograms ${typeOfFruit}.`);
}