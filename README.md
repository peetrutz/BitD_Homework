# BitD_Homework
This is my Bitdfender Homework

This Project runs on the .NET 5.0 (Core) with C#.
I chose this development framework so that these tests can be easily imported to Windows, Mac and Linux, in the idea that it offers flexibly should they be used in a pipeline.
The NuGet Packages contain the drivers (chromedriver, firefox and IE) which are for Windows (eg: chromedriver.exe). These need to be replaced with their counterparts for other OS.

On top of that I chose SpecFlow, a BDD framework and the test runner nUnit (JUnit equivalent from JAVA). The project also contains the MSTest package should it be needed.
I chose BDD because it is the easiest way to involve the entire team in the testing process, even the less technial members.

The tests were written build around the idea of test isolation, so that the scenarios are not dependent on one another.

# Setup
In order to develop these tests locally on Winodws you need Visual Studio (Community edition) and the Specflow Extension. 
Then just copy the repository and you should be able to run the tests.



# Reporting
The test restul are stored in TestExecution.json
To view the test results run the following command (changing the paths to match the locations of you Feature files and TestExecutions.json):

livingdoc test-assembly C:\Users\petrut.marin\source\repos\BitD_Homework\BitD_Homework\BitDefender_SpecFlow\Features -t C:\Users\petrut.marin\source\repos\BitD_Homework\BitD_Homework\bin\Debug\net5.0\TestExecution.json

Open LivingDoc.html file to view the report. This file also cotains the Gerkin for all tests and analytical information (eg Unused Step Definitions).


