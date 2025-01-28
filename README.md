# DevExtreme UI Template Gallery for ASP.NET Core

## Installation

Download the example and use Visual Studio 2022 to open the project. 

## Project Structure

The project contains the following sections:
- Controllers contains actions connected with `Views`
- Views holds structure of the current pages within an application.
  * Auth contains all code related to authorization forms
  * Shared contains logic related to root layots
  * Other folders are equal to name of corresponding pages in the application itself 
- All client-side source code is located in `src` . This folder repeats structure of views and layouts.

### Client-side resources and bundling

This project uses [NPM](https://www.npmjs.com/) to install client-side libraries: jQuery and DevExtreme. All application styles are built from SCSS and TypeScript is used to write client-side logic. 

The project doesn't automatically restore NPM packages. You need to run `npm i` before the first build. 
Then run `F5` and MSBuild will execute the following tasks

- `CopyTask` for jQuery and DevExtreme scripts, icons, and fonts from `node_modules` and moves them to `wwwroot`
- `AspNetCore.SassCompiler` bundles required SCSS scripts into CSS files and moves them to `wwwroot`. You can define/change this config in `appsettings.json`
- `Microsoft.TypeScript.MSBuild` compiles all TS to JS and moves files to `wwwroot` 

### Add additional 3rd-party client-side resources 

To add additional scripts/styles to application it's necessary to install corresponding NPM packages first. 
Then add corresponding files to the `CopyTask`: [link](https://github.com/artem-kurchenko/devextreme-asp-ui-template-gallery/blob/d452b4ad4b26830aec70d3527a7a3a57378b36b9/devextreme-asp-ui-template-gallery.csproj#L11)

### Add more Pages with additional features/components (aka code rules)

- Create a new folder for each group of pages you plan to add to navigation
- If a page includes multiple components, you need to create sub-folders to add partial views to separate logic.
- Partial and layout views should start with the "_" symbol. 
- All code should be written in TS and styles defined in SCSS. You need to create corresponding files in `src`. 
- You need to link scripts and styles as JS/CSS files into corresponding views (e.g. see [link](https://github.com/artem-kurchenko/devextreme-asp-ui-template-gallery/blob/d452b4ad4b26830aec70d3527a7a3a57378b36b9/Views/PlanningTasks/PlanningTasks.cshtml#L2))


## Development server

Use the Visual Studio `Run (F5)` command to run the project.

## Further help

You can learn more about the ASP.NET Core components' syntax in our documentation: [Concepts](https://docs.devexpress.com/AspNetCore/400574/devextreme-based-controls/concepts/razor-syntax)
The client-side API is based on jQuery [jQuery documentation](https://api.jquery.com/) and described in the following topics: 
* [Get and Set Properties](https://js.devexpress.com/DevExtreme/Guide/jQuery_Components/Component_Configuration_Syntax/#Get_and_Set_Properties)
* [Call Methods](https://js.devexpress.com/DevExtreme/Guide/jQuery_Components/Component_Configuration_Syntax/#Call_Methods)
* [Get a UI Component Instance](https://js.devexpress.com/DevExtreme/Guide/jQuery_Components/Component_Configuration_Syntax/#Get_a_UI_Component_Instance)

To get more help on DevExtreme submit an issue in the [Support Center](https://www.devexpress.com/Support/Center/Question/Create)
