import Axios from "axios";
import { getToken } from "../app/actions/authActions";

export const axios = Axios.create({
    baseURL: process.env.NEXT_PUBLIC_API_URL,
});

axios.interceptors.request.use(async x => {
    const token = await getToken();
    if (token) x.headers.Authorization = `Bearer ${token}`;
    return x
});