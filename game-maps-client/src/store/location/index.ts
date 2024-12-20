import { services } from "@/src/services";
import { ILocationCateogryDto, ILocationDetailDto, ILocationDto, LocationDto } from "@/src/services/nswag";
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { getMapDetailAndChildrens } from "../map";
import { ApplicationLocationDto } from "@/src/models/ApplicationLocationDto";


interface ToggleLocationProps {
    id: number;
    categoryId: number
}
export const toggleLocation = createAsyncThunk("location/toggleLocation", async ({ id }: ToggleLocationProps) => {
    return await services.locationClient.toggle(id);
});
export const getLocation = createAsyncThunk("location/getLocation", async (id: number) => {
    return await services.locationClient.locationDetail(id);
});

const location = createSlice({
    name: "location",
    initialState: {
        locations: [] as ApplicationLocationDto[],
        images: {} as Record<string, string>,
        detail: undefined as ILocationDetailDto | undefined,
    },
    reducers: {},
    extraReducers(builder) {
        builder.addCase(getMapDetailAndChildrens.fulfilled, (state, action) => {
            state.locations = action.payload.locationAndIcons.locations;
            state.images = action.payload.locationAndIcons.images;
        });
        builder.addCase(getLocation.fulfilled, (state, action) => {
            state.detail = action.payload;
        });
        builder.addCase(toggleLocation.pending, (state, action) => ({
            ...state,
            locations: state.locations.map(x => {
                if (action.meta.arg.id === x.id) {
                    return {
                        ...x,
                        checked: !x.checked
                    }
                }
                return x
            })
        }));
        builder.addCase(toggleLocation.rejected, (state, action) => ({
            ...state,
            locations: state.locations.map(x => {
                if (action.meta.arg.id === x.id) {
                    return {
                        ...x,
                        checked: !x.checked
                    }
                }
                return x
            })
        }));
    },
});

export default location.reducer;