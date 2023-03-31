import { useForm } from "react-hook-form";
import { useState } from "react";
import {yupResolver} from "@hookform/resolvers/yup"
import { RegisterUserHelper } from "./Helper";

export const UseRegisterForm = () => {
    const { register, handleSubmit,formState:{errors} , reset } = useForm({
        resolver:yupResolver(RegisterUserHelper.schema)
    });
    const myOwnHandleSubmit = (data) => {
        console.log(data);        
        reset({Email:"" , Username:"" ,Password:"" , PhoneNumber:"" , ConfirmPassword:""});
        setToastShow(true);
    }
    const onCloseToast = () => {
        setToastShow(false);
    }
    const [data, setData] = useState("");
    const [toastShow,setToastShow] = useState(false);
    return(
        {
            data,setData,handleSubmit , register , errors , myOwnHandleSubmit , toastShow,onCloseToast
        }
    );
}