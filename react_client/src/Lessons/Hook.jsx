import { useForm } from "react-hook-form";
import { useState } from "react";
import {yupResolver} from "@hookform/resolvers/yup"
import { DutyReplyHelper } from "./Helper";
import {useNavigate} from 'react-router-dom';

export const UseLessons = () => {
    const navigate = useNavigate();
    
    const [data , setData] = useState([
        {
            Id:1,
            Title:"فیزیک"
        },
        {
            Id:2,
            Title:"شیمی"
        },
        {
            Id:1,
            Title:"زیست"

        },
        {
            Id:1,
            Title:"جغرافیا"

        },
    ]);

    const onClickEditLesson = (id) => {
        navigate(`/Lessons/${id}`);
    }
   return(
        {data , onClickEditLesson}
    );
}