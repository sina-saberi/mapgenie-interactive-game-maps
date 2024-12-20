"use client"
import React from 'react'
import { useAppDispatch, useAppSelector } from '../../hooks/useRedux';
import { Modal } from 'flowbite-react';
import { AuthModals, isUserLogin, login, toggleModal } from '@/src/store/user';
import Login from './login';
import Register from './register';


const modals: Record<AuthModals, () => React.ReactNode> = {
    login: Login,
    register: Register,
};

const AuthLayout = ({ children }: React.PropsWithChildren) => {
    const dispatch = useAppDispatch();
    const { modal } = useAppSelector(x => x.user);
    const Component = modal ? modals[modal] : undefined;

    React.useEffect(() => {
        dispatch(isUserLogin())
    }, [dispatch])

    return (
        <React.Fragment>
            {Component && (
                <Modal size={"sm"} theme={{ root: { "base": "fixed inset-x-0 top-0 z-[99999999] h-screen overflow-y-auto overflow-x-hidden md:inset-0 md:h-full", } }}
                    show
                    onClose={() => dispatch(toggleModal(undefined))}
                >
                    <Component />
                </Modal>
            )}
            {children}
        </React.Fragment>
    );
}

export default AuthLayout