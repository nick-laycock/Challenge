## Challenge

This is a simple project that is part of a coding challenge for a job.
The application is designed to read in a file of HTTP logs, then run calcuations
across the data to determine the most visited pages, and the most active users.

I have not added any formal logging to the application, as I have not had time to do so. Nor
have I added any Dependency Injection. Whilst the code is inplace for this to work, the nature/size and time to write 
have not allowed me to do so.

### Assumptions
- The file is a text file
- The file is a list of HTTP logs
- The file is in the format a specific format

### Future Enhancements
- The application could be extended to read in different file types
- The application could read multiple files
- The application could read the contents of a directory passed as an arugment to the applcation
- Adding a logging interface to the application
- Add Dependency Injection to the application


### Prerequisites
.NET Core 8.0

### Installation

Download the source code, then open the terminal and run the following:

```sh
dotnet restore
```

```sh
dotnet build
```


### Running the application

To run the application, open the and navigate to the `Challenge.Console` directory, then run the following:

```sh
dotnet run
```

### Running the tests

Tests have been written for the application using xUnit.
To run the tests, run the following:

```sh
dotnet test
```

This will execute the tests and display the results in the terminal.
Below is an example of the output of the code coverage metrics provided by Rider.

![image](https://github.com/nick-laycock/Challenge/assets/152692325/cc171bb9-5e71-478a-ba8f-6e97f2b51b21)
