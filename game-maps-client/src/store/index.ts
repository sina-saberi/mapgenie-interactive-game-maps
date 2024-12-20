import { combineReducers, configureStore } from "@reduxjs/toolkit";
import { FLUSH, PAUSE, PERSIST, PURGE, REGISTER, REHYDRATE, persistReducer } from 'redux-persist';
import storage from "redux-persist/lib/storage";
import category from "./category";
import location from "./location";
import user from "./user";
import filters from "./filters";
import application from "./application";
import map from "./map";

const persistConfig = {
    key: 'root',
    storage,
    whitelist: ["filters"]
}

const reducer = persistReducer(persistConfig, combineReducers({
    category,
    location,
    user,
    application,
    filters,
    map
}));

const store = configureStore({
    reducer,
    middleware: (getDefaultMiddleware) => getDefaultMiddleware({
        serializableCheck: {
            ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER],
        },
    })
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
export default store;