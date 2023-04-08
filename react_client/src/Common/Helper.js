import callApi from '../Service/callApi';
export class UserHelper{
    async signOut(token){
        let obj={};        
        return callApi("Token/Revoke","POST",obj,{Authorization:`bearer ${token}`});              
    }
}