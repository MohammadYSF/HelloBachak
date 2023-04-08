import { useNavigate, useLocation } from 'react-router-dom';
import { UserHelper } from './Helper';
export const UseUser = () => {
    const isUserLoggedIn = window.localStorage.getItem("username") != "" &&
        window.localStorage.getItem("username") != undefined;
    const username = window.localStorage.getItem("username");
    const signOut = () => {
        new UserHelper().signOut(window.localStorage.getItem("token")).then(async d => {
            if (d.status == 200) {
                const j = await d.json();
                window.localStorage.setItem("username", "");
                window.localStorage.setItem("token", "");
                window.localStorage.setItem("refreshToken", "");
                window.localStorage.setItem("roles", "");
                window.localStorage.setItem("userid", "");
                window.location.pathname != "/" && window.location.replace("/");
                window.location.reload();
            }
            else {
                alert("Error");
            }
        }).catch(e => console.log(e));

    }
    //should dynamic this
    const userRole = window.localStorage.getItem("roles") == null ? "" : window.localStorage.getItem("roles");
    return { isUserLoggedIn, username, signOut , userRole };
}