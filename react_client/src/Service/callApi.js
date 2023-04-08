const BASE_URL = "https://localhost:7243/api/";
async function callApi(url, method = 'GET', body = null, headers = {}) {
    const options = {
        method,
        headers: {
            'Content-Type': 'application/json',
            ...headers
        }
    };
    if (body) { options.body = JSON.stringify(body); }
    const response = await fetch(BASE_URL + url, options);

    if (response.status === 401) {
        let token = window.localStorage.getItem("token");
        let refreshToken = window.localStorage.getItem("refreshToken");
        const options2 = {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            }           
        };
        const response2 = await fetch(BASE_URL + `Token/Refresh?token=${token}&refreshToken=${refreshToken}`, options2);
        const j = await response2.json();
        window.localStorage.setItem("token",j.token);
        window.localStorage.setItem("refreshToken",j.refreshToken);
        window.location.reload();
    }
    else if (response.status == 200) {
        return response;
    }
}
export default callApi;
