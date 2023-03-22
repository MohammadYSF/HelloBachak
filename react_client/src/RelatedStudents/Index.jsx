import "./style.css";
import Table from 'react-bootstrap/Table';
import { UseRelatedStudents } from "./Hook";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import { Student } from "../Student/Index";
export const RelatedStudents = () => {
    const { data, modalShowState, onClickCloseModal
        , studentModalTitle, onClickDetailStudent , onClickStudentDuties } = UseRelatedStudents();
    return (
        <>
            <div className="">
                <div className="container">
                    <h1 className="text-center">دانش آموز های شما</h1>
                    <Table striped variant="dark">
                        <thead>
                            <tr>
                                <th>نام کاربری</th>
                                <th>مقطع فعلی</th>
                                <th>شماره همراه</th>
                                <th>سن</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {data.map((item, index) => {
                                return (
                                    <tr key={index}>
                                        <td>{item.Username}</td>
                                        <td>{item.GradeTitle}</td>
                                        <td>{item.PhoneNumber}</td>
                                        <td>{item.Age}</td>
                                        <td>
                                            <button className="btn btn-danger btn-sm rounded-0">X</button>
                                            <button className="btn btn-info btn-sm rounded-0 ms-2"
                                                onClick={onClickDetailStudent}>جزئیات</button>
                                                <button className="btn btn-warning btn-sm rounded-0 ms-2"
                                                onClick={()=>{onClickStudentDuties(item.Id)}}>وظایف</button>
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
                            <Student/>
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