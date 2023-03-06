import { UseAssignDuty } from "./Hook";
import "./style.css";
export const AssignDuty = () => {
    const { data, setData, handleSubmit, register, errors } = UseAssignDuty();

    return (
        <>
            <div className="bg-info">
                <div className="row">
                    <form onSubmit={handleSubmit((data) => { })} className="container col-12 col-sm-8 col-md-6 col-lg-4" id="assignDutyCard">
                        <h1 className="text-dark text-center">ثبت تکلیف</h1>
                        <div className="row">
                            <div className="col-12">
                                <input {...register("Title")} type={"text"} placeholder="عنوان" className="w-100 inp" />
                                <span className="text-danger errorMessage">{errors.Title?.message}</span>
                            </div>
                            <div className="col-12">
                                <textarea {...register('Description')} cols="30" rows="10" placeholder="توضیحات" className="w-100 inp" />
                                <span className="text-danger errorMessage">{errors.Description?.message}</span>

                            </div>
                            <div className="col-12 row text-center">
                                <div className="col-4">
                                    <input {...register("Day")} type={"number"} defaultValue={''} min={1} max={31} placeholder="روز" className="inp w-100" />
                                    <span className="text-danger errorMessage">{errors.Day?.message}</span>
                                </div>
                                <div className="col-4">
                                    <input {...register("Month")} type={"number"} defaultValue={''} min={1} max={12} placeholder="ماه" className="inp w-100" />
                                    <span className="text-danger errorMessage">{errors.Month?.message}</span>

                                </div>
                                <div className="col-4">
                                    <input {...register("Year")} type={"number"} defaultValue={''} min={1401} max={1405} placeholder="سال" className="inp w-100" />
                                    <span className="text-danger errorMessage">{errors.Year?.message}</span>


                                </div>

                            </div>
                            <div className="col-6 mt-2">
                                <select {...register("LessonId")} class="form-select" aria-label="Default select example">
                                    <option value={0}>انتخاب درس ...</option>
                                    <option value="1">درس ۱</option>
                                    <option value="2">درس ۲</option>
                                    <option value="3">درس ۳</option>
                                </select>
                                <span className="text-danger errorMessage">{errors.LessonId?.message}</span>

                            </div>
                            <div className="col-6 mt-2">
                                <select {...register("StudentId")} class="form-select" aria-label="Default select example">
                                    <option value="0">انتخاب دانش آموز ...</option>
                                    <option value="1">دانش آموز ۱</option>
                                    <option value="2">دانش آموز ۲</option>
                                    <option value="3">دانش آموز ۳</option>
                                </select>
                                <span className="text-danger errorMessage">{errors.StudentId?.message}</span>

                            </div>
                            <div className="col-12">
                                <input type="submit" value={"ثبت"} className="btn btn-info rounded-0 px-5 py-0 mt-3" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>

        </>

    );
}