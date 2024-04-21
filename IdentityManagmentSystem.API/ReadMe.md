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

6. **SystemPermissions Controller**:
    - `POST --> {IISUrl}/SystemPermission/Add`: Add New SystemPermission by Admin.
    - `PUT --> {IISUrl}/SystemPermission/Edit`: Edit Information of SystemPermission by admin.
    - `Delete --> {IISUrl}/SystemPermission/Delete`: Delete one SystemPermission by admin.
    - `Get --> {IISUrl}/SystemPermission/filter`: Receive filtered and paged SystemPermission information 
    - `Get --> {IISUrl}/SystemPermission/search`: Receive Searched and paged SystemPermission information
    - `Get --> {IISUrl}/SystemPermission/{id}`: Receive SystemPermission information by Id

7. **SystemRole Controller**:
    - `POST --> {IISUrl}/SystemRole/Add`: Add New SystemRole by Admin.
    - `PUT --> {IISUrl}/SystemRole/Edit`: Edit Information of SystemRole by admin.
    - `Delete --> {IISUrl}/SystemRole/Delete`: Delete one SystemRole by admin.
    - `Get --> {IISUrl}/SystemRole/filter`: Receive filtered and paged SystemRole information 
    - `Get --> {IISUrl}/SystemRole/search`: Receive Searched and paged SystemRole information
    - `Get --> {IISUrl}/SystemRole/{id}`: Receive SystemRole information by Id

8. **SRP Controller**:
    - `POST --> {IISUrl}/SRP/Add`: Add New SystemRolePermission by Admin.
    - `PUT --> {IISUrl}/SRP/Edit`: Edit Information of SystemRolePermission by admin.
    - `Delete --> {IISUrl}/SRP/Delete`: Delete one SystemRolePermission by admin.
    - `Get --> {IISUrl}/SRP/filter`: Receive filtered and paged SystemRolePermission information 
    - `Get --> {IISUrl}/SRP/search`: Receive Searched and paged SystemRolePermission information
    - `Get --> {IISUrl}/SRP/{id}`: Receive SystemRolePermission information by Id

9. **SUR Controller**:
    - `POST --> {IISUrl}/SUR/Add`: Add New SystemUserRole by Admin.
    - `PUT --> {IISUrl}/SUR/Edit`: Edit Information of SystemUserRole by admin.
    - `Delete --> {IISUrl}/SUR/Delete`: Delete one SystemUserRole by admin.
    - `Get --> {IISUrl}/SUR/filter`: Receive filtered and paged SystemUserRole information 
    - `Get --> {IISUrl}/SUR/search`: Receive Searched and paged SystemUserRole information
    - `Get --> {IISUrl}/SUR/{id}`: Receive SystemUserRole information by Id

10. **SURP Controller**:
    - `POST --> {IISUrl}/SURP/Add`: Add New SystemUserRolePermission by Admin.
    - `PUT --> {IISUrl}/SURP/Edit`: Edit Information of SystemUserRolePermission by admin.
    - `Delete --> {IISUrl}/SURP/Delete`: Delete one SystemUserRolePermission by admin.
    - `Get --> {IISUrl}/SURP/filter`: Receive filtered and paged SystemUserRolePermission information 
    - `Get --> {IISUrl}/SURP/search`: Receive Searched and paged SystemUserRolePermission information
    - `Get --> {IISUrl}/SURP/{id}`: Receive SystemUserRolePermission information by Id

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
9. **SystemPermission Add**:
    - The body for this request should be set to raw and JSON format.
    - Body:
    ```json
    {
     "PermissionId": "",
     "systemId": ""
    }
     ```
