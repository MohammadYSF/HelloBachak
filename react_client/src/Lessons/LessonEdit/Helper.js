import callApi from "../../Service/callApi";
export class EditLessonHelper {

    static async FindLessonById(id) {
        let token = window.localStorage.getItem("token");
        let result = await callApi(`Lesson/FindLesson?lessonId=${id}`,"GET",null,{Authorization:`bearer ${token}`});
        return result;
    }
}