import { UseRegisterForm } from "./Hook";
import "./style.css";
import Toast from 'react-bootstrap/Toast';
import ToastContainer from 'react-bootstrap/ToastContainer';
export const RegisterUser = () => {
    const { data, setData, handleSubmit, register, errors, myOwnHandleSubmit , toastShow ,onCloseToast } = UseRegisterForm();
    return (
        <>

            <div className="bg-primary">
                <div className="row">
                    <form onSubmit={handleSubmit((data) => { myOwnHandleSubmit(data) })} className="container col-12 col-sm-8 col-md-6 col-lg-4" id="registerCard">
                        <h1 className="text-dark text-center">ثبت کاربر</h1>
                        <div className="row">
                            <div className="col-6">
                                <input {...register("Username")} type={"text"} placeholder="نام کاربری" className="w-100 inp" />
                                <span className="text-danger errorMessage">{errors.Username?.message}</span>
                            </div>
                            <div className="col-6">
                                <input {...register("Age")} type={"number"} defaultValue={16} placeholder="سن" className="w-100 inp" />
                                <span className="text-danger errorMessage">{errors.Age?.message}</span>

                            </div>
                            <div className="col-12">

                                <input {...register("Email")} type={"text"} placeholder="ایمیل" className="w-100 inp" />
                                <span className="text-danger errorMessage">{errors.Email?.message}</span>

                            </div>
                            <div className="col-12">
                                <input {...register("PhoneNumber")} type={"tel"} placeholder="شماره همراه" className="w-100 inp" />
                                <span className="text-danger errorMessage">{errors.PhoneNumber?.message}</span>

                            </div>
                            <div className="col-12">
                                <input {...register("Password")} type="password" placeholder="رمز عبور" className="w-100 inp" />
                                <span className="text-danger errorMessage">{errors.Password?.message}</span>

                            </div>
                            <div className="col-12">
                                <input {...register("ConfirmPassword")} type="password" placeholder="تکرار پسورد" className="w-100 inp" />
                                <span className="text-danger errorMessage">{errors.ConfirmPassword?.message}</span>

                            </div>
                            <div className="col-12">
                                <input type="submit" value={"ثبت"} className="btn btn-primary rounded-0 px-5 py-0 mt-3" />
                            </div>
                        </div>
                    </form>



                    <ToastContainer className="p-3" position={"bottom-end"}>
                        <Toast onClose={onCloseToast} show={toastShow} delay={10000} animation={true} autohide={true}>
                            <Toast.Header  closeButton={false}>
                                <strong className="me-auto">پیغام !</strong>
                            </Toast.Header>
                            <Toast.Body>جهت تکمیل ثبت نام ، به حساب ایمیل خود رفته و روی لینک فعالسازی حساب کلیک کنید</Toast.Body>
                        </Toast>
                    </ToastContainer>
                </div>
            </div>
        </>
    );
}