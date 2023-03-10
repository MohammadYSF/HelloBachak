import { StudentDetail } from "./StudentDetail/Index";

export const Student = ({mode}) => {
    //mode is either "edit" or "detail"
    return (
        <>
            {mode == "detail"?<StudentDetail /> : <h1>Edit mode</h1>}
            
        </>
    );
}