"use client"
import React from 'react'
import { Button, DarkThemeToggle, } from "flowbite-react";
import { HiMenu, } from "react-icons/hi";
import { useAppDispatch, useAppSelector, } from '@/src/hooks/useRedux';
import { toggleSideBar } from '@/src/store/application';
import { logout, toggleModal } from '@/src/store/user';

interface SideBarProps {
    children: React.ReactNode
}
const MainLayout = ({ children }: SideBarProps) => {
    const { isUserLogin } = useAppSelector(x => x.user);
    const dispatch = useAppDispatch();
    return (
        <div className=''>
            <header className='flex-shrink-0 border-b border-b-black top-0 sticky p-4 w-full bg-white dark:border-gray-700 dark:bg-gray-900'>
                <div className=' mx-auto flex items-center justify-between lg:justify-end lg:flex-row-reverse gap-x-3 '>
                    <div className='flex items-center gap-x-3'>
                        <button onClick={() => dispatch(toggleSideBar(true))} className='p-2 lg:hidden'>
                            <HiMenu size={30} />
                        </button>
                        <DarkThemeToggle />
                    </div>
                    {!isUserLogin ? (
                        <div>
                            <Button onClick={() => dispatch(toggleModal("login"))} size={"sm"}>Login</Button>
                        </div>
                    ) :
                        <div>
                            <Button onClick={() => dispatch(logout())} size={"sm"}>Logout</Button>
                        </div>
                    }
                </div>
            </header>

            <main>
                {children}
            </main>
        </div>
    )
}

export default React.memo(MainLayout)