function addTask() {
    console.log("Add Task for Planning Task Grid");
}

function tabValueChange(e: DevExpress.ui.dxTabs.ItemClickEvent) {
    let url: string = "/Home/PlanningTasks/";
    if (e.itemData.text === "List") url += "Grid";
    if (e.itemData.text === "Kanban Board") url += "Kanban";
    if (e.itemData.text === "Gantt") url += "Gantt";
    SPARouter.navigate(url);
}

function reload() {

}

function chooseColumnDataGrid() {

}

function exportToPdf() {

}

function exportToXlsx() {

}

function searchDataGrid(e: DevExpress.ui.dxTextBox.InputEvent) {

}