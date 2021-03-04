console.log('Hello from VS Code');

//Function declaration
function printStars(count) {
    console.log('*'.repeat(count));
}

printStars(5);

//Function expression
const walk = function() {
    console.log('walking');
}

walk()

//Arrow function

const talk = () => {
    console.log('talking')
}

talk()

function foo (a,b,c){
    console.log(a);
    console.log(b);
    console.log(c); //undefined
}

foo(1,2);

foo(1,2,3,4,5,6,7);