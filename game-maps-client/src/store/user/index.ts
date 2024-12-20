import { isLogin, loginAction, logoutAction } from "@/src/app/actions/authActions";
import { services } from "@/src/services";
import { ILoginDto, IRegisterDto, RegisterDto } from "@/src/services/nswag";
import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";

export type AuthModals = "login" | "register";

export const login = createAsyncThunk("user/login", async (model: ILoginDto) => {
    await loginAction(model);
});

export const logout = createAsyncThunk("user/logout", async () => {
    await logoutAction();
});

export const register = createAsyncThunk("user/register", async (model: IRegisterDto) => {
    return await services.authClient.register(new RegisterDto(model));
});

export const isUserLogin = createAsyncThunk("user/isLogin", async () => {
    return await isLogin();
})

const user = createSlice({
    name: "user",
    initialState: {
        loading: true,
        modal: undefined as undefined | AuthModals,
        isUserLogin: false
    },
    reducers: {
        toggleModal: (state, action: PayloadAction<AuthModals | undefined>) => {
            state.modal = action.payload;
        }
    },

    extraReducers(builder) {
        builder.addCase(logout.fulfilled, (state) => {
            state.modal = undefined;
            state.isUserLogin = false;
            state.loading = false;
        })
        builder.addCase(register.fulfilled, (state) => {
            state.modal = "login";
        });
        builder.addCase(isUserLogin.fulfilled, (state, action) => {
            state.isUserLogin = action.payload;
            state.loading = false;
        });
        builder.addCase(login.fulfilled, (state) => {
            state.modal = undefined;
            state.isUserLogin = true;
            state.loading = false;
        });
    },
});

export const { toggleModal } = user.actions;
export default user.reducer;