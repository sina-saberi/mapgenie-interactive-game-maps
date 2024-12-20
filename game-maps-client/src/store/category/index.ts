import { SideBarDto } from "@/src/services/nswag";
import { createSlice } from "@reduxjs/toolkit";
import { toggleLocation } from "../location";
import { getMapDetailAndChildrens } from "../map";


const category = createSlice({
    name: "category",
    initialState: {
        checkedCount: 0,
        locationCount: 0
    } as SideBarDto,
    reducers: {

    },
    extraReducers(builder) {
        builder.addCase(getMapDetailAndChildrens.fulfilled, (state, action) => {
            state.checkedCount = action.payload.group.checkedCount;
            state.locationCount = action.payload.group.locationCount;
            state.groups = action.payload.group.groups;
        })
        builder.addCase(toggleLocation.fulfilled, (state, action) => {
            const valueIncOrDec = (num: number) => action.payload ? num + 1 : num - 1;

            state.checkedCount = valueIncOrDec(state.checkedCount);
            state.groups = state.groups?.map(x => ({
                ...x,
                categories: x.categories?.map(c => ({
                    ...c,
                    checkedCount: (c.id === action.meta.arg.categoryId) ? valueIncOrDec(c.checkedCount) : c.checkedCount
                }))
            }))
        });
    },
});

export default category.reducer;