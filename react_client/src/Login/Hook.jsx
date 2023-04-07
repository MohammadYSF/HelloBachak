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
        new LoginHelper().login(data.Email , data.Password).then(d=> {
            if (!d.success){
                reset({Password:"" });
                if (d.emailErrorMessage){
                    setServerEmailError(d.emailErrorMessage);
                }
                else if (d.passwordErrorMessage){
                    setServerPasswordError(d.passwordErrorMessage);
                }
            }
            else{
                window.localStorage.setItem("username",d.username);
                reset({Email:"" ,Password:"" });
                navigate("/");
            }
        });
        
        // console.log(data);
    }
    const [data, setData] = useState("");
    return(
        {
            data,setData,handleSubmit , register , errors , myOwnHandleSubmit , serverEmailError , serverPasswordError 
        }
    );
}