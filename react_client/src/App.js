import "bootstrap/dist/css/bootstrap.rtl.min.css";
import "vazirmatn/Vazirmatn-font-face.css";
import logo from './logo.svg';
import './App.css';
import { RegisterUser } from './RegisterUser/Index';
import { AssignDuty } from "./AssignDuty/Index";
import { DutyReply } from "./DutyReply/Index";
import { RelatedStudents } from "./RelatedStudents/Index";

function App() {
  return (
    <div className="App">
      {/* <RegisterUser /> */}
      {/* <AssignDuty /> */}
      {/* <DutyReply /> */}
      <RelatedStudents />
    </div>
  );
}

export default App;
