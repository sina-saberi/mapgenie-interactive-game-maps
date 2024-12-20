
import { useEffect, useState } from "react";
//leaflet
import L from "leaflet";

//pixi-overlay
import * as PIXI from "pixi.js";
import "leaflet-pixi-overlay";

// react-leaflet
import { useMap } from "react-leaflet";

PIXI.settings.FAIL_IF_MAJOR_PERFORMANCE_CAVEAT = false;
PIXI.utils.skipHello();
const PIXILoader = PIXI.Loader.shared;

export interface MarkerPropsPixiOverlay {
    disabled?: boolean
    id: string | number;
    opacity?: number;
    position: [number, number];
    iconColor?: string;
    popup?: string;
    popupOpen?: boolean;
    onClick?: (id?: any) => void;
    tooltip?: string;
    customIcon?: string;
    iconId?: string;
    markerSpriteAnchor?: [number, number];
    tooltipOptions?: any
    angle?: any
}


interface PixiOverlayProps {
    markers: MarkerPropsPixiOverlay[]
}

const PixiOverlay = ({ markers }: PixiOverlayProps) => {
    const [openedPopupData, setOpenedPopupData] = useState<any>(null);
    const [openedTooltipData, setOpenedTooltipData] = useState<any>(null);

    const [openedPopup, setOpenedPopup] = useState<any>(null);
    const [openedTooltip, setOpenedTooltip] = useState<any>(null);

    const [pixiOverlay, setPixiOverlay] = useState<any>(null);
    const [loaded, setLoaded] = useState<any>(false);
    const map = useMap();

    if (map.getZoom() === undefined) {
        // this if statment is to avoid getContainer error
        // map must have zoom prop
        console.error(
            "no zoom found, add zoom prop to map to avoid getContainer error",
        );
        return null;
    }

    // load sprites
    useEffect(() => {
        // cancel loading if already loading as it may cause: Error: Cannot add resources while the loader is running.
        if (PIXILoader.loading) {
            PIXILoader.reset();
        }

        let loadingAny = false;
        for (let marker of markers) {
            const resolvedMarkerId = marker.iconId || marker.iconColor;

            // skip if no ID or already cached
            if (
                (!marker.iconColor && !marker.iconId) ||
                PIXILoader.resources[`marker_${resolvedMarkerId}`]
            ) {
                continue;
            }
            loadingAny = true;

            PIXILoader.add(
                `marker_${resolvedMarkerId}`,
                marker.customIcon
                    ? marker.customIcon
                    : getDefaultIcon(marker.iconColor),
            );
        }
        if (loaded && loadingAny) {
            setLoaded(false);
        }

        if (loadingAny) {
            PIXILoader.load(() => setLoaded(true));
        } else {
            setLoaded(true);
        }
    }, [markers]);

    // load pixi when map changes
    useEffect(() => {
        let pixiContainer = new PIXI.Container();
        const draw = () => {
            let overlay = L.pixiOverlay((utils) => {
                // redraw markers
                const scale = utils.getScale();
                utils
                    .getContainer()
                    .children.forEach((child: any) => child.scale.set(1 / scale));

                utils.getRenderer().render(utils.getContainer());
            }, pixiContainer);
            overlay.addTo(map);

            setPixiOverlay(overlay);
            setOpenedPopupData(null);
            setOpenedTooltipData(null);
        }

        draw();


        return () => {
            pixiContainer.removeChildren();
        }
    }, [map]);

    // draw markers first time in new container
    useEffect(() => {
        if (pixiOverlay && markers && loaded) {
            const utils = pixiOverlay.utils;
            let container = utils.getContainer();
            let renderer = utils.getRenderer();
            let project = utils.latLngToLayerPoint;
            let scale = utils.getScale();

            markers.forEach((marker) => {
                const {
                    id,
                    iconColor,
                    iconId,
                    onClick,
                    position,
                    popup,
                    tooltip,
                    tooltipOptions,
                    popupOpen,
                    markerSpriteAnchor,
                    disabled,
                    angle,
                    opacity
                } = marker;

                const resolvedIconId = iconId || iconColor;

                if (
                    !PIXILoader.resources[`marker_${resolvedIconId}`] ||
                    !PIXILoader.resources[`marker_${resolvedIconId}`].texture
                ) {
                    return;
                }

                const markerTexture =
                    PIXILoader.resources[`marker_${resolvedIconId}`].texture as any;
                //const markerTexture = new PIXI.Texture.fromImage(url);

                markerTexture.anchor = { x: 0.5, y: 1 };

                const markerSprite = PIXI.Sprite.from(markerTexture);
                if (markerSpriteAnchor) {
                    markerSprite.anchor.set(markerSpriteAnchor[0], markerSpriteAnchor[1]);
                } else {
                    markerSprite.anchor.set(0.5, 1);
                }

                const markerCoords = project(position);
                markerSprite.x = markerCoords.x;
                markerSprite.y = markerCoords.y;

                if (angle) {
                    markerSprite.angle = angle;
                }


                markerSprite.scale.set(1 / scale);
                if (opacity) markerSprite.alpha = opacity;

                if (popupOpen && !disabled) {
                    setOpenedPopupData({
                        id,
                        offset: [0, -35],
                        position,
                        content: popup,
                        onClick,
                    } as any);
                }

                if ((popup || onClick || tooltip) && !disabled) {
                    markerSprite.interactive = true;
                }

                if ((popup || onClick) && !disabled) {
                    // Prevent accidental launch of onClick event when dragging the map.
                    // Detect very small moves as clicks.
                    markerSprite.on("mousedown", () => {
                        let moveCount = 0;
                        markerSprite.on("mousemove", () => {
                            moveCount++;
                        });
                        markerSprite.on("mouseup", () => {
                            if (moveCount < 2 && onClick) {
                                setTimeout(() => {
                                    onClick(id as any);
                                }, 100)
                            }
                        });
                    });
                    // Prevent the same thing on touch devices.
                    markerSprite.on("touchstart", () => {
                        let moveCount = 0;
                        markerSprite.on("touchmove", () => {
                            moveCount++;
                        });
                        markerSprite.on("touchend", () => {
                            if (moveCount < 10 && onClick) {
                                onClick(id as any);
                            }
                        });
                    });

                    (markerSprite as any).defaultCursor = "pointer";
                    markerSprite.buttonMode = true;
                }

                if (tooltip && !disabled) {
                    markerSprite.on("mouseover", () => {
                        setOpenedTooltipData({
                            id,
                            offset: [0, -35],
                            position,
                            content: tooltip,
                            tooltipOptions: tooltipOptions || {}
                        } as any);
                    });

                    markerSprite.on("mouseout", () => {
                        setOpenedTooltipData(null);
                    });
                }

                container.addChild(markerSprite);
            });

            renderer.render(container);
        }

        return () =>
            pixiOverlay && pixiOverlay.utils.getContainer().removeChildren();
    }, [pixiOverlay, markers, loaded]);
    // handle tooltip
    useEffect(() => {
        if (openedTooltip) {
            map.removeLayer(openedTooltip);
        }

        if (
            openedTooltipData &&
            (!openedPopup ||
                !openedPopupData ||
                openedPopupData.id !== openedTooltipData.id)
        ) {
            setOpenedTooltip(openTooltip(map, openedTooltipData));
        }

        // we don't want to reload when openedTooltip changes as we'd get a loop
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [openedTooltipData, openedPopupData, map]);

    // handle popup
    useEffect(() => {
        // close only if different popup
        if (openedPopup) {
            map.removeLayer(openedPopup);
        }

        // open only if new popup
        if (openedPopupData) {
            setOpenedPopup(
                openPopup(map, openedPopupData, { autoClose: false }, true),
            );
        }

        // we don't want to reload when whenedPopup changes as we'd get a loop
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [openedPopupData, map]);

    return null;
};

function openPopup(map: any, data: any, extraOptions = {}, isPopup: any) {
    const popup = L.popup(Object.assign({ offset: data.offset }, extraOptions))
        .setLatLng(data.position)
        .setContent(data.content);

    // TODO don't call onClick if opened a new one
    if (isPopup && data.onClick) {
        popup.on("remove", () => {
            data.onClick(null);
        });
    }

    return popup;
}

function openTooltip(map: any, data: any) {
    const tooltip = L.tooltip(Object.assign({ offset: data.offset }, data.tooltipOptions))
        .setLatLng(data.position)
        .setContent(data.content)
        .addTo(map);

    return tooltip;
}

function getDefaultIcon(color: any) {
    const svgIcon = `<svg style="-webkit-filter: drop-shadow( 1px 1px 1px rgba(0, 0, 0, .4));filter: drop-shadow( 1px 1px 1px rgba(0, 0, 0, .4));" xmlns="http://www.w3.org/2000/svg" fill="${color}" width="36" height="36" viewBox="0 0 24 24"><path d="M12 0c-4.198 0-8 3.403-8 7.602 0 6.243 6.377 6.903 8 16.398 1.623-9.495 8-10.155 8-16.398 0-4.199-3.801-7.602-8-7.602zm0 11c-1.657 0-3-1.343-3-3s1.342-3 3-3 3 1.343 3 3-1.343 3-3 3z"/></svg>`;
    return getEncodedIcon(svgIcon);
}

function getEncodedIcon(svg: any) {
    const decoded = unescape(encodeURIComponent(svg));
    const base64 = btoa(decoded);
    return `data:image/svg+xml;base64,${base64}`;
}

export default PixiOverlay;