import * as yup from 'yup';
import callApi from '../Service/callApi';
export class LoginHelper {

    static schema = yup.object({
        Email: yup.string().email('ایمیل وارد شده نامعتبر است').required('وارد کردن ایمیل اجباری است').matches(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/, "ایمیل وارد شده نامعتبر است"),
        Password: yup.string().required('وارد کردن رمز عبور اجباری است')
    }).required();
    async login(email , password){
        let obj={email:email,password:password};
        let token = window.localStorage.getItem("token");
        let result = await callApi("User/Login","POST",obj,{Authorization:`bearer ${token}`});
        return result;
    }
}
