import { useState } from "react";
import { UseStudentDuties } from "./Hook";
import { useParams } from "react-router";
import Table from 'react-bootstrap/Table';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';

export const StudentDuties = () => {
    const { id } = useParams();
    const { data, modalShowState, onClickCloseModal
        , modalTitle, onClickDetailDuty, studentName , dutyDescription} = UseStudentDuties(id);
    return (

        <>
            <div>
                <div className="container">
                <h1>وظایف {studentName}</h1>
                <Table striped variant="dark">
                    <thead>
                        <tr>
                            <th>وظیفه</th>
                            <th>تاریخ تحویل</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {data.map((item, index) => {
                            return (
                                <tr key={index}>
                                    <td>{item.Title}</td>
                                    <td>{item.ArrangedDate}</td>
                                    <td>
                                        <button className="btn btn-danger btn-sm rounded-0">X</button>
                                        <button className="btn btn-info btn-sm rounded-0 ms-2"
                                            onClick={onClickDetailDuty}>توضیحات</button>
                                    </td>
                                </tr>
                            );
                        })}

                    </tbody>
                </Table>
                <Modal show={modalShowState} onHide={onClickCloseModal}>
                        <Modal.Header closeButton className="bg-dark text-light">
                            <Modal.Title>{modalTitle}</Modal.Title>
                        </Modal.Header>

                        <Modal.Body className="bg-dark text-light">
                            {dutyDescription}
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