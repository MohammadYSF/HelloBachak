import { useForm } from "react-hook-form";
import { useState } from "react";
import {yupResolver} from "@hookform/resolvers/yup"
import { DutyReplyHelper } from "./Helper";
import {useNavigate} from 'react-router-dom';

export const UseManageStudents = () => {
    const navigate = useNavigate();
    
    const [modalShowState , setModalShowState] = useState(false); 
    const [studentModalTitle , setStudentModalTitle] = useState("جزئیات دانش آموز");
    const [data , setData] = useState([
        {
            Id:1,
            Username:"MohammadYousefian",
            GradeTitle:"دوازدهم",
            PhoneNumber:"09141257762",
            Age:'17',
            ConsultantTitle :"فاطمه یوسفیان"
        },
        {
            Id:2,
            Username:"FatemeYYY",
            GradeTitle:"پشت کنکور",
            PhoneNumber:"09149234316",
            Age:'14',
            ConsultantTitle :"فاطمه یوسفیان"


        },
        {
            Id:1,
            Username:"Asmaaaaa",
            GradeTitle:"دهم",
            PhoneNumber:"09924300159",
            Age:'22',
            ConsultantTitle :"فاطمه یوسفیان"

        },
        {
            Id:1,
            Username:"HajBaba90",
            GradeTitle:"یازدهم",
            PhoneNumber:"09372898644",
            Age:'20',
            ConsultantTitle :"فاطمه یوسفیان"

        },
    ]);
    const onClickCloseModal = () => {
        setStudentModalTitle("جزئیات دانش آموز");
        setModalShowState(false);
    }
    const onClickDetailStudent = () => {
        setStudentModalTitle("جزئیات دانش آموز");
        setModalShowState(true);
    }
    const onClickStudentDuties = (id) => {
        navigate(`/ManageStudents/${id}/ChangeConsultant`);
    }
   return(
        {data , modalShowState  , onClickCloseModal , 
            studentModalTitle , onClickDetailStudent , onClickStudentDuties}
    );
}