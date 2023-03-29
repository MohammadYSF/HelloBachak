import { useForm } from "react-hook-form";
import { useEffect, useState } from "react";
import {yupResolver} from "@hookform/resolvers/yup"
import { EditLessonHelper } from "./Helper";

export const UseEditLesson = (id) => {
    useEffect(() => {
        let title = EditLessonHelper.FindLessonTitleById(id);
        setTitle(title);
    } , []);
    const { register, handleSubmit,formState:{errors} } = useForm({
        resolver:yupResolver(EditLessonHelper.schema)
    });
    const myOwnHandleSubmit = (data) => {
        console.log(data);
    }
    const [data, setData] = useState("");
    const [title , setTitle] = useState("");
    return(
        {
            data,setData,handleSubmit , register , errors , myOwnHandleSubmit , title
        }
    );
}