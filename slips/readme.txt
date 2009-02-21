This project was built using NAnt 0.85 and C# 3.0 compiler.
In order to run this project you will need to follow the following steps to setup and continue development.

1. Copy the root directory of this project to your file system.
	E.g. G:\Cmpp299\Assignment1\trunk...

2. In IIS create a virtual directory and name it whatever you want. E.g (Marina)
3. Point the virtual directory to 
	...Assignment1\trunk\build\deploy\app
	E.g>
	G:\Cmpp299\Assignment1\trunk\build\deploy\app
4. Go to the build directory and copy the file called 'local.properties.template' to a file called 'local.properties.xml'
5. Open the file 'local.properties.xml' and change the values for the properties listed.
Eg.
<?xml version="1.0"?>
<properties>
	<property name="framework.dir" value="D:\WINDOWS\Microsoft.NET\Framework\v2.0.50727" />
	<property name="virtual.directory.name" value="marina" />	
	<property name="run.url" value="http://${environment::get-machine-name()}/${virtual.directory.name}/Default.aspx" />
	<property name="browser.path" value="D:\program files\mozilla firefox\firefox.exe" />
	<property name="sql.tools.path" value="D:\program files\microsoft sql server\90\tools\binn\" />
	<property name="sqlcmd.connectionstring" value="-E" />
	<property name="sqlcmd.exe"  value="${sql.tools.path}\sqlcmd.exe" />
	<property name="initial.catalog" value="Marina" />
	<property name="config.connectionstring" value="data source=(local);Integrated Security=SSPI;Initial Catalog=${initial.catalog}" />
	<property name="database.path" value="G:\root\development\databases" />
	<property name="asp.net.account" value="MACHINE_NAME\ASPNET"/>
</properties>

*Note: 
- the virtual directory name is the name of the virtual directory created in step 2.
- the run.url is the startup url when running the application.
- the sqlcmd.connection string is used to build the database.
- the config.connectionstring is used to in the web.config
- initial.catalog is the name you would like to give to the database.

6. open up a command prompt and navigate to the 'build' directory.
E.g.
G:\Cmpp299\Assignment1\trunk\build>

7. type the following command "build load.data"
	- this will build the database and load it with the default data.
E.g.
G:\Cmpp299\Assignment1\trunk\build>build load.data	
	
8. type the following command "build run"
	- this will run the web application in your browser.
E.g.
G:\Cmpp299\Assignment1\trunk\build>build run
	
	
Additional notes:
Other commands you can try:
G:\Cmpp299\Assignment1\trunk\build>build test
	- this will run all unit and integration tests for the project.


This project was built without the use of the Visual Studio debugger. I have attempted to include debug support
if you need to debug, however the behaviour may differ from running in visual studio then from that compiled and
deployed from the command line.

If you have any questions you can find me at http://mokhan.ca or email me at mo at mo khan dot ca
Enjoy!