import { useForm } from "react-hook-form";
import { useState } from "react";
import {yupResolver} from "@hookform/resolvers/yup"
import { StudentDutiesHelper } from "./Helper";

export const UseStudentDuties = ({id}) => {
    const [dutyDescription , setDutyDescription] = useState('');
    const [studentName , setStudentName] = useState(StudentDutiesHelper.FindStudentName(id));
    const [modalShowState , setModalShowState] = useState(false); 
    const [modalTitle , setModalTitle] = useState("توضیحات");
    const [data , setData] = useState([
        {
            Id:1,
            Title : "وظیفه 1",
            ArrangedDate:"1401/05/04"
        },
        {
            Id:2,
            Title : "وظیفه 2",
            ArrangedDate:"1401/05/04"



        },
        {
            Id:1,
            Title :"وظیفه 3",
            ArrangedDate:"1401/05/04"



        },
        {
            Id:1,
            Title : "وظیفه 4",
            ArrangedDate:"1401/05/04"



        }
    ]);
    const onClickCloseModal = () => {
        setModalTitle("توضیحات");
        setModalShowState(false);
    }
    const onClickDetailDuty = (id) => {
        setModalTitle("توضیحات");
        setModalShowState(true);
        setDutyDescription(StudentDutiesHelper.FindDutyDescription(id));
    }
   return(
        {data , modalShowState  , onClickCloseModal , 
            modalTitle , onClickDetailDuty , studentName , dutyDescription}
    );
}