# MyAssignment
Using  MVC methodologies, Implementing  CRUD operations for the Managers and Employees entities.Implementing a one to many relation between them. FIltering based on Lastname and Country

Model
In this application there are two models: Employee and Manager. Realtion amongst them is one to many (a manager have many employees while an employee have one Manager). Where we implement a full C.R.U.D. operation.

Seed method
As soon as we run the application we drop and create the database automatic. The seed Method is located in MyContext folder, Inside Initializers folder in MockupDbInitializer class.

Validations
Our models has input validation above it's properties declaration. In create and edit view there is one more validation to make first letter capital in both Firstname and Lastname input fields. (Taking advantage of System.ComponentModel.DataAnnotations)

Filter
Option to filter Employees based on their country or Lastname
