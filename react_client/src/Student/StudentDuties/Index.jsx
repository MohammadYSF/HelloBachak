import { useState } from "react";
import { UseStudentDuties } from "./Hook";
import { useParams } from "react-router";
import Table from 'react-bootstrap/Table';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';

export const StudentDuties = () => {
    const { id } = useParams();
    const { data,
         onClickDetailDuty, studentName} = UseStudentDuties(id);
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
                            <th>انجام داده؟</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {data.map((item, index) => {
                            return (
                                <tr key={index}>
                                    <td>{item.title}</td>
                                    <td>{item.arrangedDateString}</td>
                                    <td>{item.isSucceedTitle}</td>
                                    <td>
                                        <button className="btn btn-danger btn-sm rounded-0">X</button>
                                            <button className="btn btn-light btn-sm rounded-0 ms-2"
                                            onClick={() => onClickDetailDuty(item.id)}>مشاهده</button>
                                    </td>
                                </tr>
                            );
                        })}

                    </tbody>
                </Table>
           
            </div>
        </div>
        </>
    );
}