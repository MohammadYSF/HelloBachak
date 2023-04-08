import { useForm } from "react-hook-form";
import { useEffect, useState } from "react";
import {yupResolver} from "@hookform/resolvers/yup"
import { DutyReplyHelper, RelatedStudentsHelper } from "./Helper";
import {useNavigate} from 'react-router-dom';
import { ManageStudentHelper } from "../ManageStudents/Helper";

export const UseRelatedStudents = (consultantId) => {
    const navigate = useNavigate();
    const [studentData , setStudentData] = useState({});
    const [modalShowState , setModalShowState] = useState(false); 
    const [studentModalTitle , setStudentModalTitle] = useState("جزئیات دانش آموز");
    const [data , setData] = useState([]);
    useEffect(() => {
        new RelatedStudentsHelper().getRelatedStudents(consultantId).then(async d=> {
            if (d.status === 200){
                const j = await d.json();
                setData(j);
            }
            else{
                alert("Error");
            }
        }).catch(e=>console.log(e));
    } , []);
    const onClickCloseModal = () => {
        setStudentModalTitle("جزئیات دانش آموز");
        setModalShowState(false);
    }
    const onClickDetailStudent = (id) => {
        setStudentModalTitle("جزئیات دانش آموز");
        setModalShowState(true);
        new ManageStudentHelper().getStudentDetail(id).then(async d=> {
            if (d.status === 200){
                const j = await d.json();
                setStudentData(j);
            }
            else{
                alert("خطا");
            }
        }).catch(e=> console.log(e));
    }
    const onClickStudentDuties = (id) => {
        navigate(`/Students/${id}/duties`);
    }
   return(
        {data,modalShowState  , onClickCloseModal , 
            studentModalTitle , onClickDetailStudent , onClickStudentDuties , studentData}
    );
}