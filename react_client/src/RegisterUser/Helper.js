import * as yup from 'yup';
export class RegisterUserHelper {

    static schema = yup.object({
        Username: yup.string().required('وارد کردن نام کاربری اجباری ست'),
        Email: yup.string().email('ایمیل وارد شده نامعتبر است').required('وارد کردن ایمیل اجباری است'),
        PhoneNumber: yup.string().required('وارد کردن شماره همراه اجباری است'),
        Password: yup.string().required('وارد کردن رمز عبور اجباری است'),
        ConfirmPassword: yup.string().oneOf([yup.ref("Password")] , "رمز عبور های وارد شده یکی نیستند").required('وارد کردن مجدد پسورد اجباری می باشد'),
        Age: yup.number().positive('مقدار وارد شده نامعتبر است').integer('مقدار وارد شده نامعتبر است').required('وارد کردن سن اجباری است').min(7,'مینیمم سن ۷ می باشد').max(70 , 'ماکسیمم سن ۷۰ می باشد')
    }).required();
}