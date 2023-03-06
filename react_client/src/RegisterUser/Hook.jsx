import { useForm } from "react-hook-form";
import { useState } from "react";
import {yupResolver} from "@hookform/resolvers/yup"
import { RegisterUserHelper } from "./Helper";

export const UseRegisterForm = () => {
    const { register, handleSubmit,formState:{errors} } = useForm({
        resolver:yupResolver(RegisterUserHelper.schema)
    });
    const myOwnHandleSubmit = (data) => {
        console.log(data);
    }
    const [data, setData] = useState("");
    return(
        {
            data,setData,handleSubmit , register , errors , myOwnHandleSubmit
        }
    );
}