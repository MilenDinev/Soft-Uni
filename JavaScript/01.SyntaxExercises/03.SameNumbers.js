function equalDigits(number){

    const string = number.toString();
    let sum = 0;
    let equal = true;

    for (let i = 0; i < string.length; i++) {
        
       if (string[i] !== string[i+1]&& i < string.lenght); {
            equal = false;
            
       }

        sum += Number(string[i]);
    }
    return `${equal}\n${sum}`;
}

console.log(equalDigits(1234));