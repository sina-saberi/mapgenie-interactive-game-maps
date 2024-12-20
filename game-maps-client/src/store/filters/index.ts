import { CheckedFilter } from "@/src/models/CheckedFilter";
import { services } from "@/src/services";
import { GroupedCategoryDto, LocationSearchDto } from "@/src/services/nswag";
import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";

interface SearchForLocaitons {
    gameSlug: string;
    slug: string;
    search: string;
}

export const searchForLocaitons = createAsyncThunk("filter/search", async ({ gameSlug, search, slug }: SearchForLocaitons) => {
    if (search === "") return [];
    return await services.locationClient.search(gameSlug, slug, search);
});

const filters = createSlice({
    name: "filters",
    initialState: {
        search: "",
        checkedFilter: CheckedFilter.showAll,
        categories: [] as number[],
        searchResult: [] as LocationSearchDto[]
    },
    reducers: {

        toggleCategorieInFilter: (state, action: PayloadAction<number>) => {
            const categoryId = action.payload;
            const index = state.categories.indexOf(categoryId);
            index !== -1 ? state.categories.splice(index, 1) : state.categories.push(categoryId);
        },
        setFiltersChecked: (state) => {
            const states = Object.values(CheckedFilter).filter(x => !isNaN(Number(x)))
            const currentIndex = state.checkedFilter as number;
            state.checkedFilter = states[(currentIndex + 1) % 3] as any;
        },
        toggleAllCategories: (state, action: PayloadAction<GroupedCategoryDto[]>) => {
            const arr: number[] = [];

            if (state.categories.length <= 0) {
                action.payload.forEach(x => {
                    x.categories?.forEach(({ id }) => {
                        arr.push(id);
                    })
                });
            }

            state.categories = arr;
        }
    },

    extraReducers: (builder) => {
        builder.addCase(searchForLocaitons.pending, (state, action) => {
            state.search = action.meta.arg.search;
        });
        builder.addCase(searchForLocaitons.fulfilled, (state, action) => {
            state.searchResult = action.payload;
        });
    }
});

export const { setFiltersChecked, toggleCategorieInFilter, toggleAllCategories } = filters.actions;
export default filters.reducer