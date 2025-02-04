# add-app-settings
An application to write app settings into a particular .NET project as per the selected environment. In particular, this adds settings into appsettings.json, and additional settings for local.settings.json and host.json files, which are typical files used in .NET development.

## How to use
- In the paths.json file, include the DefaultMainPath (which should be the path to your main directory)
- In the same file, also include the relative paths to your individual projects inside the directory (for which you need to add the app settings). The name of the project should match the dropdown text of the selected project.
- Settings are to be included through json files to be added inside the appsettings folder. The name of the file should match the dropdown text of the selected environment.
