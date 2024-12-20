"use client"
import { useAppSelector } from '@/src/hooks/useRedux'
import { MapContainer, TileLayer } from 'react-leaflet'
import 'leaflet/dist/leaflet.css';
import React from 'react'
import Locations from './locations'
import MarkerClusterGroup from 'react-leaflet-cluster'
import { Renderer } from 'leaflet';
import L from 'leaflet';


const Map = () => {
    const [currentTile, setCurrentTile] = React.useState(0);
    const { detail } = useAppSelector(x => x.map);

    if (!detail) return;
    const { config } = detail;

    const currentTileSet = config.tileSets?.[currentTile];
    if (currentTileSet)
        return (
            <MapContainer
                className='w-full h-full '
                zoom={currentTileSet.minZoom}
                maxZoom={currentTileSet.maxZoom}
                center={[config.startLat, config.startLng]}
                minZoom={Math.max(currentTileSet.minZoom, 1)}
                maxBoundsViscosity={0.1}
                preferCanvas
                boundsOptions={{
                    padding: [0, 0]
                }}
                scrollWheelZoom={true} >
                {config.tileSets &&
                    <div className='absolute right-5 flex gap-2 top-5 z-[999]'>
                        {config.tileSets?.map((x, index) => (
                            <button aria-selected={currentTile == index} onClick={() => setCurrentTile(index)}
                                className='bg-gray-500 aria-selected:bg-gray-600 text-white px-3 py-1 rounded-md' key={index}>
                                {x.name}
                            </button>
                        ))}
                    </div>
                }
                <TileLayer

                    className=''
                    url={`${process.env.NEXT_PUBLIC_API_URL}/api/Asset/${currentTileSet.pattern}`}
                />
                <Locations />
            </MapContainer>
        )
}


//    {/* <Pane name="yellow-rectangle" style={{ zIndex: 499 }}>
//                     <Rectangle bounds={[[, 0], [0, -1.41]]} pathOptions={{ color: 'yellow' }} />
//                 </Pane> */}
//                 {/* <MarkerClusterGroup
//                     disableClusteringAtZoom={currentTileSet.maxZoom - 1}
//                     chunkedLoading
//                 > */}
//               

//                 {/* </MarkerClusterGroup> */}
export default React.memo(Map)