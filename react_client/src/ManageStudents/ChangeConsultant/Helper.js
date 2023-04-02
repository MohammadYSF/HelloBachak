import * as yup from 'yup';
export class ChangeConsultantHelper {

    static FindUsernameById(id) {
        return "شمس الله";
    }

    static schema = yup.object({
        ConsultantId: yup.number().min(1, 'انتخاب مشاور اجباری است'),
    }).required();
}