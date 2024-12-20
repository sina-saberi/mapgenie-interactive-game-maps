import { select } from "./base/select";
import { scrap } from "./scrap";


select({
    "scrap": scrap,
    "create-map-config": () => { console.log("create-map call back") },
});