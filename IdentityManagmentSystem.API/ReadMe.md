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
    - `POST --> {IISUrl}/UserInfo/RegisterUser`: Register New User by Admin.
    - `PUT --> {IISUrl}/UserInfo/EditUser`: Edit Information of User by admin except password.
    - `PUT --> {IISUrl}/UserInfo/ChangePassword`: change password of User by admin.
    - `Get --> {IISUrl}/UserInfo/FilterUser`: Receive filtered and paged user information 
    - `Get --> {IISUrl}/UserInfo/SearchUser`: Receive Searched and paged user information
3. **Roles Controller**:
    - `POST --> {IISUrl}/Roles/AddRoles`: Add New Role by Admin.
    - `PUT --> {IISUrl}/Roles/EditRole`: Edit Information of Role by admin.
    - `Delete --> {IISUrl}/Roles/DeleteRole`: Delete one role by admin.
    - `Get --> {IISUrl}/Roles/FilterRoles`: Receive filtered and paged Role information 
    - `Get --> {IISUrl}/Roles/SearchRoles`: Receive Searched and paged Role information
 4. **Systems Controller**:
    - `POST --> {IISUrl}/Systems/Add`: Add New System by Admin.
    - `PUT --> {IISUrl}/Systems/Edit`: Edit Information of System by admin.
    - `Delete --> {IISUrl}/Systems/Delete`: Delete one System by admin.
    - `Get --> {IISUrl}/Systems/filter`: Receive filtered and paged Systems information 
    - `Get --> {IISUrl}/Systems/search`: Receive Searched and paged Systems information
    - `Get --> {IISUrl}/Systems/{id}`: Receive System information by Id

  5. **Permissions Controller**:
    - `POST --> {IISUrl}/Permissions/Add`: Add New Permission by Admin.
    - `PUT --> {IISUrl}/Permissions/Edit`: Edit Information of Permission by admin.
    - `Delete --> {IISUrl}/Permissions/Delete`: Delete one Permission by admin.
    - `Get --> {IISUrl}/Permissions/filter`: Receive filtered and paged Permissions information 
    - `Get --> {IISUrl}/Permissions/search`: Receive Searched and paged Permissions information
    - `Get --> {IISUrl}/Permissions/{id}`: Receive Permission information by Id

## JSON Bodies for POST Requests
1. **Account Login**:
     
    - The body for this request should be set to raw and JSON format.
    - A token must be received in the login response.
    - Body:
    ```json
    {
      "Email": "",
      "password": ""
    }
     ```
2. **Account Register**:
     
    - The body for this request should be set to raw and JSON format.
    - Body:
    ```json
    {
      "Email": "",
      "UserName": "",
      "FullName": "",
      "PhoneNumber": "",
      "ConfirmPassword": "",
      "password": ""
    }
     ```
3. **Account forgotPass**:
    - The body for this request should be set to raw and JSON format.
    - Body:
    ```json
    {
      "Email": ""
    }
     ```
4. **Account ressetPass**:
    - The body for this request should be set to raw and JSON format.
    - Body:
    ```json
    {
      "Email": "",
      "password": "",
      "ConfirmPassword": "",
      "code": ""
    }
     ```
5. **UserInfo RegisterUser**:
    - The body for this request should be set to raw and JSON format.
    - Body:
    ```json
    {
     "Email": "",
      "UserName": "",
      "FullName": "",
      "PhoneNumber": "",
      "ConfirmPassword": "",
      "password": ""
    }
     ```
6. **Roles AddRoles**:
    - The body for this request should be set to raw and JSON format.
    - Body:
    ```json
    {
     "Name": "",
      "NormalizedName": ""
    }
     ```
7. **Systems Add**:
    - The body for this request should be set to raw and JSON format.
    - Body:
    ```json
    {
     "Title": "",
      "Description": "",
       "IsActive" : ""
    }
     ```
8. **Permissions Add**:
    - The body for this request should be set to raw and JSON format.
    - Body:
    ```json
    {
     "Title": "",
      "Description": "",
       "IsActive" : ""
    }
     ```