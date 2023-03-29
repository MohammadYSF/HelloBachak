import { UseEditLesson } from "./Hook";
import { useParams } from "react-router";
import "./style.css";
export const LessonEdit = () => {
    const { id } = useParams();
    const { data, setData, handleSubmit, register , errors , myOwnHandleSubmit , title } = UseEditLesson(id);
    return (
        <>
            
            <div className="bg-warning">
                <div className="row">
                    <form onSubmit={handleSubmit((data) => { myOwnHandleSubmit(data)})} className="container col-12 col-sm-8 col-md-6 col-lg-4" id="registerCard">
                        <h1 className="text-dark text-center">ویرایش درس : <span className="text-primary">{title}</span></h1>
                        <div className="row">
                            <div className="col-12">

                                <input {...register("Title")} type={"text"} placeholder="نام درس" className="w-100 inp" />
                                <span className="text-danger errorMessage">{errors.Title?.message}</span>

                            </div>
                            <div className="col-12">
                                <input type="submit" value={"ثبت"} className="btn btn-primary rounded-0 px-5 py-0 mt-3" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </>
    );
}