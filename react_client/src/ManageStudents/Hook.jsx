import { useForm } from "react-hook-form";
import { useEffect, useState } from "react";
import {yupResolver} from "@hookform/resolvers/yup"
import { DutyReplyHelper, ManageStudentHelper } from "./Helper";
import {useNavigate} from 'react-router-dom';

export const UseManageStudents = () => {
    const navigate = useNavigate();
    
    const [modalShowState , setModalShowState] = useState(false); 
    const [studentModalTitle , setStudentModalTitle] = useState("جزئیات دانش آموز");
    const [data , setData] = useState([]);
    const [studentData , setStudentData] = useState({});
    useEffect(() => {
        new ManageStudentHelper().getStudents().then(async d=> {
            if (d.status === 200){
                const j = await d.json();
                setData(j);
            }
            else{
                alert("خطا در خواندن اطلاعات");
            }
        })
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

            }
        })
    }
    const onClickStudentDuties = (id) => {
        navigate(`/ManageStudents/${id}/ChangeConsultant`);
    }
   return(
        {data , modalShowState  , onClickCloseModal , 
            studentModalTitle , onClickDetailStudent , onClickStudentDuties,
            studentData}
    );
}