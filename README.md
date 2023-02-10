# About The Project
This application is a console application written in C# providing methods to create, download, read and delete data files (currently supported
formats - JSON, XML, CSV). Download option allows user to download files from a URL specified by the user.
Downloaded files are being saved to the SQL database. The application can unzip the contents of a ZIP file and then 
save it to the database. It also allows you to open and view the contents of previously saved files on the console. The user can also create 
JSON, XML, and CSV files and save their contents to the database. The application displays a list of files already saved in the database, and 
it also enables the user to delete files from the database.

# Getting Started
### Prerequisites
Before installing the application, make sure that you have the following software installed on your computer:
- .NET Core SDK
- SQL Server
### Downloading the Source Code
You can download the source code for this application by clicking the "Clone or download" button on the GitHub repository page and then 
selecting "Download ZIP." Extract the contents of the ZIP file to a location of your choice.
### Building the Application
1. Open a command prompt or terminal window and navigate to the directory where you extracted the source code.
2. Run the following command to restore the NuGet packages:
```
dotnet restore
```
3. Run the following command to build the application:
```
dotnet build
```
### Setting up the Database
4. Open SQL Server Management Studio, connect to your SQL Server instance and get connection string.
5. Open the solution in Visual Studio.
6. Go to FileContext.cs file and replace connection string inside OnConfguring method.
7. Run the following command in the Package Manager Console to apply the Entity Framework migrations:
```
Update-Database
```
### Running the Application
9. Open a command prompt or terminal window and navigate to the directory where you extracted the source code.
10. Run the following command to start the application:
```
dotnet run
```
The application should now be running and connected to your SQL Server database.
# Usage
### Code
Files are being handled trough different file classes that inherit from abstract File class.
File class consist of FileName property, Type property which is assigned via constructor in derived class and Content property, which is a string 
representation of current file. File class basically handles serialization of files to a database, and deserializes them to print out on the console.

![This is an image](https://imagizer.imageshack.com/img924/7241/7cgyJe.jpg)

FileManager class provides methods for downloading file content from given url, then file is being processed trough FileProcessor class
which determines a file type, creates proper File object and serializes content into File object. After creaing proper File object FileRepository saves it into a database.


![This is an image](https://imagizer.imageshack.com/img922/4463/DlOXnk.jpg)

User interface is handled by Dialogues static class which provides methods to interpret user input values and handles it using proper methods.

![This is an image](https://imagizer.imageshack.com/img923/6097/QyljbB.jpg)

### User interface
Starting window displays six options to choose from. By following on-screen instructions user can
choose to use the different features of the application.

![This is an image](https://imagizer.imageshack.com/img924/6386/9lmOtj.jpg)

Download file option allows user to paste url address to download file from.Application gets the file type based on given url and 
if file type is being supported user is allowed to enter file name and download it. If an error occurs, application displays information
on what went wrong and instructs user on what to do.

![This is an image](https://imagizer.imageshack.com/img924/8486/yxO3ik.jpg)

Open file option allows user to enter file name, that has been previously created or downloaded.

![This is an image](https://imagizer.imageshack.com/img922/3417/QVy3fR.jpg)

Create file opens up an interface where user chooses file name and format, then user is being asked to input keys and corresponding values to console,
based on that file is being creted and saved to the database. Show files option displays list of all files names. Delete file asks user for file name to delete
and if that file exists, deletes it.
# Contributing
If you wish to contribute to this project, please feel free to create a pull request with your changes.
# License
This project is licensed under the MIT License - see the LICENSE file for details.


