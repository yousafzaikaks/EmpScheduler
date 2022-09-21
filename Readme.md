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
	After you successfully created the Database by executing the given Script, you just need to run the application.
	The method is /Home/GetEmpScheduler

##Questions:
# How long did you spend on this assignment?
	It took me almost 5 hours to complete this. Because No Database was Provided so I did it from the scratch.

# What would you have done different if you had more time?
	1. I just run this application for 2 scenarios given in the PDF and 1 other scenario which just came into my mind. So if 
	   got more time I need to test it thoroughly with as much scenarios as possible.
	2. There is repetition of code (Code Redundancy) whenever I am going to add new slot to the list. This could be done in a single method by passing 
	   parameters to it. But just because of the time limitation I could not do that.
	3. Right now This is only designed for a ONE DAY schedule. If we insert more data for the same Employees of different dates, then there will be problem.
	   To handle this scenario I need more time.

# We sometimes need to run this logic for a large number of employees, how would you meet the performance requirements of this application? 
	As I am not familiar with your existing Database structure, but according mine DB Structure it will work fine even on large scale data as well.
