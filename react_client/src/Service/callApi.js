const BASE_URL = "https://localhost:7243/api/";
async function callApi(url , method='GET',body=null,headers={}){
    const options = {
        method,
        headers : {
            'Content-Type':'application/json',
            ...headers
        }
    };
    if (body){options.body = JSON.stringify(body);}
    const response = await fetch(BASE_URL + url , options);
    return response;
}
export default callApi;
