This is Single Page Application (SPA) built on base of Blazor WASM
Its autonomous client application without server communication.
It provides access to 3 pages:
-1- Login
-2- Public page - that can be accessed by any authenticated user.
-3- Administrator page - that can only be accessible for users authorized as administrator

All unauthenticated users being redirected to Login page.
For access to local storage nuget package Blazored.LocalStorage is used
Credential data (Security tokens of a user’s) stored in browser local storage in a crypted form.
UI contain form for login flow, logout button, navigation sidebar to navigate through pages.
