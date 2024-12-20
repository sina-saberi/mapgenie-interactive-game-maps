"use client"
import React from 'react'
import dynamic from 'next/dynamic';
import SideBar from './sideBar';
import { useAppDispatch, useAppSelector } from '@/src/hooks/useRedux';
import { getMapDetailAndChildrens } from '@/src/store/map';
const Map = dynamic(() => import("./map"), { ssr: false });

interface MapsProps {
    params: {
        slug: string;
        mapSlug: string;
    }
}
const Page = ({ params: { mapSlug, slug } }: MapsProps) => {
    const dispatch = useAppDispatch();
    const { isUserLogin } = useAppSelector(x => x.user)

    React.useEffect(() => {
        dispatch(getMapDetailAndChildrens({
            gameSlug: slug,
            mapSlug
        }))
    }, [mapSlug, slug, isUserLogin]);

    return (
        <div className='h-[calc(100vh-72px)] overflow-hidden flex absolute left-0 right-0 bottom-0  bg-gray-200 dark:bg-gray-500 '>
            <SideBar gameSlug={slug} mapSlug={mapSlug} />
            <Map />
        </div>
    )
}

export default Page