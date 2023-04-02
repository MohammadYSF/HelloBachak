import { UseChangeConsultant } from "./Hook";
import { useParams } from "react-router";
// import "./style.css";
export const ChangeConsultant = () => {
    const { id } = useParams();
    const { data, setData, handleSubmit, register , errors , myOwnHandleSubmit , title ,  onClickCancel} = UseChangeConsultant(id);
    return (
        <>
            
            <div className="bg-warning">
                <div className="row">
                    <form onSubmit={handleSubmit((data) => { myOwnHandleSubmit(data)})} className="container col-12 col-sm-8 col-md-6 col-lg-4" id="registerCard">
                        <h1 className="text-dark text-center">تغییر مشاور <span className="text-primary">{title}</span></h1>
                        <div className="row">
                            <div className="col-12">
                            
                            <select {...register("ConsultantId")} className="form-select w-100" aria-label="contaultant id select">
                                    <option value={0}>انتخاب مشاور ...</option>
                                    <option value="1">مشاور ۱</option>
                                    <option value="2">مشاور ۲</option>
                                    <option value="3">مشاور ۳</option>
                                </select>
                                <span className="text-danger errorMessage">{errors.ConsultantId?.message}</span>
                            </div>
                            <div className="col-12">
                                <input type="submit" value={"ثبت"} className="btn btn-primary rounded-0 px-5 py-0 mt-3" />
                                <input type="button" onClick={onClickCancel} value={"انصراف"} className="btn btn-secondary mx-2 rounded-0 px-5 py-0 mt-3" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </>
    );
}