const boardMenuItems = [
    { text: 'Add card' },
    { text: 'Copy list' },
    { text: 'Move list' },
];

const STATUS_ITEMS = ['Open', 'In Progress', 'Deferred', 'Completed'];

//$.get("/api/Tasks", function (data: any) {
//    console.log("Filtered:", data);

    $.ajax({
        url: '/Home/TaskMainSortable',
        type: 'POST',
        success: function (cont: any) {
            $("#kanban-load-panel").dxLoadPanel("instance").hide();
            $("#kanban-sortable-id").html(cont);

            $("#planning-tasks-toolbar").dxToolbar('instance').repaint();
            $("#planning-tasks-tabs").dxTabs('instance').option("selectedIndex", 1);
        },
        error: function (xhr) {
            console.error('Error:', xhr.status, xhr.statusText, xhr.responseText);
        }
    });
//});

const reorder = <T,>(items: T[], item: T, fromIndex: number, toIndex: number) => {
    let result = items;
    if (fromIndex >= 0) {
        result = [...result.slice(0, fromIndex), ...result.slice(fromIndex + 1)];
    }

    if (toIndex >= 0) {
        result = [...result.slice(0, toIndex), item, ...result.slice(toIndex)];
    }

    return result;
};

function onListReorder(e: DevExpress.ui.dxSortable.ReorderEvent) {
    $("#sortable-id").dxSortable('instance');
}

function onStatusReorder(e: DevExpress.ui.dxSortable.ReorderEvent) {
    let newOrder: string[] = [];
    $(".list-title span").each(function () {
        const text = $(this).text();
        if (newOrder.indexOf(text) === -1) {
            newOrder.push(text);
        }
    })

    $.ajax({
        url: '/api/KanbanOrder/UpdateOrder',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ statuses: newOrder }),
    });
}

function navigateToDetails() {
    console.log("Navigating to task details...");
}

function onClick(item:any) {
    console.log("Edit button clicked for item:", item);
}

function changePopupVisibility(e: DevExpress.ui.dxButton.ClickEvent) {

}
function onTaskDragStart(e: DevExpress.ui.dxSortable.DragStartEvent) {

}

function onTaskDrop(e: DevExpress.ui.dxSortable.AddEvent | DevExpress.ui.dxSortable.ReorderEvent) {
    const $item = $(e.itemElement);
    const taskId = $item.data("task-id");
    const newStatus = $item.closest('.list').find('.list-title span').text();

    if (!taskId || !newStatus) return;

    $.ajax({
        url: '/api/Tasks/UpdateTask',
        type: 'PUT',
        data: {
            key: taskId,
            values: JSON.stringify({ Status: newStatus })
        },
        success: function (res) {
            console.log("Task status updated", res);
        },
        error: function (xhr) {
            console.error('Error updating task status:', xhr.status, xhr.statusText);
        }
    });
}