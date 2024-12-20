import { axios } from "./axios";
import { MapClient, GameClient, CategoryClient, LocationClient, AuthClient } from "./nswag";

export const services = {
    mapClient: new MapClient(undefined, axios),
    gameClient: new GameClient(undefined, axios),
    categoryClient: new CategoryClient(undefined, axios),
    locationClient: new LocationClient(undefined, axios),
    authClient: new AuthClient(undefined, axios),
}