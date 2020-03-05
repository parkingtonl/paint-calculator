# borwell-challenge
Borwell Software Challenge

The repository containing the solution files

# Installation 

The software can be cloned into Visual Studio from GitHub  by connecting to the repository and cloning in the usual way.

A pipeline is in progress in Microsoft DevOps in the Azure Portal and could be built in Azure but not quite completed. CI/CD may also need administrator rights which are essentially single user (I'm the one who pays my Azure bill).

# Discussion of Technologies

Always difficult since everything changes so rapidly, has to be web based and easily deployable to Azure so Net Core 3.1 and Angular make most sense. The front end uses Bootstrap 4 and JQuery enabling fully responsive pages on screens/phones and glyphicons can also be used for buttons. Moost donkey work is done in HTML, CSS, and C#. A database would normally be used in an application, and SqlServer or an instance of Sql in Azure a good place to start. I wanted to do some Unit Tests on both Front End and Back End though realised haven't used Karma or Jasamine enough to get one working. So used JQuery and Javascript on its own (living dangerously) since really need a proper javascript framework to do front end testing. Good old MVC using standard routing is fine here

# Meeting the Rdequirements

I hope it meets most of the requirements, however ran out of time on the one of ajax promise things and would need a second look. Rather embarrasing it does the calculation but doesn't populate the text boxes when the Submit button is clicked. To improve it, I would throw away the existing front end and use Angular 7, adding a few unit tests along the way. 
