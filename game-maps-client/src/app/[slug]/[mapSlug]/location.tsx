"use client"
import { ILocationDto } from '@/src/services/nswag'
import React, { useRef } from 'react'
import { Marker, Popup, useMap } from 'react-leaflet'
import LocationDetail from './locationDetail'
import { useAppSelector } from '@/src/hooks/useRedux'
import { Icon, LatLng, Marker as MarkerClass, Popup as PopupClass } from 'leaflet'
import { FLY_EVENT_NAME } from '@/src/utils/flyToLocation'
import { usePathname } from 'next/navigation'

const Location = ({ title, latitude, longitude, id, checked, categoryId, icon }: ILocationDto & { categoryId: number, icon?: string }) => {
    // const ref = useRef<MarkerClass>(null);
    // const popupRef = useRef<PopupClass>(null)
    // const map = useMap();
    // const { checked: locationChecked, search } = useAppSelector(x => x.filters);
    // const path = usePathname();
    // const [, slug] = path.split("/");
    // const [isPopupOpen, setIsPopupOpen] = React.useState(false);


    // React.useEffect(() => {
    //     const onOpen = (e: CustomEvent<number>) => {
    //         if (e.detail === id && ref.current && popupRef.current) {
    //             map.flyTo([latitude, longitude], map.getMaxZoom());
    //             console.log("popup:", popupRef.current, "map:", map);
    //             if (ref.current && popupRef.current) {
    //                 popupRef.current.setLatLng([latitude, longitude]);
    //                 popupRef.current.openOn(map);
    //             }
    //         }
    //     }
    //     window.addEventListener(FLY_EVENT_NAME, onOpen as any);
    //     return document.removeEventListener(FLY_EVENT_NAME, onOpen as any);
    // }, [latitude, longitude, id, map, popupRef, ref])


    // React.useEffect(() => {
    //     const marker = ref.current;

    //     if (marker) {
    //         marker.on('popupopen', () => setIsPopupOpen(true));
    //         marker.on('popupclose', () => setIsPopupOpen(false));
    //     }

    //     return () => {
    //         if (marker) {
    //             marker.off('popupopen');
    //             marker.off('popupclose');
    //         }
    //     };
    // }, [ref]);

    // React.useEffect(()=>{
    //     console.log(isPopupOpen);
    // },[isPopupOpen])

    // if (!isPopupOpen)
    //     if (search === "" && typeof locationChecked != "undefined")
    //         if (locationChecked && !checked || !locationChecked && checked)
    //             return null;


    // return (
    //     <Marker
    //         opacity={(!locationChecked && checked) ? .5 : 1}
    //         autoPan
    //         ref={ref}
    //         key={title}
    //         icon={new Icon({
    //             className: "!top-[-45px] !left-[-15px]",
    //             iconRetinaUrl: "/images/marker-icon-2x.png",
    //             iconUrl: `${process.env.NEXT_PUBLIC_API_URL}/api/Asset/images/${slug}/${icon}.png`,
    //             shadowUrl: "/images/marker-shadow.png",
    //         })}
    //         position={[latitude, longitude]}>
    //         <Popup ref={popupRef} className='relative w-[400px]'>
    //             <div className='h-full flex items-center flex-col w-[355px]'>
    //                 {/* <LocationDetail id={id} checked={checked} categoryId={categoryId} /> */}
    //             </div>
    //         </Popup>
    //     </Marker>
    // )
    return null
}

export default React.memo(Location)