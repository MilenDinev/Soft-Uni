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

console.log(citiRecord('Tortuga', 1500, 1000));

console.log(myObj.age);
myObj.age = 25;
console.log(myObj.age);

console.log(myObj['age']);

const propName = 'age'

console.log(myObj[propName]);

myObj.lastName = 'Johnson';

console.log(myObj);

myObj['height'] = 1.76;

console.log(myObj);

delete myObj.height;

console.log(myObj)

