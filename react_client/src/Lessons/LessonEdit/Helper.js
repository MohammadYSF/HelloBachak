import * as yup from 'yup';
export class EditLessonHelper {

    static FindLessonTitleById(id) {
        return "فیزیک 2";
    }


    static schema = yup.object({
        Title: yup.string().required('وارد کردن عنوان درس اجباری است').max(50)
    }).required();
}