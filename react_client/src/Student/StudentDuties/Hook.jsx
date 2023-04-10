import { useForm } from "react-hook-form";
import { useEffect, useState } from "react";
import {yupResolver} from "@hookform/resolvers/yup"
import { StudentDutiesHelper } from "./Helper";
import { useNavigate } from "react-router";

export const UseStudentDuties = (id) => {
    useEffect(() => {
        StudentDutiesHelper.FindStudentName(id).then(async d=> {
            if (d.status === 200){
                let j = await d.json();
                setStudentName(j.result);                
            }
            else{
                let j = await d.json();
                alert(j.studentIdErrorMessage);
            }
        }).catch(e=> console.log(e));
        StudentDutiesHelper.GetRelatedStudentDuties(id).then(async d=> {
            if (d.status === 200){
                let j = await d.json();
                setData(j);
            }
            else{
                alert("error");
            }
        }).catch(e=> console.log(e));
    },[]);
    const navigate = useNavigate();
    const [studentName , setStudentName] = useState("");
    const [data , setData] = useState([]);
    const onClickDetailDuty = (id) => {
        navigate(`/Duties/${id}`);
    }
   return(
        {data ,onClickDetailDuty , studentName}
    );
}