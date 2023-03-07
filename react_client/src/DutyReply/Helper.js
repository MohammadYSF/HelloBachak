import * as yup from 'yup';
export class DutyReplyHelper {

    static schema = yup.object({
        Description: yup.string().required('وارد کردن توضیحات اجباری است'),
        IsSucceed:yup.bool().nonNullable("مشخص کردن وضعیت اجباری است")

    });
}