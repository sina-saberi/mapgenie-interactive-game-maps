import { services } from '@/src/services';
import { LocationDetailDto } from '@/src/services/nswag';
import React from 'react'
import Markdown from 'react-markdown'
import { Swiper, SwiperSlide } from "swiper/react"
import { Pagination } from "swiper/modules"
import Image from 'next/image';
import { Checkbox } from 'flowbite-react';
import { useAppDispatch } from '@/src/hooks/useRedux';
import { toggleLocation } from '@/src/store/location';
import Link from 'next/link';

interface LocationDetailProps {
    id: number;
    checked?: boolean;
    categoryId: number;
    onLocationIdClicked: (e: string) => void;
}
function LocationDetail({ id, checked, categoryId, onLocationIdClicked }: LocationDetailProps) {
    const dispatch = useAppDispatch();
    const [state, setState] = React.useState<LocationDetailDto>();

    React.useEffect(() => {
        const getData = async () => {
            const result = await services.locationClient.locationDetail(id);
            setState(result);
        }
        getData();
    }, [setState, id]);



    return (
        <React.Fragment>
            {state?.medias && (
                <Swiper
                    className='w-full'
                    pagination
                    modules={[Pagination]}
                    slidesPerView={1}
                >
                    {state.medias.map(x => (
                        <SwiperSlide
                            key={x.fileName}>
                            <div className='h-56'>
                                <Link target='_blank' href={`${process.env.NEXT_PUBLIC_API_URL}/api/Asset/storage/media/${x.fileName}`}>
                                    <Image className='w-full h-full' alt={x.title || x.fileName || "map-media"} src={`${process.env.NEXT_PUBLIC_API_URL}/api/Asset/storage/media/${x.fileName}`} width={400} height={500} />
                                </Link>
                            </div>
                        </SwiperSlide>
                    ))}
                </Swiper>
            )}
            <div className='w-full'>
                <h2 className='font-bold text-xl'>{state?.title}</h2>
                <h2 className='font-bold text-sm'>category : {state?.categoryTitle}</h2>
            </div>
            <Markdown
                components={{
                    a: x =>
                        <Link
                            {...x}
                            onClick={(c) => {
                                const target = (c.target as HTMLAnchorElement);
                                if (target.href) {
                                    const url = new URL(target.href);
                                    var locId = url.searchParams.get("locationIds");
                                    if (locId) {
                                        c.preventDefault();
                                        onLocationIdClicked(locId)
                                    }
                                }
                            }}
                            href={x.href?.replace("https://mapgenie.io", "") || ""}
                        />
                }}
                className={"w-full"}>
                {state?.description}
            </Markdown>
            <label className='mx-auto font-bold flex items-center justify-center gap-3 mt-4'>
                <span className='leading-tight mt-0.5'>FOUND</span> <Checkbox checked={!!checked} onChange={() => dispatch(toggleLocation({ id, categoryId }))} />
            </label>
        </React.Fragment>
    )
}

export default React.memo(LocationDetail);