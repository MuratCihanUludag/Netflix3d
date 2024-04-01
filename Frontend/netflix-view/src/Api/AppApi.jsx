import axios from "axios";


const AppApi = ()=>{
    const api = axios.create({
        baseURL:"https://localhost:7091/",
        headers:{
            Authorization: `Bearer ${sessionStorage.getItem("key") ?? null}`,
        }
    });
}