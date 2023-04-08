import "./style.css";
import Table from 'react-bootstrap/Table';
import { UseLessons } from "./Hook";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import { Student } from "../Student/Index";
export const Lessons = () => {
    const { data, onClickEditLesson } = UseLessons();
    return (
        <>
            <div className="">
                <div className="container">
                    <h1 className="text-center">فهرست درس ها</h1>
                    <Table striped variant="dark w-25 mx-auto">
                        <thead>
                            <tr>
                                <th>نام</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {data.map((item, index) => {
                                return (
                                    <tr key={index}>
                                        <td>{item.title}</td>
                                        <td>
                                            <button className="btn btn-danger btn-sm rounded-0">X</button>                                            
                                                <button className="btn btn-warning btn-sm rounded-0 ms-2"
                                                onClick={()=>{onClickEditLesson(item.id)}}>ویرایش</button>
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