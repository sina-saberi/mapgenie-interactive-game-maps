import { createSlice, PayloadAction } from "@reduxjs/toolkit";

const application = createSlice({
    name: "application",
    initialState: {
        sidbar: false,
    },
    reducers: {
        toggleSideBar: (state, action: PayloadAction<boolean | undefined>) => {
            state.sidbar = !!action.payload;
        }
    }
});

export const { toggleSideBar } = application.actions;
export default application.reducer;