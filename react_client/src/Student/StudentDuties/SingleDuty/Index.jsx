import { UseSingleDuty } from "./Hook";
import Accordion from 'react-bootstrap/Accordion';
import { useParams } from "react-router";
export const SingleDuty = () => {
    const { id } = useParams();
    const { dutyData, accordionData } = UseSingleDuty();

    return (
        <>
            <div className="bg-secondary">
                <div className="container w-50 pt-5">
                    <Accordion>
                        {accordionData.map(item => <Accordion.Item eventKey={item.Id} key={item.Id}>
                            <Accordion.Header>{item.Title}</Accordion.Header>
                            <Accordion.Body>
                                {item.Description}
                            </Accordion.Body>
                        </Accordion.Item>)}

                    </Accordion>
                    <br />
                    <br />
                    <div className="text-center text-light">
                        <h1 className="h1">{dutyData.Title}</h1>
                        <br />
                        <p className="text-warning">توضیحات :‌<span className="text-light ms-3 span-detail">{dutyData.Description}</span></p>
                        <p className="text-warning">تاریخ تحویل :‌<span className="text-light ms-3 span-detail">{dutyData.ArrangedDateString}</span></p>
                    </div>
                </div>
            </div>
        </>
    );
}