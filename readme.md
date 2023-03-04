# Hello Bachak : Introduction

Hi ! This is a project which I've started to build in order to solve my sister's problem . She is a mentor for high school students and She always has trouble with assigning tasks to his students or scheduling.
My Main concentration is on the API of this project . I hope you guys help me in building the api and also the clients for this project (web , windows, console and linux )



# Main Business logic
There will be mentors and there will be students . each mentor has only one mentor . but a mentor can have as many students as he/she wants . The mentor will assign duties to his student . The students have to do his duties and respond to the assigned duty and determine wether or not he/she is able to do the complete the duty.If the duty is not finished , the will be a new duty (child duty ) with some changes from the parent duty . This procedure goes on until the student finishes the duty , or the mentor stops closes the task

## Project Structure
there are 7 projects in the solution right now : 
1.Business : responsible for implementing the business logic
2.DataAccess : responsible for accessing the data from context defined in the Entity project
3.Dto : responsible for data transformation from the database model to the model that we want
4.Entity:responsible for manipulating the data from the database (the database is postgres database)
5.react_client : a web client using react 
6.Test : ensures that Business project works properly
7.WebApi : defines endpoint for our api

## TO DO's
1.Adding security to the project by using Identity Server
2.react client needs someone to code
3.a simple console client is needed ( no matter in what language)


## My Coding approach

I have used TDD approach to build trustable  and maintainable WEB API. So please follow this approach if you want to continue
But there is no limit in implementing the clients But be sure to continue the former approach

