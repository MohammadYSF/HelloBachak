import { UseStudentDetail } from "./Hook";
import "../StudentDetail/style.css"
export const StudentDetail = ({studentData}) => {
    //const {studentData}  = UseStudentDetail();
    return (
        <>
       
            <h1 className="text-center h1">{studentData.username}</h1>
            <p>سن :‌<span className="text-info ms-3 span-detail">{studentData.age}</span></p>
            <p>جنسیت :‌<span className="text-info ms-3 span-detail">{studentData.sexTitle}</span></p>
            <p>مقطع تحصیلی :‌<span className="text-info ms-3 span-detail">{studentData.gradeTitle}</span></p>
            <p>ایمیل :‌<span className="text-info ms-3 span-detail">{studentData.email}</span></p>
            <p>شماره همراه :‌<span className="text-info ms-3 span-detail">{studentData.phoneNumber}</span></p>
            <p>تاریخ ثبت نام :‌<span className="text-info ms-3 span-detail">{studentData.registerDateString}</span></p>
            <p>توضیحات :‌<span className="text-info ms-3 span-detail">{studentData.description}</span></p>
        </>
    );
}