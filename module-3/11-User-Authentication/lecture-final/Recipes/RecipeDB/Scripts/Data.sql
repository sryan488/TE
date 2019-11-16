Use RecipeDB 
Delete from Ingredient;
Delete from Recipe;
Delete from [user];

Declare @user int = 1
Declare @recipe int
Set Identity_insert [user] On

Insert [user] (id, username, password, salt, role)
Values (@user, 'user01@te.com', 'y9RIkC9NCWZ/m1qXWR/IkKhfR/Y=', 'Tdz9nDZJbvE=', 'User');

Insert [user] (id, username, password, salt, role)
Values (2, 'admin01@te.com', 'tBp606xku5mE3HkYNwBJScItpuU=', 'XHIReP7dGQ0=', 'Admin');

Set Identity_insert [user] Off

Insert Recipe (Name, CreatedById, Description, Steps, Meal, Cuisine, ImageFile, PrepTime, CookTime, Serves)
    values ('Recipe01', @user, '', '', 'Dinner', 'American', 'file01.jpg', 25, 30, 4)
Select @recipe = @@IDENTITY
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ingred01', 10, 'TBS')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ingred02', 05, 'oz')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ingred03', 03, 'Cup')


Insert Recipe (Name, CreatedById, Description, Steps, Meal, Cuisine, ImageFile, PrepTime, CookTime, Serves)
    values ('Recipe02', @user, '', '', 'Dinner', 'American', 'file02.jpg', 25, 30, 4)
Select @recipe = @@IDENTITY
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ingred01', 10, 'TBS')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ingred02', 05, 'oz')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ingred03', 03, 'Cup')

Insert Recipe (Name, CreatedById, Description, Steps, Meal, Cuisine, ImageFile, PrepTime, CookTime, Serves)
    values ('Recipe03', @user, '', '', 'Dinner', 'Indian', 'file03.jpg', 25, 30, 4)
Select @recipe = @@IDENTITY
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ingred01', 10, 'TBS')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ingred02', 05, 'oz')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ingred03', 03, 'Cup')

Insert Recipe (Name, CreatedById, Description, Steps, Meal, Cuisine, ImageFile, PrepTime, CookTime, Serves)
    values ('Recipe04', @user, '', '', 'Dinner', 'Indian', 'file04.jpg', 25, 30, 4)
Select @recipe = @@IDENTITY
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ingred01', 10, 'TBS')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ingred02', 05, 'oz')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ingred03', 03, 'Cup')

Insert Recipe (Name, CreatedById, Description, Steps, Meal, Cuisine, ImageFile, PrepTime, CookTime, Serves)
    values ('Recipe05', @user, '', '', 'Dinner', 'Italian', 'file05.jpg', 25, 30, 4)
Select @recipe = @@IDENTITY
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ingred01', 10, 'TBS')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ingred02', 05, 'oz')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ingred03', 03, 'Cup')
