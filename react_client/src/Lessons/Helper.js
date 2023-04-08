import * as yup from 'yup';
import callApi from '../Service/callApi';
export class LessonHelper {
    async getLessons(){
        let obj = {};
        let token = window.localStorage.getItem("token");
        return await callApi("Lesson/GetAllLessons","GET",null,{Authorization:`bearer ${token}`});
    }
  
}
