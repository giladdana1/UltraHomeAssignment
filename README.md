# UltraHomeAssignment
home assignment for Ultra
steps for installation:
1.download and install visual studio code(development environment light wieght)
2.install nuget package manager for VS CODE
3.download .net core sdk (from dotnet.microsoft.com/download,  inorder to create NUnit test project)
4.install C# for visual studio code via nuget (need to restart vscode)
5.check if dot net core was installed 
	- open terminal
	- >type dotnet -version
6.create a new nunit test project(using the command prompt : > dotnet new nunit)
7.build the project(using command prompt : > dotnet build)
8.download chromedriver.exe put it in the project folder : "UltraHomeAssignment\bin\Debug\netcoreapp3.1\"
(download via chromedriver.chromium.org/downloads my chrome version is : "Version 83.0.4103.61 (Official Build) (64-bit)")

***before you run the tests read carefully the remarks in the code and change the parameters accordingly
i.e :
           //here you should insert your username and password
            email.SendKeys("my email CHANGEME");
            password.SendKeys("my password CHANGEME");
	    
# pipline 
I would use azure devops pipline ,use github for source control, and jenkins for running the tests.
