# Creating APIs Exercise Final

In this exercise you are going to take the shopping list exercise from yesterday and build your own API. In this directory you will find the folder `shopping-list` that contains the starting code for this exercise. You will only need to make **one** change in this application but you can worry about that later. 

## Building your own API

In this exercise you are going to be responsible for building an API that your front end code can use to retrieve a list of groceries. You are going to be building an API that is just like the [mockAPI](http://5c53275ea659410014eeea14.mockapi.io/api/groceries) you used in a previous exercise.

In this directory you will find the starting code for .NET

* .NET: `/shopping-api-dotnet`

Everything you need to build your API is in these projects. There is a data access layer that uses an in memory representation of a shopping list item. This is very similar to what you did in your tutorial and during lecture today. What you will need to do is build out the controller and that controller can use the data access layer to perform crud operations on the list of groceries. 

### Requirements

* The endpoint for your API should be /api/groceries
* You should have at least 10 items in your list of groceries when the application loads.
* When you click on an item it should update the status of that item

## Testing Your API

The `shopping-list` folder includes an HTML file like the one that was completed in class today. You can open this file up and while using the Chrome Console debugger validate that all 5 of your requests work and log a response correctly. 

You should also open up Postman and test your API endpoint directly to make sure that you can send GET, PUT, POST, and DELETE requests.
