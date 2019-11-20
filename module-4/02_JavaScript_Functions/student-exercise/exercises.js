/*
 * Document this function
 */
function isSummer(month, day = 1, hemisphere = 'northern') {
  if (month === 7 || month === 8) {
    return hemisphere === 'northern';
  } else if (month === 6 && day >= 20) {
    return hemisphere === 'northern';
  } else if (month === 9 && day <= 20) {
    return hemisphere === 'northern';
  } else if (month === 1 || month === 2) {
    return hemisphere === 'southern';
  } else if (month === 12 && day >= 20) {
    return hemisphere === 'southern';
  } else if (month === 3 && day <= 20) {
    return hemisphere === 'southern';
  } else {
    return false;
  }
}

/**
 * Write a function called isAdmitted. It will check entrance
 * scores and return true if the students is admitted and
 * false if rejected. It takes three parameters:
 *
 *     * gpa
 *     * satScore (optional)
 *     * recommendation (optional)
 *
 * We admit them--return true--if:
 * gpa is above 4.0 OR
 * SAT score is above 1300 OR
 * gpa above 3.0 and they have a recommendation OR
 * SAT score is above 1200 and they have a recommendation
 * OTHERWISE reject it
 *
 * @param {number} gpa the GPA of the student, between 4.2 and 1.0
 * @param {number} [satScore=0] the student's SAT score
 * @param {boolean} [recommendation=false] does the student have a recommendation
 * @returns {boolean} true if they are admitted
 */
function isAdmitted(gpa, satScore = 0, recommendation=false){
  if (gpa > 4.0 || satScore > 1300) {
    return true;
  } else if(gpa > 3.0 && recommendation === true){
    return true;
  } else if(satScore > 1200 && recommendation === true){
  return true;
} return false;}


/**
 * Write a function called useParameterToFilterArray so that it takes an anonymous
 * function and uses that in `unfilteredArray` filter function. Return the result.
 *
 * @param {function} filterFunction the function to filter with
 * @returns {number[]} the filtered array
 */
let unfilteredArray = [1, 2, 3, 4, 5, 6];
function useParameterToFilterArray(filterFunction){
  return unfilteredArray.filter(filterFunction)
}

/**
 * Write a function called makeNumber to take two strings
 * of digits, concatenate them together, and then return
 * the value back as a number.
 *
 * So if two strings are passed in "42293" and "443", then this function
 * should return the number 42293443.
 *
 * @param {string} first the first string of digits to concatenate
 * @param {string} [second=''] the second string of digits to concatenate
 * @returns {number} the resultant number
 */
function makeNumber(first, second=''){
  let result = Number(first + second);{
    return result;
  }
}

/**
 * Write a function called addAll that takes an unknown number of parameters
 * and adds them all together. Return the result.
 *
 * @param {...number} num a series of numbers to add together
 * @returns {number} the sum of all the parameters (or arguments)
 */
function addAll(){
  let result = 0;
  for(let i = 0; i < arguments.length; i++){
    result += arguments[i];
  }
  return result;
}

/**
 * Write and document a function called makeHappy that takes
 * an array and prepends 'Happy ' to the beginning of all the
 * words and returns them as a new array. Use the `map` function.
 *
 * @param {array} arr array of strings
 * @returns {array} returns an array of strings with "Happy" prepended
 */
function makeHappy(arr){

  let happyArr = arr.map( (element) => {
    return 'Happy ' + element;
  });

  return happyArr;
}

/**
 * Write and document a function called getFullAddressesOfProperties
 * that takes an array of JavaScript objects containing the
 * following keys:
 *     * streetNumber
 *     * streetName
 *     * streetType
 *     * city
 *     * state
 *     * zip
 *
 * and returns an array of strings that turns the JavaScript objects
 * into mailing addresses in the form of:
 *     streetNumber streetName streetType city state zip
 *
 * Use `map` and an anonymous function.
 * 
 * @param {array} arr array of JavaScript objects containing keys for an address
 * @returns {array} returns an array of strings that turns the objects into a mailing address
 */
function getFullAddressesOfProperties(arr){
  let addressArr = arr.map( (a) => {
    return a.streetNumber + ' ' + a.streetName + ' ' + a.streetType + ' ' + a.city + ' ' + a.state + ' ' + a.zip;
  });
return addressArr;
}

/**
 * Create and document a function called findLargest.
 *
 * Using `forEach`, find the largest element in an array.
 * It should work for strings and numbers.
 * @param {array} arr array of strings
 * @returns {element} returns the largest element of an array of strings or numbers
 */
function findLargest(arr){
  let largest = 0 || '';
  arr.forEach(function(a) {
    if(largest < a)
      largest = a;
    });
  return largest;
}

/*
 * CHALLENGE
 * Create and document a function called getSumOfSubArrayValues.
 *
 * Take an array of arrays and add up all sub values and return
 * the sum. For instance, if you got this array as a parameter:
 * [
 *   [1, 2, 3],
 *   [2, 4, 6],
 *   [5, 10, 15]
 * ];
 *
 * You would return 48. To do this, you will use two nested `reduce`
 * calls with two anonymous functions.
 *
 * Read the tests to verify you have the correct behavior.
 */
