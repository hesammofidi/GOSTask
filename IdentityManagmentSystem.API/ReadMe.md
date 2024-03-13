# Identity Managment System API 

## Table of Contents
1. Introduction
2. Controllers
3. API Endpoints
4. JSON Bodies for POST Requests
5. Possible Responses
 ## Introduction
This is a web API project designed for the integrated management of users, their roles, and their access levels in any system.
## Controllers
1. **AccountController**: Manages User Authentication(Login-Register-RessetPassword) Using AspNetCore.Identity.
2. **UserInfoController**: Manages the operations of adding, updating, deleting, and reading in various ways from the users table.
3. **RolesController**: Manages the operations of adding, updating, deleting, and reading in various ways from the  roles table.
4. **PermissionsController**: Manages the operations of adding, updating, deleting, and reading in various ways from the permissions table.
5. **SystemsController**: Manages the operations of adding, updating, deleting, and reading in various ways from the Systems table.
 ## API Endpoints
1.**Account Controller**:
    - `POST --> {IISUrl}/Account/login`: Login User and return Token and referesh token.
    - `POST --> {IISUrl}/Account/register`:Creating a new user with the details entered by the user. 
    - `POST --> {IISUrl}/Account/forgotPass`:Sending a code to the email entered by the user, if a user has previously registered with the entered email.
    - `POST --> {IISUrl}/Account/ressetPass`:change password by the user with the code that sent to user in ForgotPass. 
2. **UserInfo Controller**:
    - `POST --> {IISUrl}/api/WFTasks/add`: Get New Items of WFTask List and Add To WfTasks Table in Database.
    - `PUT --> {IISUrl}/api/WFTasks/{id}`: Set ShowNotif Flag to 0 If the item notification is displayed.
    - `Get --> {IISUrl}/api/WFTasks/{id}`: Returns new user notifications that the user has not yet received.
  return New items that have been added to the table from the WFTask list and their notification has not yet been sent to the user.
3. **Roles Controller**:
    - `POST --> {IISUrl}/AdminInformation/SpAuthentication`: Authenticate User With Sharepoint.
    - `POST --> {IISUrl}/AdminInformation`: Add New User Admin (Sharepoint or System admin).
    - `Get --> {IISUrl}/AdminInformation/{id}`: Returns Information Of User by Id of item of table.
    - `Get --> {IISUrl}/AdminInformation/Type/{title}`: Returns Information Of Sharepoint Admin or System Admin .
    - `Delete --> {IISUrl}/AdminInformation/{id}`: The user whose ID is entered will be deleted if it exists.
    - `Put --> {IISUrl}/AdminInformation`: Update User Info whose ID is entered in body of request.