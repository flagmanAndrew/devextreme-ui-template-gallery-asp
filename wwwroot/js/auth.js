const user = {
    email: 'jheart@dx-email.com',
    name: 'John',
    lastName: 'Heart',
    avatarUrl: 'https://js.devexpress.com/Demos/WidgetsGallery/JSDemos/images/employees/01.png',
};

function logIn(email, password){
    try {
        let _user = { ...user, email };
        console.log("logIn", _user);
        return {
            isOk: true,
            data: _user,
        };
    } catch {
        return {
            isOk: false,
            message: 'Authentication failed',
        };
    }
};