import { UseStudentDetail } from "./Hook";
import "../StudentDetail/style.css"
export const StudentDetail = () => {
    const {studentData}  = UseStudentDetail();
    return (
        <>
       
            <h1 className="text-center h1">{studentData.Username}</h1>
            <p>سن :‌<span className="text-info ms-3 span-detail">{studentData.Age}</span></p>
            <p>جنسیت :‌<span className="text-info ms-3 span-detail">{studentData.SexTitle}</span></p>
            <p>مقطع تحصیلی :‌<span className="text-info ms-3 span-detail">{studentData.GradeTitle}</span></p>
            <p>ایمیل :‌<span className="text-info ms-3 span-detail">{studentData.Email}</span></p>
            <p>شماره همراه :‌<span className="text-info ms-3 span-detail">{studentData.PhoneNumber}</span></p>
            <p>تاریخ ثبت نام :‌<span className="text-info ms-3 span-detail">{studentData.CreationDate}</span></p>
            <p>توضیحات :‌<span className="text-info ms-3 span-detail">{studentData.Description}</span></p>
        </>
    );
}