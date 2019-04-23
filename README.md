# watermango
demo for tapmango

## running the project

start: clone down project

### IIS Setup
* IIS setup: make sure you have enabled **Internet Information Services**
* Specifically World Wide Web Services > **all** Application Development Features
  
#### Setup hosts file
navigate to `C:\Windows\System32\drivers\etc` and in hosts file add the following line
to the bottom of the page `127.0.0.1 dev.watermango.com`

#### Setup web api server
1. open IIS Manager
2. on the left bar expand your computer name
3. right click on sites -> add website 
4. Site name: devwatermango
5. Physical Path: navigate to the watermango folder -> open Wm.Web folder
6. Host name: dev.watermango.com

### Project build
1. open sln with visual studio 2017 (.NET Framework 4.6.1)
2. build projecct (might need to restore nuget packages)
3. open app folder (need node.js and npm)
4. run `npm run serve` from the command line it will run the dev server for dev.watermango.com:8080

you can now navigate to the url and test the application.

cheers


