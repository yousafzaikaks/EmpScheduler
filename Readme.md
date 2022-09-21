# Employees Scheduler

This small application gets data from the database and displays every employee daily shift routine i.e. Shift start and end time, Break time and Leave etc

## How to Set Database
Please go to DBSrcipts folder. There is script file i.e. DBScript.sql. 
Run this file in SQL Server Management Studio and it will generate new DB and its tables along with data insertion.


## Code Structure
As this is a pure MVC application so we have Models, Views, Controllers and a new Layer i.e. BusinessLogic.
The whole business logic is inside the BusinessLogic folder. So the Controller is only calling the Methods created in the BusinessLogic folder.
This is a DB first application. The Context class is inside the Models Folder

## How to test it?
After you successfully created the Database by executing the given Script, you need to run the application and call this method i.e. /Home/GetEmpScheduler

