const BASE_URL = "http://localhost:7243/";
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
    const data = await response.json();
    return data;
}
export default callApi;