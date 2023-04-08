import { useForm } from "react-hook-form";
import { useEffect, useState } from "react";
import { yupResolver } from "@hookform/resolvers/yup"
import { DutyReplyHelper, LessonHelper } from "./Helper";
import { useNavigate } from 'react-router-dom';

export const UseLessons = () => {
    const navigate = useNavigate();

    const [data, setData] = useState([]);
    useEffect(() => {
        new LessonHelper().getLessons().then(async d => {
            if (d.status === 200) {
                const j = await d.json();
                setData(j);
            }
        })
    }, []);
    const onClickEditLesson = (id) => {
        navigate(`/Lessons/${id}`);
    }
    return (
        { data, onClickEditLesson }
    );
}