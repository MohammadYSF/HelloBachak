import "./style.css";
import Table from 'react-bootstrap/Table';
import { UseRelatedStudents } from "./Hook";
export const RelatedStudents = () => {
    const { data } = UseRelatedStudents();
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
                                            <button className="btn btn-warning btn-sm rounded-0 ms-2">E</button>
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