function calculatePrice(typeFruit, weight, pricePerKilogram){
    let totalPrice = weight * pricePerKilogram /1000;
    weight /= 1000;
    console.log(`I need $${totalPrice.toFixed(2)} to buy ${weight.toFixed(2)} kilgrams ${typeFruit}.`);
}

calculatePrice('orange', 2500, 1.80)