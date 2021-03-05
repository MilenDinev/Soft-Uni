function population(townsArray) {

    const towns = {};
    // iterate over input

    for (let townAsString of townsArray) {
        //parse input strings
        let args = townAsString.split(' <-> ');
        let name = args[0];
        let population = Number(args[1]);

        //store population in associate array (object)

        if (towns[name] == undefined){
            towns[name] = population;
        }else{
            towns[name] += population;
        }
    }

    //print result
    for (let name in towns){
        console.log(`${name} : ${towns[name]}`);
    }
}

population(['Instanbul <-> 100000',
    'Honk Kong <-> 286397',
    'Jerusalem <-> 24125',
    'Mexico City <-> 14536',
    'New York <-> 250000',
    'Instanbul <-> 500'
]);