import { UseLogin } from "./Hook";
import "./style.css";
export const Login = () => {
    const { data, setData, handleSubmit, register , errors , myOwnHandleSubmit } = UseLogin();
    return (
        <>
            
            <div className="bg-secondary">
                <div className="row">
                    <form onSubmit={handleSubmit((data) => { myOwnHandleSubmit(data)})} className="container col-12 col-sm-8 col-md-6 col-lg-4" id="registerCard">
                        <h1 className="text-dark text-center">ورود</h1>
                        <div className="row">
                            <div className="col-12">

                                <input {...register("Email")} type={"text"} placeholder="ایمیل" className="w-100 inp" />
                                <span className="text-danger errorMessage">{errors.Email?.message}</span>

                            </div>
                            <div className="col-12">
                                <input {...register("Password")} type="password" placeholder="رمز عبور" className="w-100 inp" />
                                <span className="text-danger errorMessage">{errors.Password?.message}</span>

                            </div>
                            
                            <div className="col-12">
                                <input type="submit" value={"ثبت"} className="btn btn-secondary rounded-0 px-5 py-0 mt-3" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </>
    );
}