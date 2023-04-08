import * as yup from 'yup';
import callApi from '../Service/callApi';
export class ManageStudentHelper {

    async getStudents(){
        let token = window.localStorage.getItem("token");
        let result = await callApi("User/GetAllStudents","GET",null,{Authorization:`bearer ${token}`});
        return result;
    }
    async getStudentDetail(id){
        let token = window.localStorage.getItem("token");
        let result  =await callApi(`User/GetStudentDetail?studentId=${id}` , "GET",null ,{Authorization:`bearer ${token}`} );
        return result;
    }
}
