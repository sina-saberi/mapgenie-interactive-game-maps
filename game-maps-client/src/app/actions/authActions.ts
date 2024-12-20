"use server"
import { services } from "@/src/services";
import { ILoginDto, LoginDto } from "@/src/services/nswag";
import { ResponseCookie } from "next/dist/compiled/@edge-runtime/cookies";
import { cookies } from "next/headers"

const cookieSetting = {
    key: "game-maps-access-token",
    options: {
        path: "/",
        httpOnly: true,
        sameSite: "lax",
    } as ResponseCookie
}

export const loginAction = async (model: ILoginDto) => {
    const result = await services.authClient.login(new LoginDto(model));
    if (result.accessToken) {
        const expirationDate = new Date(result.expiration);
        const cookie = cookies();
        cookie.set(cookieSetting.key, result.accessToken, {
            expires: expirationDate,
            ...cookieSetting.options
        });
    }
}

export const logoutAction = async () => {
    const cookie = cookies();
    cookie.delete(cookieSetting.key);
}

export const getToken = async () => {
    const cookie = cookies();
    return cookie.get(cookieSetting.key)?.value;
}

export const isLogin = async () => {
    const cookie = cookies();
    return !!cookie.get(cookieSetting.key)?.value;
}