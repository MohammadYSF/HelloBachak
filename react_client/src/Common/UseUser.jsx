export const UseUser = () => {
    const isUserLoggedIn = window.localStorage.getItem("username") != "" &&
        window.localStorage.getItem("username") != undefined;
    const username = window.localStorage.getItem("username");
    return {isUserLoggedIn , username};
}