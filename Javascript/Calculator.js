// Author: Sasha Andersen
// Date created: 19/10/2022

document.querySelector("#add").addEventListener('click', addition);
document.querySelector("#subtract").addEventListener('click', subtraction);
document.querySelector("#multiply").addEventListener('click',  multiplication);
document.querySelector("#divide").addEventListener('click', division);

function addition () {
    let firstNum = parseInt((document.getElementById("firstNum").value));
    let secondNum = parseInt((document.getElementById("secondNum").value));
    let result = firstNum + secondNum;
    document.querySelector("#answer").innerHTML = result;
    //document.querySelector("#answer").innerHTML = firstNum + secondNum;
}

function subtraction () {
    let firstNum = parseInt((document.getElementById("firstNum").value));
    let secondNum = parseInt((document.getElementById("secondNum").value));
    let result = firstNum - secondNum;
    document.querySelector("#answer").innerHTML = result;
    //document.querySelector("#answer").innerHTML = firstNum + secondNum;
}

function multiplication () {
    let firstNum = parseInt((document.getElementById("firstNum").value));
    let secondNum = parseInt((document.getElementById("secondNum").value));
    let result = firstNum * secondNum;
    document.querySelector("#answer").innerHTML = result;
    //document.querySelector("#answer").innerHTML = firstNum + secondNum;
}

function division () {
    let firstNum = parseInt((document.getElementById("firstNum").value));
    let secondNum = parseInt((document.getElementById("secondNum").value));
    let result = firstNum / secondNum;
    document.querySelector("#answer").innerHTML = result;
    //document.querySelector("#answer").innerHTML = firstNum + secondNum;
}