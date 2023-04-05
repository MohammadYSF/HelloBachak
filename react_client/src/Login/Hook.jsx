import { useForm } from "react-hook-form";
import { useState } from "react";
import {yupResolver} from "@hookform/resolvers/yup"
import { LoginHelper } from "./Helper";

export const UseLogin = () => {
    const { register, handleSubmit,formState:{errors} } = useForm({
        resolver:yupResolver(LoginHelper.schema)
    });
    const myOwnHandleSubmit = (data) => {
        new LoginHelper().login(data.Email , data.Password);
        // console.log(data);
    }
    const [data, setData] = useState("");
    return(
        {
            data,setData,handleSubmit , register , errors , myOwnHandleSubmit
        }
    );
}