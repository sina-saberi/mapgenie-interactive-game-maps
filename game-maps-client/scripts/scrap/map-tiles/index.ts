import { input } from "../../base/input";

interface TileObject {
    url: string;
    z: number;
    x: number;
    y: number;
}

const maxNativeZoom = 5;
const tilesUrlTemplate = "https://kingdomcomemap.github.io/map/{z}_{x}_{y}.jpg";

const generateTileList = () => {
    const tileList: TileObject[] = [];
    for (let z = 1; z <= maxNativeZoom; z++) {
        const maxIndex = Math.pow(2, z) - 1;
        for (let x = 0; x <= maxIndex; x++) {
            for (let y = 0; y <= maxIndex; y++) {
                const url = tilesUrlTemplate.replace('{z}', z.toString()).replace('{x}', x.toString()).replace('{y}', y.toString());
                tileList.push({ url, z, x, y });
            }
        }
    }
    return tileList;
};

export const mapTilerScrap = async () => {
    const tilesUrlTemplate = await input("url template:");
    const listOfTiles = generateTileList();

}