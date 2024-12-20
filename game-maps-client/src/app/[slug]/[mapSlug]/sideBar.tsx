"use client"
import { useAppDispatch, useAppSelector } from '@/src/hooks/useRedux';
import { CheckedFilter } from '@/src/models/CheckedFilter';
import { services } from '@/src/services';
import { MapDto } from '@/src/services/nswag';
import { toggleSideBar } from '@/src/store/application';
import { searchForLocaitons, setFiltersChecked, toggleAllCategories, toggleCategorieInFilter } from '@/src/store/filters';
import flyToLocation from '@/src/utils/flyToLocation';
import { TextInput } from 'flowbite-react'
import Link from 'next/link';
import React from 'react'
import { HiSearch, HiX } from 'react-icons/hi';
import Markdown from 'react-markdown';


interface SideBarProps {
    mapSlug: string,
    gameSlug: string
}
const SideBar = ({ gameSlug, mapSlug }: SideBarProps) => {
    const ref = React.useRef<NodeJS.Timeout>();
    const [searchValue, setSearchValue] = React.useState("");
    const dispatch = useAppDispatch();
    const { checkedCount, groups, locationCount } = useAppSelector(x => x.category);
    const { checkedFilter, categories, searchResult } = useAppSelector(x => x.filters);
    const { maps, detail } = useAppSelector(x => x.map);
    const { sidbar } = useAppSelector(x => x.application);

    const onChangeInput = (e: React.ChangeEvent<HTMLInputElement>) => {
        if (!detail?.slug) return;

        if (ref.current) clearTimeout(ref.current);
        setSearchValue(e.target.value);
        ref.current = setTimeout(() => dispatch(searchForLocaitons({
            gameSlug,
            search: e.target.value,
            slug: mapSlug
        })), 1000);
    }

    const isAnyCategoryFiltered = React.useMemo(() =>
        groups?.some(group => group.categories?.some(({ id }) => categories.includes(id))), [groups, categories]);

    if (groups) {
        return (
            <aside className={`p-5 flex-shrink-0 fixed lg:static ${sidbar ? "left-0" : "-left-full"} transition-all top-0 bottom-0 z-[5000] dark:bg-gray-700 dark:text-white bg-white flex flex-col overflow-hidden `}>
                <div className='w-full flex items-center justify-end lg:hidden pb-4'>
                    <button onClick={() => dispatch(toggleSideBar(false))} className=''><HiX size={30} /></button>
                </div>
                <div className='flex flex-wrap gap-3 mb-4 max-w-[400px]  mx-auto'>
                    {maps?.map(x => (
                        <div key={x.slug}>
                            <Link aria-selected={x.slug === mapSlug} className='bg-gray-500 aria-selected:bg-gray-600 text-white px-3 py-1 rounded-md inline-block' href={`/${gameSlug}/${x.slug}`} >{x.name}</Link>
                        </div>
                    ))}
                </div>
                <TextInput onChange={onChangeInput} value={searchValue} icon={HiSearch} rightIcon={() => <button
                    onClick={() => {
                        dispatch(searchForLocaitons({
                            gameSlug,
                            search: "",
                            slug: mapSlug
                        }));
                        setSearchValue("");
                    }}
                    className='z-[99999] pointer-events-auto'><HiX /></button>} />
                <div className='max-h-full overflow-y-auto mt-3 pr-1'>
                    {searchResult.length >= 1 ? (
                        <div className='max-w-sm'>
                            {searchResult.map(x => (
                                <div key={x.id}>
                                    <button onClick={() => flyToLocation(x.id)} className='w-full flex flex-col text-start text-sm font-medium hover:bg-gray-50 dark:hover:bg-gray-600 py-2 px-4 rounded-md'>
                                        <div className='text-lg'>
                                            {x.title}
                                        </div>
                                        {x.description && (
                                            <div className='text-wrap font-normal mt-2 truncate line-clamp-3 text-sm'>
                                                <Markdown>
                                                    {x.description}
                                                </Markdown>
                                            </div>
                                        )}
                                    </button>
                                </div>
                            ))}
                        </div>
                    ) : (
                        <React.Fragment>
                            <div>
                                <h5 className='font-bold my-3'>locations</h5>
                                <div className='grid grid-cols-2 pl-2'>
                                    <button onClick={() => dispatch(toggleAllCategories(groups))} className='w-full flex text-start text-sm font-medium whitespace-nowrap hover:bg-gray-50 dark:hover:bg-gray-600 py-2 px-4 rounded-md'>
                                        {!isAnyCategoryFiltered ? "filter all categories" : "unfilter all categories"}
                                    </button>
                                    <button onClick={() => dispatch(setFiltersChecked())} className='w-full flex text-start text-sm font-medium whitespace-nowrap hover:bg-gray-50 dark:hover:bg-gray-600 py-2 px-4 rounded-md'>
                                        {checkedFilter == CheckedFilter.showAll && (
                                            "show all"

                                        )}

                                        {checkedFilter == CheckedFilter.showChecked && (
                                            "show checked"
                                        )}

                                        {checkedFilter == CheckedFilter.hideChecked && (
                                            "hide checked"
                                        )}
                                    </button>
                                </div>
                            </div>
                            {groups?.map(x => (
                                <ul key={x.title}>
                                    <li>
                                        <h5 className='font-bold my-3'>{x.title}</h5>
                                        <ul className='grid grid-cols-2 pl-2'>
                                            {x.categories?.map(c => (
                                                <li className='group' aria-selected={categories.some(f => f === c.id)} key={c.title}>
                                                    <button onClick={() => dispatch(toggleCategorieInFilter(c.id))} className='group-aria-selected:line-through w-full flex text-start text-sm font-medium whitespace-nowrap hover:bg-gray-50 dark:hover:bg-gray-600 py-2 px-4 rounded-md items-center gap-1'>
                                                        {c.title} <span className='text-xs font-semibold'>{c.locationCount}/{c.checkedCount}</span>
                                                    </button>
                                                </li>
                                            ))}
                                        </ul>
                                    </li>
                                </ul>
                            ))}
                        </React.Fragment>
                    )}
                </div>
            </aside >
        )
    }
}

export default SideBar