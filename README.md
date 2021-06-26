# csv-editor

The purpose of this project is to provide the functionality of a mini back office.
Attached to this project is a CSV containing 2 columns, first name and last name, of employees in a particular company, and it functions as a database. The program will load the CSV from the folder, and through the client side, will display it on the screen when the user will be able to edit the data within the CSV.

# Server Side
The server side is implemented using .NET Core 5.0 in Microservice Architecture.

* IContext service is responsible for loading and writing the information into the CSV file.
* IRepository is responsible for storing the information from the CSV and additional information that will be used for testing.
* CsvController contains the endpoint for HTTP calls. It returns a HTTP reponse for the proper scenario.

To run the project, select Visual Studio Pro You are the project name, and then the project will start running, until it opens a new tab in the browser that will display the data.

# Client Side

The client side is implemented using Angular 11 and Angular Material for the UI components.

* When the client side is running, the user will read a short guide to manipulate the CSV editing option.
* csv-table.component responsible for presenting the information, editing it, and managing the situations in front of the user.
* csv-editor.service Contains the HTTP readings with a server-side retry mechanism.
* For each HTTP request that is made, there is documentation in the browser console with full details of the request, including displaying error messages, if necessary.

# Validations
To avoid unpleasant situations, I have included a number of different validations, both on the server side and the client side.

* A user cannot enter blank fields or a field over 50 characters.
* A user cannot "save" information to CSV if he has not made any changes.
* A user can not delete or add new information, because only editing can be performed.
* As soon as there is an error message, or success in saving the information to a CSV file, a suitable message will be displayed to the user at the bottom of the screen :)
