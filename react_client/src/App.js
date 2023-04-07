import "bootstrap/dist/css/bootstrap.rtl.min.css";
import "vazirmatn/Vazirmatn-font-face.css";
import logo from './logo.svg';
import './App.css';
import { RegisterUser } from './RegisterUser/Index';
import { AssignDuty } from "./AssignDuty/Index";
import { DutyReply } from "./DutyReply/Index";
import { RelatedStudents } from "./RelatedStudents/Index";
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import Container from 'react-bootstrap/Container';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { NavLink } from "react-router-dom";
import { StudentDuties } from "./Student/StudentDuties/Index";
import { Login } from "./Login/Index";
import { Lessons } from "./Lessons/Index";
import { LessonEdit } from "./Lessons/LessonEdit/Index";
import { Home } from "./Home/Index";
import { SingleDuty } from "./Student/StudentDuties/SingleDuty/Index";
import { ManageStudents } from "./ManageStudents/Index";
import { ChangeConsultant } from "./ManageStudents/ChangeConsultant/Index";
import { UseUser } from "./Common/UseUser";
function App() {
  const { isUserLoggedIn, username } = UseUser();
  return (
    <>

      <BrowserRouter>
        <div className="App">
          <Navbar bg="dark" variant="dark">
            <Container>
              <NavLink className={"navbar-brand"} to="/">هلو بچک</NavLink>
              <Nav className="me-auto">
                <NavLink className={"nav-link"} to={"/"}>خانه</NavLink>
                {!isUserLoggedIn && <><Nav.Item><NavLink className={"nav-link"} to={"/RegisterUser"}>ثبت نام</NavLink></Nav.Item>
                  <Nav.Item><NavLink className={"nav-link"} to={"/Login"}>ورود</NavLink></Nav.Item></>}
                <Nav.Item><NavLink className={"nav-link"} to={"/AssignDuty"}>ثبت وظیفه</NavLink></Nav.Item>
                <Nav.Item><NavLink className={"nav-link"} to={"/DutyReply"}>ثبت بازخورد</NavLink></Nav.Item>
                <Nav.Item><NavLink className={"nav-link"} to={"/RelatedStudents"}>دانش آموز ها</NavLink></Nav.Item>
                <Nav.Item><NavLink className={"nav-link"} to={"/Lessons"}>درس های تعریف شده</NavLink></Nav.Item>
                <Nav.Item><NavLink className={"nav-link"} to={"/ManageStudents"}>مدیریت دانش آموزان</NavLink></Nav.Item>
                {isUserLoggedIn && <Nav.Item><NavLink className={"nav-link text-danger"} to={"/SignOut"}>خروج</NavLink></Nav.Item>}
              </Nav>
            </Container>
          </Navbar>
        </div>


        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/RegisterUser" element={<RegisterUser />} />
          <Route path="/AssignDuty" element={<AssignDuty />} />
          <Route path="/DutyReply" element={<DutyReply />} />
          <Route path="/RelatedStudents" element={<RelatedStudents />} />
          <Route path="/Students/:id/Duties" element={<StudentDuties />} />
          <Route path="/Login" element={<Login />} />
          <Route path="/Lessons" element={<Lessons />} />
          <Route path="/Lessons/:id" element={<LessonEdit />} />
          <Route path="/Duties/:id" element={<SingleDuty />} />
          <Route path="/ManageStudents" element={<ManageStudents />} />
          <Route path="ManageStudents/:id/ChangeConsultant" element={<ChangeConsultant />} />
        </Routes>
      </BrowserRouter>

    </>

  );
}

export default App;
