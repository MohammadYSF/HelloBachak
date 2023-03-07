import { useForm } from "react-hook-form";
import { useState } from "react";
import {yupResolver} from "@hookform/resolvers/yup"
import { AssignDutyHelper } from "./Helper";

export const UseAssignDuty = () => {
    const { register, handleSubmit,formState:{errors} ,  } = useForm({
        resolver:yupResolver(AssignDutyHelper.schema)
    });
    const [numberOfDaysOfMonth , setNumberOfDaysOfMonth] = useState(31);
    const [maxMonthNumber , setMaxMonthNumber] = useState(12);
    const [data, setData] = useState("");
    const [mode , setMode] = useState(1);
    const [previousDuties , setPreviousDuties] = useState([]);
    const myOwnHandleSubmit = (data) => {

    }
    const onChangeMonthInput = (e) => {
        if (e.target.value > 6){
            //31 days
            setNumberOfDaysOfMonth(30);
        }
        else{
            //30 days
            setNumberOfDaysOfMonth(31);
        }
       
    }
    const onChangeDayInput = (e) => {
        if (e.target.value == 31){
            setMaxMonthNumber(6);
        }
        else{
            setMaxMonthNumber(12);
        }        
    }
    const accordionData = new AssignDutyHelper().previousDuties;
    return(        
        {
            data,setData,handleSubmit , register , errors  ,
             myOwnHandleSubmit , onChangeDayInput , onChangeMonthInput , numberOfDaysOfMonth , maxMonthNumber,
             mode , accordionData
        }
    );
}