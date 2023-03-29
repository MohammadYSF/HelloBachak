import * as yup from 'yup';
export class LoginHelper {

    static schema = yup.object({
        Email: yup.string().email('ایمیل وارد شده نامعتبر است').required('وارد کردن ایمیل اجباری است').matches(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/, "ایمیل وارد شده نامعتبر است"),
        Password: yup.string().required('وارد کردن رمز عبور اجباری است')
    }).required();
}