import * as yup from 'yup';
import callApi from '../Service/callApi';
export class RelatedStudentsHelper {

   
    async getRelatedStudents(id){
        let token = window.localStorage.getItem("token");
        let result  =await callApi(`User/GetConsultantRelatedStudents?consultantId=${id}` , "GET",null ,{Authorization:`bearer ${token}`} );
        return result;
    }
}
