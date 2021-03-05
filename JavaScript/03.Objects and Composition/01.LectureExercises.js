const myObj = {
    name: 'Peter',
    age: 23,
    haircolor: 'brown'
};


function citiRecord(name, population, treasury){
    const city = {
        name: name,
        population: population,
        treasury : treasury
    }

    return city
}

console.log(citiRecord('Tortuga', 1500, 1000))