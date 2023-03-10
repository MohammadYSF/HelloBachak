import * as yup from 'yup';
export class RegisterUserHelper {

    static schema = yup.object({
        Username: yup.string().required('وارد کردن نام کاربری اجباری ست').matches(/^[A-Za-z][A-Za-z0-9]*$/, "نام کابری معتبر نیست").min(4, "نام کاربری کوتاه است").max(50, "نام کاربری طولانی است"),
        Email: yup.string().email('ایمیل وارد شده نامعتبر است').required('وارد کردن ایمیل اجباری است').matches(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/, "ایمیل وارد شده نامعتبر است"),
        PhoneNumber: yup.string().required('وارد کردن شماره همراه اجباری است').matches(/[0][9][0-9][0-9]{8,8}/, "شماره همراه نامعتبر است"),
        Password: yup.string().required('وارد کردن رمز عبور اجباری است').matches(/^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/, "رمز عبور وارد شده ضعیف است").max(100, 'رمز عبور وارد شده طولانی است'),
        ConfirmPassword: yup.string().oneOf([yup.ref("Password")], "رمز عبور های وارد شده یکی نیستند").required('وارد کردن مجدد پسورد اجباری می باشد'),
        Age: yup.number().positive('مقدار وارد شده نامعتبر است').integer('مقدار وارد شده نامعتبر است').required('وارد کردن سن اجباری است').min(7, 'مینیمم سن ۷ می باشد').max(70, 'ماکسیمم سن ۷۰ می باشد')
    }).required();
}