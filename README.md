
### Document File Structure
NOTE: Make the file structure and source code simple, secure and optimize
Always document the changes in the folder structure and source code.


### Api Project
- This is the presentation layer according to the Clean Architecture

### Shared Folder
- Common
  - Create Common Methods, Properties, Constants, Enums, Objects, Class that are only shared in this project
  - If you want to add global features that will be use in other project please do following:
	- update the Common Library;
	- or create another project for the shared / common features
	- 

### Database Migration

USE the Commands below for the following actions:

- migrate db
- ``` Add-Migration InitDb ` -Project Authentication.Infrastructure ` -StartupProject Authentication.Api ` -Context AuthenticationDbContext ```
- update db
- ``` Update-Database ` -Project Authentication.Infrastructure ` -StartupProject Authentication.Api ` -Context AuthenticationDbContext ```


