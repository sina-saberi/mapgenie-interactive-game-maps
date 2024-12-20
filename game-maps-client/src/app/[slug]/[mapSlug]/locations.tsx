"use client"
import { useAppSelector } from '@/src/hooks/useRedux'
import React from 'react'
import 'leaflet-pixi-overlay';
import PixiOverlay, { MarkerPropsPixiOverlay } from './pixiOverlay';
import { useMap } from 'react-leaflet';
import L, { Popup } from 'leaflet';
import { createPortal } from 'react-dom';
import LocationDetail from './locationDetail';
import { ApplicationLocationDto } from '@/src/models/ApplicationLocationDto';
import { CheckedFilter } from '@/src/models/CheckedFilter';
import { FLY_EVENT_NAME } from '@/src/utils/flyToLocation';

const location = () => {
    const ref = React.useRef<Popup>();
    const [openedPopupId, setOpenedPopupId] = React.useState<number>();
    const map = useMap();
    const { locations, images } = useAppSelector(x => x.location);
    const { checkedFilter, search, categories, searchResult } = useAppSelector(x => x.filters);


    const selectedLocations = locations;

    const onClickOpenModal = React.useCallback((location: ApplicationLocationDto, zoomAndTravel: boolean = false) => {
        setOpenedPopupId(undefined);

        if (ref.current) {
            ref.current.removeFrom(map);
        }


        let div: HTMLElement | null = document.getElementById(location.id.toString());
        if (!div) {
            div = document.createElement("div");
            div.id = location.id.toString();
        }

        if (zoomAndTravel) {
            map.flyTo([location.latitude, location.longitude], map.getMaxZoom(), {
                animate: true,
            });
        }

        const instanse = L.popup({
            minWidth: 300,
            maxHeight: 300,
            content: div,
        })
            .on('remove', () => {
                setOpenedPopupId(undefined);
            })
            .setLatLng([location.latitude, location.longitude]).addTo(map);

        ref.current = instanse;

        setTimeout(() => {
            setOpenedPopupId(location.id);
        }, 500)
    }, [openedPopupId, setOpenedPopupId])

    const condition = (x: ApplicationLocationDto) => {
        if (x.id === openedPopupId || search.length > 0) return 1;

        if (categories.some(c => c === x.categoryId))
            return 0.001;

        switch (checkedFilter) {
            case CheckedFilter.showAll:
                return x.checked ? 0.5 : 1;

            case CheckedFilter.hideChecked:
                return x.checked ? 0.001 : 1;

            case CheckedFilter.showChecked:
                return x.checked ? 1 : 0.001;

            default:
                return 1;
        }
    };

    const markers: MarkerPropsPixiOverlay[] =
        selectedLocations
            .filter(c => searchResult.length <= 0 || searchResult.some(x => x.id == c.id))
            .map(x => ({
                id: x.id,
                disabled: condition(x) < 0.5,
                opacity: condition(x),
                position: [x.latitude, x.longitude],
                iconColor: "red",
                customIcon: x.icon ? images[x.icon] : undefined,
                iconId: x.icon,
                tooltip: x.title,
                onClick: () => onClickOpenModal(x),
            }));

    const openedPopupData = React.useMemo(() =>
        openedPopupId ? selectedLocations.find(x => x.id == openedPopupId) : undefined, [openedPopupId, selectedLocations])

    const onLocationIdClicked = React.useCallback((id: string) => {
        const location = selectedLocations.find(x => x.id.toString() == id);
        if (location) onClickOpenModal(location, true);
    }, [onClickOpenModal, selectedLocations])

    React.useEffect(() => {
        const onClickSearch = (e: CustomEvent<number>) => {
            onLocationIdClicked(e.detail.toString());
        }
        window.addEventListener(FLY_EVENT_NAME, onClickSearch as any);
        return document.removeEventListener(FLY_EVENT_NAME, onClickSearch as any);
    }, [onLocationIdClicked])


    const container = React.useMemo(() => {
        if (!openedPopupData) return;
        const element = document.getElementById(`${openedPopupData.id}`);
        if (!element) return;

        return createPortal(
            <LocationDetail
                onLocationIdClicked={onLocationIdClicked}
                categoryId={openedPopupData.categoryId}
                id={openedPopupData.id}
                checked={openedPopupData.checked} />, element)
    }, [openedPopupData])

    return (
        <React.Fragment>
            {container}
            <PixiOverlay markers={markers} />
        </React.Fragment>
    )
}



export default React.memo(location);