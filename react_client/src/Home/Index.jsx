import { UseUser } from "../Common/UseUser";
import "./style.css";
export const Home = () => {
    const {isUserLoggedIn , username} = UseUser();
    return (
        <>

            <div className="bg-dark" id="home">
                <div className="row text-light text-center">
                    <div className="col-12 pt-5">
                        <h1 className="pt-5">هلو بچک</h1>
                        {isUserLoggedIn && <p className="text-secondary">درود بر تو ، <span className="text-success"><b>{username}</b></span></p>}
                        <div className="text-secondary">
                            <p>ای برادر تو همان اندیشه ای</p>
                            <p>مابقی خود استخوان و ریشه ای</p>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}