import * as yup from 'yup';
export class AssignDutyHelper {

    static schema = yup.object({
        Title: yup.string().required('وارد کردن عنوان اجباری ست'),
        Description: yup.string().required('وارد کردن توضیحات اجباری است'),
        Day:yup.string().required("مشخص کردن روز اجباری است"),
        Month:yup.string().required("مشخص کردن ماه اجباری است"),
        Year:yup.string().required("مشخص کردن سال اجباری است"),
        LessonId: yup.number().min(1, 'انتخاب درس اجباری است'),
        StudentId: yup.number().min(1, 'انتخاب دانش آموز اجباری است')
    });
}