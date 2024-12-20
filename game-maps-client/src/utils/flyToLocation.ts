import { Map } from 'leaflet';

export const FLY_EVENT_NAME = "open-popup";
const flyToLocation = (id: number) => window.dispatchEvent(new CustomEvent(FLY_EVENT_NAME, {
    detail: id
}))

export default flyToLocation