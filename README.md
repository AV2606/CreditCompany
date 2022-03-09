# CreditCompany
A Winform application that handles all the necceseties of a credit card company

The project is divided to 3 modules:
 * CreditCompany module: Handles the UI of the project and communicate with _CreditCompantEF_
 * CreditCompany module: Handles all the raw data and the communication to the database (back-end).
 * Tools module: Has a minor effect on the project, a project used as helper for many uses.

## CreditCompany module
Contains mostly the UI as winforms-user controls with a little of classes used for easier displaying of the content.

## CreditCompanyEF module
Contains all the logic of the data the company needs to handle with taking advantages of proxy and agent design patterns.
Also is the only module that can communicate with the server and database.

## Tools module
Helps with handling information at the _CreditCompantEF_ module.

### Main abilities of the program:
 * Managing users and managers of the company.
 * Projecting the data to the users and allow them to ask the company for requests.
 * **Managers only**: 
 * * Adding a new user to the company (clients and managers).
 * * Writing new transactions.
 * * Issueing new cards and canceling/suspending cards.
 * * Handle clients requests.
