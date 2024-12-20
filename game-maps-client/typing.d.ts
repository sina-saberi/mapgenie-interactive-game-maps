import * as L from 'leaflet';
import type { Container } from 'pixi.js';

declare module 'leaflet' {
    function pixiOverlay(callBack: (utils: any) => void, Container: Container<ContainerChild>): SetStateAction<any>;
}

