import callApi from "../../Service/callApi";
export class StudentDutiesHelper {

    static async FindStudentName(id){
        let token = window.localStorage.getItem("token");
        let result  =await callApi(`User/FindStudentName?studentId=${id}` , "GET",null ,{Authorization:`bearer ${token}`} );
        return result;
    }
    static FindDutyDescription(id){
        return "ما با گروه گردنه مه‌آلود رفتیم که برنامه ریزی فوق العاده ای داشتن. در مسیرهایی که دوچرخه سواری مناسبش نبود (مثلا به خاطر تنگی و یکنواختی و شلوغی خیابون ماشین رو از یک شهر تا یک منطقه دور افتاده) رو با مینی بوس (و دوچرخه ها در کامیون پشت سر) می‌رفتیم و بعد چند روز در منطقه زیبایی رکاب می‌زدیم تا مثلا از یه کوه بالا بریم، برسیم به یه منطقه کاملا عشایری و یک شب در یورت بخوابیم و بعد با دو روز رکاب زدن برسیم به یه ریزورت برای یک روز استراحت قبل از رفتن به دشت و رسیدن به شهر بعدی. این باعث می‌شد برنامه در عین سنگین بودن (مثلا رکاب زدن‌های ۸۰ کیلومتر در روز و ارتفاع گرفتن های ۲۰۰۰ متری) بسیار لذت بخش باشه";
    }
    static async GetRelatedStudentDuties(id){
        let token = window.localStorage.getItem("token");
        let result  =await callApi(`Duty/GetRelatedStudentDuties?studentId=${id}` , "GET",null ,{Authorization:`bearer ${token}`} );
        return result;
    }
}