10. **SystemRole Add**:
    - The body for this request should be set to raw and JSON format.
    - Body:
    ```json
    {
     "RoleId": "",
     "systemId": ""
    }
     ```
 11. **SRP Add**:
    - The body for this request should be set to raw and JSON format.
    - Body:
    ```json
    {
     "RoleId": "",
     "systemId": "",
     "PermissionId": ""
    }
     ```
 12. **SUR Add**:
    - The body for this request should be set to raw and JSON format.
    - Body:
    ```json
    {
     "RoleId": "",
     "systemId": "",
     "usersId": ""
    }
     ```
  13. **SURP Add**:
    - The body for this request should be set to raw and JSON format.
    - Body:
    ```json
    {
     "RoleId": "",
     "systemId": "",
     "usersId": "",
     "PermissionId": ""
    }
     ```
 
 ## JSON Bodies for PUT Requests
 1. **UserInfo EditUser**:
      - The body for this request should be set to raw and JSON format.
     - Body:
 ```json
    {
      "Id": "",
      "Email": "",
      "UserName": "",
      "FullName": "",
      "PhoneNumber": "",
    }
     
```
 2. **UserInfo ChangePassword**:
      - The body for this request should be set to raw and JSON format.
     - Body:
 ```json
    {
      "Id": "",
      "ConfirmPassword": "",
      "password": ""
    }
```
3. **Systems Edit**:
     - The body for this request should be set to raw and JSON format.
     - Body:
 ```json
    {
      "Id": "",
      "Title": "",
      "Description": "",
      "IsActive" : ""
    }
```
4. **Permissions Edit**:
     - The body for this request should be set to raw and JSON format.
     - Body:
 ```json
    {
      "Id": "",
      "Title": "",
      "Description": "",
      "IsActive" : ""
    }
```
5. **Roles EditRole**:
     - The body for this request should be set to raw and JSON format.
     - Body:
 ```json
    {
      "Id": "",
      "Name": "",
      "NormalizedName": "",
    }
```
6. **Roles EditRole**:
     - The body for this request should be set to raw and JSON format.
     - Body:
 ```json
    {
      "Id": "",
      "Name": "",
      "NormalizedName": "",
    }
```
7. **SystemPermission Edit**:
     - The body for this request should be set to raw and JSON format.
     - Body:
 ```json
    {
      "Id": "",
      "PermissionId": "",
      "systemId": "",
    }
```
8. **SystemRole Edit**:
     - The body for this request should be set to raw and JSON format.
     - Body:
 ```json
    {
      "Id": "",
      "RoleId": "",
      "systemId": ""
      
    }
```
9. **SRP Edit**:
     - The body for this request should be set to raw and JSON format.
     - Body:
 ```json
    {
      "Id": "",
      "RoleId": "",
      "systemId": "",
      "PermissionId": ""
    }
```
10. **SUR Edit**:
     - The body for this request should be set to raw and JSON format.
     - Body:
 ```json
    {
      "Id": "",
      "RoleId": "",
      "systemId": "",
      "UserId": ""
    }
```
11. **SURP Edit**:
     - The body for this request should be set to raw and JSON format.
     - Body:
 ```json
    {
      "Id": "",
      "RoleId": "",
      "systemId": "",
      "UserId": "",
      "PermissionId": ""
    }
```
##  Responses
1. **Account Login**:
   `POST --> {IISUrl}/Account/login`
  - If the user Authenticate successfully The response will be:
    - Status: 200
    - Body:
  ```json
    {
    "Id": "",
    "Email": "",
    "AccessToken": ""
    }
  ```
  2. **Account Register**:
   `POST --> {IISUrl}/Account/register`
  - If the user Registration successfully The response will be:
    - Status: 200
    - Body:
  ```json
    {
    "UserId": "",
    "UserEmail": ""
    }
  ```
  3. **Account forgotPass**:
   `POST --> {IISUrl}/Account/forgotPass`
  - If forgotPass successfully resive an email and The response will be:
    - Status: 200
   
  4. **Account ressetPass**:
   `POST --> {IISUrl}/Account/ressetPass`
    - If ressetPass successfully password will be change The response will be:
    - Status: 200
   
  5. **UserInfo RegisterUser**:
    - `POST --> {IISUrl}/UserInfo/RegisterUser`
    - If registration User successfully The response will be:
    - Status: 200
       - Body:
  ```json
    {
    "Success": "true",
    "Message": "Creation Successful"
    }
  
 ```
   - If registration User fail The response will be:
    - Status: 400
       - Body:
  ```json
    {
    "Success": "false",
    "Message": "Creation fail",
    "errors": "validation errors"
    }
  
 ```

   6. **UserInfo EditUser**:
      - `PUT --> {IISUrl}/UserInfo/EditUser`
    - If Edit User successfully The response will be:
    - Status: 200
       - Body:
  ```json
    {
    "Success": "true",
    "Message": "Edit Successful"
    }
  
 ```
  - If User Id Is Null response will be:
   - Status: 400 or BadRequest    
   - Body: UserId is Null
   
  - If User With the Id that Enter by client not found response will be:
   - Status: 404 or Not Found    
   - Body: User Not Found!

 7. **UserInfo ChangePassword**:
      - `PUT --> {IISUrl}/UserInfo/ChangePassword`
    - If Edit User successfully The response will be:
    - Status: 200
       - Body:
  ```json
    {
    "Success": "true",
    "Message": "Edit Successful"
    }
  
 ```
  - If User Id Is Null response will be:
   - Status: 400 or BadRequest    
   - Body: UserId is Null
   
  - If User With the Id that Enter by client not found response will be:
   - Status: 404 or Not Found    
   - Body: User Not Found!

   8. **UserInfo FilterUser**:
      - `GET --> {IISUrl}/UserInfo/FilterUser`
    - If Request for Get Filltered and Paged User is successfully The response will be:
    - Status: 200
       - Body can be list or single object:
  ```json
    {
    "Id": "",
    "UserName": "",
    "Email":"Fullname",
    "PhoneNumber":""
    }
  
 ```
 - If Request for Get Filltered and Paged User is fail from handler and cant return data The response will be:
 - Status : 404 NotFound 
 
 9. **UserInfo SearchUser**:
      - `GET --> {IISUrl}/UserInfo/SearchUser`
    - If Request for Get Searched and Paged User is successfully The response will be:
    - Status: 200
       - Body can be list or single object:
  ```json
    {
    "Id": "",
    "UserName": "",
    "Email":"Fullname",
    "PhoneNumber":""
    }
  
 ```
  - If Request for Get Searched and Paged User is fail from handler and cant return data The response will be:
 - Status : 404 NotFound 

10. ** Roles AddRoles**:
    - `POST --> {IISUrl}/Roles/AddRoles`
    - If Add role request is successfully The response will be:
    - Status: 200
       - Body:
  ```json
    {
    "Success": "true",
    "Message": "Creation Successful"
    }
  ```
  - If Add role request fail for eny other reason The response will be:
  - Status: 400
   - Body:
  ```json
    {
    "Success": "false",
    "Message": "Creation fail",
    "errors": "validation errors"
    }
  
 ```
 11. ** Roles EditRole**:
    - `POST --> {IISUrl}/Roles/EditRole`
    - If Edit role request is successfully The response will be:
    - Status: 200
       - Body:
  ```json
    {
    "Success": "true",
    "Message": "Creation Successful"
    }
  ```
  - If id of object of request is null response will be:
  - Status: 400
  - Body:RoleId is Null
  
   - If User not exist in database response will be:
   - Status: 404 NotFound
   - Body:Role Not Found!

  - If Edit role request fail for eny other reason The response will be:
  - Status: 400
   - Body:
  ```json
    {
    "Success": "false",
    "Message": "Creation fail",
    "errors": "validation errors"
    }
 ```
  


  