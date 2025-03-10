# DevExtreme.Asp.Template.Gallery
### How to add a new view
1) Create a new subdirectory in 'Views' for your new view.
2) Create a regular view in this directory.
3) Open HomeController and add a method that returns the new view.
4) Find TreeView items Razor declaration in Shared/Layout.cshtml and add a new item for your view.

How to add TS scripts for the view

6) Create myview.ts file in src/ts/views.
7) Link myview.js file in the view's code. This JS file will be generated based on the TS file during the build process.
   ```html
   <script src="~/js/views/myview.js"></script>
   ```
  
### How does the router work? 
We implemented a custom router to navigate between views. The router combines regular and SPA navigation between views. The router reloads pages if a target view's Layout differs from the current view's Layout. If the Layout is the same, footer, header, and the left-side navigation bar remains visible and only the content part is dynamically replaced.
 
Router uses the [pushstate](https://developer.mozilla.org/en-US/docs/Web/API/History/pushState) method and [popstate](https://developer.mozilla.org/en-US/docs/Web/API/Window/popstate_event) event to handle URL modifications. It calls pushstate to push the target URL and then decides if it is necessary to reload the page. For this, the router loads content of the target page and checks if its Layout part equals to the Layout part of the current page. We use the custom "data-target-placeholder-id" attribute for comparison. If the Layout pages are the same, the loaded content replaces the content element. If the Layout pages are different, the page is reloaded.
 
If the page is not reloaded, the lightweight Layout file is selected for the loaded content. This logic is implemented in the _ViewStart.cshtml files. The _ViewStart.cshtml file in the Views/Auth directory has additional Layout selection logic since Auth views can be shown in the main Layout and when users log out.
