import { UseDutyReply } from "./Hook";
import "./style.css";
export const DutyReply = () => {
    const { data, setData, handleSubmit, register, errors, myOwnHandleSubmit
        , onChangeDayInput, onChangeMonthInput, numberOfDaysOfMonth, maxMonthNumber } = UseDutyReply();

    return (
        <>
            <div className="bg-danger">
                <div className="row">
                    <form onSubmit={handleSubmit((data) => { console.log(data) })} className="container col-12 col-sm-8 col-md-6 col-lg-4" id="assignDutyCard">
                        <h1 className="text-dark text-center">ثبت تکلیف</h1>
                        <h2 className="text-dark text-center mb-5">تحویل تکلیف : <span className="text-danger">تکلیف شماره ۱</span></h2>
                        <div className="row">
                            <div className="col-12">
                                <label className="isSuccessLabel">به طور کلی انجامش دادی ؟</label>
                                <input {...register("IsSucceed")} className="form-check-input" type="radio" value={true} />                                <label className="form-check-label ml-5" htmlFor="isSuccess1">
                                    آره
                                </label>

                                <input {...register("IsSucceed")} className="form-check-input" type="radio" value={false} />                                <label className="form-check-label" htmlFor="isSuccess2">
                                    نه
                                </label>
                                <p>
                                    <span className="text-danger errorMessage">{errors.IsFailed?.message}</span>
                                    <span className="text-danger errorMessage">{errors.IsSucceed?.message}</span>
                                </p>
                            </div>
                            <div className="col-12">
                                <textarea {...register('Description')} cols="30" rows="10" placeholder="توضیحات" className="w-100 inp" />
                                <span className="text-danger errorMessage">{errors.Description?.message}</span>

                            </div>

                            <div className="col-12">
                                <input type="submit" value={"ثبت"} className="btn btn-danger rounded-0 px-5 py-0 mt-3" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>

        </>

    );
}