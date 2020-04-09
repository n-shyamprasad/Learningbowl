This is a simple demo on creation of WebAPI and consume that webapi in ASP.NET MVC project
Created 3 projects
1. Emp.ModelLayer: this contains model of the Employee class, will be used in 2 other projects
2. Emp.PresentationLayer: this is MVC project which will call WebAPI and view the data
3. Emp.WebAPILayer: this is very simple WebAPI project
                  Hardcoded the list of employees
This is very simple demo WebAPI has 2 actions 
      1. is to return all employees details
      2. is to reurn employee details by Id
      
Presentation layer nothing but MVC project will call WebAPI to display the data.
