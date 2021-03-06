const para = document.querySelector('p');
const classErr = document.querySelector('.error');
const divClassErr = document.querySelector('div.error');
const paras = document.querySelectorAll('p');

console.log(para);
console.log(classErr);
console.log(divClassErr);
console.log(paras);

console.log(paras[2]);

paras.forEach(p => {
    console.log(p)
});


const tittle = document.getElementById('page-title')
const errors = document.getElementsByClassName('error')

console.log(tittle)
console.log(errors)