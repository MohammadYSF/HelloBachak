import { useForm } from "react-hook-form";
import { useState } from "react";
import {yupResolver} from "@hookform/resolvers/yup"
import { AssignDutyHelper } from "./Helper";

export const UseAssignDuty = () => {
    const { register, handleSubmit,formState:{errors} } = useForm({
        resolver:yupResolver(AssignDutyHelper.schema)
    });
    
    const [data, setData] = useState("");
    const myOwnHandleSubmit = (data) => {

    }
    return(
        {
            data,setData,handleSubmit , register , errors  , myOwnHandleSubmit
        }
    );
}