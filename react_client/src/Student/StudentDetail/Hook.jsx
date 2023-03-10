import { useState } from "react";

export const UseStudentDetail = () => {
    const [studentData,setStudentData] = useState({
        Id : 1,
        Email:"aa.yosefiyan7@gmail.com",
        Username : "MohammadYSF",
        IsActive : true,
        Age : 18,
        PhoneNumber:"09141257762",
        SexTitle : "دختر",
        GradeTitle :"دوازدهم",
        Description:"توضیحاتی مختصر راجع به این دانش آموز درس خوان و کوشای هجده ساله پایه دوازدهم",
        CreationDate:"1401/09/10"
    });
    return (
        {
            studentData
        }
    );
}