import { useForm } from "react-hook-form";
import { useEffect, useState } from "react";
import {yupResolver} from "@hookform/resolvers/yup"
import { LoginHelper } from "./Helper";
import {useNavigate} from 'react-router-dom';

export const UseLogin = () => {
    const navigate = useNavigate();
    const [serverEmailError , setServerEmailError] = useState("");
    const [serverPasswordError , setServerPasswordError] = useState("");

    const { register, handleSubmit,formState:{errors} , reset , watch } = useForm({
        resolver:yupResolver(LoginHelper.schema)
    });
    useEffect(() => {
        const subscription = watch((value, { name, type }) => {
            setServerEmailError("");
            setServerPasswordError("");
        });
        return () => subscription.unsubscribe();
    } , [watch]);
    const myOwnHandleSubmit = (data) => {
        new LoginHelper().login(data.Email , data.Password).then(async d=> {            
            const j = await d.json();
            if (!j.success){
                reset({Password:"" });
                if (j.emailErrorMessage){
                    setServerEmailError(j.emailErrorMessage);
                }
                else if (j.passwordErrorMessage){
                    setServerPasswordError(j.passwordErrorMessage);
                }
            }
            else{
                window.localStorage.setItem("username",j.username);
                window.localStorage.setItem("token",j.token);
                window.localStorage.setItem("refreshToken",j.refreshToken);
                window.localStorage.setItem("roles" , j.roleTitle);
                window.localStorage.setItem("userid" , j.userId);

                reset({Email:"" ,Password:"" });
                navigate("/");
                window.location.reload();
            }
        }).catch(e=> console.log(e));        
    }
    const [data, setData] = useState("");
    return(
        {
            data,setData,handleSubmit , register , errors , myOwnHandleSubmit , serverEmailError , serverPasswordError 
        }
    );
}