const navigation = (function () {

    const TOP_LEVEL_VIEW_SELECTOR = "#view-placeholder";
    const NAVIGATABLE_VIEW_SELECTOR = "#navigatable-view-placeholder";
    const NAVIGATOR_URL = "Navigation/GetNavigationRootComponent";
    const GET_NAVDATA_URL = "Navigation/GetNavigationData";
    const startupView = "Tasks";

    let navigationData = null;
    let currentViewName;

    function getNavigationData(onlyWithNavigation) {
        return onlyWithNavigation ? navigationData.filter(n => !n.HideNavigation) : navigationData;
    }

    $.get(GET_NAVDATA_URL, function (navData) {
        navigationData = navData;
        if (window.location.pathname === "/") {
            loadView(startupView);
        } else {
            loadViewByUrl(url);
        }
    });

    function loadView(viewName) {
        if (viewName === currentViewName) return;
        const navItem = navigationData.find(n => n.ViewName === viewName);
        if (navItem) {
            const navigationVisible = currentViewName
                ? !navigationData.find(n => n.ViewName === currentViewName).HideNavigation
                : false;
            if (navigationVisible) {
                loadViewByUrl(navItem.Path, navItem.HideNavigation ? TOP_LEVEL_VIEW_SELECTOR : NAVIGATABLE_VIEW_SELECTOR);
            } else {
                if (navItem.HideNavigation) {
                    loadViewByUrl(navItem.Path, TOP_LEVEL_VIEW_SELECTOR);
                } else {
                    loadViewByUrl(NAVIGATOR_URL, TOP_LEVEL_VIEW_SELECTOR)
                        .then(() => {
                            loadViewByUrl(navItem.Path, NAVIGATABLE_VIEW_SELECTOR);
                        });
                }
            }
            currentViewName = viewName;
        } else {
            console.error(`Cannot navigate to '${viewName}'. This view doesn't exist.`);
        }
    }

    function loadViewByUrl(url, targetSelector) {
        const contentLoaded = new Promise(res => {
            $.get(url, function (data) {
                $(targetSelector).html(data);
                res();
            });
        });
        return contentLoaded;
    }

    function openInitialView() {
        if (navigationData) {
            loadViewByUrl(window.location.pathname);
        }
    };

    return {
        getNavigationData,
        openInitialView,
        loadView
    }
})();