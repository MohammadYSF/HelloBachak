import { useForm } from "react-hook-form";
import { useEffect, useState } from "react";
import {yupResolver} from "@hookform/resolvers/yup"
import { ChangeConsultantHelper } from "./Helper";
import { useNavigate } from "react-router";
export const UseChangeConsultant = (id) => {
    const navigate = useNavigate();
    useEffect(() => {
        let title = ChangeConsultantHelper.FindUsernameById(id);
        setTitle(title);
    } , []);
    const { register, handleSubmit,formState:{errors} } = useForm({
        resolver:yupResolver(ChangeConsultantHelper.schema)
    });
    const myOwnHandleSubmit = (data) => {
        console.log(data);
    }
    const onClickCancel = () => {
        navigate(`/ManageStudents`);

    }
    const [data, setData] = useState("");
    const [title , setTitle] = useState("");
    return(
        {
            data,setData,handleSubmit , register , errors , myOwnHandleSubmit , title,onClickCancel
        }
    );
}