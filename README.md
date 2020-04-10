# Basic demo on WebAPI & ASP.NET MVC

## Created 3 projects under visual studio solution
* Emp.ModelLayer: this contains model of the Employee class, will be used in 2 other projects
* Emp.PresentationLayer: this is MVC project which will call WebAPI and view the data
* Emp.WebAPILayer: this is very simple WebAPI project
                  Hardcoded the list of employees
                 
This is very simple WebAPI which has 2 actions 
* is to return all employees details
* is to reurn employee details by Id
      
Presentation layer nothing but MVC project will call WebAPI to display the data.
