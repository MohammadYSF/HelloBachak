import "./style.css";
import Table from 'react-bootstrap/Table';
import { UseManageStudents } from "./Hook";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import { Student } from "../Student/Index";
import { StudentDetail } from "../Student/StudentDetail/Index";
export const ManageStudents = () => {
    const { data, modalShowState, onClickCloseModal
        , studentModalTitle, onClickDetailStudent , onClickStudentDuties , studentData } = UseManageStudents();
    return (
        <>
            <div className="">
                <div className="container">
                    <h1 className="text-center">مدیریت دانش آموزان</h1>
                    <Table striped variant="dark">
                        <thead>
                            <tr>
                                <th>نام کاربری</th>
                                <th>مقطع فعلی</th>
                                <th>شماره همراه</th>
                                <th>نام مشاورش</th>
                                <th>سن</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {data.map((item, index) => {
                                return (
                                    <tr key={index}>
                                        <td>{item.username}</td>
                                        <td>{item.gradeTitle}</td>
                                        <td>{item.phoneNumber}</td>
                                        <td>{item.consultantTitle}</td>
                                        <td>{item.age}</td>
                                        <td>
                                            <button className="btn btn-danger btn-sm rounded-0">X</button>
                                            <button className="btn btn-info btn-sm rounded-0 ms-2"
                                                onClick={() => {onClickDetailStudent(item.id)}}>جزئیات</button>
                                                <button className="btn btn-warning btn-sm rounded-0 ms-2"
                                                onClick={()=>{onClickStudentDuties(item.id)}}>تغییر مشاور</button>
                                        </td>
                                    </tr>
                                );
                            })}

                        </tbody>
                    </Table>
                    <Modal show={modalShowState} onHide={onClickCloseModal}>
                        <Modal.Header closeButton className="bg-dark text-light">
                            <Modal.Title>{studentModalTitle}</Modal.Title>
                        </Modal.Header>

                        <Modal.Body className="bg-dark text-light">
                            <StudentDetail studentData={studentData}/>
                        </Modal.Body>

                        <Modal.Footer className="bg-dark text-light">
                            <Button className="rounded-0" variant="secondary" onClick={onClickCloseModal}>بستن</Button>
                        </Modal.Footer>
                    </Modal>
                </div>
            </div>
        </>

    );
}