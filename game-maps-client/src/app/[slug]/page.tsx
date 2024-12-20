"use server"
import { services } from '@/src/services'
import { Card } from 'flowbite-react'
import React from 'react'

interface MapsProps {
    params: {
        slug: string
    }
}

const Maps = async ({ params: { slug } }: MapsProps) => {
    const maps = await services.mapClient.map2(slug);
    return (
        <div className='container mx-auto py-10'>
            <ul className='grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-5'>
                {maps.map(x => (
                    <li key={x.slug} className='flex w-full'>
                        <Card
                            theme={{
                                img: {
                                    base: "h-64 object-cover"
                                }
                            }}
                            href={`/${slug}/${x.slug}`}
                            className="max-w-sm hover:!shadow-xl cursor-pointer  w-full mx-auto transition-all"
                            imgAlt={x.slug}
                            imgSrc={`/images/games/${slug}/maps/${x.slug}.jpg`}
                        >
                            <h5 className="text-2xl font-bold tracking-tight text-gray-900 dark:text-white">
                                {x.name}
                            </h5>
                            <p className="font-normal text-gray-700 dark:text-gray-400 h-20">
                                {x.description}
                            </p>
                        </Card>
                    </li>
                ))}
            </ul>
        </div>
    )
}

export default Maps