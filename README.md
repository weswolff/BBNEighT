# **Live Laugh Love Inventories**

## **Description**
A program to aid in providing an inventory for household items in cases of fire, damage, loss, etc. which can easily access and find items.

## **Table of Contents**
- Installation
- Usage
- Contributing
- Credits
- License

## **Installation**
Make sure you are using Microsoft Visual Studio, found here: https://visualstudio.microsoft.com/downloads/
In NuGet Package Manager, install the following packages

1. Microsoft.AspNet.Identity.EntityFramework
Make sure the package refferences:
- BlueBadgeBBNEighT.Data
- BlueBadgeBBNEighT.Models
- BlueBadgeBBNEighT.Services
- BlueBadgeBBNEighT.WebAPI
- Project

2. Microsoft.AspNet.Identity.Owin
Make sure the package refferences:
- BlueBadgeBBNEighT.Data

3. Microsoft.AspNet.WebApi.Owin
Make sure the package refferences:
- BlueBadgeBBNEighT.Data

Next, clone the Repository using the URL: https://github.com/weswolff/BBNEighT.git

Now you will need to remake your Data Tables by doing the following:
1. Delete the Migrations Folder in you Data Layer
2. Open Package Manager
3. Change the Default Project to your Data Layer, or BBNeight.Data\
4. Enter these three commands into Package Manager\
`Enable-Migrations`\
`Add-Migration "your migration title here"`\
`Update-Database`

## **Usage**
Use a Web API Testing Tool like Postman to test your API endpoints. Postman can be found here: https://www.postman.com/downloads/

When you Run your application, it will bring up your API Home Page. There will be a small button or drop down menu that says "API." Click this to see the API Documentation.

When you start testing the API, you must first Post at least 1 Room and 1 Category before you can Post an Item.

## **Contributing**
Contributing Team Git Members:
- weswolff
- JonathanCarey13
- jacr777
- ToriiJenkins

## **Credits**
This Program was made by:
- Torii Jenkins
- Antonio Cordero
- Wes Wolff
- Jonathan Carey

## **License**
Creative Commons Attribution Share Alike 4.0	cc-by-sa-4.0
