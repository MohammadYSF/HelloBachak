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
function App() {
  return (
    <>

      <BrowserRouter>
        <div className="App">
          <Navbar bg="dark" variant="dark">
            <Container>
              <NavLink className={"navbar-brand"} to="/">Hello Bachak</NavLink>
              <Nav className="me-auto">
                <NavLink className={"nav-link"} to={"/"}>Home</NavLink>
                <Nav.Item><NavLink className={"nav-link"} to={"/RegisterUser"}>RegisterUser</NavLink></Nav.Item>
                <Nav.Item><NavLink className={"nav-link"} to={"/Login"}>Login</NavLink></Nav.Item>
                <Nav.Item><NavLink className={"nav-link"} to={"/AssignDuty"}>AssignDuty</NavLink></Nav.Item>
                <Nav.Item><NavLink className={"nav-link"} to={"/DutyReply"}>DutyReply</NavLink></Nav.Item>
                <Nav.Item><NavLink className={"nav-link"} to={"/RelatedStudents"}>RelatedStudents</NavLink></Nav.Item>
              </Nav>
            </Container>
          </Navbar>
        </div>

        
        <Routes>
          <Route path="/RegisterUser" element={<RegisterUser />} />
          <Route path="/AssignDuty" element={<AssignDuty />} />
          <Route path="/DutyReply" element={<DutyReply />} />
          <Route path="/RelatedStudents" element={<RelatedStudents />} />
          <Route path="/Students/:id/Duties" element={<StudentDuties />} />
          <Route path="/Login" element={<Login />} />
        </Routes>
      </BrowserRouter>

    </>

  );
}

export default App;
