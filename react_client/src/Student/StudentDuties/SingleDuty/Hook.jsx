
export const UseSingleDuty = () => {
    const dutyData = {
        Id: 1,
        Title: "عنوات دیوتی اصلی",
        Description: "توضیحاتی برای دیوتی اصلی",
        ArrangedDateString: "1402/02/02"
    };

    const accordionData = [
        {
            Id: 1,
            Title: "دیوتی تست 1",
            Description: "توضیحات تستی برای دیوتی تستی 1"
        },
        {
            Id: 2,
            Title: "دیوتی تست شماره 2",
            Description: "توضیحات تستی برای دیوتی تستی 2"
        }, {
            Id: 3,
            Title: "دیوتی تست شماره 3",
            Description: "توضیحات تستی برای دیوتی تستی 3"
        },
    ];

    return { dutyData,accordionData };

}