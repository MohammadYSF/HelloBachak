import { useForm } from "react-hook-form";
import { useState } from "react";
import {yupResolver} from "@hookform/resolvers/yup"
import { DutyReplyHelper } from "./Helper";

export const UseRelatedStudents = () => {
    const [modalMode , setModalMode] = useState("detail");
    const [modalShowState , setModalShowState] = useState(false); 
    const [studentModalTitle , setStudentModalTitle] = useState("جزئیات دانش آموز");
    const [data , setData] = useState([
        {
            Id:1,
            Username:"MohammadYousefian",
            GradeTitle:"دوازدهم",
            PhoneNumber:"09141257762",
            Age:'17'
        },
        {
            Id:2,
            Username:"FatemeYYY",
            GradeTitle:"پشت کنکور",
            PhoneNumber:"09149234316",
            Age:'14'


        },
        {
            Id:1,
            Username:"Asmaaaaa",
            GradeTitle:"دهم",
            PhoneNumber:"09924300159",
            Age:'22'


        },
        {
            Id:1,
            Username:"HajBaba90",
            GradeTitle:"یازدهم",
            PhoneNumber:"09372898644",
            Age:'20'


        },
    ]);
    const onClickEditStudent = () => {
        setModalMode("edit");
        setStudentModalTitle("ویرایش دانش آموز");
        setModalShowState(true);

    }
    const onClickCloseModal = () => {
        setModalMode("detail");
        setStudentModalTitle("جزئیات دانش آموز");
        setModalShowState(false);
    }
    const onClickDetailStudent = () => {
        setModalMode("detail");
        setStudentModalTitle("جزئیات دانش آموز");
        setModalShowState(true);
    }
   return(
        {data , modalShowState , onClickEditStudent , onClickCloseModal , 
            studentModalTitle , onClickDetailStudent , modalMode}
    );
}