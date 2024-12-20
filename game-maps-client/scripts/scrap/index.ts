import { select } from "../base/select"
import { mapTilerScrap } from "./map-tiles"

export const scrap = () => {
    select({
        "map-tiles": mapTilerScrap
    })
}