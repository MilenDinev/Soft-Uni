let firstName = 'Brandon';
let lastName = 'Sanderson';
let fullName = firstName + ' ' + lastName;
console.log(fullName);

const speak = function(name = 'luigi', time ='night'){
    console.log(`Good ${time} ${name}`);
};

speak('Georgi', 'Morning')