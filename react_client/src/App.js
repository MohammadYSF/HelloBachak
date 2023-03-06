import "bootstrap/dist/css/bootstrap.rtl.min.css";
import "vazirmatn/Vazirmatn-font-face.css";
import logo from './logo.svg';
import './App.css';
import { RegisterUser } from './RegisterUser/Index';
import { AssignDuty } from "./AssignDuty/Index";

function App() {
  return (
    <div className="App">
      {/* <RegisterUser /> */}
      <AssignDuty />
    </div>
  );
}

export default App;
