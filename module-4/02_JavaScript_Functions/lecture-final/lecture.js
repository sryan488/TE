// Const arrays are still mutable. You just cannot re-assign a value to arr below.
const arr = [2,3,4,5];
arr[2] = 6;
// console.table(arr);
arr.push(10);
// console.table(arr);


// Join elements of an array into a string
let names = ["Reid", "Glenn", "Brad"];
// console.log(names.join(", "));


/**
 * All named functions will have the function keyword and
 * a name followed by parentheses.
 */
function returnOne() {
  return 1;
}

/**
 * Functions can also take parameters. These are just variables that are filled
 * in by whoever is calling the function.
 *
 * Also, we don't *have* to return anything from the actual function.
 *
 * @param {any} value the value to print to the console
 */
function printToConsole(value) {
  console.log(value);
}

/**
 * Write a function called multiplyTogether that multiplies two numbers together. 
 * But what happens if we don't pass a value in? 
 * What happens if the value is not a number?
 *
 * @param {number} firstParameter the first parameter to multiply
 * @param {number} secondParameter the second parameter to multiply
 */
function multiplyTogether(x, y) {
  return x * y;
}

/**
 * This version makes sure that no parameters are ever missing. If
 * someone calls this function without parameters, we default the
 * values to 0. However, it is impossible in JavaScript to prevent
 * someone from calling this function with data that is not a number.
 * Call this function multiplyNoUndefined
 *
 * @param {number} [firstParameter=0] the first parameter to multiply
 * @param {number} [secondParameter=0] the second parameter to multiply
 */
function multiplyNoUndefined(x = 0, y = 0) {
  return x * y;
}

/**
 * Scope is defined as where a variable is available to be used.
 *
 * If a variable is declare inside of a block, it will only exist in
 * that block and any block underneath it. Once the block that the
 * variable was defined in ends, the variable disappears.
 */
function scopeTest() {
  // This variable will always be in scope in this function
  let inScopeInScopeTest = true;

  {
    // this variable lives inside this block and doesn't
    // exist outside of the block
    let scopedToBlock = inScopeInScopeTest;
  }

  // scopedToBlock doesn't exist here so an error will be thrown
  // if (inScopeInScopeTest && scopedToBlock) {
  //   console.log("This won't print!");
  // }


  for (let i = 0; i < 10; i++)
  {
    console.log(i);
    for (let i = 0; i < 5; i++)
    {
      console.log(`\t${i}`);
    }
  }



}

function createSentenceFromUser(name, age, listOfQuirks = [], separator = ', ') {
  let description = `${name} is currently ${age} years old. Their quirks are: `;
  return description + listOfQuirks.join(separator);
}

/*********************************************************
 * Anonymous Functions
 * 
 * Functions are a "first-class object" in JavaScript.  
 * There are numerous ways to define functions.  We have seen just one 
 * way so far... with the "function" keyword simlilar to hpow we define a method in C#.
 */
// Anonymous functions
function doubleIt(n){
  return n * 2;
}

/***************************
 * There is actually a "variable" called doubleIt now
 */
console.log(`doubleIt is a type ${typeof(doubleIt)}`);
console.log(doubleIt.name);

// /************************
//  * Now that the function is defined, we can actually "assign" that function to 
//  * another variable.
//  */
let f = doubleIt; // f is now a function
console.log(`f is a type ${typeof(f)}`);
console.log(f.name);

// /*****************************
//  * Another way to define a function - assign it to a variable directly
//  * 
//  */
let tripleIt = function (n) {
  return n * 3;
}
console.log(`tripleIt is a type ${typeof(tripleIt)}`);
console.log(tripleIt.name);

// /*******************************
//  * And finally, a shortcut for the above using lambda (fat arrow)
//  * 
//  */
let quadrupleIt = (n) => {return n*4;}

// /************************************
//  * You may even see a shorter-cut, called an expression-bodied function
//  * but I won't use it normally
//  */
let quintupleIt = n => n*5;
console.log(quintupleIt.name);
console.log(quintupleIt);

// /************************************
//  * Now we can write a function, which takes another function as a parameter.
//  * The passed-in function can be called (executed / invoked).
//  */
function toAllElements(array, functionToApply){
  let outArray = [];
  for (let i = 0; i < array.length; i++) {
    outArray.push(functionToApply(array[i]));
  }
  return outArray;
}

/***********************************
 * Define an array of numbers
 */
let myArray = [1,2,3,4,5];

/**********************************
 * Now in the Console window, call toAllElements, passing in myArray, and a function
 * which will perform an operation on every element
 */
//toAllElements(myArray, doubleIt);



/*************************************************************************************
 * ***********************************************************************************
 */

/**
 * Takes an array and, using the power of anonymous functions, generates
 * their sum.
 *
 * @param {number[]} numbersToSum numbers to add up
 * @returns {number} sum of all the numbers
 */
function sumAllNumbers(numbersToSum) {
  return numbersToSum.reduce(
    (sum, element) => {
      return sum + element;
    }
  );
}

/**
 * Takes an array and returns a new array of only numbers that are
 * multiples of 3
 *
 * @param {number[]} numbersToFilter numbers to filter through
 * @returns {number[]} a new array with only those numbers that are
 *   multiples of 3
 */
function allDivisibleByThree(numbersToFilter) {
  let outArr = numbersToFilter.filter( (element) => {
    return element % 3 === 0;
  });
  return outArr;
}


function sortNumbers(array)
{
   return array.sort(
     (a, b) => {
       console.log(`a is ${a}, b is ${b}`);
       return b-a;
     }
   );
}

function compareTwoElements(a, b) {
  if (a > b) {
    return 1;
  }
  if (b > a) {
    return -1;
  }
  return 0;
}

function sortNumbers2(array)
{
   return array.sort(compareTwoElements);
}

let numbers = [10,4, 1, 123, 56, 43];

let people = [
  { name: "Mike", age: 56, height: 71 },
  { name: "Tyler", age: 28, height: 74 },
  { name: "El", age: 26, height: 60 },
];



