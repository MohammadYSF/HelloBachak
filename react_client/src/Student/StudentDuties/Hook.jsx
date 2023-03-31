import { useForm } from "react-hook-form";
import { useState } from "react";
import {yupResolver} from "@hookform/resolvers/yup"
import { StudentDutiesHelper } from "./Helper";
import { useNavigate } from "react-router";

export const UseStudentDuties = ({id}) => {
    const navigate = useNavigate();
    const [dutyDescription , setDutyDescription] = useState('');
    const [studentName , setStudentName] = useState(StudentDutiesHelper.FindStudentName(id));
    const [data , setData] = useState([
        {
            Id:1,
            Title : "وظیفه 1",
            ArrangedDate:"1401/05/04",
            IsSucceedTitle:"آره"
        },
        {
            Id:2,
            Title : "وظیفه 2",
            ArrangedDate:"1401/05/04",
            IsSucceedTitle:"نه"
        },
        {
            Id:1,
            Title :"وظیفه 3",
            ArrangedDate:"1401/05/04",
            IsSucceedTitle:"نه"

        },
        {
            Id:1,
            Title : "وظیفه 4",
            ArrangedDate:"1401/05/04",
            IsSucceedTitle:"آره"
        }
    ]);
    const onClickDetailDuty = (id) => {
        navigate(`/Duties/${id}`);
    }
   return(
        {data ,onClickDetailDuty , studentName , dutyDescription}
    );
}