import { ApplicationLocationDto } from "@/src/models/ApplicationLocationDto";
import { services } from "@/src/services";
import { LocationCateogryDto, LocationDto, MapDetailDto, MapDto } from "@/src/services/nswag";
import convertIconsToBase64Obj from "@/src/utils/convertIconsToBase64";
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { MarkerPropsPixiOverlay } from "react-leaflet-pixi-overlay";


interface GetMapDetailAndChildrensProps {
    gameSlug: string;
    mapSlug: string;
}


interface LocationCateogryDtoToLocationResult {
    images: Record<string, string>
    locations: ApplicationLocationDto[]
}
export const locationCateogryDtoToLocation = async (slug: string, data: Promise<LocationCateogryDto[]>) => {
    const result = await data;
    const locations = result.reduce((p, c) => {
        if (c.locations) {
            c.locations.forEach(x => {
                p.push({
                    ...x,
                    icon: c.icon,
                    categoryId: c.id
                })
            })
        }
        return p;
    }, [] as ApplicationLocationDto[])

    const obj = await convertIconsToBase64Obj(slug, locations.map(x => x.icon));

    return {
        locations,
        images: obj
    };
}

export const getMapDetailAndChildrens = createAsyncThunk("getMapDetailAndChildrens", async ({ gameSlug, mapSlug }: GetMapDetailAndChildrensProps) => {
    const maps = await services.mapClient.map2(gameSlug);
    const map = await services.mapClient.detail(gameSlug, mapSlug);
    const group = await services.categoryClient.category(gameSlug, mapSlug);
    const locationAndIcons: LocationCateogryDtoToLocationResult = await locationCateogryDtoToLocation(gameSlug, services.locationClient.location(gameSlug, mapSlug));
    return { map, group, locationAndIcons, maps };
});


const map = createSlice({
    name: "map",
    initialState: {
        maps: undefined as MapDto[] | undefined,
        detail: undefined as undefined | MapDetailDto
    },
    reducers: {

    },
    extraReducers(builder) {
        builder.addCase(getMapDetailAndChildrens.fulfilled, (state, action) => {
            state.detail = action.payload.map;
            state.maps = action.payload.maps
        })
    },
});

export default map.reducer;