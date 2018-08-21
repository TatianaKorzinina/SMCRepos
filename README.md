# SMCRepos
Test project.

The project was implemented on ASP.NET MVC and MS SQL. To communicate with the database, the Entity Framework Code First was used. 

The database consists of 5 tables:
1. Employes
2. Organizations
3. Departments
4. Logs
5. Types of logs 

Implemented:
1. authorization form (cookies life time 12 hours). Test login: admin. Password: secret.
2. Main page containing a list of all employes. Search form by part of full name. An "edit" button, which opens the form for editing the employee's data. Buttons "add employee", which opens the form for adding a new employee, and "see log", which opens a list of logs.
3. The form for editing / adding an employee.
4. The page with the list of logs.

Used technologies:
HTML, bootstrap, JQuery for views;
Ajax for depending drop-down lists;
Ninject for dependency injection.

Don't forget to change SQL server name in Web.config.
The database backup is in Domain.SMCContext.bak.
