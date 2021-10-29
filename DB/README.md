
# Create and Connect to a MySQL Database with Amazon RDS

![image](https://user-images.githubusercontent.com/89664234/139353203-50c12af0-20ed-4821-a6d4-190aed8c9bd9.png)

## Create a MySQL DB Instance

![image](https://user-images.githubusercontent.com/89664234/139353263-69314bc2-30a1-4204-ad83-d226fd1f229d.png)

![image](https://user-images.githubusercontent.com/89664234/139353287-6ec41e0f-c68d-460e-ae10-6ad8cfddf491.png)

## Download a SQL Client

Go to the [Download MySQL Workbench](http://dev.mysql.com/downloads/workbench/) page to download and install MySQL Workbench. For more information on using MySQL, see the [MySQL Documentation.](http://dev.mysql.com/doc/)

## Connect to MySQL instance created on AWS

In this step, we will connect to the database you created using MySQL Workbench.

a. Launch the MySQL Workbench application and go to Database > Connect to Database (Ctrl+U) from the menu bar.

b. A dialog box appears.  Enter the following:

  * Hostname: You can find your hostname on the Amazon RDS console as shown in the screenshot to the right.  
  * Port: The default value should be 3306.
  * Username: Type in the username you created for the Amazon RDS database.  In this tutorial, it is 'masterUsername.'
  * Password: Click Store in Vault (or Store in Keychain on macOS) and enter the password that you used when creating the Amazon RDS database.

  Click OK.

![image](https://user-images.githubusercontent.com/89664234/139353616-d1fba5c2-45e4-497c-901d-9c16c39171e6.png)

c. You are now connected to the database! On the MySQL Workbench, you will see various schema objects available in the database. Now you can start creating tables, insert data, and run queries.

![image](https://user-images.githubusercontent.com/89664234/139353813-0c912604-aba7-445d-91bb-4a60c2511018.png)

## Sample Queries

### Retrieving all the Marker Points
`SELECT * FROM markerpoints;`
### Retrieving the Marker Points by severity 
`SELECT * FROM markerpoints WHERE Severity = '4';`
### Retrieving the Marker Points by ID 
`SELECT * FROM markerpoints WHERE ID = '1';`
### Inserting a new Marker Point
`INSERT INTO markerpoints VALUES ('1', '123', '2020-09-14 23:18:17', '2021-12-30 23:18:17', '29.715981', '-95.428841', 'https://assets.bwbx.io/images/users/iqjWHBFdfxIU/iUM87hW9S7rI/v1/1000x-1.jpg');`
### Updating a Marker Point by ID
`UPDATE markerpoints SET Description = 'description changed' WHERE ID = 1;`
### Deleting a Marker Point by ID
`DELETE FROM markerpoints WHERE ID = 1;`
